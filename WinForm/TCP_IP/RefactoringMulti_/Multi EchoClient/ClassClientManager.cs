using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ClassClientManager
{
    #region PV
    private TcpClient tcpClient;
    private NetworkStream stream;
    private Thread recvThread;
    private Thread sendThread;
    private BlockingCollection<string> sendQueue = new BlockingCollection<string>();
    private bool isConnected = false;

    public event Action<string> OnReceived;
    public event Action<string> OnLog;
    public event Action OnDisconnected;

    private ClassLogManager logManager;
    #endregion

    public ClassClientManager(ClassLogManager logManager)
    {
        this.logManager = logManager;
    }

    public void Connect(string ip, int port)
    {
        tcpClient = new TcpClient();
        tcpClient.Connect(ip, port);
        stream = tcpClient.GetStream();
        isConnected = true;

        startThread(ref recvThread, receiveLoop);
        startThread(ref sendThread, sendLoop);

        OnLog?.Invoke("연결 성공!");
    }

    public void Disconnect()
    {
        isConnected = false;
        sendQueue.CompleteAdding();

        stopThread(recvThread);
        stopThread(sendThread);

        stream?.Close();
        tcpClient?.Close();

        OnLog?.Invoke("연결 종료");
        OnDisconnected?.Invoke();
    }
    
    public void Send(string message)
    {
        if (isConnected)
        {
            sendQueue.Add(message);
        }            
    }

    private void receiveLoop() 
    {
        try
        {
            byte[] buffer = new byte[1024];

            while (isConnected)
            {
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0)
                    break;

                string received = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                logManager.addLog($"[받음] {received}");
            }
        }
        catch (Exception ex)
        {
            logManager.addLog($"[수신오류] {ex.Message}");
        }
        finally
        {
            Invoke(new Action(() => DisconnectClient()));
        }
    }
    private void sendLoop()
    {
        try
        {
            while (isConnected)
            {
                string message = sendQueue.Take();
                if (stream != null && stream.CanWrite)
                {
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    logManager.addLog(message);
                }
            }
        }
        catch (InvalidOperationException)
        {
            // sendQueue가 CompleteAdding()으로 닫혔을 경우 발생 (정상 종료)
        }
        catch (Exception ex)
        {
            logManager.addLog($"[전송 오류] {ex.Message}");
        }
    }

    private void startThread(ref Thread thread, ThreadStart targetMethod)
    {
        thread = new Thread(targetMethod);
        thread.IsBackground = true;
        thread.Start();
    }

    private void stopThread(Thread thread)
    {
        if (thread != null && thread.IsAlive)
        {
            thread.Join(1000);
            thread = null;
        }
    }
}
