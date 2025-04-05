using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.CompilerServices;

namespace RTOSMiniProject
{
    public partial class MainGUI : Form
    {
        private SerialPort serialPort;
        private bool autoScroll = true;

        public MainGUI()
        {
            InitializeComponent();
            //InitializeSerial();
            InitializeSerialSettings();
            InitializeSerialStatus();
            InitializeDataButtonManage();
            InitializeLog();
            InitializeDataBits();
            PB_LIGNEX1_LOGO.Image = Properties.Resources.LIGNex1Logo;
        }

        private void InitializeDataBits()
        {
            TB_BIT0.Text= "00";
            TB_BIT1.Text= "00";
            TB_BIT2.Text= "00";
            TB_BIT3.Text= "00";
            TB_BIT4.Text= "00";
            TB_BIT5.Text= "00";
            TB_BIT6.Text= "00";
            TB_BIT7.Text= "00";
        }

        private void InitializeSerialStatus()
        {
            PNL_STATUS.BackColor = Color.Red;
        }

        private void InitializeLog()
        {

            LV_LOG.View = View.Details;
            LV_LOG.FullRowSelect = true;
            LV_LOG.GridLines = true;

            LV_LOG.Columns.Add("시간", 150);
            LV_LOG.Columns.Add("RX/TX", 50);
            LV_LOG.Columns.Add("메시지", 250);
            LV_LOG.Columns.Add("BIT 0", 50);
            LV_LOG.Columns.Add("BIT 1", 50);
            LV_LOG.Columns.Add("BIT 2", 50);
            LV_LOG.Columns.Add("BIT 3", 50);
            LV_LOG.Columns.Add("BIT 4", 50);
            LV_LOG.Columns.Add("BIT 5", 50);
            LV_LOG.Columns.Add("BIT 6", 50);
            LV_LOG.Columns.Add("BIT 7", 50);
        }

