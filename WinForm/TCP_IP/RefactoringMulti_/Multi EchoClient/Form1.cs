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

        private ClassLogManager logManager;
        private ClassClientManager clientManager;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            logManager = new ClassLogManager(LV_CLIENT);
            clientManager = new ClassClientManager(logManager);
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

                        logManager.addLog(message);
                        TB_DATA.Clear();
                    }
                }
                catch (Exception ex)
                {
                    logManager.addLog("BTN_SEND_Click 오류 " + ex.Message);
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

        private void DisconnectClient()
        {
            clientManager.Disconnect();
            setButtonStates(false);
            logManager.addLog("연결 종료됨");
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