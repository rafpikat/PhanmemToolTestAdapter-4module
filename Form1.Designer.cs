using OfficeOpenXml;
using System.IO.Ports;

namespace Tool_test_adapter_power
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Text.ASCIIEncoding asciiEncoding1 = new System.Text.ASCIIEncoding();
            System.Text.DecoderReplacementFallback decoderReplacementFallback1 = new System.Text.DecoderReplacementFallback();
            System.Text.EncoderReplacementFallback encoderReplacementFallback1 = new System.Text.EncoderReplacementFallback();
            label2 = new Label();
            UartStatus = new Label();
            CONNECTION = new GroupBox();
            button1 = new Button();
            comboBoxBaurateUart = new ComboBox();
            btnConnect = new Button();
            label1 = new Label();
            comboBoxPortUart = new ComboBox();
            groupBox1 = new GroupBox();
            groupBox12 = new GroupBox();
            buttonRetrySaveData1 = new Button();
            labelStatusOfSaveExcel1 = new Label();
            label69 = new Label();
            label67 = new Label();
            label66 = new Label();
            labelStatusOfSaveServer1 = new Label();
            groupBox2 = new GroupBox();
            label16 = new Label();
            textBoxPowerMax1 = new TextBox();
            label18 = new Label();
            textBoxPowerMin1 = new TextBox();
            label19 = new Label();
            label20 = new Label();
            textBoxPower1 = new TextBox();
            label4 = new Label();
            label6 = new Label();
            textBoxCurrentMax1 = new TextBox();
            label8 = new Label();
            textBoxCurrentMin1 = new TextBox();
            label13 = new Label();
            label14 = new Label();
            textBoxCurrent1 = new TextBox();
            label12 = new Label();
            textBoxVoltageMax1 = new TextBox();
            label9 = new Label();
            label10 = new Label();
            textBoxVoltageMin1 = new TextBox();
            label5 = new Label();
            label3 = new Label();
            textBoxVoltage1 = new TextBox();
            groupBox3 = new GroupBox();
            btnStopProcessTest1 = new Button();
            labelTestControlStatus1 = new Label();
            textBoxIDAdapter1 = new TextBox();
            progressBarTest1 = new ProgressBar();
            btnRestartProcessTest1 = new Button();
            btnStartProcessTest1 = new Button();
            btnImport = new Button();
            btnSave = new Button();
            groupBox4 = new GroupBox();
            labelNameFileConfigTest = new Label();
            label34 = new Label();
            domainUpDownTimeTesting = new DomainUpDown();
            label35 = new Label();
            domainUpDownVoltageMax = new DomainUpDown();
            domainUpDownCurrentMax = new DomainUpDown();
            domainUpDownCurrentMin = new DomainUpDown();
            domainUpDownVoltageMin = new DomainUpDown();
            label7 = new Label();
            label11 = new Label();
            label24 = new Label();
            label15 = new Label();
            label23 = new Label();
            label22 = new Label();
            label17 = new Label();
            label21 = new Label();
            btnStopRecording = new Button();
            pictureBox1 = new PictureBox();
            label30 = new Label();
            label31 = new Label();
            label32 = new Label();
            textBoxPathData = new TextBox();
            groupBox6 = new GroupBox();
            comboBoxTestingStage = new ComboBox();
            label61 = new Label();
            label60 = new Label();
            textBoxOperatingWorkes = new TextBox();
            label45 = new Label();
            checkBoxUpdateToLark = new CheckBox();
            API_Lark = new TextBox();
            btnStartRecording = new Button();
            btnBrowsePart = new Button();
            label33 = new Label();
            serialPort1 = new SerialPort(components);
            groupBox5 = new GroupBox();
            groupBox13 = new GroupBox();
            buttonRetrySaveData2 = new Button();
            labelStatusOfSaveExcel2 = new Label();
            label62 = new Label();
            label63 = new Label();
            label64 = new Label();
            labelStatusOfSaveServer2 = new Label();
            groupBox7 = new GroupBox();
            label25 = new Label();
            textBoxPowerMax2 = new TextBox();
            label26 = new Label();
            textBoxPowerMin2 = new TextBox();
            label27 = new Label();
            label28 = new Label();
            textBoxPower2 = new TextBox();
            label29 = new Label();
            label36 = new Label();
            textBoxCurrentMax2 = new TextBox();
            label37 = new Label();
            textBoxCurrentMin2 = new TextBox();
            label38 = new Label();
            label39 = new Label();
            textBoxCurrent2 = new TextBox();
            label40 = new Label();
            textBoxVoltageMax2 = new TextBox();
            label41 = new Label();
            label42 = new Label();
            textBoxVoltageMin2 = new TextBox();
            label43 = new Label();
            label44 = new Label();
            textBoxVoltage2 = new TextBox();
            groupBox8 = new GroupBox();
            btnStopProcessTest2 = new Button();
            labelTestControlStatus2 = new Label();
            textBoxIDAdapter2 = new TextBox();
            progressBarTest2 = new ProgressBar();
            btnRestartProcessTest2 = new Button();
            btnStartProcessTest2 = new Button();
            groupBox9 = new GroupBox();
            groupBox14 = new GroupBox();
            buttonRetrySaveData3 = new Button();
            label72 = new Label();
            labelStatusOfSaveExcel3 = new Label();
            labelStatusOfSaveServer3 = new Label();
            label71 = new Label();
            label73 = new Label();
            groupBox10 = new GroupBox();
            label46 = new Label();
            textBoxPowerMax3 = new TextBox();
            label47 = new Label();
            textBoxPowerMin3 = new TextBox();
            label48 = new Label();
            label49 = new Label();
            textBoxPower3 = new TextBox();
            label50 = new Label();
            label51 = new Label();
            textBoxCurrentMax3 = new TextBox();
            label52 = new Label();
            textBoxCurrentMin3 = new TextBox();
            label53 = new Label();
            label54 = new Label();
            textBoxCurrent3 = new TextBox();
            label55 = new Label();
            textBoxVoltageMax3 = new TextBox();
            label56 = new Label();
            label57 = new Label();
            textBoxVoltageMin3 = new TextBox();
            label58 = new Label();
            label59 = new Label();
            textBoxVoltage3 = new TextBox();
            groupBox11 = new GroupBox();
            btnStopProcessTest3 = new Button();
            labelTestControlStatus3 = new Label();
            textBoxIDAdapter3 = new TextBox();
            progressBarTest3 = new ProgressBar();
            btnRestartProcessTest3 = new Button();
            btnStartProcessTest3 = new Button();
            Control_all = new GroupBox();
            checkBoxTestAdapter3 = new CheckBox();
            checkBoxTestAdapter2 = new CheckBox();
            checkBoxTestAdapter1 = new CheckBox();
            btnStopProcessTestAll = new Button();
            btnRestartProcessTestAll = new Button();
            btnStartProcessTestAll = new Button();
            CONNECTION.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox12.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox13.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox9.SuspendLayout();
            groupBox14.SuspendLayout();
            groupBox10.SuspendLayout();
            groupBox11.SuspendLayout();
            Control_all.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 28);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 1;
            label2.Text = "PORT";
            // 
            // UartStatus
            // 
            UartStatus.AutoSize = true;
            UartStatus.ForeColor = Color.Red;
            UartStatus.Location = new Point(6, 91);
            UartStatus.Name = "UartStatus";
            UartStatus.Size = new Size(93, 15);
            UartStatus.TabIndex = 3;
            UartStatus.Text = "DISCONNECTED";
            // 
            // CONNECTION
            // 
            CONNECTION.BackColor = SystemColors.ButtonHighlight;
            CONNECTION.Controls.Add(button1);
            CONNECTION.Controls.Add(comboBoxBaurateUart);
            CONNECTION.Controls.Add(btnConnect);
            CONNECTION.Controls.Add(label1);
            CONNECTION.Controls.Add(comboBoxPortUart);
            CONNECTION.Controls.Add(label2);
            CONNECTION.Controls.Add(UartStatus);
            CONNECTION.Location = new Point(12, 12);
            CONNECTION.Name = "CONNECTION";
            CONNECTION.Size = new Size(265, 122);
            CONNECTION.TabIndex = 4;
            CONNECTION.TabStop = false;
            CONNECTION.Text = "CONNECTION";
            // 
            // button1
            // 
            button1.Location = new Point(153, 89);
            button1.Name = "button1";
            button1.Size = new Size(106, 23);
            button1.TabIndex = 8;
            button1.Text = "Calib";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBoxBaurateUart
            // 
            comboBoxBaurateUart.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBaurateUart.FormattingEnabled = true;
            comboBoxBaurateUart.Items.AddRange(new object[] { "110", "300", "600", "1200", "2400", "4800", "9600", "14400", "19200", "28800", "38400", "56000", "57600", "115200", "230400" });
            comboBoxBaurateUart.Location = new Point(70, 51);
            comboBoxBaurateUart.Name = "comboBoxBaurateUart";
            comboBoxBaurateUart.Size = new Size(77, 23);
            comboBoxBaurateUart.TabIndex = 7;
            comboBoxBaurateUart.SelectedIndexChanged += comboBoxBaurateUart_SelectedIndexChanged_1;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(153, 24);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(106, 23);
            btnConnect.TabIndex = 5;
            btnConnect.Text = "CONNECT";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 54);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 6;
            label1.Text = "BAUDRATE";
            // 
            // comboBoxPortUart
            // 
            comboBoxPortUart.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPortUart.FormattingEnabled = true;
            comboBoxPortUart.Location = new Point(70, 23);
            comboBoxPortUart.Name = "comboBoxPortUart";
            comboBoxPortUart.Size = new Size(77, 23);
            comboBoxPortUart.TabIndex = 4;
            comboBoxPortUart.SelectedIndexChanged += comboBoxPortUart_SelectedIndexChanged_1;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonHighlight;
            groupBox1.Controls.Add(groupBox12);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Location = new Point(10, 271);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(430, 471);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "NGUỒN SỐ 1";
            // 
            // groupBox12
            // 
            groupBox12.Controls.Add(buttonRetrySaveData1);
            groupBox12.Controls.Add(labelStatusOfSaveExcel1);
            groupBox12.Controls.Add(label69);
            groupBox12.Controls.Add(label67);
            groupBox12.Controls.Add(label66);
            groupBox12.Controls.Add(labelStatusOfSaveServer1);
            groupBox12.Location = new Point(15, 369);
            groupBox12.Name = "groupBox12";
            groupBox12.Size = new Size(399, 76);
            groupBox12.TabIndex = 7;
            groupBox12.TabStop = false;
            groupBox12.Text = "Qúa trình lưu trữ dữ liệu";
            // 
            // buttonRetrySaveData1
            // 
            buttonRetrySaveData1.Location = new Point(35, 32);
            buttonRetrySaveData1.Name = "buttonRetrySaveData1";
            buttonRetrySaveData1.Size = new Size(75, 25);
            buttonRetrySaveData1.TabIndex = 43;
            buttonRetrySaveData1.Text = "Thử lại";
            buttonRetrySaveData1.UseVisualStyleBackColor = true;
            buttonRetrySaveData1.Click += buttonRetrySaveData1_Click;
            // 
            // labelStatusOfSaveExcel1
            // 
            labelStatusOfSaveExcel1.AutoSize = true;
            labelStatusOfSaveExcel1.Location = new Point(326, 31);
            labelStatusOfSaveExcel1.Name = "labelStatusOfSaveExcel1";
            labelStatusOfSaveExcel1.Size = new Size(30, 15);
            labelStatusOfSaveExcel1.TabIndex = 51;
            labelStatusOfSaveExcel1.Text = "IDLE";
            labelStatusOfSaveExcel1.TextAlign = ContentAlignment.TopRight;
            // 
            // label69
            // 
            label69.AutoSize = true;
            label69.Location = new Point(320, 11);
            label69.Name = "label69";
            label69.Size = new Size(39, 15);
            label69.TabIndex = 50;
            label69.Text = "Status";
            label69.Click += label69_Click;
            // 
            // label67
            // 
            label67.AutoSize = true;
            label67.Font = new Font("Segoe UI", 8.25F);
            label67.Location = new Point(225, 32);
            label67.Name = "label67";
            label67.Size = new Size(90, 13);
            label67.TabIndex = 49;
            label67.Text = "Upload to excel:";
            // 
            // label66
            // 
            label66.AutoSize = true;
            label66.Font = new Font("Segoe UI", 8.25F);
            label66.Location = new Point(225, 55);
            label66.Name = "label66";
            label66.Size = new Size(95, 13);
            label66.TabIndex = 33;
            label66.Text = "Upload to server:";
            // 
            // labelStatusOfSaveServer1
            // 
            labelStatusOfSaveServer1.AutoSize = true;
            labelStatusOfSaveServer1.Location = new Point(326, 55);
            labelStatusOfSaveServer1.Name = "labelStatusOfSaveServer1";
            labelStatusOfSaveServer1.Size = new Size(30, 15);
            labelStatusOfSaveServer1.TabIndex = 48;
            labelStatusOfSaveServer1.Text = "IDLE";
            labelStatusOfSaveServer1.TextAlign = ContentAlignment.TopRight;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(textBoxPowerMax1);
            groupBox2.Controls.Add(label18);
            groupBox2.Controls.Add(textBoxPowerMin1);
            groupBox2.Controls.Add(label19);
            groupBox2.Controls.Add(label20);
            groupBox2.Controls.Add(textBoxPower1);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(textBoxCurrentMax1);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(textBoxCurrentMin1);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(textBoxCurrent1);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(textBoxVoltageMax1);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(textBoxVoltageMin1);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textBoxVoltage1);
            groupBox2.Location = new Point(15, 31);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(400, 159);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông số đo";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(373, 124);
            label16.Name = "label16";
            label16.Size = new Size(18, 15);
            label16.TabIndex = 37;
            label16.Text = "W";
            // 
            // textBoxPowerMax1
            // 
            textBoxPowerMax1.Location = new Point(287, 121);
            textBoxPowerMax1.Name = "textBoxPowerMax1";
            textBoxPowerMax1.Size = new Size(80, 23);
            textBoxPowerMax1.TabIndex = 36;
            textBoxPowerMax1.TextChanged += textBoxPowerMax_TextChanged;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(261, 125);
            label18.Name = "label18";
            label18.Size = new Size(18, 15);
            label18.TabIndex = 34;
            label18.Text = "W";
            // 
            // textBoxPowerMin1
            // 
            textBoxPowerMin1.Location = new Point(179, 120);
            textBoxPowerMin1.Name = "textBoxPowerMin1";
            textBoxPowerMin1.Size = new Size(80, 23);
            textBoxPowerMin1.TabIndex = 33;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 8.25F);
            label19.Location = new Point(3, 124);
            label19.Name = "label19";
            label19.Size = new Size(60, 13);
            label19.TabIndex = 32;
            label19.Text = "Công suất";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(150, 125);
            label20.Name = "label20";
            label20.Size = new Size(18, 15);
            label20.TabIndex = 31;
            label20.Text = "W";
            // 
            // textBoxPower1
            // 
            textBoxPower1.Location = new Point(69, 120);
            textBoxPower1.Name = "textBoxPower1";
            textBoxPower1.Size = new Size(80, 23);
            textBoxPower1.TabIndex = 30;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 7F);
            label4.Location = new Point(314, 17);
            label4.Name = "label4";
            label4.Size = new Size(26, 12);
            label4.TabIndex = 29;
            label4.Text = "MAX";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(373, 81);
            label6.Name = "label6";
            label6.Size = new Size(26, 15);
            label6.TabIndex = 28;
            label6.Text = "mA";
            // 
            // textBoxCurrentMax1
            // 
            textBoxCurrentMax1.Location = new Point(287, 77);
            textBoxCurrentMax1.Name = "textBoxCurrentMax1";
            textBoxCurrentMax1.Size = new Size(80, 23);
            textBoxCurrentMax1.TabIndex = 27;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(261, 80);
            label8.Name = "label8";
            label8.Size = new Size(26, 15);
            label8.TabIndex = 25;
            label8.Text = "mA";
            // 
            // textBoxCurrentMin1
            // 
            textBoxCurrentMin1.Location = new Point(179, 76);
            textBoxCurrentMin1.Name = "textBoxCurrentMin1";
            textBoxCurrentMin1.Size = new Size(80, 23);
            textBoxCurrentMin1.TabIndex = 24;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 8.25F);
            label13.Location = new Point(3, 80);
            label13.Name = "label13";
            label13.Size = new Size(62, 13);
            label13.TabIndex = 23;
            label13.Text = "Dòng điện";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(150, 80);
            label14.Name = "label14";
            label14.Size = new Size(26, 15);
            label14.TabIndex = 22;
            label14.Text = "mA";
            // 
            // textBoxCurrent1
            // 
            textBoxCurrent1.Location = new Point(69, 76);
            textBoxCurrent1.Name = "textBoxCurrent1";
            textBoxCurrent1.Size = new Size(80, 23);
            textBoxCurrent1.TabIndex = 21;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(373, 37);
            label12.Name = "label12";
            label12.Size = new Size(14, 15);
            label12.TabIndex = 19;
            label12.Text = "V";
            // 
            // textBoxVoltageMax1
            // 
            textBoxVoltageMax1.Location = new Point(287, 33);
            textBoxVoltageMax1.Name = "textBoxVoltageMax1";
            textBoxVoltageMax1.Size = new Size(80, 23);
            textBoxVoltageMax1.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 7F);
            label9.Location = new Point(207, 16);
            label9.Name = "label9";
            label9.Size = new Size(24, 12);
            label9.TabIndex = 17;
            label9.Text = "MIN";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(261, 37);
            label10.Name = "label10";
            label10.Size = new Size(14, 15);
            label10.TabIndex = 16;
            label10.Text = "V";
            // 
            // textBoxVoltageMin1
            // 
            textBoxVoltageMin1.Location = new Point(179, 32);
            textBoxVoltageMin1.Name = "textBoxVoltageMin1";
            textBoxVoltageMin1.Size = new Size(80, 23);
            textBoxVoltageMin1.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8.25F);
            label5.Location = new Point(3, 36);
            label5.Name = "label5";
            label5.Size = new Size(47, 13);
            label5.TabIndex = 10;
            label5.Text = "Điện áp";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(150, 37);
            label3.Name = "label3";
            label3.Size = new Size(14, 15);
            label3.TabIndex = 8;
            label3.Text = "V";
            // 
            // textBoxVoltage1
            // 
            textBoxVoltage1.Location = new Point(69, 32);
            textBoxVoltage1.Name = "textBoxVoltage1";
            textBoxVoltage1.Size = new Size(80, 23);
            textBoxVoltage1.TabIndex = 6;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnStopProcessTest1);
            groupBox3.Controls.Add(labelTestControlStatus1);
            groupBox3.Controls.Add(textBoxIDAdapter1);
            groupBox3.Controls.Add(progressBarTest1);
            groupBox3.Controls.Add(btnRestartProcessTest1);
            groupBox3.Controls.Add(btnStartProcessTest1);
            groupBox3.Location = new Point(15, 194);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(400, 169);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Điều khiển quá trình test";
            // 
            // btnStopProcessTest1
            // 
            btnStopProcessTest1.Location = new Point(261, 100);
            btnStopProcessTest1.Name = "btnStopProcessTest1";
            btnStopProcessTest1.Size = new Size(75, 25);
            btnStopProcessTest1.TabIndex = 42;
            btnStopProcessTest1.Text = "Dừng";
            btnStopProcessTest1.UseVisualStyleBackColor = true;
            btnStopProcessTest1.Click += btnStopProcessTest1_Click;
            // 
            // labelTestControlStatus1
            // 
            labelTestControlStatus1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelTestControlStatus1.BackColor = Color.LawnGreen;
            labelTestControlStatus1.BorderStyle = BorderStyle.Fixed3D;
            labelTestControlStatus1.Font = new Font("Tahoma", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTestControlStatus1.Location = new Point(21, 35);
            labelTestControlStatus1.Name = "labelTestControlStatus1";
            labelTestControlStatus1.Size = new Size(195, 50);
            labelTestControlStatus1.TabIndex = 13;
            labelTestControlStatus1.Text = "IDLE";
            labelTestControlStatus1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxIDAdapter1
            // 
            textBoxIDAdapter1.Location = new Point(225, 35);
            textBoxIDAdapter1.Multiline = true;
            textBoxIDAdapter1.Name = "textBoxIDAdapter1";
            textBoxIDAdapter1.ScrollBars = ScrollBars.Vertical;
            textBoxIDAdapter1.Size = new Size(156, 50);
            textBoxIDAdapter1.TabIndex = 12;
            // 
            // progressBarTest1
            // 
            progressBarTest1.Location = new Point(21, 137);
            progressBarTest1.Name = "progressBarTest1";
            progressBarTest1.Size = new Size(360, 23);
            progressBarTest1.TabIndex = 8;
            // 
            // btnRestartProcessTest1
            // 
            btnRestartProcessTest1.Location = new Point(168, 100);
            btnRestartProcessTest1.Name = "btnRestartProcessTest1";
            btnRestartProcessTest1.Size = new Size(75, 25);
            btnRestartProcessTest1.TabIndex = 11;
            btnRestartProcessTest1.Text = "Bắt đầu lại";
            btnRestartProcessTest1.UseVisualStyleBackColor = true;
            btnRestartProcessTest1.Click += btnRestartProcessTest1_Click;
            // 
            // btnStartProcessTest1
            // 
            btnStartProcessTest1.Location = new Point(74, 100);
            btnStartProcessTest1.Name = "btnStartProcessTest1";
            btnStartProcessTest1.Size = new Size(75, 25);
            btnStartProcessTest1.TabIndex = 9;
            btnStartProcessTest1.Text = "Bắt đầu";
            btnStartProcessTest1.UseVisualStyleBackColor = true;
            btnStartProcessTest1.Click += btnStartProcessTest1_Click;
            // 
            // btnImport
            // 
            btnImport.Location = new Point(345, 61);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(75, 23);
            btnImport.TabIndex = 8;
            btnImport.Text = "IMPORT";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(345, 32);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 7;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += button3_Click;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = SystemColors.ButtonHighlight;
            groupBox4.Controls.Add(labelNameFileConfigTest);
            groupBox4.Controls.Add(btnImport);
            groupBox4.Controls.Add(label34);
            groupBox4.Controls.Add(domainUpDownTimeTesting);
            groupBox4.Controls.Add(btnSave);
            groupBox4.Controls.Add(label35);
            groupBox4.Controls.Add(domainUpDownVoltageMax);
            groupBox4.Controls.Add(domainUpDownCurrentMax);
            groupBox4.Controls.Add(domainUpDownCurrentMin);
            groupBox4.Controls.Add(domainUpDownVoltageMin);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(label24);
            groupBox4.Controls.Add(label15);
            groupBox4.Controls.Add(label23);
            groupBox4.Controls.Add(label22);
            groupBox4.Controls.Add(label17);
            groupBox4.Controls.Add(label21);
            groupBox4.Location = new Point(295, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(439, 141);
            groupBox4.TabIndex = 7;
            groupBox4.TabStop = false;
            groupBox4.Text = "CÀI ĐẶT THÔNG SỐ TEST";
            // 
            // labelNameFileConfigTest
            // 
            labelNameFileConfigTest.AutoSize = true;
            labelNameFileConfigTest.Font = new Font("Segoe UI", 8.25F);
            labelNameFileConfigTest.Location = new Point(219, 96);
            labelNameFileConfigTest.Name = "labelNameFileConfigTest";
            labelNameFileConfigTest.Size = new Size(84, 13);
            labelNameFileConfigTest.TabIndex = 57;
            labelNameFileConfigTest.Text = "Tên_file_config";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(179, 95);
            label34.Name = "label34";
            label34.Size = new Size(12, 15);
            label34.TabIndex = 56;
            label34.Text = "s";
            // 
            // domainUpDownTimeTesting
            // 
            domainUpDownTimeTesting.Location = new Point(93, 91);
            domainUpDownTimeTesting.Name = "domainUpDownTimeTesting";
            domainUpDownTimeTesting.Size = new Size(80, 23);
            domainUpDownTimeTesting.TabIndex = 55;
            domainUpDownTimeTesting.Text = "0";
            domainUpDownTimeTesting.TextAlign = HorizontalAlignment.Right;
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Font = new Font("Segoe UI", 8.25F);
            label35.Location = new Point(15, 96);
            label35.Name = "label35";
            label35.Size = new Size(78, 13);
            label35.TabIndex = 54;
            label35.Text = "Thời gian test";
            // 
            // domainUpDownVoltageMax
            // 
            domainUpDownVoltageMax.Location = new Point(219, 32);
            domainUpDownVoltageMax.Name = "domainUpDownVoltageMax";
            domainUpDownVoltageMax.Size = new Size(80, 23);
            domainUpDownVoltageMax.TabIndex = 52;
            domainUpDownVoltageMax.Text = "0";
            domainUpDownVoltageMax.TextAlign = HorizontalAlignment.Right;
            // 
            // domainUpDownCurrentMax
            // 
            domainUpDownCurrentMax.Location = new Point(219, 61);
            domainUpDownCurrentMax.Name = "domainUpDownCurrentMax";
            domainUpDownCurrentMax.Size = new Size(80, 23);
            domainUpDownCurrentMax.TabIndex = 51;
            domainUpDownCurrentMax.Text = "0";
            domainUpDownCurrentMax.TextAlign = HorizontalAlignment.Right;
            // 
            // domainUpDownCurrentMin
            // 
            domainUpDownCurrentMin.Location = new Point(93, 61);
            domainUpDownCurrentMin.Name = "domainUpDownCurrentMin";
            domainUpDownCurrentMin.Size = new Size(80, 23);
            domainUpDownCurrentMin.TabIndex = 50;
            domainUpDownCurrentMin.Text = "0";
            domainUpDownCurrentMin.TextAlign = HorizontalAlignment.Right;
            // 
            // domainUpDownVoltageMin
            // 
            domainUpDownVoltageMin.Location = new Point(93, 32);
            domainUpDownVoltageMin.Name = "domainUpDownVoltageMin";
            domainUpDownVoltageMin.Size = new Size(80, 23);
            domainUpDownVoltageMin.TabIndex = 7;
            domainUpDownVoltageMin.Text = "0";
            domainUpDownVoltageMin.TextAlign = HorizontalAlignment.Right;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 7F);
            label7.Location = new Point(246, 16);
            label7.Name = "label7";
            label7.Size = new Size(26, 12);
            label7.TabIndex = 49;
            label7.Text = "MAX";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(303, 65);
            label11.Name = "label11";
            label11.Size = new Size(26, 15);
            label11.TabIndex = 48;
            label11.Text = "mA";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 8.25F);
            label24.Location = new Point(15, 37);
            label24.Name = "label24";
            label24.Size = new Size(47, 13);
            label24.TabIndex = 38;
            label24.Text = "Điện áp";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(179, 65);
            label15.Name = "label15";
            label15.Size = new Size(26, 15);
            label15.TabIndex = 46;
            label15.Text = "mA";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(179, 36);
            label23.Name = "label23";
            label23.Size = new Size(14, 15);
            label23.TabIndex = 40;
            label23.Text = "V";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 7F);
            label22.Location = new Point(121, 16);
            label22.Name = "label22";
            label22.Size = new Size(24, 12);
            label22.TabIndex = 41;
            label22.Text = "MIN";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 8.25F);
            label17.Location = new Point(15, 66);
            label17.Name = "label17";
            label17.Size = new Size(62, 13);
            label17.TabIndex = 44;
            label17.Text = "Dòng điện";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(303, 36);
            label21.Name = "label21";
            label21.Size = new Size(14, 15);
            label21.TabIndex = 43;
            label21.Text = "V";
            // 
            // btnStopRecording
            // 
            btnStopRecording.Location = new Point(448, 213);
            btnStopRecording.Name = "btnStopRecording";
            btnStopRecording.Size = new Size(130, 25);
            btnStopRecording.TabIndex = 10;
            btnStopRecording.Text = "Dừng ghi dữ liệu";
            btnStopRecording.UseVisualStyleBackColor = true;
            btnStopRecording.Click += btnStopRecording_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.AccessibleRole = AccessibleRole.None;
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.ErrorImage = (Image)resources.GetObject("pictureBox1.ErrorImage");
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(973, 768);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(188, 63);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(1178, 767);
            label30.Name = "label30";
            label30.Size = new Size(128, 15);
            label30.TabIndex = 9;
            label30.Text = "Adapter test tool v1.0.5";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(1178, 791);
            label31.Name = "label31";
            label31.Size = new Size(104, 15);
            label31.TabIndex = 10;
            label31.Text = "(C) 2025 Lumi Jsc. ";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(1178, 816);
            label32.Name = "label32";
            label32.Size = new Size(77, 15);
            label32.TabIndex = 11;
            label32.Text = "www.lumi.vn";
            // 
            // textBoxPathData
            // 
            textBoxPathData.Location = new Point(127, 30);
            textBoxPathData.Name = "textBoxPathData";
            textBoxPathData.Size = new Size(447, 23);
            textBoxPathData.TabIndex = 12;
            textBoxPathData.TextChanged += textBoxPathData_TextChanged;
            // 
            // groupBox6
            // 
            groupBox6.BackColor = SystemColors.ButtonHighlight;
            groupBox6.Controls.Add(comboBoxTestingStage);
            groupBox6.Controls.Add(label61);
            groupBox6.Controls.Add(label60);
            groupBox6.Controls.Add(textBoxOperatingWorkes);
            groupBox6.Controls.Add(label45);
            groupBox6.Controls.Add(checkBoxUpdateToLark);
            groupBox6.Controls.Add(API_Lark);
            groupBox6.Controls.Add(btnStartRecording);
            groupBox6.Controls.Add(btnStopRecording);
            groupBox6.Controls.Add(btnBrowsePart);
            groupBox6.Controls.Add(label33);
            groupBox6.Controls.Add(textBoxPathData);
            groupBox6.Location = new Point(748, 12);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(584, 247);
            groupBox6.TabIndex = 13;
            groupBox6.TabStop = false;
            groupBox6.Text = "CÀI ĐẶT LƯU TRỮ DỮ LIỆU";
            // 
            // comboBoxTestingStage
            // 
            comboBoxTestingStage.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTestingStage.FormattingEnabled = true;
            comboBoxTestingStage.Items.AddRange(new object[] { "Thành phẩm", "PCBA" });
            comboBoxTestingStage.Location = new Point(127, 184);
            comboBoxTestingStage.Name = "comboBoxTestingStage";
            comboBoxTestingStage.Size = new Size(151, 23);
            comboBoxTestingStage.TabIndex = 51;
            // 
            // label61
            // 
            label61.AutoSize = true;
            label61.Location = new Point(6, 188);
            label61.Name = "label61";
            label61.Size = new Size(91, 15);
            label61.TabIndex = 50;
            label61.Text = "Công đoạn test:";
            // 
            // label60
            // 
            label60.AutoSize = true;
            label60.Location = new Point(6, 147);
            label60.Name = "label60";
            label60.Size = new Size(118, 15);
            label60.TabIndex = 49;
            label60.Text = "Người thực hiện test:";
            // 
            // textBoxOperatingWorkes
            // 
            textBoxOperatingWorkes.Location = new Point(127, 143);
            textBoxOperatingWorkes.Name = "textBoxOperatingWorkes";
            textBoxOperatingWorkes.Size = new Size(185, 23);
            textBoxOperatingWorkes.TabIndex = 48;
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Location = new Point(6, 107);
            label45.Name = "label45";
            label45.Size = new Size(53, 15);
            label45.TabIndex = 47;
            label45.Text = "Link API:";
            // 
            // checkBoxUpdateToLark
            // 
            checkBoxUpdateToLark.AutoSize = true;
            checkBoxUpdateToLark.Location = new Point(418, 136);
            checkBoxUpdateToLark.Name = "checkBoxUpdateToLark";
            checkBoxUpdateToLark.Size = new Size(156, 19);
            checkBoxUpdateToLark.TabIndex = 10;
            checkBoxUpdateToLark.Text = "Update dữ liệu lên server\r\n";
            checkBoxUpdateToLark.UseVisualStyleBackColor = true;
            // 
            // API_Lark
            // 
            API_Lark.Location = new Point(127, 103);
            API_Lark.Name = "API_Lark";
            API_Lark.Size = new Size(447, 23);
            API_Lark.TabIndex = 43;
            API_Lark.TextChanged += API_Lark_TextChanged;
            // 
            // btnStartRecording
            // 
            btnStartRecording.Location = new Point(448, 182);
            btnStartRecording.Name = "btnStartRecording";
            btnStartRecording.Size = new Size(130, 25);
            btnStartRecording.TabIndex = 42;
            btnStartRecording.Text = "Bắt đầu ghi dữ liệu";
            btnStartRecording.UseVisualStyleBackColor = true;
            btnStartRecording.Click += btnStartRecording_Click;
            // 
            // btnBrowsePart
            // 
            btnBrowsePart.Location = new Point(499, 65);
            btnBrowsePart.Name = "btnBrowsePart";
            btnBrowsePart.Size = new Size(75, 23);
            btnBrowsePart.TabIndex = 8;
            btnBrowsePart.Text = "Browse";
            btnBrowsePart.UseVisualStyleBackColor = true;
            btnBrowsePart.Click += btnBrowsePart_Click;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(6, 34);
            label33.Name = "label33";
            label33.Size = new Size(99, 15);
            label33.TabIndex = 40;
            label33.Text = "Đường dẫn excel:";
            // 
            // serialPort1
            // 
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.DiscardNull = false;
            serialPort1.DtrEnable = false;
            serialPort1.Handshake = Handshake.None;
            serialPort1.NewLine = "\n";
            serialPort1.Parity = Parity.None;
            serialPort1.ParityReplace = 63;
            serialPort1.PortName = "COM1";
            serialPort1.ReadBufferSize = 4096;
            serialPort1.ReadTimeout = -1;
            serialPort1.ReceivedBytesThreshold = 1;
            serialPort1.RtsEnable = false;
            serialPort1.StopBits = StopBits.One;
            serialPort1.WriteBufferSize = 2048;
            serialPort1.WriteTimeout = -1;
            serialPort1.DataReceived += SerialPort_DataReceived;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = SystemColors.ButtonHighlight;
            groupBox5.Controls.Add(groupBox13);
            groupBox5.Controls.Add(groupBox7);
            groupBox5.Controls.Add(groupBox8);
            groupBox5.Location = new Point(457, 271);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(430, 471);
            groupBox5.TabIndex = 7;
            groupBox5.TabStop = false;
            groupBox5.Text = "NGUỒN SỐ 2";
            // 
            // groupBox13
            // 
            groupBox13.Controls.Add(buttonRetrySaveData2);
            groupBox13.Controls.Add(labelStatusOfSaveExcel2);
            groupBox13.Controls.Add(label62);
            groupBox13.Controls.Add(label63);
            groupBox13.Controls.Add(label64);
            groupBox13.Controls.Add(labelStatusOfSaveServer2);
            groupBox13.Location = new Point(15, 369);
            groupBox13.Name = "groupBox13";
            groupBox13.Size = new Size(399, 76);
            groupBox13.TabIndex = 8;
            groupBox13.TabStop = false;
            groupBox13.Text = "Qúa trình lưu trữ dữ liệu";
            // 
            // buttonRetrySaveData2
            // 
            buttonRetrySaveData2.Location = new Point(34, 32);
            buttonRetrySaveData2.Name = "buttonRetrySaveData2";
            buttonRetrySaveData2.Size = new Size(75, 25);
            buttonRetrySaveData2.TabIndex = 53;
            buttonRetrySaveData2.Text = "Thử lại";
            buttonRetrySaveData2.UseVisualStyleBackColor = true;
            buttonRetrySaveData2.Click += buttonRetrySaveData2_Click;
            // 
            // labelStatusOfSaveExcel2
            // 
            labelStatusOfSaveExcel2.AutoSize = true;
            labelStatusOfSaveExcel2.Location = new Point(326, 32);
            labelStatusOfSaveExcel2.Name = "labelStatusOfSaveExcel2";
            labelStatusOfSaveExcel2.Size = new Size(30, 15);
            labelStatusOfSaveExcel2.TabIndex = 57;
            labelStatusOfSaveExcel2.Text = "IDLE";
            labelStatusOfSaveExcel2.TextAlign = ContentAlignment.TopRight;
            // 
            // label62
            // 
            label62.AutoSize = true;
            label62.Location = new Point(320, 12);
            label62.Name = "label62";
            label62.Size = new Size(39, 15);
            label62.TabIndex = 56;
            label62.Text = "Status";
            // 
            // label63
            // 
            label63.AutoSize = true;
            label63.Font = new Font("Segoe UI", 8.25F);
            label63.Location = new Point(225, 33);
            label63.Name = "label63";
            label63.Size = new Size(90, 13);
            label63.TabIndex = 55;
            label63.Text = "Upload to excel:";
            // 
            // label64
            // 
            label64.AutoSize = true;
            label64.Font = new Font("Segoe UI", 8.25F);
            label64.Location = new Point(225, 56);
            label64.Name = "label64";
            label64.Size = new Size(95, 13);
            label64.TabIndex = 52;
            label64.Text = "Upload to server:";
            // 
            // labelStatusOfSaveServer2
            // 
            labelStatusOfSaveServer2.AutoSize = true;
            labelStatusOfSaveServer2.Location = new Point(326, 56);
            labelStatusOfSaveServer2.Name = "labelStatusOfSaveServer2";
            labelStatusOfSaveServer2.Size = new Size(30, 15);
            labelStatusOfSaveServer2.TabIndex = 54;
            labelStatusOfSaveServer2.Text = "IDLE";
            labelStatusOfSaveServer2.TextAlign = ContentAlignment.TopRight;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(label25);
            groupBox7.Controls.Add(textBoxPowerMax2);
            groupBox7.Controls.Add(label26);
            groupBox7.Controls.Add(textBoxPowerMin2);
            groupBox7.Controls.Add(label27);
            groupBox7.Controls.Add(label28);
            groupBox7.Controls.Add(textBoxPower2);
            groupBox7.Controls.Add(label29);
            groupBox7.Controls.Add(label36);
            groupBox7.Controls.Add(textBoxCurrentMax2);
            groupBox7.Controls.Add(label37);
            groupBox7.Controls.Add(textBoxCurrentMin2);
            groupBox7.Controls.Add(label38);
            groupBox7.Controls.Add(label39);
            groupBox7.Controls.Add(textBoxCurrent2);
            groupBox7.Controls.Add(label40);
            groupBox7.Controls.Add(textBoxVoltageMax2);
            groupBox7.Controls.Add(label41);
            groupBox7.Controls.Add(label42);
            groupBox7.Controls.Add(textBoxVoltageMin2);
            groupBox7.Controls.Add(label43);
            groupBox7.Controls.Add(label44);
            groupBox7.Controls.Add(textBoxVoltage2);
            groupBox7.Location = new Point(15, 31);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(400, 159);
            groupBox7.TabIndex = 0;
            groupBox7.TabStop = false;
            groupBox7.Text = "Thông số đo";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(373, 124);
            label25.Name = "label25";
            label25.Size = new Size(18, 15);
            label25.TabIndex = 37;
            label25.Text = "W";
            // 
            // textBoxPowerMax2
            // 
            textBoxPowerMax2.Location = new Point(287, 121);
            textBoxPowerMax2.Name = "textBoxPowerMax2";
            textBoxPowerMax2.Size = new Size(80, 23);
            textBoxPowerMax2.TabIndex = 36;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(261, 125);
            label26.Name = "label26";
            label26.Size = new Size(18, 15);
            label26.TabIndex = 34;
            label26.Text = "W";
            // 
            // textBoxPowerMin2
            // 
            textBoxPowerMin2.Location = new Point(179, 120);
            textBoxPowerMin2.Name = "textBoxPowerMin2";
            textBoxPowerMin2.Size = new Size(80, 23);
            textBoxPowerMin2.TabIndex = 33;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI", 8.25F);
            label27.Location = new Point(3, 124);
            label27.Name = "label27";
            label27.Size = new Size(60, 13);
            label27.TabIndex = 32;
            label27.Text = "Công suất";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(150, 125);
            label28.Name = "label28";
            label28.Size = new Size(18, 15);
            label28.TabIndex = 31;
            label28.Text = "W";
            // 
            // textBoxPower2
            // 
            textBoxPower2.Location = new Point(69, 120);
            textBoxPower2.Name = "textBoxPower2";
            textBoxPower2.Size = new Size(80, 23);
            textBoxPower2.TabIndex = 30;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Segoe UI", 7F);
            label29.Location = new Point(314, 17);
            label29.Name = "label29";
            label29.Size = new Size(26, 12);
            label29.TabIndex = 29;
            label29.Text = "MAX";
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new Point(373, 81);
            label36.Name = "label36";
            label36.Size = new Size(26, 15);
            label36.TabIndex = 28;
            label36.Text = "mA";
            // 
            // textBoxCurrentMax2
            // 
            textBoxCurrentMax2.Location = new Point(287, 77);
            textBoxCurrentMax2.Name = "textBoxCurrentMax2";
            textBoxCurrentMax2.Size = new Size(80, 23);
            textBoxCurrentMax2.TabIndex = 27;
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new Point(261, 80);
            label37.Name = "label37";
            label37.Size = new Size(26, 15);
            label37.TabIndex = 25;
            label37.Text = "mA";
            // 
            // textBoxCurrentMin2
            // 
            textBoxCurrentMin2.Location = new Point(179, 76);
            textBoxCurrentMin2.Name = "textBoxCurrentMin2";
            textBoxCurrentMin2.Size = new Size(80, 23);
            textBoxCurrentMin2.TabIndex = 24;
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Font = new Font("Segoe UI", 8.25F);
            label38.Location = new Point(3, 80);
            label38.Name = "label38";
            label38.Size = new Size(62, 13);
            label38.TabIndex = 23;
            label38.Text = "Dòng điện";
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Location = new Point(150, 80);
            label39.Name = "label39";
            label39.Size = new Size(26, 15);
            label39.TabIndex = 22;
            label39.Text = "mA";
            // 
            // textBoxCurrent2
            // 
            textBoxCurrent2.Location = new Point(69, 76);
            textBoxCurrent2.Name = "textBoxCurrent2";
            textBoxCurrent2.Size = new Size(80, 23);
            textBoxCurrent2.TabIndex = 21;
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Location = new Point(373, 37);
            label40.Name = "label40";
            label40.Size = new Size(14, 15);
            label40.TabIndex = 19;
            label40.Text = "V";
            // 
            // textBoxVoltageMax2
            // 
            textBoxVoltageMax2.Location = new Point(287, 33);
            textBoxVoltageMax2.Name = "textBoxVoltageMax2";
            textBoxVoltageMax2.Size = new Size(80, 23);
            textBoxVoltageMax2.TabIndex = 18;
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Font = new Font("Segoe UI", 7F);
            label41.Location = new Point(207, 16);
            label41.Name = "label41";
            label41.Size = new Size(24, 12);
            label41.TabIndex = 17;
            label41.Text = "MIN";
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Location = new Point(261, 37);
            label42.Name = "label42";
            label42.Size = new Size(14, 15);
            label42.TabIndex = 16;
            label42.Text = "V";
            // 
            // textBoxVoltageMin2
            // 
            textBoxVoltageMin2.Location = new Point(179, 32);
            textBoxVoltageMin2.Name = "textBoxVoltageMin2";
            textBoxVoltageMin2.Size = new Size(80, 23);
            textBoxVoltageMin2.TabIndex = 15;
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Font = new Font("Segoe UI", 8.25F);
            label43.Location = new Point(3, 36);
            label43.Name = "label43";
            label43.Size = new Size(47, 13);
            label43.TabIndex = 10;
            label43.Text = "Điện áp";
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Location = new Point(150, 37);
            label44.Name = "label44";
            label44.Size = new Size(14, 15);
            label44.TabIndex = 8;
            label44.Text = "V";
            // 
            // textBoxVoltage2
            // 
            textBoxVoltage2.Location = new Point(69, 32);
            textBoxVoltage2.Name = "textBoxVoltage2";
            textBoxVoltage2.Size = new Size(80, 23);
            textBoxVoltage2.TabIndex = 6;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(btnStopProcessTest2);
            groupBox8.Controls.Add(labelTestControlStatus2);
            groupBox8.Controls.Add(textBoxIDAdapter2);
            groupBox8.Controls.Add(progressBarTest2);
            groupBox8.Controls.Add(btnRestartProcessTest2);
            groupBox8.Controls.Add(btnStartProcessTest2);
            groupBox8.Location = new Point(15, 194);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(400, 169);
            groupBox8.TabIndex = 6;
            groupBox8.TabStop = false;
            groupBox8.Text = "Điều khiển quá trình test";
            // 
            // btnStopProcessTest2
            // 
            btnStopProcessTest2.Location = new Point(261, 100);
            btnStopProcessTest2.Name = "btnStopProcessTest2";
            btnStopProcessTest2.Size = new Size(75, 25);
            btnStopProcessTest2.TabIndex = 42;
            btnStopProcessTest2.Text = "Dừng";
            btnStopProcessTest2.UseVisualStyleBackColor = true;
            btnStopProcessTest2.Click += btnStopProcessTest2_Click;
            // 
            // labelTestControlStatus2
            // 
            labelTestControlStatus2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelTestControlStatus2.BackColor = Color.LawnGreen;
            labelTestControlStatus2.BorderStyle = BorderStyle.Fixed3D;
            labelTestControlStatus2.Font = new Font("Tahoma", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTestControlStatus2.Location = new Point(21, 35);
            labelTestControlStatus2.Name = "labelTestControlStatus2";
            labelTestControlStatus2.Size = new Size(195, 50);
            labelTestControlStatus2.TabIndex = 13;
            labelTestControlStatus2.Text = "IDLE";
            labelTestControlStatus2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxIDAdapter2
            // 
            textBoxIDAdapter2.Location = new Point(225, 35);
            textBoxIDAdapter2.Multiline = true;
            textBoxIDAdapter2.Name = "textBoxIDAdapter2";
            textBoxIDAdapter2.ScrollBars = ScrollBars.Vertical;
            textBoxIDAdapter2.Size = new Size(156, 50);
            textBoxIDAdapter2.TabIndex = 12;
            // 
            // progressBarTest2
            // 
            progressBarTest2.Location = new Point(21, 137);
            progressBarTest2.Name = "progressBarTest2";
            progressBarTest2.Size = new Size(360, 23);
            progressBarTest2.TabIndex = 8;
            // 
            // btnRestartProcessTest2
            // 
            btnRestartProcessTest2.Location = new Point(168, 100);
            btnRestartProcessTest2.Name = "btnRestartProcessTest2";
            btnRestartProcessTest2.Size = new Size(75, 25);
            btnRestartProcessTest2.TabIndex = 11;
            btnRestartProcessTest2.Text = "Bắt đầu lại";
            btnRestartProcessTest2.UseVisualStyleBackColor = true;
            btnRestartProcessTest2.Click += btnRestartProcessTest2_Click;
            // 
            // btnStartProcessTest2
            // 
            btnStartProcessTest2.Location = new Point(74, 100);
            btnStartProcessTest2.Name = "btnStartProcessTest2";
            btnStartProcessTest2.Size = new Size(75, 25);
            btnStartProcessTest2.TabIndex = 9;
            btnStartProcessTest2.Text = "Bắt đầu";
            btnStartProcessTest2.UseVisualStyleBackColor = true;
            btnStartProcessTest2.Click += btnStartProcessTest2_Click;
            // 
            // groupBox9
            // 
            groupBox9.BackColor = SystemColors.ButtonHighlight;
            groupBox9.Controls.Add(groupBox14);
            groupBox9.Controls.Add(groupBox10);
            groupBox9.Controls.Add(groupBox11);
            groupBox9.Location = new Point(902, 271);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(430, 471);
            groupBox9.TabIndex = 8;
            groupBox9.TabStop = false;
            groupBox9.Text = "NGUỒN SỐ 3";
            // 
            // groupBox14
            // 
            groupBox14.Controls.Add(buttonRetrySaveData3);
            groupBox14.Controls.Add(label72);
            groupBox14.Controls.Add(labelStatusOfSaveExcel3);
            groupBox14.Controls.Add(labelStatusOfSaveServer3);
            groupBox14.Controls.Add(label71);
            groupBox14.Controls.Add(label73);
            groupBox14.Location = new Point(15, 369);
            groupBox14.Name = "groupBox14";
            groupBox14.Size = new Size(399, 76);
            groupBox14.TabIndex = 8;
            groupBox14.TabStop = false;
            groupBox14.Text = "Qúa trình lưu trữ dữ liệu";
            // 
            // buttonRetrySaveData3
            // 
            buttonRetrySaveData3.Location = new Point(39, 32);
            buttonRetrySaveData3.Name = "buttonRetrySaveData3";
            buttonRetrySaveData3.Size = new Size(75, 25);
            buttonRetrySaveData3.TabIndex = 59;
            buttonRetrySaveData3.Text = "Thử lại";
            buttonRetrySaveData3.UseVisualStyleBackColor = true;
            buttonRetrySaveData3.Click += buttonRetrySaveData3_Click;
            // 
            // label72
            // 
            label72.AutoSize = true;
            label72.Font = new Font("Segoe UI", 8.25F);
            label72.Location = new Point(225, 31);
            label72.Name = "label72";
            label72.Size = new Size(90, 13);
            label72.TabIndex = 61;
            label72.Text = "Upload to excel:";
            // 
            // labelStatusOfSaveExcel3
            // 
            labelStatusOfSaveExcel3.AutoSize = true;
            labelStatusOfSaveExcel3.Location = new Point(326, 30);
            labelStatusOfSaveExcel3.Name = "labelStatusOfSaveExcel3";
            labelStatusOfSaveExcel3.Size = new Size(30, 15);
            labelStatusOfSaveExcel3.TabIndex = 63;
            labelStatusOfSaveExcel3.Text = "IDLE";
            labelStatusOfSaveExcel3.TextAlign = ContentAlignment.TopRight;
            // 
            // labelStatusOfSaveServer3
            // 
            labelStatusOfSaveServer3.AutoSize = true;
            labelStatusOfSaveServer3.Location = new Point(326, 54);
            labelStatusOfSaveServer3.Name = "labelStatusOfSaveServer3";
            labelStatusOfSaveServer3.Size = new Size(30, 15);
            labelStatusOfSaveServer3.TabIndex = 60;
            labelStatusOfSaveServer3.Text = "IDLE";
            labelStatusOfSaveServer3.TextAlign = ContentAlignment.TopRight;
            // 
            // label71
            // 
            label71.AutoSize = true;
            label71.Location = new Point(320, 10);
            label71.Name = "label71";
            label71.Size = new Size(39, 15);
            label71.TabIndex = 62;
            label71.Text = "Status";
            // 
            // label73
            // 
            label73.AutoSize = true;
            label73.Font = new Font("Segoe UI", 8.25F);
            label73.Location = new Point(225, 54);
            label73.Name = "label73";
            label73.Size = new Size(95, 13);
            label73.TabIndex = 58;
            label73.Text = "Upload to server:";
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(label46);
            groupBox10.Controls.Add(textBoxPowerMax3);
            groupBox10.Controls.Add(label47);
            groupBox10.Controls.Add(textBoxPowerMin3);
            groupBox10.Controls.Add(label48);
            groupBox10.Controls.Add(label49);
            groupBox10.Controls.Add(textBoxPower3);
            groupBox10.Controls.Add(label50);
            groupBox10.Controls.Add(label51);
            groupBox10.Controls.Add(textBoxCurrentMax3);
            groupBox10.Controls.Add(label52);
            groupBox10.Controls.Add(textBoxCurrentMin3);
            groupBox10.Controls.Add(label53);
            groupBox10.Controls.Add(label54);
            groupBox10.Controls.Add(textBoxCurrent3);
            groupBox10.Controls.Add(label55);
            groupBox10.Controls.Add(textBoxVoltageMax3);
            groupBox10.Controls.Add(label56);
            groupBox10.Controls.Add(label57);
            groupBox10.Controls.Add(textBoxVoltageMin3);
            groupBox10.Controls.Add(label58);
            groupBox10.Controls.Add(label59);
            groupBox10.Controls.Add(textBoxVoltage3);
            groupBox10.Location = new Point(15, 31);
            groupBox10.Name = "groupBox10";
            groupBox10.Size = new Size(400, 159);
            groupBox10.TabIndex = 0;
            groupBox10.TabStop = false;
            groupBox10.Text = "Thông số đo";
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Location = new Point(373, 124);
            label46.Name = "label46";
            label46.Size = new Size(18, 15);
            label46.TabIndex = 37;
            label46.Text = "W";
            // 
            // textBoxPowerMax3
            // 
            textBoxPowerMax3.Location = new Point(287, 121);
            textBoxPowerMax3.Name = "textBoxPowerMax3";
            textBoxPowerMax3.Size = new Size(80, 23);
            textBoxPowerMax3.TabIndex = 36;
            // 
            // label47
            // 
            label47.AutoSize = true;
            label47.Location = new Point(261, 125);
            label47.Name = "label47";
            label47.Size = new Size(18, 15);
            label47.TabIndex = 34;
            label47.Text = "W";
            // 
            // textBoxPowerMin3
            // 
            textBoxPowerMin3.Location = new Point(179, 120);
            textBoxPowerMin3.Name = "textBoxPowerMin3";
            textBoxPowerMin3.Size = new Size(80, 23);
            textBoxPowerMin3.TabIndex = 33;
            // 
            // label48
            // 
            label48.AutoSize = true;
            label48.Font = new Font("Segoe UI", 8.25F);
            label48.Location = new Point(3, 124);
            label48.Name = "label48";
            label48.Size = new Size(60, 13);
            label48.TabIndex = 32;
            label48.Text = "Công suất";
            // 
            // label49
            // 
            label49.AutoSize = true;
            label49.Location = new Point(150, 125);
            label49.Name = "label49";
            label49.Size = new Size(18, 15);
            label49.TabIndex = 31;
            label49.Text = "W";
            // 
            // textBoxPower3
            // 
            textBoxPower3.Location = new Point(69, 120);
            textBoxPower3.Name = "textBoxPower3";
            textBoxPower3.Size = new Size(80, 23);
            textBoxPower3.TabIndex = 30;
            // 
            // label50
            // 
            label50.AutoSize = true;
            label50.Font = new Font("Segoe UI", 7F);
            label50.Location = new Point(314, 17);
            label50.Name = "label50";
            label50.Size = new Size(26, 12);
            label50.TabIndex = 29;
            label50.Text = "MAX";
            // 
            // label51
            // 
            label51.AutoSize = true;
            label51.Location = new Point(373, 81);
            label51.Name = "label51";
            label51.Size = new Size(26, 15);
            label51.TabIndex = 28;
            label51.Text = "mA";
            // 
            // textBoxCurrentMax3
            // 
            textBoxCurrentMax3.Location = new Point(287, 77);
            textBoxCurrentMax3.Name = "textBoxCurrentMax3";
            textBoxCurrentMax3.Size = new Size(80, 23);
            textBoxCurrentMax3.TabIndex = 27;
            // 
            // label52
            // 
            label52.AutoSize = true;
            label52.Location = new Point(261, 80);
            label52.Name = "label52";
            label52.Size = new Size(26, 15);
            label52.TabIndex = 25;
            label52.Text = "mA";
            // 
            // textBoxCurrentMin3
            // 
            textBoxCurrentMin3.Location = new Point(179, 76);
            textBoxCurrentMin3.Name = "textBoxCurrentMin3";
            textBoxCurrentMin3.Size = new Size(80, 23);
            textBoxCurrentMin3.TabIndex = 24;
            // 
            // label53
            // 
            label53.AutoSize = true;
            label53.Font = new Font("Segoe UI", 8.25F);
            label53.Location = new Point(3, 80);
            label53.Name = "label53";
            label53.Size = new Size(62, 13);
            label53.TabIndex = 23;
            label53.Text = "Dòng điện";
            // 
            // label54
            // 
            label54.AutoSize = true;
            label54.Location = new Point(150, 80);
            label54.Name = "label54";
            label54.Size = new Size(26, 15);
            label54.TabIndex = 22;
            label54.Text = "mA";
            // 
            // textBoxCurrent3
            // 
            textBoxCurrent3.Location = new Point(69, 76);
            textBoxCurrent3.Name = "textBoxCurrent3";
            textBoxCurrent3.Size = new Size(80, 23);
            textBoxCurrent3.TabIndex = 21;
            // 
            // label55
            // 
            label55.AutoSize = true;
            label55.Location = new Point(373, 37);
            label55.Name = "label55";
            label55.Size = new Size(14, 15);
            label55.TabIndex = 19;
            label55.Text = "V";
            // 
            // textBoxVoltageMax3
            // 
            textBoxVoltageMax3.Location = new Point(287, 33);
            textBoxVoltageMax3.Name = "textBoxVoltageMax3";
            textBoxVoltageMax3.Size = new Size(80, 23);
            textBoxVoltageMax3.TabIndex = 18;
            // 
            // label56
            // 
            label56.AutoSize = true;
            label56.Font = new Font("Segoe UI", 7F);
            label56.Location = new Point(207, 16);
            label56.Name = "label56";
            label56.Size = new Size(24, 12);
            label56.TabIndex = 17;
            label56.Text = "MIN";
            // 
            // label57
            // 
            label57.AutoSize = true;
            label57.Location = new Point(261, 37);
            label57.Name = "label57";
            label57.Size = new Size(14, 15);
            label57.TabIndex = 16;
            label57.Text = "V";
            // 
            // textBoxVoltageMin3
            // 
            textBoxVoltageMin3.Location = new Point(179, 32);
            textBoxVoltageMin3.Name = "textBoxVoltageMin3";
            textBoxVoltageMin3.Size = new Size(80, 23);
            textBoxVoltageMin3.TabIndex = 15;
            // 
            // label58
            // 
            label58.AutoSize = true;
            label58.Font = new Font("Segoe UI", 8.25F);
            label58.Location = new Point(3, 36);
            label58.Name = "label58";
            label58.Size = new Size(47, 13);
            label58.TabIndex = 10;
            label58.Text = "Điện áp";
            // 
            // label59
            // 
            label59.AutoSize = true;
            label59.Location = new Point(150, 37);
            label59.Name = "label59";
            label59.Size = new Size(14, 15);
            label59.TabIndex = 8;
            label59.Text = "V";
            // 
            // textBoxVoltage3
            // 
            textBoxVoltage3.Location = new Point(69, 32);
            textBoxVoltage3.Name = "textBoxVoltage3";
            textBoxVoltage3.Size = new Size(80, 23);
            textBoxVoltage3.TabIndex = 6;
            // 
            // groupBox11
            // 
            groupBox11.Controls.Add(btnStopProcessTest3);
            groupBox11.Controls.Add(labelTestControlStatus3);
            groupBox11.Controls.Add(textBoxIDAdapter3);
            groupBox11.Controls.Add(progressBarTest3);
            groupBox11.Controls.Add(btnRestartProcessTest3);
            groupBox11.Controls.Add(btnStartProcessTest3);
            groupBox11.Location = new Point(15, 194);
            groupBox11.Name = "groupBox11";
            groupBox11.Size = new Size(400, 169);
            groupBox11.TabIndex = 6;
            groupBox11.TabStop = false;
            groupBox11.Text = "Điều khiển quá trình test";
            // 
            // btnStopProcessTest3
            // 
            btnStopProcessTest3.Location = new Point(261, 100);
            btnStopProcessTest3.Name = "btnStopProcessTest3";
            btnStopProcessTest3.Size = new Size(75, 25);
            btnStopProcessTest3.TabIndex = 42;
            btnStopProcessTest3.Text = "Dừng";
            btnStopProcessTest3.UseVisualStyleBackColor = true;
            btnStopProcessTest3.Click += btnStopProcessTest3_Click;
            // 
            // labelTestControlStatus3
            // 
            labelTestControlStatus3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelTestControlStatus3.BackColor = Color.LawnGreen;
            labelTestControlStatus3.BorderStyle = BorderStyle.Fixed3D;
            labelTestControlStatus3.Font = new Font("Tahoma", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTestControlStatus3.Location = new Point(21, 35);
            labelTestControlStatus3.Name = "labelTestControlStatus3";
            labelTestControlStatus3.Size = new Size(195, 50);
            labelTestControlStatus3.TabIndex = 13;
            labelTestControlStatus3.Text = "IDLE";
            labelTestControlStatus3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxIDAdapter3
            // 
            textBoxIDAdapter3.Location = new Point(225, 35);
            textBoxIDAdapter3.Multiline = true;
            textBoxIDAdapter3.Name = "textBoxIDAdapter3";
            textBoxIDAdapter3.ScrollBars = ScrollBars.Vertical;
            textBoxIDAdapter3.Size = new Size(156, 50);
            textBoxIDAdapter3.TabIndex = 12;
            // 
            // progressBarTest3
            // 
            progressBarTest3.Location = new Point(21, 137);
            progressBarTest3.Name = "progressBarTest3";
            progressBarTest3.Size = new Size(360, 23);
            progressBarTest3.TabIndex = 8;
            // 
            // btnRestartProcessTest3
            // 
            btnRestartProcessTest3.Location = new Point(168, 100);
            btnRestartProcessTest3.Name = "btnRestartProcessTest3";
            btnRestartProcessTest3.Size = new Size(75, 25);
            btnRestartProcessTest3.TabIndex = 11;
            btnRestartProcessTest3.Text = "Bắt đầu lại";
            btnRestartProcessTest3.UseVisualStyleBackColor = true;
            btnRestartProcessTest3.Click += btnRestartProcessTest3_Click;
            // 
            // btnStartProcessTest3
            // 
            btnStartProcessTest3.Location = new Point(74, 100);
            btnStartProcessTest3.Name = "btnStartProcessTest3";
            btnStartProcessTest3.Size = new Size(75, 25);
            btnStartProcessTest3.TabIndex = 9;
            btnStartProcessTest3.Text = "Bắt đầu";
            btnStartProcessTest3.UseVisualStyleBackColor = true;
            btnStartProcessTest3.Click += btnStartProcessTest3_Click;
            // 
            // Control_all
            // 
            Control_all.Controls.Add(checkBoxTestAdapter3);
            Control_all.Controls.Add(checkBoxTestAdapter2);
            Control_all.Controls.Add(checkBoxTestAdapter1);
            Control_all.Controls.Add(btnStopProcessTestAll);
            Control_all.Controls.Add(btnRestartProcessTestAll);
            Control_all.Controls.Add(btnStartProcessTestAll);
            Control_all.Location = new Point(10, 159);
            Control_all.Name = "Control_all";
            Control_all.Size = new Size(605, 100);
            Control_all.TabIndex = 14;
            Control_all.TabStop = false;
            Control_all.Text = "Bảng điều khiển quá trình test";
            // 
            // checkBoxTestAdapter3
            // 
            checkBoxTestAdapter3.AutoSize = true;
            checkBoxTestAdapter3.Location = new Point(483, 72);
            checkBoxTestAdapter3.Name = "checkBoxTestAdapter3";
            checkBoxTestAdapter3.Size = new Size(87, 19);
            checkBoxTestAdapter3.TabIndex = 9;
            checkBoxTestAdapter3.Text = "Nguồn số 3";
            checkBoxTestAdapter3.UseVisualStyleBackColor = true;
            // 
            // checkBoxTestAdapter2
            // 
            checkBoxTestAdapter2.AutoSize = true;
            checkBoxTestAdapter2.Location = new Point(483, 47);
            checkBoxTestAdapter2.Name = "checkBoxTestAdapter2";
            checkBoxTestAdapter2.Size = new Size(87, 19);
            checkBoxTestAdapter2.TabIndex = 8;
            checkBoxTestAdapter2.Text = "Nguồn số 2";
            checkBoxTestAdapter2.UseVisualStyleBackColor = true;
            // 
            // checkBoxTestAdapter1
            // 
            checkBoxTestAdapter1.AutoSize = true;
            checkBoxTestAdapter1.Location = new Point(483, 22);
            checkBoxTestAdapter1.Name = "checkBoxTestAdapter1";
            checkBoxTestAdapter1.Size = new Size(87, 19);
            checkBoxTestAdapter1.TabIndex = 7;
            checkBoxTestAdapter1.Text = "Nguồn số 1";
            checkBoxTestAdapter1.UseVisualStyleBackColor = true;
            // 
            // btnStopProcessTestAll
            // 
            btnStopProcessTestAll.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStopProcessTestAll.Location = new Point(300, 34);
            btnStopProcessTestAll.Name = "btnStopProcessTestAll";
            btnStopProcessTestAll.Size = new Size(119, 42);
            btnStopProcessTestAll.TabIndex = 2;
            btnStopProcessTestAll.Text = "Dừng";
            btnStopProcessTestAll.UseVisualStyleBackColor = true;
            btnStopProcessTestAll.Click += btnStopProcessTestAll_Click;
            // 
            // btnRestartProcessTestAll
            // 
            btnRestartProcessTestAll.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRestartProcessTestAll.Location = new Point(165, 34);
            btnRestartProcessTestAll.Name = "btnRestartProcessTestAll";
            btnRestartProcessTestAll.Size = new Size(119, 42);
            btnRestartProcessTestAll.TabIndex = 1;
            btnRestartProcessTestAll.Text = "Bắt đầu lại";
            btnRestartProcessTestAll.UseVisualStyleBackColor = true;
            btnRestartProcessTestAll.Click += btnRestartProcessTestAll_Click;
            // 
            // btnStartProcessTestAll
            // 
            btnStartProcessTestAll.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStartProcessTestAll.Location = new Point(30, 34);
            btnStartProcessTestAll.Name = "btnStartProcessTestAll";
            btnStartProcessTestAll.Size = new Size(119, 42);
            btnStartProcessTestAll.TabIndex = 0;
            btnStartProcessTestAll.Text = "Bắt đầu";
            btnStartProcessTestAll.UseVisualStyleBackColor = true;
            btnStartProcessTestAll.Click += btnStartProcessTestAll_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1344, 881);
            Controls.Add(Control_all);
            Controls.Add(groupBox9);
            Controls.Add(groupBox5);
            Controls.Add(groupBox6);
            Controls.Add(label32);
            Controls.Add(groupBox4);
            Controls.Add(label31);
            Controls.Add(label30);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox1);
            Controls.Add(CONNECTION);
            Name = "Form1";
            Text = "Adapter test tool";
            CONNECTION.ResumeLayout(false);
            CONNECTION.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox12.ResumeLayout(false);
            groupBox12.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox13.ResumeLayout(false);
            groupBox13.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            groupBox9.ResumeLayout(false);
            groupBox14.ResumeLayout(false);
            groupBox14.PerformLayout();
            groupBox10.ResumeLayout(false);
            groupBox10.PerformLayout();
            groupBox11.ResumeLayout(false);
            groupBox11.PerformLayout();
            Control_all.ResumeLayout(false);
            Control_all.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label UartStatus;
        private GroupBox CONNECTION;
        private NumericUpDown numericUpDown1;
        private ComboBox comboBoxPortUart;
        private Button btnConnect;
        private Label label1;
        private ComboBox comboBoxBaurateUart;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox textBoxVoltage1;
        private Label label12;
        private TextBox textBoxVoltageMax1;
        private Label label9;
        private Label label10;
        private TextBox textBoxVoltageMin1;
        private Label label5;
        private Label label3;
        private Label label16;
        private TextBox textBoxPowerMax1;
        private Label label18;
        private TextBox textBoxPowerMin1;
        private Label label19;
        private Label label20;
        private TextBox textBoxPower1;
        private Label label4;
        private Label label6;
        private TextBox textBoxCurrentMax1;
        private Label label8;
        private TextBox textBoxCurrentMin1;
        private Label label13;
        private Label label14;
        private TextBox textBoxCurrent1;
        private GroupBox groupBox3;
        private Button btnSave;
        private GroupBox groupBox4;
        private DomainUpDown domainUpDownVoltageMin;
        private Label label7;
        private Label label11;
        private Label label24;
        private Label label15;
        private Label label23;
        private Label label22;
        private Label label17;
        private Label label21;
        private Button btnImport;
        private DomainUpDown domainUpDownVoltageMax;
        private DomainUpDown domainUpDownCurrentMax;
        private DomainUpDown domainUpDownCurrentMin;
        private Button btnRestartProcessTest1;
        private Button btnStopRecording;
        private Button btnStartProcessTest1;
        private TextBox textBoxIDAdapter1;
        private ProgressBar progressBarTest1;
        private Label labelTestControlStatus1;
        private PictureBox pictureBox1;
        private Label label30;
        private Label label31;
        private Label label32;
        private TextBox textBoxPathData;
        private GroupBox groupBox6;
        private Label label33;
        private Button btnStartRecording;
        private Button btnBrowsePart;
        private Label label34;
        private DomainUpDown domainUpDownTimeTesting;
        private Label label35;
        private Button btnStopProcessTest1;
        private SerialPort serialPort1;
        private GroupBox groupBox5;
        private GroupBox groupBox7;
        private Label label25;
        private TextBox textBoxPowerMax2;
        private Label label26;
        private TextBox textBoxPowerMin2;
        private Label label27;
        private Label label28;
        private TextBox textBoxPower2;
        private Label label29;
        private Label label36;
        private TextBox textBoxCurrentMax2;
        private Label label37;
        private TextBox textBoxCurrentMin2;
        private Label label38;
        private Label label39;
        private TextBox textBoxCurrent2;
        private Label label40;
        private TextBox textBoxVoltageMax2;
        private Label label41;
        private Label label42;
        private TextBox textBoxVoltageMin2;
        private Label label43;
        private Label label44;
        private TextBox textBoxVoltage2;
        private GroupBox groupBox8;
        private Button btnStopProcessTest2;
        private Label labelTestControlStatus2;
        private TextBox textBoxIDAdapter2;
        private ProgressBar progressBarTest2;
        private Button btnRestartProcessTest2;
        private Button btnStartProcessTest2;
        private GroupBox groupBox9;
        private GroupBox groupBox10;
        private Label label46;
        private TextBox textBoxPowerMax3;
        private Label label47;
        private TextBox textBoxPowerMin3;
        private Label label48;
        private Label label49;
        private TextBox textBoxPower3;
        private Label label50;
        private Label label51;
        private TextBox textBoxCurrentMax3;
        private Label label52;
        private TextBox textBoxCurrentMin3;
        private Label label53;
        private Label label54;
        private TextBox textBoxCurrent3;
        private Label label55;
        private TextBox textBoxVoltageMax3;
        private Label label56;
        private Label label57;
        private TextBox textBoxVoltageMin3;
        private Label label58;
        private Label label59;
        private TextBox textBoxVoltage3;
        private GroupBox groupBox11;
        private Button btnStopProcessTest3;
        private Label labelTestControlStatus3;
        private TextBox textBoxIDAdapter3;
        private ProgressBar progressBarTest3;
        private Button btnRestartProcessTest3;
        private Button btnStartProcessTest3;
        private Button button1;
        private CheckBox checkBoxTestAdapter1;
        private CheckBox checkBoxTestAdapter2;
        private CheckBox checkBoxTestAdapter3;
        private GroupBox Control_all;
        private Button btnStopProcessTestAll;
        private Button btnRestartProcessTestAll;
        private Button btnStartProcessTestAll;
        private Label labelNameFileConfigTest;
        private Label label45;
        private TextBox API_Lark;
        private CheckBox checkBoxUpdateToLark;
        private GroupBox groupBox12;
        private Label labelStatusOfSaveServer1;
        private GroupBox groupBox13;
        private GroupBox groupBox14;
        private Label labelStatusOfSaveExcel1;
        private Label label69;
        private Label label67;
        private Label label66;
        private Button buttonRetrySaveData1;
        private Button buttonRetrySaveData2;
        private Label labelStatusOfSaveExcel2;
        private Label label62;
        private Label label63;
        private Label label64;
        private Label labelStatusOfSaveServer2;
        private Button buttonRetrySaveData3;
        private Label label72;
        private Label labelStatusOfSaveExcel3;
        private Label labelStatusOfSaveServer3;
        private Label label71;
        private Label label73;
        private Label label60;
        private TextBox textBoxOperatingWorkes;
        private ComboBox comboBoxTestingStage;
        private Label label61;
    }
}
