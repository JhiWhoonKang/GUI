using System;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EchoClient
{
    public partial class Form1 : Form
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private bool isConnected = false;
        private Thread recvThread;
        private Thread sendThread;
        private BlockingCollection<string> sendQueue = new BlockingCollection<string>();
        public Form1()
        {
            InitializeComponent();
            LVInit();
        }

        private void LVInit()
        {
            LV_CLIENT.View = View.Details;
            LV_CLIENT.Columns.Add("시간", 100, HorizontalAlignment.Left);
            LV_CLIENT.Columns.Add("보낸 데이터", 200, HorizontalAlignment.Left);
        }

        private void AddLog(string time, string sent)
        {
            ListViewItem item = new ListViewItem(time);
            item.SubItems.Add(sent);
            LV_CLIENT.Items.Add(item);
        }

        private void ReceiveLoop()
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

                    Invoke(new Action(() =>
                    {
                        AddLog(DateTime.Now.ToString("HH:mm:ss"), $"[받음] {received}");
                    }));
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    AddLog(DateTime.Now.ToString("HH:mm:ss"), $"[수신오류] {ex.Message}");
                }));
            }
            finally
            {
                Invoke(new Action(() => BTN_DISCONNECT.PerformClick()));
            }
        }

        private void SendLoop()
        {
            try
            {
                while (isConnected)
                {
                    string message = sendQueue.Take();  // 큐에서 메시지 꺼냄 (블로킹)
                    if (stream != null && stream.CanWrite)
                    {
                        byte[] data = Encoding.UTF8.GetBytes(message);
                        stream.Write(data, 0, data.Length);

                        Invoke(new Action(() =>
                        {
                            AddLog(DateTime.Now.ToString("HH:mm:ss"), message);
                        }));
                    }
                }
            }
            catch (InvalidOperationException)
            {
                // sendQueue가 CompleteAdding()으로 닫혔을 경우 발생 (정상 종료)
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    AddLog(DateTime.Now.ToString("HH:mm:ss"), $"[전송 오류] {ex.Message}");
                }));
            }
        }


        private void BTN_SEND_Click(object sender, EventArgs e)
        {
            if (isConnected && stream != null)
            {
                try
                {
                    BTN_SEND.Enabled = true;
                    string message = TB_DATA.Text.Trim();
                    if (!string.IsNullOrEmpty(message))
                    {
                        byte[] data = Encoding.UTF8.GetBytes(message);
                        stream.Write(data, 0, data.Length);

                        AddLog(DateTime.Now.ToString("HH:mm:ss"), message);
                        TB_DATA.Clear();
                    }
                }
                catch (Exception ex)
                {
                    AddLog(DateTime.Now.ToString("HH:mm:ss"), "BTN_SEND_Click 오류 " + ex.Message);
                }
            }
        }        

        private void CloseClient()
        {
            isConnected = false;

            if (stream != null)
            {
                stream.Close();
                stream = null;
            }
            if (tcpClient != null)
            {
                tcpClient.Close();
                tcpClient = null;
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
        
        private void tcpClientConnect()
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(TB_IP.Text, int.Parse(TB_PORT.Text));
            stream = tcpClient.GetStream();
        }

        private void setButtonStates(bool isConnected)
        {
            BTN_CONNECT.Enabled = !isConnected;
            BTN_DISCONNECT.Enabled = isConnected;
            BTN_SEND.Enabled = isConnected;
        }

        private void BTN_CONNECT_Click(object sender, EventArgs e)
        {
            try
            {
                tcpClientConnect();

                isConnected = true;

                setButtonStates(true);

                startThread(ref recvThread, ReceiveLoop);
                startThread(ref sendThread, SendLoop);                

                AddLog(DateTime.Now.ToString("HH:mm:ss"), "나이스");
            }
            catch (Exception ex)
            {
                AddLog(DateTime.Now.ToString("HH:mm:ss"), "BTN_CONNECT_Click 오류 " + ex.Message);
            }
        }

        private void BTN_DISCONNECT_Click(object sender, EventArgs e)
        {
            isConnected = false;

            sendQueue.CompleteAdding();

            setButtonStates(false);

            stopThread(recvThread);
            stopThread(sendThread);
            
            CloseClient();                   

            AddLog(DateTime.Now.ToString("HH:mm:ss"), "ㅂㅂ");
        }

        private void BTN_EXIT_Click(object sender, EventArgs e)
        {
            CloseClient();
            Application.Exit();
        }
    }
}