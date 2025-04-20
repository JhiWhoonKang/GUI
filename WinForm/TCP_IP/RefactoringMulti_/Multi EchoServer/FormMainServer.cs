using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;

namespace EchoServer
{
    public partial class FormMainServer : Form
    {
        private Thread listenerThread;

        private ClassDefine define;
        private ClassLogManager logManager;
        private ClassServerManager serverManager;
        private ClassClientManager clientManager;

        public FormMainServer()
        {
            InitializeComponent();
        }

        private void FormMainServer_Load(object sender, EventArgs e)
        {
            logManager = new ClassLogManager(LV_SERVER);
            serverManager = new ClassServerManager();
            clientManager = new ClassClientManager(LV_MANAGE_CLIENT);

            serverManager.eventLog += (log) =>
            {
                Invoke(new Action(() => logManager.addLog(log)));
            };

            serverManager.eventConnected += () =>
            {
                Invoke(new Action(() => setButtonStates(true)));
            };

            serverManager.eventDisconnected += () =>
            {
                Invoke(new Action(() => setButtonStates(false)));
            };
        }

        private void setButtonStates(bool isOpened)
        {
            BTN_OPEN.Enabled = !isOpened;
            BTN_STOP.Enabled = isOpened;
            BTN_SEND.Enabled = isOpened;
        }

        private void BTN_OPEN_Click(object sender, EventArgs e)
        {            
            if (!serverManager.isRunning)
            {                
                serverManager.startServer(define.serverPort);
            }
        }

        private void BTN_STOP_Click(object sender, EventArgs e)
        {
            serverManager.stopServer();
        }
        
        private void BTN_SEND_Click(object sender, EventArgs e)
        {
            try
            {
                string message = TB_SEND.Text.Trim();
                string selectedClientKey = clientManager.getSelectedClientKey();
                //
                //  클라이언트 선택
                //
                if (string.IsNullOrEmpty(selectedClientKey))
                {
                    logManager.addLog("클라이언트를 선택하삼");
                    return;
                }
                //
                //  보낼 메시지 입력
                //
                if (string.IsNullOrEmpty(message))
                {
                    logManager.addLog("보낼 메시지를 입력하삼");
                    return;
                }
                //
                //  전송
                //
                serverManager.sendLoop(selectedClientKey, message);
                TB_SEND.Clear();
            }
            catch (Exception ex)
            {
                logManager.addLog($"[BTN_SEND_Click catch문] {ex.Message}");
            }
        }        
    }
}