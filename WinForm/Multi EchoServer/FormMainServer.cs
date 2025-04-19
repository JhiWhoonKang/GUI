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

        public FormMainServer()
        {
            InitializeComponent();

            LVInit();
        }

        private void LVInit()
        {
            LV_SERVER.View = View.Details;
            LV_SERVER.Columns.Add("시간", 100, HorizontalAlignment.Left);
            LV_SERVER.Columns.Add("데이터", 300, HorizontalAlignment.Left);

            LV_MANAGE_CLIENT.View = View.Details;
            LV_MANAGE_CLIENT.Columns.Add("클라이언트", 200, HorizontalAlignment.Left);
            LV_MANAGE_CLIENT.FullRowSelect = true;
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

                    Invoke(new Action(() =>
                    {
                        LV_MANAGE_CLIENT.Items.Add(new ListViewItem(clientKey));
                        AddListViewItem(DateTime.Now.ToString("HH:mm:ss"), $"연결 됐수다: {clientKey}");
                    }));

                    Thread clientThread = new Thread(() => ReceiveLoop(client, clientKey));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
            }

            catch (SocketException ex)
            {
                Invoke(new Action(() =>
                {
                    AddListViewItem("서버 ㅂㅂ", ex.Message);
                }));
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

                AddListViewItem(DateTime.Now.ToString("HH:mm:ss"), "서버 ㄴㄴ");
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

                    Invoke(new Action(() =>
                    {
                        AddListViewItem(DateTime.Now.ToString("HH:mm:ss"), receivedData);
                    }));
                }

                Invoke(new Action(() =>
                {
                    foreach (ListViewItem item in LV_MANAGE_CLIENT.Items)
                    {
                        if (item.Text == clientKey)
                        {
                            LV_MANAGE_CLIENT.Items.Remove(item);
                            break;
                        }
                    }
                    AddListViewItem(DateTime.Now.ToString("HH:mm:ss"), "클라이언트 ㅂㅂ");
                }));

            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    AddListViewItem("클라이언트 에러 ;;", ex.Message);
                }));
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

        private void AddListViewItem(string time, string data)
        {
            ListViewItem item = new ListViewItem(time);
            item.SubItems.Add(data);
            LV_SERVER.Items.Add(item);
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
                AddListViewItem("서버 ㄱㄱ", $"포트 {Port}");
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
            if (LV_MANAGE_CLIENT.SelectedItems.Count == 0)
            {
                MessageBox.Show("클라이언트를 선택하세요.");
                return;
            }

            string selectedClientKey = LV_MANAGE_CLIENT.SelectedItems[0].Text;
            string message = TB_SEND.Text.Trim();

            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("보낼 메시지를 입력하세요.");
                return;
            }

            if (manageClients.TryGetValue(selectedClientKey, out TcpClient client))
            {
                try
                {
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    client.GetStream().Write(data, 0, data.Length);

                    AddListViewItem(DateTime.Now.ToString("HH:mm:ss"), $"[Sent to {selectedClientKey}] {message}");
                }
                catch (Exception ex)
                {
                    AddListViewItem(DateTime.Now.ToString("HH:mm:ss"), $"[Send Error] {selectedClientKey}: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("해당 클라이언트가 연결되어 있지 않습니다.");
            }
        }
    }
}