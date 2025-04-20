using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace EchoServer
{
    public partial class FormMainServer : Form
    {
        private TcpListener server;
        Dictionary<string, TcpClient> manageClients = new Dictionary<string, TcpClient>();
        private bool isRunning = false;
        private Thread listenerThread;
        private const int Port = 9000;
        CancellationTokenSource cts = new CancellationTokenSource();

        private ClassLogManager logManager;
        private ClassClientManager clientManager;

        public FormMainServer()
        {
            InitializeComponent();
        }

        private void FormMainServer_Load(object sender, EventArgs e)
        {
            logManager = new ClassLogManager(LV_SERVER);
            clientManager = new ClassClientManager(LV_MANAGE_CLIENT);
        }

        private async void StartServer()
        {
            try
            {
                server = new TcpListener(IPAddress.Any, Port);
                server.Start();

                while (isRunning && !cts.Token.IsCancellationRequested)
                {
                    TcpClient client = await server.AcceptTcpClientAsync();
                    string clientKey = ((IPEndPoint)client.Client.RemoteEndPoint).ToString();

                    manageClients[clientKey] = client;

                    clientManager.addClient(clientKey);
                    logManager.AddLog($"연결 됐수다: {clientKey}");

                    Thread clientThread = new Thread(() => ReceiveLoop(client, clientKey));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
            }

            catch (SocketException ex)
            {
                logManager.AddLog($"서버 ㅂㅂ, {ex.Message}");
            }
        }

        private void StopServer()
        {
            try
            {
                server?.Stop();

                foreach (var clientsList in manageClients)
                {
                    clientsList.Value?.Close();
                }

                cts?.Cancel();

                logManager.AddLog("서버 ㄴㄴ");
            }

            catch (Exception ex)
            {
                MessageBox.Show($"서버 종료 오류: {ex.Message}");
            }
        }

        private void Socket_Close(TcpClient client)
        {
            client?.GetStream().Close();
            client?.Close();
            client = null;
        }

        private void ReceiveLoop(TcpClient client, string clientKey)
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

                    logManager.AddLog(receivedData);
                }

                logManager.AddLog("클라이언트 ㅂㅂ");
                clientManager.removeClient(clientKey);

            }
            catch (Exception ex)
            {
                logManager.AddLog($"클라이언트 에러 ;;, {ex.Message}");
            }

            finally
            {
                Socket_Close(client);
            }
        }        

        private void setButtonStates(bool isOpened)
        {
            BTN_OPEN.Enabled = !isOpened;
            BTN_STOP.Enabled = isOpened;
            BTN_SEND.Enabled = isOpened;
        }

        private void BTN_OPEN_Click(object sender, EventArgs e)
        {            
            if (!isRunning)
            {
                isRunning = true;   
                setButtonStates(true);

                listenerThread = new Thread(new ThreadStart(StartServer));
                listenerThread.IsBackground = true;
                listenerThread.Start();
                logManager.AddLog($"서버 온, 포트: {Port}");
            }
        }

        private void BTN_STOP_Click(object sender, EventArgs e)
        {
            setButtonStates(false);
            StopServer();
        }

        private void BTN_EXIT_Click(object sender, EventArgs e)
        {
            StopServer();
            Application.Exit();
        }
       
        private void BTN_SEND_Click(object sender, EventArgs e)
        {
            //
            //  클라이언트 선택
            //
            string selectedClientKey = clientManager.getSelectedClientKey();            
            if (string.IsNullOrEmpty(selectedClientKey))
            {
                MessageBox.Show("클라이언트를 선택하세요.");
                return;
            }

            //
            //  보낼 메시지 입력
            //
            string message = TB_SEND.Text.Trim();
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("보낼 메시지를 입력하세요.");
                return;
            }

            //
            //  전송
            //
            if (manageClients.TryGetValue(selectedClientKey, out TcpClient client))
            {
                try
                {
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    client.GetStream().Write(data, 0, data.Length);

                    logManager.AddLog($"Sent to {selectedClientKey} -> {message}");
                }
                catch (Exception ex)
                {
                    logManager.AddLog($"[Send Error] {selectedClientKey}: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("해당 클라이언트가 연결되어 있지 않습니다.");
            }
        }        
    }
}