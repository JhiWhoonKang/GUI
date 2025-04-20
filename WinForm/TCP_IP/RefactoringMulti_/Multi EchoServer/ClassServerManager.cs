using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;

public class ClassServerManager
{
    #region PV
    public bool isRunning = false;

    private Thread serverListenerThread;

    private TcpListener server;
    private int serverPort = 9000;
    Dictionary<string, TcpClient> manageClients = new Dictionary<string, TcpClient>();    

    private ClassClientManager clientManager;
    #endregion

    #region PE
    public event Action<string> eventLog;
    public event Action eventConnected;
    public event Action eventDisconnected;
    #endregion

    public ClassServerManager()
    {

    }

    public void startServer(int port)
    {
        if (isRunning)
        {
            return;
        }

        serverPort = port;
        isRunning = true;

        startThread(ref serverListenerThread, new ThreadStart(runServer));

        eventConnected?.Invoke();        
        eventLog?.Invoke($"서버 시작됨 (포트: {port})");

    }

    private void runServer()
    {
        try
        {
            TcpListener server = new TcpListener(IPAddress.Any, serverPort);
            server.Start();
            eventLog?.Invoke("클라이언트 다 드르와;");

            while (isRunning)
            {
                TcpClient client = server.AcceptTcpClient();
                string clientKey = ((IPEndPoint)client.Client.RemoteEndPoint).ToString();

                manageClients[clientKey] = client;
                clientManager.addClient(clientKey);                

                Thread clientThread = new Thread(() => receiveLoop(client, clientKey));
                clientThread.IsBackground = true;
                clientThread.Start();

                eventLog?.Invoke($"연결 됐수다: {clientKey}");
                eventConnected?.Invoke();
            }
        }

        catch (SocketException ex)
        {
            eventLog?.Invoke($"서버 ㅂㅂ, {ex.Message}");
        }
    }

    public void stopServer()
    {
        isRunning = false;
        try
        {
            server?.Stop();
            foreach (var client in manageClients.Values)
            {
                client?.Close();
            }

            manageClients.Clear();
            eventLog?.Invoke("-- 서버 the end--");
            eventDisconnected?.Invoke();
        }
        catch (Exception ex)
        {
            eventLog?.Invoke($"[stopServer catch문] {ex.Message}");
        }
    }

    private void receiveLoop(TcpClient client, string clientKey)
    {
        try
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];

            while (isRunning)
            {
                int bytesRead = 0;
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }

                string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                eventLog?.Invoke(receivedData);
            }

            eventLog?.Invoke("클라이언트 ㅂㅂ");
            clientManager.removeClient(clientKey);
        }
        catch (Exception ex)
        {
            eventLog?.Invoke($"클라이언트 에러 ;;, {ex.Message}");
        }

        finally
        {
            closeSocket(client);
        }
    }

    public void sendLoop(string clientKey, string message)
    {
        if (manageClients.TryGetValue(clientKey, out TcpClient client))
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                client.GetStream().Write(data, 0, data.Length);
                eventLog?.Invoke($"Sent to {clientKey} -> {message}");
            }

            catch (Exception ex)
            {
                eventLog?.Invoke($"[sendLoop catch문] {clientKey}: {ex.Message}");
            }
        }
        else
        {
            eventLog?.Invoke("해당 클라이언트가 연결ㄴㄴ임");
        }
    }


    private void closeSocket(TcpClient client)
    {
        client?.GetStream().Close();
        client?.Close();
        client = null;
    }

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