        private void BTN_SEND_Click(object sender, EventArgs e)
        {
            try
            {
                string[] hexStrings = new string[]
                {
                    TB_BIT0.Text.Trim(),
                    TB_BIT1.Text.Trim(),
                    TB_BIT2.Text.Trim(),
                    TB_BIT3.Text.Trim(),
                    TB_BIT4.Text.Trim(),
                    TB_BIT5.Text.Trim(),
                    TB_BIT6.Text.Trim(),
                    TB_BIT7.Text.Trim()
                };
                byte[] byteArray = new byte[8];

                for (int i = 0; i < hexStrings.Length; ++i)
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(hexStrings[i], @"^[0-9A-Fa-f]{2}$"))
                    {
                        MessageBox.Show($"잘못된 입력: '{hexStrings[i]}' (16진수 2자리만 입력하세요)", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    byteArray[i] = Convert.ToByte(hexStrings[i], 16); // 16진수 변환
                }

                serialPort.Write(byteArray, 0, 8);

                string[] convertedHexStrings = byteArray.Select(b => b.ToString("X2")).ToArray();

                SortLogDataBits("TX", hexStrings);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"전송 오류: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string receivedData = serialPort.ReadLine().Trim();
            this.Invoke((MethodInvoker)delegate
            {
                LogMessage("RX", receivedData);
            });
        }

        private void LogMessage(string direction, string message)
        {      

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            ListViewItem item = new ListViewItem(timestamp);
            item.SubItems.Add(direction);
            item.SubItems.Add(message);
            LV_LOG.Items.Add(item);
            if(autoScroll)
            {
                LV_LOG.EnsureVisible(LV_LOG.Items.Count - 1);
            }            
        }

        private void BTN_SCROLL_Click(object sender, EventArgs e)
        {
            autoScroll = !autoScroll;          
            BTN_SCROLL.Text = autoScroll ? "자동 스크롤: ON" : "자동 스크롤: OFF";
        }

        private void InitializeSerialSettings()
        {
            CB_COMPORT.Items.AddRange(SerialPort.GetPortNames());

            // Baudrate 설정
            CB_BAUDRATE.Items.Add("9600");
            CB_BAUDRATE.Items.Add("115200");
            CB_BAUDRATE.SelectedIndex = 1;

            // Parity 설정
            CB_PARITY.Items.Add(Parity.None.ToString());
            CB_PARITY.Items.Add(Parity.Odd.ToString());
            CB_PARITY.Items.Add(Parity.Even.ToString());
            CB_PARITY.SelectedIndex = 0;

            // DataBits 설정
            CB_DATABITS.Items.Add("7");
            CB_DATABITS.Items.Add("8");
            CB_DATABITS.SelectedIndex = 1;

            // StopBits 설정
            CB_STOPBITS.Items.Add(StopBits.One.ToString());
            CB_STOPBITS.Items.Add(StopBits.Two.ToString());
            CB_STOPBITS.SelectedIndex = 0;

            // 초기 상태
            BTN_SERIAL_DISCONNECT.Enabled = false;
        }

        private void BTN_SERIAL_CONNECT_Click(object sender, EventArgs e)
        {
            if (CB_COMPORT.SelectedItem == null)
            {
                MessageBox.Show("COM 포트 선택 필요!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 선택한 설정 가져오기
                string selectedPort = CB_COMPORT.SelectedItem.ToString();
                int baudRate = int.Parse(CB_BAUDRATE.SelectedItem.ToString());
                Parity parity = (Parity)Enum.Parse(typeof(Parity), CB_PARITY.SelectedItem.ToString());
                int dataBits = int.Parse(CB_DATABITS.SelectedItem.ToString());
                StopBits stopBits = (StopBits)Enum.Parse(typeof(StopBits), CB_STOPBITS.SelectedItem.ToString());

                // SerialPort 객체 생성 및 설정
                serialPort = new SerialPort(selectedPort, baudRate, parity, dataBits, stopBits);
                serialPort.DataReceived += SerialPort_DataReceived;
                serialPort.Open();

                BTN_SERIAL_CONNECT.Enabled = false;
                BTN_SERIAL_DISCONNECT.Enabled = true;

                PNL_STATUS.BackColor = Color.Green;

                LogMessage("INFO", $"Connected to {selectedPort} @ {baudRate} baud, {parity}, {dataBits} DataBits, {stopBits} StopBits");

                BTN_SEND.Enabled = true;
            }
            catch (Exception ex)
            {
                PNL_STATUS.BackColor = Color.Red;
                MessageBox.Show($"포트 연결 실패: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_LVCLEAR_Click(object sender, EventArgs e)
        {
            LV_LOG.Items.Clear();
        }

        private void BTN_SERIAL_DISCONNECT_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
                serialPort.Dispose();

                BTN_SERIAL_CONNECT.Enabled = true;
                BTN_SERIAL_DISCONNECT.Enabled = false;

                PNL_STATUS.BackColor = Color.Red;

                LogMessage("INFO", "Disconnected");

                BTN_SEND.Enabled = false;
            }
        }
        
        private void InitializeDataButtonManage()
        {
            BTN_SEND.Enabled = false;
        }

        private void TB_DEC_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string input = TB_DEC.Text.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    return;
                }

                if (int.TryParse(input, out int decimalValue))
                {
                    if (decimalValue < 0 || decimalValue > 255)
                    {
                        MessageBox.Show("입력 범위 오류(0~255)", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TB_DEC.Clear();
                        return;
                    }

                    TB_HEX.Text = decimalValue.ToString("X2");
                }
                else
                {
                    MessageBox.Show("입력 범위 오류(0~255)", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TB_DEC.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SortLogDataBits(string type, string[] hexStrings)
        {
            ListViewItem item = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            item.SubItems.Add("Tx");
            item.SubItems.Add("");
            for (int i = 0; i < 8; i++)
            {
                item.SubItems.Add(hexStrings[i]);
            }

            LV_LOG.Items.Add(item);

            LogMessage("TX", $"Sent: {string.Join(" ", hexStrings)} (8 bytes)");
        }
    }
}