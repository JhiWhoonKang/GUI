namespace RTOSMiniProject
{
    partial class MainGUI
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGUI));
            this.BTN_SEND = new System.Windows.Forms.Button();
            this.TB_BIT7 = new System.Windows.Forms.TextBox();
            this.LV_LOG = new System.Windows.Forms.ListView();
            this.PB_LIGNEX1_LOGO = new System.Windows.Forms.PictureBox();
            this.BTN_SCROLL = new System.Windows.Forms.Button();
            this.CB_COMPORT = new System.Windows.Forms.ComboBox();
            this.LB_COMPORT = new System.Windows.Forms.Label();
            this.LB_BAUDRATE = new System.Windows.Forms.Label();
            this.CB_BAUDRATE = new System.Windows.Forms.ComboBox();
            this.LB_PARITY = new System.Windows.Forms.Label();
            this.CB_PARITY = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_DATABITS = new System.Windows.Forms.ComboBox();
            this.LB_STOPBITS = new System.Windows.Forms.Label();
            this.CB_STOPBITS = new System.Windows.Forms.ComboBox();
            this.BTN_SERIAL_CONNECT = new System.Windows.Forms.Button();
            this.GB_SERIALSETTING = new System.Windows.Forms.GroupBox();
            this.BTN_SERIAL_DISCONNECT = new System.Windows.Forms.Button();
            this.BTN_LVCLEAR = new System.Windows.Forms.Button();
            this.PNL_STATUS = new System.Windows.Forms.Panel();
            this.TB_BIT6 = new System.Windows.Forms.TextBox();
            this.TB_BIT5 = new System.Windows.Forms.TextBox();
            this.TB_BIT4 = new System.Windows.Forms.TextBox();
            this.TB_BIT3 = new System.Windows.Forms.TextBox();
            this.TB_BIT2 = new System.Windows.Forms.TextBox();
            this.TB_BIT1 = new System.Windows.Forms.TextBox();
            this.TB_BIT0 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LB_RIGHT = new System.Windows.Forms.Label();
            this.LB_HEX = new System.Windows.Forms.Label();
            this.LB_DEC = new System.Windows.Forms.Label();
            this.TB_HEX = new System.Windows.Forms.TextBox();
            this.TB_DEC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PB_LIGNEX1_LOGO)).BeginInit();
            this.GB_SERIALSETTING.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_SEND
            // 
            this.BTN_SEND.Location = new System.Drawing.Point(675, 126);
            this.BTN_SEND.Name = "BTN_SEND";
            this.BTN_SEND.Size = new System.Drawing.Size(111, 39);
            this.BTN_SEND.TabIndex = 0;
            this.BTN_SEND.Text = "Send";
            this.BTN_SEND.UseVisualStyleBackColor = true;
            this.BTN_SEND.Click += new System.EventHandler(this.BTN_SEND_Click);
            // 
            // TB_BIT7
            // 
            this.TB_BIT7.Location = new System.Drawing.Point(37, 136);
            this.TB_BIT7.Name = "TB_BIT7";
            this.TB_BIT7.Size = new System.Drawing.Size(47, 21);
            this.TB_BIT7.TabIndex = 2;
            // 
            // LV_LOG
            // 
            this.LV_LOG.HideSelection = false;
            this.LV_LOG.Location = new System.Drawing.Point(12, 189);
            this.LV_LOG.Name = "LV_LOG";
            this.LV_LOG.Size = new System.Drawing.Size(1328, 265);
            this.LV_LOG.TabIndex = 4;
            this.LV_LOG.UseCompatibleStateImageBehavior = false;
            // 
            // PB_LIGNEX1_LOGO
            // 
            this.PB_LIGNEX1_LOGO.BackColor = System.Drawing.Color.White;
            this.PB_LIGNEX1_LOGO.Image = ((System.Drawing.Image)(resources.GetObject("PB_LIGNEX1_LOGO.Image")));
            this.PB_LIGNEX1_LOGO.Location = new System.Drawing.Point(1083, 489);
            this.PB_LIGNEX1_LOGO.Name = "PB_LIGNEX1_LOGO";
            this.PB_LIGNEX1_LOGO.Size = new System.Drawing.Size(257, 44);
            this.PB_LIGNEX1_LOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_LIGNEX1_LOGO.TabIndex = 7;
            this.PB_LIGNEX1_LOGO.TabStop = false;
            // 
            // BTN_SCROLL
            // 
            this.BTN_SCROLL.Location = new System.Drawing.Point(1218, 460);
            this.BTN_SCROLL.Name = "BTN_SCROLL";
            this.BTN_SCROLL.Size = new System.Drawing.Size(122, 23);
            this.BTN_SCROLL.TabIndex = 8;
            this.BTN_SCROLL.Text = "자동 스크롤: ON";
            this.BTN_SCROLL.UseVisualStyleBackColor = true;
            this.BTN_SCROLL.Click += new System.EventHandler(this.BTN_SCROLL_Click);
            // 
            // CB_COMPORT
            // 
            this.CB_COMPORT.FormattingEnabled = true;
            this.CB_COMPORT.Location = new System.Drawing.Point(101, 30);
            this.CB_COMPORT.Name = "CB_COMPORT";
            this.CB_COMPORT.Size = new System.Drawing.Size(121, 20);
            this.CB_COMPORT.TabIndex = 9;
            // 
            // LB_COMPORT
            // 
            this.LB_COMPORT.AutoSize = true;
            this.LB_COMPORT.Location = new System.Drawing.Point(10, 30);
            this.LB_COMPORT.Name = "LB_COMPORT";
            this.LB_COMPORT.Size = new System.Drawing.Size(88, 12);
            this.LB_COMPORT.TabIndex = 10;
            this.LB_COMPORT.Text = "COM Port 설정";
            // 
            // LB_BAUDRATE
            // 
            this.LB_BAUDRATE.AutoSize = true;
            this.LB_BAUDRATE.Location = new System.Drawing.Point(234, 30);
            this.LB_BAUDRATE.Name = "LB_BAUDRATE";
            this.LB_BAUDRATE.Size = new System.Drawing.Size(83, 12);
            this.LB_BAUDRATE.TabIndex = 12;
            this.LB_BAUDRATE.Text = "Baudrate 설정";
            // 
            // CB_BAUDRATE
            // 
            this.CB_BAUDRATE.FormattingEnabled = true;
            this.CB_BAUDRATE.Location = new System.Drawing.Point(325, 30);
            this.CB_BAUDRATE.Name = "CB_BAUDRATE";
            this.CB_BAUDRATE.Size = new System.Drawing.Size(121, 20);
            this.CB_BAUDRATE.TabIndex = 11;
            // 
            // LB_PARITY
            // 
            this.LB_PARITY.AutoSize = true;
            this.LB_PARITY.Location = new System.Drawing.Point(456, 30);
            this.LB_PARITY.Name = "LB_PARITY";
            this.LB_PARITY.Size = new System.Drawing.Size(65, 12);
            this.LB_PARITY.TabIndex = 14;
            this.LB_PARITY.Text = "Parity 설정";
            // 
            // CB_PARITY
            // 
            this.CB_PARITY.FormattingEnabled = true;
            this.CB_PARITY.Location = new System.Drawing.Point(527, 30);
            this.CB_PARITY.Name = "CB_PARITY";
            this.CB_PARITY.Size = new System.Drawing.Size(121, 20);
            this.CB_PARITY.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(659, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "Data Bits 설정";
            // 
            // CB_DATABITS
            // 
            this.CB_DATABITS.FormattingEnabled = true;
            this.CB_DATABITS.Location = new System.Drawing.Point(748, 30);
            this.CB_DATABITS.Name = "CB_DATABITS";
            this.CB_DATABITS.Size = new System.Drawing.Size(121, 20);
            this.CB_DATABITS.TabIndex = 15;
            // 
            // LB_STOPBITS
            // 
            this.LB_STOPBITS.AutoSize = true;
            this.LB_STOPBITS.Location = new System.Drawing.Point(875, 30);
            this.LB_STOPBITS.Name = "LB_STOPBITS";
            this.LB_STOPBITS.Size = new System.Drawing.Size(83, 12);
            this.LB_STOPBITS.TabIndex = 18;
            this.LB_STOPBITS.Text = "Stop Bits 설정";
            // 
            // CB_STOPBITS
            // 
            this.CB_STOPBITS.FormattingEnabled = true;
            this.CB_STOPBITS.Location = new System.Drawing.Point(964, 30);
            this.CB_STOPBITS.Name = "CB_STOPBITS";
            this.CB_STOPBITS.Size = new System.Drawing.Size(121, 20);
            this.CB_STOPBITS.TabIndex = 17;
            // 
            // BTN_SERIAL_CONNECT
            // 
            this.BTN_SERIAL_CONNECT.Location = new System.Drawing.Point(1127, 12);
            this.BTN_SERIAL_CONNECT.Name = "BTN_SERIAL_CONNECT";
            this.BTN_SERIAL_CONNECT.Size = new System.Drawing.Size(75, 23);
            this.BTN_SERIAL_CONNECT.TabIndex = 19;
            this.BTN_SERIAL_CONNECT.Text = "Connect";
            this.BTN_SERIAL_CONNECT.UseVisualStyleBackColor = true;
            this.BTN_SERIAL_CONNECT.Click += new System.EventHandler(this.BTN_SERIAL_CONNECT_Click);
            // 
            // GB_SERIALSETTING
            // 
            this.GB_SERIALSETTING.Controls.Add(this.LB_STOPBITS);
            this.GB_SERIALSETTING.Controls.Add(this.CB_COMPORT);
            this.GB_SERIALSETTING.Controls.Add(this.CB_STOPBITS);
            this.GB_SERIALSETTING.Controls.Add(this.LB_COMPORT);
            this.GB_SERIALSETTING.Controls.Add(this.label2);
            this.GB_SERIALSETTING.Controls.Add(this.CB_BAUDRATE);
            this.GB_SERIALSETTING.Controls.Add(this.CB_DATABITS);
            this.GB_SERIALSETTING.Controls.Add(this.LB_BAUDRATE);
            this.GB_SERIALSETTING.Controls.Add(this.LB_PARITY);
            this.GB_SERIALSETTING.Controls.Add(this.CB_PARITY);
            this.GB_SERIALSETTING.Location = new System.Drawing.Point(14, 9);
            this.GB_SERIALSETTING.Name = "GB_SERIALSETTING";
            this.GB_SERIALSETTING.Size = new System.Drawing.Size(1107, 66);
            this.GB_SERIALSETTING.TabIndex = 20;
            this.GB_SERIALSETTING.TabStop = false;
            this.GB_SERIALSETTING.Text = "Serial Port 설정";
            // 
            // BTN_SERIAL_DISCONNECT
            // 
            this.BTN_SERIAL_DISCONNECT.Location = new System.Drawing.Point(1208, 12);
            this.BTN_SERIAL_DISCONNECT.Name = "BTN_SERIAL_DISCONNECT";
            this.BTN_SERIAL_DISCONNECT.Size = new System.Drawing.Size(75, 23);
            this.BTN_SERIAL_DISCONNECT.TabIndex = 21;
            this.BTN_SERIAL_DISCONNECT.Text = "Disconnect";
            this.BTN_SERIAL_DISCONNECT.UseVisualStyleBackColor = true;
            this.BTN_SERIAL_DISCONNECT.Click += new System.EventHandler(this.BTN_SERIAL_DISCONNECT_Click);
            // 
            // BTN_LVCLEAR
            // 
            this.BTN_LVCLEAR.Location = new System.Drawing.Point(1137, 460);
            this.BTN_LVCLEAR.Name = "BTN_LVCLEAR";
            this.BTN_LVCLEAR.Size = new System.Drawing.Size(75, 23);
            this.BTN_LVCLEAR.TabIndex = 22;
            this.BTN_LVCLEAR.Text = "CLR";
            this.BTN_LVCLEAR.UseVisualStyleBackColor = true;
            this.BTN_LVCLEAR.Click += new System.EventHandler(this.BTN_LVCLEAR_Click);
            // 
            // PNL_STATUS
            // 
            this.PNL_STATUS.Location = new System.Drawing.Point(1127, 45);
            this.PNL_STATUS.Name = "PNL_STATUS";
            this.PNL_STATUS.Size = new System.Drawing.Size(156, 30);
            this.PNL_STATUS.TabIndex = 23;
            // 
            // TB_BIT6
            // 
            this.TB_BIT6.Location = new System.Drawing.Point(90, 136);
            this.TB_BIT6.Name = "TB_BIT6";
            this.TB_BIT6.Size = new System.Drawing.Size(47, 21);
            this.TB_BIT6.TabIndex = 24;
            // 
            // TB_BIT5
            // 
            this.TB_BIT5.Location = new System.Drawing.Point(143, 136);
            this.TB_BIT5.Name = "TB_BIT5";
            this.TB_BIT5.Size = new System.Drawing.Size(47, 21);
            this.TB_BIT5.TabIndex = 25;
            // 
            // TB_BIT4
            // 
            this.TB_BIT4.Location = new System.Drawing.Point(196, 136);
            this.TB_BIT4.Name = "TB_BIT4";
            this.TB_BIT4.Size = new System.Drawing.Size(47, 21);
            this.TB_BIT4.TabIndex = 26;
            // 
            // TB_BIT3
            // 
            this.TB_BIT3.Location = new System.Drawing.Point(249, 136);
            this.TB_BIT3.Name = "TB_BIT3";
            this.TB_BIT3.Size = new System.Drawing.Size(47, 21);
            this.TB_BIT3.TabIndex = 27;
            // 
            // TB_BIT2
            // 
            this.TB_BIT2.Location = new System.Drawing.Point(302, 136);
            this.TB_BIT2.Name = "TB_BIT2";
            this.TB_BIT2.Size = new System.Drawing.Size(47, 21);
            this.TB_BIT2.TabIndex = 28;
            // 
            // TB_BIT1
            // 
            this.TB_BIT1.Location = new System.Drawing.Point(355, 136);
            this.TB_BIT1.Name = "TB_BIT1";
            this.TB_BIT1.Size = new System.Drawing.Size(47, 21);
            this.TB_BIT1.TabIndex = 29;
            // 
            // TB_BIT0
            // 
            this.TB_BIT0.Location = new System.Drawing.Point(408, 136);
            this.TB_BIT0.Name = "TB_BIT0";
            this.TB_BIT0.Size = new System.Drawing.Size(47, 21);
            this.TB_BIT0.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LB_RIGHT);
            this.groupBox1.Controls.Add(this.LB_HEX);
            this.groupBox1.Controls.Add(this.LB_DEC);
            this.groupBox1.Controls.Add(this.TB_HEX);
            this.groupBox1.Controls.Add(this.TB_DEC);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(14, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 67);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "제어 데이터 입력";
            // 
            // LB_RIGHT
            // 
            this.LB_RIGHT.AutoSize = true;
            this.LB_RIGHT.Location = new System.Drawing.Point(558, 21);
            this.LB_RIGHT.Name = "LB_RIGHT";
            this.LB_RIGHT.Size = new System.Drawing.Size(17, 12);
            this.LB_RIGHT.TabIndex = 43;
            this.LB_RIGHT.Text = "→";
            // 
            // LB_HEX
            // 
            this.LB_HEX.AutoSize = true;
            this.LB_HEX.Location = new System.Drawing.Point(581, 21);
            this.LB_HEX.Name = "LB_HEX";
            this.LB_HEX.Size = new System.Drawing.Size(41, 12);
            this.LB_HEX.TabIndex = 42;
            this.LB_HEX.Text = "16진수";
            // 
            // LB_DEC
            // 
            this.LB_DEC.AutoSize = true;
            this.LB_DEC.Location = new System.Drawing.Point(511, 21);
            this.LB_DEC.Name = "LB_DEC";
            this.LB_DEC.Size = new System.Drawing.Size(41, 12);
            this.LB_DEC.TabIndex = 41;
            this.LB_DEC.Text = "10진수";
            // 
            // TB_HEX
            // 
            this.TB_HEX.Location = new System.Drawing.Point(583, 36);
            this.TB_HEX.Name = "TB_HEX";
            this.TB_HEX.ReadOnly = true;
            this.TB_HEX.Size = new System.Drawing.Size(38, 21);
            this.TB_HEX.TabIndex = 40;
            // 
            // TB_DEC
            // 
            this.TB_DEC.Location = new System.Drawing.Point(513, 36);
            this.TB_DEC.Name = "TB_DEC";
            this.TB_DEC.Size = new System.Drawing.Size(38, 21);
            this.TB_DEC.TabIndex = 39;
            this.TB_DEC.TextChanged += new System.EventHandler(this.TB_DEC_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "Byte 6";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(401, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 12);
            this.label9.TabIndex = 38;
            this.label9.Text = "Byte 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "Byte 7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(348, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 12);
            this.label8.TabIndex = 37;
            this.label8.Text = "Byte 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 12);
            this.label4.TabIndex = 33;
            this.label4.Text = "Byte 5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(297, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 12);
            this.label7.TabIndex = 36;
            this.label7.Text = "Byte 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 12);
            this.label5.TabIndex = 34;
            this.label5.Text = "Byte 4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 12);
            this.label6.TabIndex = 35;
            this.label6.Text = "Byte 3";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RTOSMiniProject.Properties.Resources.rapa_kor_eng_ci_jpg;
            this.pictureBox1.Location = new System.Drawing.Point(917, 489);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 541);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TB_BIT0);
            this.Controls.Add(this.TB_BIT1);
            this.Controls.Add(this.TB_BIT2);
            this.Controls.Add(this.TB_BIT3);
            this.Controls.Add(this.TB_BIT4);
            this.Controls.Add(this.TB_BIT5);
            this.Controls.Add(this.TB_BIT6);
            this.Controls.Add(this.PNL_STATUS);
            this.Controls.Add(this.BTN_LVCLEAR);
            this.Controls.Add(this.BTN_SERIAL_DISCONNECT);
            this.Controls.Add(this.BTN_SERIAL_CONNECT);
            this.Controls.Add(this.BTN_SCROLL);
            this.Controls.Add(this.PB_LIGNEX1_LOGO);
            this.Controls.Add(this.LV_LOG);
            this.Controls.Add(this.TB_BIT7);
            this.Controls.Add(this.BTN_SEND);
            this.Controls.Add(this.GB_SERIALSETTING);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainGUI";
            this.Text = "RTOSMiniProject";
            ((System.ComponentModel.ISupportInitialize)(this.PB_LIGNEX1_LOGO)).EndInit();
            this.GB_SERIALSETTING.ResumeLayout(false);
            this.GB_SERIALSETTING.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_SEND;
        private System.Windows.Forms.TextBox TB_BIT7;
        private System.Windows.Forms.ListView LV_LOG;
        private System.Windows.Forms.PictureBox PB_LIGNEX1_LOGO;
        private System.Windows.Forms.Button BTN_SCROLL;
        private System.Windows.Forms.ComboBox CB_COMPORT;
        private System.Windows.Forms.Label LB_COMPORT;
        private System.Windows.Forms.Label LB_BAUDRATE;
        private System.Windows.Forms.ComboBox CB_BAUDRATE;
        private System.Windows.Forms.Label LB_PARITY;
        private System.Windows.Forms.ComboBox CB_PARITY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_DATABITS;
        private System.Windows.Forms.Label LB_STOPBITS;
        private System.Windows.Forms.ComboBox CB_STOPBITS;
        private System.Windows.Forms.Button BTN_SERIAL_CONNECT;
        private System.Windows.Forms.GroupBox GB_SERIALSETTING;
        private System.Windows.Forms.Button BTN_SERIAL_DISCONNECT;
        private System.Windows.Forms.Button BTN_LVCLEAR;
        private System.Windows.Forms.Panel PNL_STATUS;
        private System.Windows.Forms.TextBox TB_BIT6;
        private System.Windows.Forms.TextBox TB_BIT5;
        private System.Windows.Forms.TextBox TB_BIT4;
        private System.Windows.Forms.TextBox TB_BIT3;
        private System.Windows.Forms.TextBox TB_BIT2;
        private System.Windows.Forms.TextBox TB_BIT1;
        private System.Windows.Forms.TextBox TB_BIT0;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LB_HEX;
        private System.Windows.Forms.Label LB_DEC;
        private System.Windows.Forms.TextBox TB_HEX;
        private System.Windows.Forms.TextBox TB_DEC;
        private System.Windows.Forms.Label LB_RIGHT;
    }
}

