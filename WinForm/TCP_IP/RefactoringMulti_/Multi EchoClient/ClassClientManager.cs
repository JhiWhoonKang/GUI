using System;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class ClassClientManager
{
    #region PV
    public bool isConnected = false;

    private TcpClient tcpClient;
    private NetworkStream stream;

    private Thread recvThread;
    private Thread sendThread;

    private BlockingCollection<string> sendQueue = new BlockingCollection<string>();
    #endregion 

    #region PE
    public event Action<string> eventLog;
    public event Action eventConnected;
    public event Action eventDisconnected;
    #endregion

    public ClassClientManager() { }

    //
    //  클라이언트 데이터 송수신 메소드
    //  connectClient, disconnectClient
    //
    #region manage connection
    public void connectClient(string ip, int port)
    {
        tcpClient = new TcpClient();
        tcpClient.Connect(ip, port);
        stream = tcpClient.GetStream();

        isConnected = true;

        startThread(ref recvThread, receiveLoop);
        startThread(ref sendThread, sendLoop);

        eventLog?.Invoke("연결 ㅇㅇ");
        eventConnected?.Invoke();
    }

    public void disconnectClient()
    {
        isConnected = false;
        sendQueue.CompleteAdding();

        stopThread(recvThread);
        stopThread(sendThread);

        stream?.Close();
        tcpClient?.Close();

        eventLog?.Invoke("연결 끄읕");
        eventDisconnected?.Invoke();
    }
    #endregion

    //
    //  클라이언트 데이터 송수신 메소드
    //  receiveLoop, sendLoop
    //
    #region data communication
    public void sendData(string message)
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
                {
                    break;
                }

                string received = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                eventLog?.Invoke($"[수신] {received}");
            }
        }

        catch (Exception ex)
        {
            eventLog?.Invoke($"[receiveLoop catch문] {ex.Message}");
        }

        finally
        {
            eventDisconnected?.Invoke();
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
                    eventLog?.Invoke($"[송신] {message}");
                }
            }
        }
        catch (InvalidOperationException)
        {

        }
        catch (Exception ex)
        {
            eventLog?.Invoke($"[sendLoop catch문] {ex.Message}");
        }
    }
    #endregion

    //
    //  스레드 관련
    //  startThread, stopThread
    //
    #region manageThread
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
    #endregion
}