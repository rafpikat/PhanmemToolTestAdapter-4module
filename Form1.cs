using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Configuration;
using System.Timers;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.IO;
using System.Collections.Generic; // Thêm để sử dụng List
using System.Linq; // Thêm để sử dụng LINQ
using Tool_test_adapter_power.Properties;
using System.Net.Http.Headers;
using System.Text;

namespace Tool_test_adapter_power
{
    public partial class Form1 : Form
    {

        private List<byte> buffer = new List<byte>();

        //Adapter 1
        private float current = 0;
        private float currentMax = 0;
        private float currentMin = 0;
        private float voltage = 0;
        private float voltageMax = 0;
        private float voltageMin = 0;
        private float power = 0;
        private float powerMax = 0;
        private float powerMin = 0;

        private int testProgress1 = 0; // Tiến trình test
        private int testProgress2 = 0; // Tiến trình test
        private int testProgress3 = 0; // Tiến trình test
        private TestSettings currentSettings; // Lưu thông số cài đặt
        private string currentConfigFilePath = null;
        private bool isTesting1 = false; // Trạng thái test của Adapter 1
        private bool isTesting2 = false; // Trạng thái test của Adapter 2
        private bool isTesting3 = false; // Trạng thái test của Adapter 3

        //Adapter 2

        private bool isFirstVoltage = true;
        private bool isFirstCurrent = true;
        private bool isFirstVoltage2 = true;
        private bool isFirstCurrent2 = true;
        private float current2 = 0;
        private float currentMax2 = 0;
        private float currentMin2 = 0;
        private float voltage2 = 0;
        private float voltageMax2 = 0;
        private float voltageMin2 = 0;
        private float power2 = 0;
        private float powerMax2 = 0;
        private float powerMin2 = 0;

        //Adapter 3
        private bool isFirstVoltage3 = true;
        private bool isFirstCurrent3 = true;
        private float current3 = 0;
        private float currentMax3 = 0;
        private float currentMin3 = 0;
        private float voltage3 = 0;
        private float voltageMax3 = 0;
        private float voltageMin3 = 0;
        private float power3 = 0;
        private float powerMax3 = 0;
        private float powerMin3 = 0;


        private System.Windows.Forms.Timer connectionCheckTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer testTimer1 = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer testTimer2 = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer testTimer3 = new System.Windows.Forms.Timer();
        //private StreamWriter logFile = null;
        private bool isLogging = false;
        private string[] _lastPorts = new string[0];
        private bool _connectionLostNotified = false; // Biến kiểm soát thông báo mất kết nối

        private bool isRecording = false; // Trạng thái ghi dữ liệu
        private string excelFilePath; // Đường dẫn file Excel

        // Thêm các trường mới cho xử lý QR

        private System.Windows.Forms.Timer qrTimer = new System.Windows.Forms.Timer();

        private string qrBuffer = string.Empty; // Lưu tạm dữ liệu QR

        private List<(TextBox TextBox, CheckBox CheckBox)> adapterInputs; // Danh sách ô ID và checkbox

        private int currentAdapterIndex = 0; // Chỉ số adapter hiện tại để nhập ID

        private bool isWaitingForQR = false; // Trạng thái chờ nhập QR

        private bool isReadyForNewQR = false; // Trạng thái cho phép xóa ID khi có QR mới
        public class TestSettings
        {
            public float VoltageMin { get; set; }
            public float VoltageMax { get; set; }
            public float CurrentMin { get; set; }
            public float CurrentMax { get; set; }
            public int TestTime { get; set; }
        }
        public class TestResult
        {
            public string ID_Adapter { get; set; }
            public string Thời_gian { get; set; }
            public string Kết_quả { get; set; }
            public float Vmax_V { get; set; }
            public float Vmin_V { get; set; }
            public float Imax_mA { get; set; }
            public float Imin_mA { get; set; }
            public float Pmax_W { get; set; }
            public float Pmin_W { get; set; }
            public string Operator { get; set; } //Người thực hiện test
            public string TestingStage { get; set; } //Công đoạn test
        }

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            // Kích hoạt nhận sự kiện bàn phím
            this.KeyPreview = true;
            this.KeyPress += Form1_KeyPress;
            // Thiết lập timer tách QR
            qrTimer.Interval = 200; // 500ms để tách các lần quét
            qrTimer.Tick += QrTimer_Tick;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveTestSettings();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxPortUart.Items.AddRange(ports);
            connectionCheckTimer.Interval = 1000; // Kiểm tra mỗi 1 giây
            connectionCheckTimer.Tick += ConnectionCheckTimer_Tick;


            testTimer1.Interval = 1000; // Cập nhật mỗi 1 giây
            testTimer1.Tick += TestTimer1_Tick;


            testTimer2.Interval = 1000; // Cập nhật mỗi 1 giây
            testTimer2.Tick += TestTimer2_Tick;


            testTimer3.Interval = 1000; // Cập nhật mỗi 1 giây
            testTimer3.Tick += TestTimer3_Tick;
            serialPort1.ErrorReceived += SerialPort_ErrorReceived;

            LoadUartSettings();
            // Đảm bảo trạng thái ban đầu
            UpdateUartControlsState();
            connectionCheckTimer.Start();
            // Tải ảnh từ đường dẫn tương đối
            try
            {
                string imagePath = Path.Combine("Images", "Logo.png");
                if (File.Exists(imagePath))
                {
                    pictureBox1.ImageLocation = imagePath;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tệp ảnh: " + imagePath, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                // Tải URL API từ Properties.Settings
                API_Lark.Text = Properties.Settings.Default.APILark ?? "";

                // Kiểm tra URL hợp lệ và cập nhật checkbox
                bool isValidUrl = Uri.TryCreate(API_Lark.Text.Trim(), UriKind.Absolute, out Uri uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                checkBoxUpdateToLark.Enabled = isValidUrl;
                checkBoxUpdateToLark.Checked = isValidUrl && Properties.Settings.Default.checkBoxEnableApi; // Khôi phục trạng thái checked
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải URL API: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                API_Lark.Text = "";
                checkBoxUpdateToLark.Enabled = false;
                checkBoxUpdateToLark.Checked = false;
            }

            LoadTestSettings();
            // Tải đường dẫn lưu trữ
            try
            {
                textBoxPathData.Text = Properties.Settings.Default.StoragePath ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải đường dẫn lưu trữ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPathData.Text = "";
            }
            InitializeAdapterInputs();
        }

        private void InitializeAdapterInputs()
        {
            adapterInputs = new List<(TextBox TextBox, CheckBox CheckBox)>
            {
                (textBoxIDAdapter1, checkBoxTestAdapter1),
                (textBoxIDAdapter2, checkBoxTestAdapter2),
                (textBoxIDAdapter3, checkBoxTestAdapter3)
            };
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ xử lý khi đang ghi dữ liệu và chờ nhập QR
            if (!isRecording || !isWaitingForQR) return;

            // Nếu nhận Enter, không xử lý (máy quét QR thường gửi Enter sau mỗi chuỗi)
            if (e.KeyChar == '\r') return;

            // Thêm ký tự vào buffer
            qrBuffer += e.KeyChar;
            qrTimer.Stop();
            qrTimer.Start(); // Reset timer mỗi khi nhận ký tự mới
            e.Handled = true; // Ngăn ký tự hiển thị ở ô nhập liệu khác
        }
        private void QrTimer_Tick(object sender, EventArgs e)
        {
            qrTimer.Stop();
            if (!string.IsNullOrWhiteSpace(qrBuffer))
            {
                // Khi có QR mới, kiểm tra nếu được phép xóa ID
                if (isReadyForNewQR)
                {
                    ClearAdapterIDs();
                    isReadyForNewQR = false; // Reset trạng thái sau khi xóa
                }
                ProcessQRCode(qrBuffer);
                qrBuffer = string.Empty;
            }
        }
        private void ClearAdapterIDs()
        {
            foreach (var adapter in adapterInputs.Where(a => a.CheckBox.Checked))
            {
                adapter.TextBox.Text = string.Empty;
            }
        }
        private void ProcessQRCode(string qrData)
        {
            // Lấy danh sách adapter được chọn
            var selectedAdapters = adapterInputs.Where(a => a.CheckBox.Checked).ToList();
            if (currentAdapterIndex < selectedAdapters.Count)
            {
                // Nhập QR vào ô ID hiện tại
                selectedAdapters[currentAdapterIndex].TextBox.Text = qrData.Trim();
                currentAdapterIndex++;

                // Nếu đã nhập đủ ID, tự động chạy test
                if (currentAdapterIndex >= selectedAdapters.Count)
                {
                    btnStartProcessTestAll_Click(this, EventArgs.Empty);
                }
            }
        }
        private void SaveUartSettings()
        {
            try
            {
                Properties.Settings.Default.UartPort = comboBoxPortUart.Text;
                Properties.Settings.Default.UartBaudRate = comboBoxBaurateUart.Text;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu cài đặt UART: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUartSettings()
        {
            try
            {
                string savedPort = Properties.Settings.Default.UartPort;
                string[] availablePorts = SerialPort.GetPortNames();
                if (!string.IsNullOrEmpty(savedPort) && availablePorts.Contains(savedPort))
                {
                    comboBoxPortUart.SelectedItem = savedPort;
                }
                else
                {
                    comboBoxPortUart.SelectedIndex = -1;
                }

                string savedBaudRate = Properties.Settings.Default.UartBaudRate;
                if (!string.IsNullOrEmpty(savedBaudRate) && comboBoxBaurateUart.Items.Contains(savedBaudRate))
                {
                    comboBoxBaurateUart.SelectedItem = savedBaudRate;
                }
                else
                {
                    comboBoxBaurateUart.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải cài đặt UART: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxPortUart.SelectedIndex = -1;
                comboBoxBaurateUart.SelectedIndex = -1;
            }
        }
        private void UpdateUartControlsState()
        {
            if (serialPort1.IsOpen)
            {
                comboBoxPortUart.Enabled = false;
                comboBoxBaurateUart.Enabled = false;
                btnConnect.Text = "DISCONNECT";
                UartStatus.Text = "CONNECTED";
                UartStatus.ForeColor = Color.Green;
            }
            else
            {
                comboBoxPortUart.Enabled = true;
                comboBoxBaurateUart.Enabled = true;
                btnConnect.Text = "CONNECT";
                UartStatus.Text = "DISCONNECTED";
                UartStatus.ForeColor = Color.Red;
            }
        }
        private TestSettings LoadTestSettings()
        {
            try
            {
                string filePath = Path.Combine(Application.StartupPath, "settings.json");
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    TestSettings settings = JsonConvert.DeserializeObject<TestSettings>(json);
                    domainUpDownVoltageMin.Text = settings.VoltageMin.ToString("F3");
                    domainUpDownVoltageMax.Text = settings.VoltageMax.ToString("F3");
                    domainUpDownCurrentMin.Text = settings.CurrentMin.ToString("F3");
                    domainUpDownCurrentMax.Text = settings.CurrentMax.ToString("F3");
                    domainUpDownTimeTesting.Text = settings.TestTime.ToString();
                    labelNameFileConfigTest.Text = Path.GetFileName(filePath);
                    return settings;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải cài đặt: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private void SaveTestSettings()
        {
            try
            {
                if (!float.TryParse(domainUpDownVoltageMin.Text.Replace(" V", ""), out float voltageMin) ||
                    !float.TryParse(domainUpDownVoltageMax.Text.Replace(" V", ""), out float voltageMax) ||
                    !float.TryParse(domainUpDownCurrentMin.Text.Replace(" mA", ""), out float currentMin) ||
                    !float.TryParse(domainUpDownCurrentMax.Text.Replace(" mA", ""), out float currentMax) ||
                    !int.TryParse(domainUpDownTimeTesting.Text.Replace(" s", ""), out int testTime))
                {
                    MessageBox.Show("Dữ liệu nhập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                TestSettings settings = new TestSettings
                {
                    VoltageMin = voltageMin,
                    VoltageMax = voltageMax,
                    CurrentMin = currentMin,
                    CurrentMax = currentMax,
                    TestTime = testTime
                };

                string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
                string filePath = Path.Combine(Application.StartupPath, "settings.json");
                File.WriteAllText(filePath, json);
                MessageBox.Show("Cài đặt đã được lưu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu cài đặt: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SerialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                UpdateUartControlsState();
                MessageBox.Show("Mất kết nối UART!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StopLogging();
            }));
        }

        private void ConnectionCheckTimer_Tick(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen && btnConnect.Text != "CONNECT")
            {
                if (!_connectionLostNotified && !this.IsDisposed)
                {
                    this.Invoke(new Action(() =>
                    {
                        UpdateUartControlsState();
                        MessageBox.Show("Mất kết nối UART!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        StopLogging();
                    }));
                    _connectionLostNotified = true;
                }
            }
            else
            {
                _connectionLostNotified = false;
            }

            string[] ports = SerialPort.GetPortNames();
            if (!ports.SequenceEqual(_lastPorts))
            {
                this.Invoke(new Action(() =>
                {
                    string selectedPort = comboBoxPortUart.SelectedItem?.ToString();
                    comboBoxPortUart.Items.Clear();
                    comboBoxPortUart.Items.AddRange(ports);
                    if (!string.IsNullOrEmpty(selectedPort) && ports.Contains(selectedPort))
                    {
                        comboBoxPortUart.SelectedItem = selectedPort;
                    }
                }));
                _lastPorts = ports;
            }
        }
        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                if (string.IsNullOrEmpty(comboBoxPortUart.Text) || string.IsNullOrEmpty(comboBoxBaurateUart.Text))
                {
                    MessageBox.Show("Vui lòng chọn cổng UART và baud rate!", "Thiếu thông số", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    serialPort1.PortName = comboBoxPortUart.Text;
                    serialPort1.BaudRate = Convert.ToInt32(comboBoxBaurateUart.Text);
                    serialPort1.DataBits = 8;
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Open();
                    SaveUartSettings();
                    UpdateUartControlsState();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connectionCheckTimer.Stop();
            }
            else
            {
                connectionCheckTimer.Start();
                serialPort1.Close();
                UpdateUartControlsState();
                StopLogging();
            }
        }

        private void comboBoxBaurateUart_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBoxPortUart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytesToRead = serialPort1.BytesToRead;
            byte[] received = new byte[bytesToRead];
            serialPort1.Read(received, 0, bytesToRead);

            buffer.AddRange(received);
            ProcessBuffer();
        }

        private void ProcessBuffer()
        {
            if (buffer.Count > 10000) // Giới hạn kích thước buffer
            {
                buffer.Clear();
                return;
            }
            while (buffer.Count >= 8) // bản tin tối thiểu
            {
                int index = buffer.FindIndex(0, b => b == 0x4C);
                if (index < 0 || index + 1 >= buffer.Count || buffer[index + 1] != 0x4D)
                {
                    buffer.RemoveAt(0);
                    continue;
                }

                if (buffer.Count < index + 5) return;

                byte cmd = buffer[index + 2];
                byte len = buffer[index + 3];
                int fullLength = 2 + 1 + 1 + len + 1;

                if (buffer.Count < index + fullLength) return;

                byte[] packet = buffer.Skip(index).Take(fullLength).ToArray();

                byte xor = 0;
                for (int i = index + 4; i < fullLength - 1; i++)
                    xor ^= packet[i];

                if (xor == packet[fullLength - 1])
                {
                    float value = ParseFloatBigEndian(packet.Skip(5).Take(len - 1).ToArray());
                    byte adapter = packet[index + 4];
                    HandlePacket(cmd, value, adapter);
                    //if (isLogging && logFile != null)
                    //{
                    //    string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] CMD: {cmd}, Data: {BitConverter.ToString(packet)}\n";
                    //    logFile.Write(logEntry);
                    //    logFile.Flush(); // Đảm bảo ghi ngay lập tức
                    //}
                }

                buffer.RemoveRange(0, index + fullLength);
            }
        }

        private float ParseFloatBigEndian(byte[] data)
        {
            if (data.Length != 4) return 0f;
            Array.Reverse(data);
            return BitConverter.ToSingle(data, 0);
        }

        private void HandlePacket(byte cmd, float value, byte adapter)
        {
            this.Invoke(new Action(() =>
            {
                switch (cmd)
                {
                    case 0x01:
                        {
                            if (adapter == 0x01)
                            {
                                voltage = value;
                                if (isTesting1)
                                {

                                    if (isFirstVoltage)
                                    {
                                        voltageMax = value;
                                        voltageMin = value;
                                        isFirstVoltage = false;
                                    }
                                    else
                                    {
                                        voltageMax = Math.Max(voltageMax, value);
                                        voltageMin = Math.Min(voltageMin, value);
                                    }

                                    textBoxVoltage1.Text = value.ToString("F3");
                                    textBoxVoltageMax1.Text = voltageMax.ToString("F3");
                                    textBoxVoltageMin1.Text = voltageMin.ToString("F3");
                                    powerMax = voltageMax * currentMax / 1000;
                                    powerMin = voltageMin * currentMin / 1000;
                                    textBoxPowerMax1.Text = powerMax.ToString("F3");
                                    textBoxPowerMin1.Text = powerMin.ToString("F3");

                                }


                            }
                            else if (adapter == 0x02)
                            {
                                voltage2 = value;
                                if (isTesting2)
                                {

                                    if (isFirstVoltage2)
                                    {
                                        voltageMax2 = value;
                                        voltageMin2 = value;
                                        isFirstVoltage2 = false;
                                    }
                                    else
                                    {
                                        voltageMax2 = Math.Max(voltageMax2, value);
                                        voltageMin2 = Math.Min(voltageMin2, value);
                                    }

                                    textBoxVoltage2.Text = value.ToString("F3");
                                    textBoxVoltageMax2.Text = voltageMax2.ToString("F3");
                                    textBoxVoltageMin2.Text = voltageMin2.ToString("F3");
                                    powerMax2 = voltageMax2 * currentMax2 / 1000;
                                    powerMin2 = voltageMin2 * currentMin2 / 1000;
                                    textBoxPowerMax2.Text = powerMax2.ToString("F3");
                                    textBoxPowerMin2.Text = powerMin2.ToString("F3");

                                }
                            }
                            else if (adapter == 0x03)
                            {
                                voltage3 = value;

                                if (isTesting3)
                                {

                                    if (isFirstVoltage3)
                                    {
                                        voltageMax3 = value;
                                        voltageMin3 = value;
                                        isFirstVoltage3 = false;
                                    }
                                    else
                                    {
                                        voltageMax3 = Math.Max(voltageMax3, value);
                                        voltageMin3 = Math.Min(voltageMin3, value);
                                    }

                                    textBoxVoltage3.Text = value.ToString("F3");
                                    textBoxVoltageMax3.Text = voltageMax3.ToString("F3");
                                    textBoxVoltageMin3.Text = voltageMin3.ToString("F3");
                                    powerMax3 = voltageMax3 * currentMax3 / 1000;
                                    powerMin3 = voltageMin3 * currentMin3 / 1000;
                                    textBoxPowerMax3.Text = powerMax3.ToString("F3");
                                    textBoxPowerMin3.Text = powerMin3.ToString("F3");

                                }
                            }
                            break;
                        }
                    case 0x02:
                        {
                            if (adapter == 0x01)
                            {
                                current = value;

                                if (isTesting1)
                                {
                                    if (isFirstCurrent)
                                    {
                                        currentMax = value;
                                        currentMin = value;
                                        isFirstCurrent = false;
                                    }
                                    else
                                    {
                                        currentMax = Math.Max(currentMax, value);
                                        currentMin = Math.Min(currentMin, value);
                                    }

                                    textBoxCurrent1.Text = value.ToString("F3");
                                    textBoxCurrentMax1.Text = currentMax.ToString("F3");
                                    textBoxCurrentMin1.Text = currentMin.ToString("F3");
                                    powerMax = voltageMax * currentMax / 1000;
                                    powerMin = voltageMin * currentMin / 1000;
                                    textBoxPowerMax1.Text = powerMax.ToString("F3");
                                    textBoxPowerMin1.Text = powerMin.ToString("F3");
                                }
                            }
                            else if (adapter == 0x02)
                            {
                                current2 = value;
                                if (isTesting2)
                                {
                                    if (isFirstCurrent2)
                                    {
                                        currentMax2 = value;
                                        currentMin2 = value;
                                        isFirstCurrent2 = false;
                                    }
                                    else
                                    {
                                        currentMax2 = Math.Max(currentMax2, value);
                                        currentMin2 = Math.Min(currentMin2, value);
                                    }

                                    textBoxCurrent2.Text = value.ToString("F3");
                                    textBoxCurrentMax2.Text = currentMax2.ToString("F3");
                                    textBoxCurrentMin2.Text = currentMin2.ToString("F3");
                                    powerMax2 = voltageMax2 * currentMax2 / 1000;
                                    powerMin2 = voltageMin2 * currentMin2 / 1000;
                                    textBoxPowerMax2.Text = powerMax2.ToString("F3");
                                    textBoxPowerMin2.Text = powerMin2.ToString("F3");
                                }
                            }
                            else if (adapter == 0x03)
                            {
                                current3 = value;
                                if (isTesting3)
                                {
                                    if (isFirstCurrent3)
                                    {
                                        currentMax3 = value;
                                        currentMin3 = value;
                                        isFirstCurrent3 = false;
                                    }
                                    else
                                    {
                                        currentMax3 = Math.Max(currentMax3, value);
                                        currentMin3 = Math.Min(currentMin3, value);
                                    }

                                    textBoxCurrent3.Text = value.ToString("F3");
                                    textBoxCurrentMax3.Text = currentMax3.ToString("F3");
                                    textBoxCurrentMin3.Text = currentMin3.ToString("F3");
                                    powerMax3 = voltageMax3 * currentMax3 / 1000;
                                    powerMin3 = voltageMin3 * currentMin3 / 1000;
                                    textBoxPowerMax3.Text = powerMax3.ToString("F3");
                                    textBoxPowerMin3.Text = powerMin3.ToString("F3");
                                }

                            }

                            break;
                        }

                    default:
                        break;
                }

                power = voltage * current / 1000;

                power2 = voltage2 * current2 / 1000;

                power3 = voltage3 * current3 / 1000;

                textBoxPower1.Text = power.ToString("F3");
                textBoxVoltage1.Text = voltage.ToString("F3");
                textBoxCurrent1.Text = current.ToString("F3"); ;

                textBoxPower2.Text = power2.ToString("F3");
                textBoxVoltage2.Text = voltage2.ToString("F3");
                textBoxCurrent2.Text = current2.ToString("F3");

                textBoxPower3.Text = power3.ToString("F3");
                textBoxVoltage3.Text = voltage3.ToString("F3");
                textBoxCurrent3.Text = current3.ToString("F3");

            }));
        }

        private void textBoxPowerMax_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                openFileDialog.Title = "Chọn file cài đặt để import";
                openFileDialog.InitialDirectory = string.IsNullOrEmpty(textBoxPathData.Text)
                    ? Application.StartupPath
                    : textBoxPathData.Text;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = openFileDialog.FileName;
                        if (File.Exists(filePath))
                        {
                            string json = File.ReadAllText(filePath);
                            TestSettings settings = JsonConvert.DeserializeObject<TestSettings>(json);
                            if (settings == null)
                            {
                                MessageBox.Show("File cài đặt không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Cập nhật giao diện với các giá trị từ file
                            domainUpDownVoltageMin.Text = settings.VoltageMin.ToString("F3");
                            domainUpDownVoltageMax.Text = settings.VoltageMax.ToString("F3");
                            domainUpDownCurrentMin.Text = settings.CurrentMin.ToString("F3");
                            domainUpDownCurrentMax.Text = settings.CurrentMax.ToString("F3");
                            domainUpDownTimeTesting.Text = settings.TestTime.ToString();

                            // Lưu cài đặt vào currentSettings
                            currentSettings = settings;
                            currentConfigFilePath = filePath;
                            labelNameFileConfigTest.Text = Path.GetFileName(filePath);
                            MessageBox.Show("Đã import cài đặt thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("File không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi import cài đặt: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnBrowsePart_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Chọn thư mục lưu trữ dữ liệu";
                folderDialog.SelectedPath = textBoxPathData.Text.Trim() != "" ? textBoxPathData.Text : Application.StartupPath;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxPathData.Text = folderDialog.SelectedPath;
                    Properties.Settings.Default.StoragePath = textBoxPathData.Text;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void btnStopRecording_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPathData.Text))
            {
                MessageBox.Show("Vui lòng chọn thư mục lưu trữ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isRecording = false;
            isWaitingForQR = false; // Dừng chờ QR
            btnStartRecording.Enabled = true;
            btnStopRecording.Enabled = false;
            if (!isLogging)
            {
                try
                {
                    string filePath = Path.Combine(textBoxPathData.Text, $"log_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
                    //logFile = new StreamWriter(filePath, true);
                    isLogging = true;
                    //btnStartLogging.Text = "Dừng ghi dữ liệu";
                    MessageBox.Show("Bắt đầu ghi dữ liệu vào: " + filePath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi bắt đầu ghi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                StopLogging();
            }
        }

        private void textBoxPathData_TextChanged(object sender, EventArgs e)
        {

        }
        private bool ValidateOperatorInfo()
        {
            if (string.IsNullOrWhiteSpace(textBoxOperatingWorkes.Text))
            {
                MessageBox.Show("Vui lòng nhập tên người thực hiện test!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxOperatingWorkes.Focus();
                return false;
            }
            if (comboBoxTestingStage.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn công đoạn test!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxTestingStage.Focus();
                return false;
            }
            return true;
        }
        private void btnStartRecording_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin người test
            if (!ValidateOperatorInfo()) return;

            if (string.IsNullOrEmpty(textBoxPathData.Text))
            {
                MessageBox.Show("Vui lòng chọn thư mục lưu trữ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Directory.Exists(textBoxPathData.Text))
            {
                Directory.CreateDirectory(textBoxPathData.Text);
            }
            // Đặt đường dẫn file Excel
            excelFilePath = Path.Combine(textBoxPathData.Text, "TestResults.xlsx");

            // Nếu file chưa tồn tại, tạo file mới với tiêu đề
            if (!File.Exists(excelFilePath))
            {
                try
                {
                    using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
                    {
                        var worksheet = package.Workbook.Worksheets.Add("TestResults");
                        // Định nghĩa tiêu đề cột
                        worksheet.Cells[1, 1].Value = "ID Adapter";
                        worksheet.Cells[1, 2].Value = "Thời gian";
                        worksheet.Cells[1, 3].Value = "Kết quả";
                        worksheet.Cells[1, 4].Value = "Vmax (V)";
                        worksheet.Cells[1, 5].Value = "Vmin (V)";
                        worksheet.Cells[1, 6].Value = "Imax (mA)";
                        worksheet.Cells[1, 7].Value = "Imin (mA)";
                        worksheet.Cells[1, 8].Value = "Pmax (W)";
                        worksheet.Cells[1, 9].Value = "Pmin (W)";
                        worksheet.Cells[1, 10].Value = "Operator"; // Thêm cột Người thực hiện
                        worksheet.Cells[1, 11].Value = "Testing Stage"; // Thêm cột Công đoạn test

                        // Định dạng tiêu đề
                        using (var range = worksheet.Cells[1, 1, 1, 11])
                        {
                            range.Style.Font.Bold = true;
                            range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                            range.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }

                        package.Save();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tạo file Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // Bật trạng thái ghi dữ liệu
            isRecording = true;
            btnStartRecording.Enabled = false;
            btnStopRecording.Enabled = true;

            isWaitingForQR = true; // Bắt đầu chờ nhập QR
            currentAdapterIndex = 0; // Reset chỉ số adapter
            isReadyForNewQR = true; // Cho phép xóa ID khi có QR mới
            if (!isLogging)
            {
                try
                {
                    string filePath = Path.Combine(textBoxPathData.Text, $"log_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
                    isLogging = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi bắt đầu ghi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                StopLogging();
            }
        }
        private void StopLogging()
        {
            //if (logFile != null)
            //{
            //    logFile.Close();
            //    logFile.Dispose();
            //    logFile = null;
            //    isLogging = false;
            //    //btnStartLogging.Text = "Bắt đầu ghi dữ liệu";
            //    MessageBox.Show("Dừng ghi dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void comboBoxPortUart_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void btnStartProcessTest1_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin người test
            if (!ValidateOperatorInfo()) return;

            // Reset Min/Max trước khi test
            ResetMinMaxValues(1);
            // Kiểm tra ID Adapter
            if (string.IsNullOrWhiteSpace(textBoxIDAdapter1.Text))
            {
                MessageBox.Show("Thiếu ID của adapter 1!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra kết nối UART
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("Kết nối UART chưa được thiết lập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra thông số cài đặt
            if (!LoadAndValidateSettings())
            {
                MessageBox.Show("Thông số test không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Reset trạng thái Upload
            labelStatusOfSaveExcel1.Text = "IDLE";
            labelStatusOfSaveServer1.Text = "IDLE";
            labelStatusOfSaveExcel1.ForeColor = Color.Black;
            labelStatusOfSaveServer1.ForeColor = Color.Black;

            // Bắt đầu test
            isFirstVoltage = true;
            isFirstCurrent = true;
            StartTest(1);
        }
        private bool LoadAndValidateSettings()
        {
            return currentSettings != null &&
                   currentSettings.VoltageMin >= 0 && currentSettings.VoltageMax > currentSettings.VoltageMin &&
                   currentSettings.CurrentMin >= 0 && currentSettings.CurrentMax > currentSettings.CurrentMin &&
                   currentSettings.TestTime > 0;
        }

        private void ResetMinMaxValues(int adapterIndex)
        {
            if (adapterIndex == 1)
            {
                // Reset các giá trị Min/Max về 0
                voltageMax = 0;
                voltageMin = 0;
                currentMax = 0;
                currentMin = 0;
                powerMax = 0;
                powerMin = 0;

                // Cập nhật lên màn hình
                textBoxVoltageMax1.Text = voltageMax.ToString("F3");
                textBoxVoltageMin1.Text = voltageMin.ToString("F3");
                textBoxCurrentMax1.Text = currentMax.ToString("F3");
                textBoxCurrentMin1.Text = currentMin.ToString("F3");
                textBoxPowerMax1.Text = powerMax.ToString("F3");
                textBoxPowerMin1.Text = powerMin.ToString("F3");

                // Đặt lại màu chữ về mặc định (Black)
                textBoxVoltageMax1.ForeColor = Color.Black;
                textBoxVoltageMin1.ForeColor = Color.Black;
                textBoxCurrentMax1.ForeColor = Color.Black;
                textBoxCurrentMin1.ForeColor = Color.Black;
                textBoxPowerMax1.ForeColor = Color.Black;
                textBoxPowerMin1.ForeColor = Color.Black;
            }
            if (adapterIndex == 2)
            {
                // Reset các giá trị Min/Max về 0
                voltageMax2 = 0;
                voltageMin2 = 0;
                currentMax2 = 0;
                currentMin2 = 0;
                powerMax2 = 0;
                powerMin2 = 0;

                // Cập nhật lên màn hình
                textBoxVoltageMax2.Text = voltageMax2.ToString("F3");
                textBoxVoltageMin2.Text = voltageMin2.ToString("F3");
                textBoxCurrentMax2.Text = currentMax2.ToString("F3");
                textBoxCurrentMin2.Text = currentMin2.ToString("F3");
                textBoxPowerMax2.Text = powerMax2.ToString("F3");
                textBoxPowerMin2.Text = powerMin2.ToString("F3");

                // Đặt lại màu chữ về mặc định (Black)
                textBoxVoltageMax2.ForeColor = Color.Black;
                textBoxVoltageMin2.ForeColor = Color.Black;
                textBoxCurrentMax2.ForeColor = Color.Black;
                textBoxCurrentMin2.ForeColor = Color.Black;
                textBoxPowerMax2.ForeColor = Color.Black;
                textBoxPowerMin2.ForeColor = Color.Black;
            }
            if (adapterIndex == 3)
            {
                // Reset các giá trị Min/Max về 0
                voltageMax3 = 0;
                voltageMin3 = 0;
                currentMax3 = 0;
                currentMin3 = 0;
                powerMax3 = 0;
                powerMin3 = 0;

                // Cập nhật lên màn hình
                textBoxVoltageMax3.Text = voltageMax3.ToString("F3");
                textBoxVoltageMin3.Text = voltageMin3.ToString("F3");
                textBoxCurrentMax3.Text = currentMax3.ToString("F3");
                textBoxCurrentMin3.Text = currentMin3.ToString("F3");
                textBoxPowerMax3.Text = powerMax3.ToString("F3");
                textBoxPowerMin3.Text = powerMin3.ToString("F3");

                // Đặt lại màu chữ về mặc định (Black)
                textBoxVoltageMax3.ForeColor = Color.Black;
                textBoxVoltageMin3.ForeColor = Color.Black;
                textBoxCurrentMax3.ForeColor = Color.Black;
                textBoxCurrentMin3.ForeColor = Color.Black;
                textBoxPowerMax3.ForeColor = Color.Black;
                textBoxPowerMin3.ForeColor = Color.Black;
            }
        }
        private void StartTest(int adapterIndex)
        {
            if (adapterIndex == 1)
            {
                isTesting1 = true;
                testProgress1 = 0;
                progressBarTest1.Value = 0;
                progressBarTest1.Maximum = currentSettings.TestTime; // Đơn vị giây
                labelTestControlStatus1.Text = "TESTING";
                labelTestControlStatus1.ForeColor = Color.Blue;
                testTimer1.Start();
            }
            else if (adapterIndex == 2)
            {
                isTesting2 = true;
                testProgress2 = 0;
                progressBarTest2.Value = 0;
                progressBarTest2.Maximum = currentSettings.TestTime; // Đơn vị giây
                labelTestControlStatus2.Text = "TESTING";
                labelTestControlStatus2.ForeColor = Color.Blue;
                testTimer2.Start();
            }
            else if (adapterIndex == 3)
            {
                isTesting3 = true;
                testProgress3 = 0;
                progressBarTest3.Value = 0;
                progressBarTest3.Maximum = currentSettings.TestTime; // Đơn vị giây
                labelTestControlStatus3.Text = "TESTING";
                labelTestControlStatus3.ForeColor = Color.Blue;
                testTimer3.Start();
            }
        }
        private async void TestTimer1_Tick(object sender, EventArgs e)
        {
            if (isTesting1)
            {
                testProgress1++;
                progressBarTest1.Value = Math.Min(testProgress1, currentSettings.TestTime);

                // Kiểm tra kết thúc test
                if (testProgress1 >= currentSettings.TestTime)
                {
                    testTimer1.Stop();
                    isTesting1 = false;
                    await EvaluateTestResult(1);
                    CheckAllTestsCompleted();
                    return;
                }
            }
        }
        private async void TestTimer2_Tick(object sender, EventArgs e)
        {
            if (isTesting2)
            {
                testProgress2++;
                progressBarTest2.Value = Math.Min(testProgress2, currentSettings.TestTime);

                // Kiểm tra kết thúc test
                if (testProgress2 >= currentSettings.TestTime)
                {
                    testTimer2.Stop();
                    isTesting2 = false;
                    await EvaluateTestResult(2);
                    CheckAllTestsCompleted();
                    return;
                }
            }
        }
        private async void TestTimer3_Tick(object sender, EventArgs e)
        {
            if (isTesting3)
            {
                testProgress3++;
                progressBarTest3.Value = Math.Min(testProgress3, currentSettings.TestTime);

                // Kiểm tra kết thúc test
                if (testProgress3 >= currentSettings.TestTime)
                {
                    testTimer3.Stop();
                    isTesting3 = false;
                    await EvaluateTestResult(3);
                    CheckAllTestsCompleted();
                    return;
                }
            }
        }
        //private void CheckAllTestsCompleted()
        //{
        //    // Kiểm tra nếu tất cả adapter được chọn đã hoàn tất
        //    bool allTestsDone = true;
        //    if (checkBoxTestAdapter1.Checked && isTesting1) allTestsDone = false;
        //    if (checkBoxTestAdapter2.Checked && isTesting2) allTestsDone = false;
        //    if (checkBoxTestAdapter3.Checked && isTesting3) allTestsDone = false;

        //    if (allTestsDone && isRecording)
        //    {
        //        // Reset để nhập QR mới
        //        currentAdapterIndex = 0;
        //        isWaitingForQR = true;
        //        ClearAdapterIDs();
        //    }
        //}
        private void CheckAllTestsCompleted()
        {
            // Kiểm tra nếu tất cả adapter được chọn đã hoàn tất
            bool allTestsDone = true;
            if (checkBoxTestAdapter1.Checked && isTesting1) allTestsDone = false;
            if (checkBoxTestAdapter2.Checked && isTesting2) allTestsDone = false;
            if (checkBoxTestAdapter3.Checked && isTesting3) allTestsDone = false;

            if (allTestsDone && isRecording)
            {
                isWaitingForQR = true;
                isReadyForNewQR = true; // Cho phép xóa ID khi có QR mới
                currentAdapterIndex = 0;
            }
        }
        private async Task EvaluateTestResult(int adapterIndex)
        {
            if (adapterIndex == 1)
            {
                bool isPass = true;

                // So sánh với thông số cài đặt
                if (voltageMax > currentSettings.VoltageMax || voltageMin < currentSettings.VoltageMin)
                {
                    textBoxVoltageMax1.ForeColor = (voltageMax > currentSettings.VoltageMax) ? Color.Red : textBoxVoltageMax1.ForeColor;
                    textBoxVoltageMin1.ForeColor = (voltageMin < currentSettings.VoltageMin) ? Color.Red : textBoxVoltageMin1.ForeColor;
                    isPass = false;
                }
                else
                {
                    textBoxVoltageMax1.ForeColor = Color.Black;
                    textBoxVoltageMin1.ForeColor = Color.Black;
                }

                if (currentMax > currentSettings.CurrentMax || currentMin < currentSettings.CurrentMin)
                {
                    textBoxCurrentMax1.ForeColor = (currentMax > currentSettings.CurrentMax) ? Color.Red : textBoxCurrentMax1.ForeColor;
                    textBoxCurrentMin1.ForeColor = (currentMin < currentSettings.CurrentMin) ? Color.Red : textBoxCurrentMin1.ForeColor;
                    isPass = false;
                }
                else
                {
                    textBoxCurrentMax1.ForeColor = Color.Black;
                    textBoxCurrentMin1.ForeColor = Color.Black;
                }

                // Tính powerMax và powerMin dựa trên voltage và current
                powerMax = voltageMax * currentMax / 1000; // Giả sử đơn vị
                powerMin = voltageMin * currentMin / 1000;
                textBoxPowerMax1.Text = powerMax.ToString("F3") + " W";
                textBoxPowerMin1.Text = powerMin.ToString("F3") + " W";

                // Cập nhật trạng thái
                labelTestControlStatus1.Text = isPass ? "PASS" : "FAIL";
                labelTestControlStatus1.ForeColor = isPass ? Color.Green : Color.Red;
                await SaveTestResultToExcel(1);
            }
            else if (adapterIndex == 2)
            {
                bool isPass = true;

                // So sánh với thông số cài đặt
                if (voltageMax2 > currentSettings.VoltageMax || voltageMin2 < currentSettings.VoltageMin)
                {
                    textBoxVoltageMax2.ForeColor = (voltageMax2 > currentSettings.VoltageMax) ? Color.Red : textBoxVoltageMax2.ForeColor;
                    textBoxVoltageMin2.ForeColor = (voltageMin2 < currentSettings.VoltageMin) ? Color.Red : textBoxVoltageMin2.ForeColor;
                    isPass = false;
                }
                else
                {
                    textBoxVoltageMax2.ForeColor = Color.Black;
                    textBoxVoltageMin2.ForeColor = Color.Black;
                }

                if (currentMax2 > currentSettings.CurrentMax || currentMin2 < currentSettings.CurrentMin)
                {
                    textBoxCurrentMax2.ForeColor = (currentMax2 > currentSettings.CurrentMax) ? Color.Red : textBoxCurrentMax2.ForeColor;
                    textBoxCurrentMin2.ForeColor = (currentMin2 < currentSettings.CurrentMin) ? Color.Red : textBoxCurrentMin2.ForeColor;
                    isPass = false;
                }
                else
                {
                    textBoxCurrentMax2.ForeColor = Color.Black;
                    textBoxCurrentMin2.ForeColor = Color.Black;
                }

                // Tính powerMax và powerMin dựa trên voltage và current
                powerMax2 = voltageMax2 * currentMax2 / 1000; // Giả sử đơn vị
                powerMin2 = voltageMin2 * currentMin2 / 1000;
                textBoxPowerMax2.Text = powerMax2.ToString("F3") + " W";
                textBoxPowerMin2.Text = powerMin2.ToString("F3") + " W";

                // Cập nhật trạng thái
                labelTestControlStatus2.Text = isPass ? "PASS" : "FAIL";
                labelTestControlStatus2.ForeColor = isPass ? Color.Green : Color.Red;
                await SaveTestResultToExcel(2);
            }
            else if (adapterIndex == 3)
            {
                bool isPass = true;

                // So sánh với thông số cài đặt
                if (voltageMax3 > currentSettings.VoltageMax || voltageMin3 < currentSettings.VoltageMin)
                {
                    textBoxVoltageMax3.ForeColor = (voltageMax3 > currentSettings.VoltageMax) ? Color.Red : textBoxVoltageMax3.ForeColor;
                    textBoxVoltageMin3.ForeColor = (voltageMin3 < currentSettings.VoltageMin) ? Color.Red : textBoxVoltageMin3.ForeColor;
                    isPass = false;
                }
                else
                {
                    textBoxVoltageMax3.ForeColor = Color.Black;
                    textBoxVoltageMin3.ForeColor = Color.Black;
                }

                if (currentMax3 > currentSettings.CurrentMax || currentMin3 < currentSettings.CurrentMin)
                {
                    textBoxCurrentMax3.ForeColor = (currentMax3 > currentSettings.CurrentMax) ? Color.Red : textBoxCurrentMax3.ForeColor;
                    textBoxCurrentMin3.ForeColor = (currentMin3 < currentSettings.CurrentMin) ? Color.Red : textBoxCurrentMin3.ForeColor;
                    isPass = false;
                }
                else
                {
                    textBoxCurrentMax3.ForeColor = Color.Black;
                    textBoxCurrentMin3.ForeColor = Color.Black;
                }

                // Tính powerMax và powerMin dựa trên voltage và current
                powerMax3 = voltageMax3 * currentMax3 / 1000; // Giả sử đơn vị
                powerMin3 = voltageMin3 * currentMin3 / 1000;
                textBoxPowerMax3.Text = powerMax3.ToString("F3") + " W";
                textBoxPowerMin3.Text = powerMin3.ToString("F3") + " W";

                // Cập nhật trạng thái
                labelTestControlStatus3.Text = isPass ? "PASS" : "FAIL";
                labelTestControlStatus3.ForeColor = isPass ? Color.Green : Color.Red;
                await SaveTestResultToExcel(3);
            }
        }

        private void btnRestartProcessTest1_Click(object sender, EventArgs e)
        {
            if (isTesting1)
            {
                testTimer1.Stop();
            }
            btnStartProcessTest1_Click(sender, e); // Gọi lại logic bắt đầu
        }

        private void btnStopProcessTest1_Click(object sender, EventArgs e)
        {
            testTimer1.Stop();
            isTesting1 = false;
            labelTestControlStatus1.Text = "IDLE";
            labelTestControlStatus1.ForeColor = Color.Black;
            labelStatusOfSaveExcel1.Text = "IDLE";
            labelStatusOfSaveServer1.Text = "IDLE";
            labelStatusOfSaveExcel1.ForeColor = Color.Black;
            labelStatusOfSaveServer1.ForeColor = Color.Black;
        }

        private void btnStartProcessTest2_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin người test
            if (!ValidateOperatorInfo()) return;

            // Reset Min/Max trước khi test
            ResetMinMaxValues(2);
            // Kiểm tra ID Adapter
            if (string.IsNullOrWhiteSpace(textBoxIDAdapter2.Text))
            {
                MessageBox.Show("Thiếu ID của adapter 2!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra kết nối UART
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("Kết nối UART chưa được thiết lập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra thông số cài đặt
            if (!LoadAndValidateSettings())
            {
                MessageBox.Show("Thông số test không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Bắt đầu test
            isFirstVoltage2 = true;
            isFirstCurrent2 = true;
            StartTest(2);
            labelStatusOfSaveExcel2.Text = "IDLE";
            labelStatusOfSaveServer2.Text = "IDLE";
            labelStatusOfSaveExcel2.ForeColor = Color.Black;
            labelStatusOfSaveServer2.ForeColor = Color.Black;
        }

        private void btnRestartProcessTest2_Click(object sender, EventArgs e)
        {
            if (isTesting2)
            {
                testTimer2.Stop();
            }
            btnStartProcessTest2_Click(sender, e); // Gọi lại logic bắt đầu
        }

        private void btnStopProcessTest2_Click(object sender, EventArgs e)
        {
            testTimer2.Stop();
            isTesting2 = false;
            labelTestControlStatus2.Text = "IDLE";
            labelTestControlStatus2.ForeColor = Color.Black;
            labelStatusOfSaveExcel2.Text = "IDLE";
            labelStatusOfSaveServer2.Text = "IDLE";
            labelStatusOfSaveExcel2.ForeColor = Color.Black;
            labelStatusOfSaveServer2.ForeColor = Color.Black;
        }

        private void btnStartProcessTest3_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin người test
            if (!ValidateOperatorInfo()) return;

            // Reset Min/Max trước khi test
            ResetMinMaxValues(3);
            // Kiểm tra ID Adapter
            if (string.IsNullOrWhiteSpace(textBoxIDAdapter3.Text))
            {
                MessageBox.Show("Thiếu ID của adapter 3!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra kết nối UART
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("Kết nối UART chưa được thiết lập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra thông số cài đặt
            if (!LoadAndValidateSettings())
            {
                MessageBox.Show("Thông số test không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Bắt đầu test
            isFirstVoltage3 = true;
            isFirstCurrent3 = true;
            StartTest(3);
            labelStatusOfSaveExcel3.Text = "IDLE";
            labelStatusOfSaveServer3.Text = "IDLE";
            labelStatusOfSaveExcel3.ForeColor = Color.Black;
            labelStatusOfSaveServer3.ForeColor = Color.Black;
        }

        private void btnRestartProcessTest3_Click(object sender, EventArgs e)
        {
            if (isTesting3)
            {
                testTimer3.Stop();
            }
            btnStartProcessTest3_Click(sender, e); // Gọi lại logic bắt đầu
        }

        private void btnStopProcessTest3_Click(object sender, EventArgs e)
        {
            testTimer3.Stop();
            isTesting3 = false;
            labelTestControlStatus3.Text = "IDLE";
            labelTestControlStatus3.ForeColor = Color.Black;
            labelStatusOfSaveExcel3.Text = "IDLE";
            labelStatusOfSaveServer3.Text = "IDLE";
            labelStatusOfSaveExcel3.ForeColor = Color.Black;
            labelStatusOfSaveServer3.ForeColor = Color.Black;
        }
        private async Task SendTestResultToServer(int adapterIndex)
        {
            if (!checkBoxUpdateToLark.Checked)
            {
                this.Invoke((Action)(() =>
                {
                    // MessageBox.Show($"Gửi dữ liệu API bị tắt cho adapter {adapterIndex}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
                return;
            }

            if (adapterIndex == 1)
            {
                labelStatusOfSaveServer1.Text = "UPLOADING";
                labelStatusOfSaveServer1.ForeColor = Color.Blue;
            }
            else if (adapterIndex == 2)
            {
                labelStatusOfSaveServer2.Text = "UPLOADING";
                labelStatusOfSaveServer2.ForeColor = Color.Blue;
            }
            else if (adapterIndex == 3)
            {
                labelStatusOfSaveServer3.Text = "UPLOADING";
                labelStatusOfSaveServer3.ForeColor = Color.Blue;
            }

            try
            {
                string apiUrl = API_Lark.Text.Trim();
                if (string.IsNullOrEmpty(apiUrl))
                {
                    MessageBox.Show("Chưa cấu hình URL API trong API_Lark!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (adapterIndex == 1)
                    {
                        labelStatusOfSaveServer1.Text = "ERROR";
                        labelStatusOfSaveServer1.ForeColor = Color.Red;
                    }
                    else if (adapterIndex == 2)
                    {
                        labelStatusOfSaveServer2.Text = "ERROR";
                        labelStatusOfSaveServer2.ForeColor = Color.Red;
                    }
                    else if (adapterIndex == 3)
                    {
                        labelStatusOfSaveServer3.Text = "ERROR";
                        labelStatusOfSaveServer3.ForeColor = Color.Red;
                    }
                    return;
                }

                TestResult testResult = new TestResult
                {
                    ID_Adapter = adapterIndex == 1 ? textBoxIDAdapter1.Text :
                                 adapterIndex == 2 ? textBoxIDAdapter2.Text : textBoxIDAdapter3.Text,
                    Thời_gian = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Kết_quả = adapterIndex == 1 ? labelTestControlStatus1.Text :
                              adapterIndex == 2 ? labelTestControlStatus2.Text : labelTestControlStatus3.Text,
                    Vmax_V = adapterIndex == 1 ? voltageMax : adapterIndex == 2 ? voltageMax2 : voltageMax3,
                    Vmin_V = adapterIndex == 1 ? voltageMin : adapterIndex == 2 ? voltageMin2 : voltageMin3,
                    Imax_mA = adapterIndex == 1 ? currentMax : adapterIndex == 2 ? currentMax2 : currentMax3,
                    Imin_mA = adapterIndex == 1 ? currentMin : adapterIndex == 2 ? currentMin2 : currentMin3,
                    Pmax_W = adapterIndex == 1 ? powerMax : adapterIndex == 2 ? powerMax2 : powerMax3,
                    Pmin_W = adapterIndex == 1 ? powerMin : adapterIndex == 2 ? powerMin2 : powerMin3,
                    Operator = textBoxOperatingWorkes.Text,
                    TestingStage = comboBoxTestingStage.SelectedItem?.ToString() ?? "Unknown"
                };

                string jsonData = JsonConvert.SerializeObject(testResult, Formatting.Indented);

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = TimeSpan.FromSeconds(10); // Timeout 10 giây

                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    int maxRetries = 3;
                    for (int i = 0; i < maxRetries; i++)
                    {
                        try
                        {
                            HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                            if (response.IsSuccessStatusCode)
                            {
                                this.Invoke((Action)(() =>
                                {
                                    if (adapterIndex == 1)
                                    {
                                        labelStatusOfSaveServer1.Text = "FINISH";
                                        labelStatusOfSaveServer1.ForeColor = Color.Green;
                                    }
                                    else if (adapterIndex == 2)
                                    {
                                        labelStatusOfSaveServer2.Text = "FINISH";
                                        labelStatusOfSaveServer2.ForeColor = Color.Green;
                                    }
                                    else if (adapterIndex == 3)
                                    {
                                        labelStatusOfSaveServer3.Text = "FINISH";
                                        labelStatusOfSaveServer3.ForeColor = Color.Green;
                                    }
                                }));
                                return;
                            }
                            else
                            {
                                string error = await response.Content.ReadAsStringAsync();
                                this.Invoke((Action)(() =>
                                {
                                    if (adapterIndex == 1)
                                    {
                                        labelStatusOfSaveServer1.Text = "ERROR";
                                        labelStatusOfSaveServer1.ForeColor = Color.Red;
                                    }
                                    else if (adapterIndex == 2)
                                    {
                                        labelStatusOfSaveServer2.Text = "ERROR";
                                        labelStatusOfSaveServer2.ForeColor = Color.Red;
                                    }
                                    else if (adapterIndex == 3)
                                    {
                                        labelStatusOfSaveServer3.Text = "ERROR";
                                        labelStatusOfSaveServer3.ForeColor = Color.Red;
                                    }
                                }));
                                if (i < maxRetries - 1)
                                    await Task.Delay(1000); // Chờ 1 giây trước khi thử lại
                            }
                        }
                        catch (HttpRequestException ex)
                        {
                            if (i == maxRetries - 1)
                            {
                                SaveFailedRequest(jsonData);
                                this.Invoke((Action)(() =>
                                {
                                    if (adapterIndex == 1)
                                    {
                                        labelStatusOfSaveServer1.Text = "ERROR";
                                        labelStatusOfSaveServer1.ForeColor = Color.Red;
                                    }
                                    else if (adapterIndex == 2)
                                    {
                                        labelStatusOfSaveServer2.Text = "ERROR";
                                        labelStatusOfSaveServer2.ForeColor = Color.Red;
                                    }
                                    else if (adapterIndex == 3)
                                    {
                                        labelStatusOfSaveServer3.Text = "ERROR";
                                        labelStatusOfSaveServer3.ForeColor = Color.Red;
                                    }
                                }));
                            }
                            else
                            {
                                await Task.Delay(1000); // Chờ trước khi thử lại
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SaveFailedRequest(JsonConvert.SerializeObject(new TestResult
                {
                    ID_Adapter = adapterIndex == 1 ? textBoxIDAdapter1.Text :
                                 adapterIndex == 2 ? textBoxIDAdapter2.Text : textBoxIDAdapter3.Text,
                    Thời_gian = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Kết_quả = adapterIndex == 1 ? labelTestControlStatus1.Text :
                              adapterIndex == 2 ? labelTestControlStatus2.Text : labelTestControlStatus3.Text,
                    Vmax_V = adapterIndex == 1 ? voltageMax : adapterIndex == 2 ? voltageMax2 : voltageMax3,
                    Vmin_V = adapterIndex == 1 ? voltageMin : adapterIndex == 2 ? voltageMin2 : voltageMin3,
                    Imax_mA = adapterIndex == 1 ? currentMax : adapterIndex == 2 ? currentMax2 : currentMax3,
                    Imin_mA = adapterIndex == 1 ? currentMin : adapterIndex == 2 ? currentMin2 : currentMin3,
                    Pmax_W = adapterIndex == 1 ? powerMax : adapterIndex == 2 ? powerMax2 : powerMax3,
                    Pmin_W = adapterIndex == 1 ? powerMin : adapterIndex == 2 ? powerMin2 : powerMin3,
                    Operator = textBoxOperatingWorkes.Text,
                    TestingStage = comboBoxTestingStage.SelectedItem?.ToString() ?? "Unknown"
                }, Formatting.Indented));
                this.Invoke((Action)(() =>
                {
                    if (adapterIndex == 1)
                    {
                        labelStatusOfSaveServer1.Text = "ERROR";
                        labelStatusOfSaveServer1.ForeColor = Color.Red;
                    }
                    else if (adapterIndex == 2)
                    {
                        labelStatusOfSaveServer2.Text = "ERROR";
                        labelStatusOfSaveServer2.ForeColor = Color.Red;
                    }
                    else if (adapterIndex == 3)
                    {
                        labelStatusOfSaveServer3.Text = "ERROR";
                        labelStatusOfSaveServer3.ForeColor = Color.Red;
                    }
                }));
            }
        }
        private void SaveFailedRequest(string jsonData)
        {
            try
            {
                string failedRequestsPath = Path.Combine(Application.StartupPath, "failed_requests.json");
                List<string> failedRequests = new List<string>();
                if (File.Exists(failedRequestsPath))
                {
                    string existingData = File.ReadAllText(failedRequestsPath);
                    if (!string.IsNullOrWhiteSpace(existingData))
                    {
                        failedRequests = JsonConvert.DeserializeObject<List<string>>(existingData) ?? new List<string>();
                    }
                }
                failedRequests.Add(jsonData);
                File.WriteAllText(failedRequestsPath, JsonConvert.SerializeObject(failedRequests, Formatting.Indented));
            }
            catch (Exception ex)
            {
                this.Invoke((Action)(() =>
                {
                    MessageBox.Show($"Lỗi khi lưu yêu cầu thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }

        private async Task RetryFailedRequestsForAdapter(int adapterIndex, string adapterId)
        {
            if (!checkBoxUpdateToLark.Checked)
            {
                MessageBox.Show($"Gửi dữ liệu API bị tắt cho adapter {adapterIndex}!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(adapterId))
            {
                MessageBox.Show($"ID adapter {adapterIndex} trống!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string failedRequestsPath = Path.Combine(Application.StartupPath, "failed_requests.json");
            if (!File.Exists(failedRequestsPath))
            {
                MessageBox.Show($"Không có lần gửi thất bại nào cho adapter {adapterIndex}!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string apiUrl = API_Lark.Text.Trim();
                if (string.IsNullOrEmpty(apiUrl))
                {
                    MessageBox.Show("Chưa cấu hình URL API trong API_Lark!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Đọc danh sách yêu cầu thất bại
                string existingData = File.ReadAllText(failedRequestsPath);
                List<string> failedRequests = JsonConvert.DeserializeObject<List<string>>(existingData) ?? new List<string>();
                if (failedRequests.Count == 0)
                {
                    MessageBox.Show($"Không có yêu cầu thất bại nào cho adapter {adapterIndex}!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.Timeout = TimeSpan.FromSeconds(10);

                    List<string> successfulRequests = new List<string>();
                    foreach (string jsonData in failedRequests)
                    {
                        try
                        {
                            TestResult result = JsonConvert.DeserializeObject<TestResult>(jsonData);
                            if (result.ID_Adapter == adapterId)
                            {
                                StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
                                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                                if (response.IsSuccessStatusCode)
                                {
                                    this.Invoke((Action)(() =>
                                    {
                                        MessageBox.Show($"Gửi lại dữ liệu cho adapter {adapterIndex} (ID: {adapterId}) thành công!",
                                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }));
                                    successfulRequests.Add(jsonData);
                                }
                                else
                                {
                                    string error = await response.Content.ReadAsStringAsync();
                                    this.Invoke((Action)(() =>
                                    {
                                        MessageBox.Show($"Lỗi khi gửi lại cho adapter {adapterIndex}: {response.StatusCode} - {error}",
                                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }));
                                }
                            }
                        }
                        catch (HttpRequestException ex)
                        {
                            this.Invoke((Action)(() =>
                            {
                                MessageBox.Show($"Lỗi khi gửi lại cho adapter {adapterIndex}: {ex.Message}",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }));
                        }
                    }

                    // Cập nhật file: xóa các yêu cầu đã gửi thành công
                    failedRequests.RemoveAll(req => successfulRequests.Contains(req));
                    File.WriteAllText(failedRequestsPath, JsonConvert.SerializeObject(failedRequests, Formatting.Indented));
                }
            }
            catch (Exception ex)
            {
                this.Invoke((Action)(() =>
                {
                    MessageBox.Show($"Lỗi khi gửi lại yêu cầu cho adapter {adapterIndex}: {ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
        }
        private async Task SaveTestResultToExcel(int adapterIndex)
        {
            // Chỉ ghi nếu đang ở trạng thái ghi dữ liệu
            if (!isRecording)
                return;

            if (adapterIndex == 1)
            {
                labelStatusOfSaveExcel1.Text = "UPLOADING";
                labelStatusOfSaveExcel1.ForeColor = Color.Blue;
            }
            else if (adapterIndex == 2)
            {
                labelStatusOfSaveExcel2.Text = "UPLOADING";
                labelStatusOfSaveExcel2.ForeColor = Color.Blue;
            }
            else if (adapterIndex == 3)
            {
                labelStatusOfSaveExcel3.Text = "UPLOADING";
                labelStatusOfSaveExcel3.ForeColor = Color.Blue;
            }

            try
            {
                // Đảm bảo file tồn tại
                if (!File.Exists(excelFilePath))
                {
                    MessageBox.Show("File Excel không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                // Mở file Excel hiện có
                using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
                {
                    var worksheet = package.Workbook.Worksheets["TestResults"];
                    if (worksheet == null)
                    {
                        MessageBox.Show("Worksheet không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Tìm dòng tiếp theo để ghi (bỏ qua dòng tiêu đề)
                    int row = worksheet.Dimension?.Rows + 1 ?? 2;

                    // Ghi dữ liệu cho Adapter
                    if (adapterIndex == 1)
                    {
                        worksheet.Cells[row, 1].Value = textBoxIDAdapter1.Text;
                        worksheet.Cells[row, 2].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        worksheet.Cells[row, 3].Value = labelTestControlStatus1.Text;
                        worksheet.Cells[row, 4].Value = voltageMax.ToString("F3");
                        worksheet.Cells[row, 5].Value = voltageMin.ToString("F3");
                        worksheet.Cells[row, 6].Value = currentMax.ToString("F3");
                        worksheet.Cells[row, 7].Value = currentMin.ToString("F3");
                        worksheet.Cells[row, 8].Value = powerMax.ToString("F3");
                        worksheet.Cells[row, 9].Value = powerMin.ToString("F3");
                        worksheet.Cells[row, 10].Value = textBoxOperatingWorkes.Text;
                        worksheet.Cells[row, 11].Value = comboBoxTestingStage.SelectedItem?.ToString() ?? "Unknown";
                        labelStatusOfSaveExcel1.Text = "FINISH";
                        labelStatusOfSaveExcel1.ForeColor = Color.Green;
                    }
                    else if (adapterIndex == 2)
                    {
                        worksheet.Cells[row, 1].Value = textBoxIDAdapter2.Text;
                        worksheet.Cells[row, 2].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        worksheet.Cells[row, 3].Value = labelTestControlStatus2.Text;
                        worksheet.Cells[row, 4].Value = voltageMax2.ToString("F3");
                        worksheet.Cells[row, 5].Value = voltageMin2.ToString("F3");
                        worksheet.Cells[row, 6].Value = currentMax2.ToString("F3");
                        worksheet.Cells[row, 7].Value = currentMin2.ToString("F3");
                        worksheet.Cells[row, 8].Value = powerMax2.ToString("F3");
                        worksheet.Cells[row, 9].Value = powerMin2.ToString("F3");
                        worksheet.Cells[row, 10].Value = textBoxOperatingWorkes.Text;
                        worksheet.Cells[row, 11].Value = comboBoxTestingStage.SelectedItem?.ToString() ?? "Unknown";
                        labelStatusOfSaveExcel2.Text = "FINISH";
                        labelStatusOfSaveExcel2.ForeColor = Color.Green;
                    }
                    else if (adapterIndex == 3)
                    {
                        worksheet.Cells[row, 1].Value = textBoxIDAdapter3.Text;
                        worksheet.Cells[row, 2].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        worksheet.Cells[row, 3].Value = labelTestControlStatus3.Text;
                        worksheet.Cells[row, 4].Value = voltageMax3.ToString("F3");
                        worksheet.Cells[row, 5].Value = voltageMin3.ToString("F3");
                        worksheet.Cells[row, 6].Value = currentMax3.ToString("F3");
                        worksheet.Cells[row, 7].Value = currentMin3.ToString("F3");
                        worksheet.Cells[row, 8].Value = powerMax3.ToString("F3");
                        worksheet.Cells[row, 9].Value = powerMin3.ToString("F3");
                        worksheet.Cells[row, 10].Value = textBoxOperatingWorkes.Text;
                        worksheet.Cells[row, 11].Value = comboBoxTestingStage.SelectedItem?.ToString() ?? "Unknown";
                        labelStatusOfSaveExcel3.Text = "FINISH";
                        labelStatusOfSaveExcel3.ForeColor = Color.Green;
                    }

                    // Lưu file
                    package.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi ghi dữ liệu vào file Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (adapterIndex == 1)
                {
                    labelStatusOfSaveExcel1.Text = "ERROR";
                    labelStatusOfSaveExcel1.ForeColor = Color.Red;
                }
                else if (adapterIndex == 2)
                {
                    labelStatusOfSaveExcel2.Text = "ERROR";
                    labelStatusOfSaveExcel2.ForeColor = Color.Red;
                }
                else if (adapterIndex == 3)
                {
                    labelStatusOfSaveExcel3.Text = "ERROR";
                    labelStatusOfSaveExcel3.ForeColor = Color.Red;
                }
            }

            // Gửi dữ liệu lên server
            await SendTestResultToServer(adapterIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("Kết nối UART chưa được thiết lập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                byte[] packet = new byte[] { 0x4C, 0x4D, 0x03, 0x01, 0x00, 0x00 };
                serialPort1.Write(packet, 0, packet.Length);
                MessageBox.Show("Quá trình calib bắt đầu, hãy chờ 5s trước khi lắp tải để quá trình calib hoàn tất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Quá trình calib lỗi, xin hãy thử lại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStartProcessTestAll_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin người test
            if (!ValidateOperatorInfo()) return;

            // Kiểm tra kết nối UART
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("Kết nối UART chưa được thiết lập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra thông số cài đặt
            if (!LoadAndValidateSettings())
            {
                MessageBox.Show("Thông số test không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool anyAdapterSelected = false;

            // Kiểm tra và bắt đầu test cho Adapter 1 nếu được chọn
            if (checkBoxTestAdapter1.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBoxIDAdapter1.Text))
                {
                    MessageBox.Show("Thiếu ID của adapter 1!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ResetMinMaxValues(1);
                isFirstVoltage = true;
                isFirstCurrent = true;
                StartTest(1);
                labelStatusOfSaveExcel1.Text = "IDLE";
                labelStatusOfSaveServer1.Text = "IDLE";
                labelStatusOfSaveExcel1.ForeColor = Color.Black;
                labelStatusOfSaveServer1.ForeColor = Color.Black;
                anyAdapterSelected = true;
            }

            // Kiểm tra và bắt đầu test cho Adapter 2 nếu được chọn
            if (checkBoxTestAdapter2.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBoxIDAdapter2.Text))
                {
                    MessageBox.Show("Thiếu ID của adapter 2!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ResetMinMaxValues(2);
                isFirstVoltage2 = true;
                isFirstCurrent2 = true;
                StartTest(2);
                labelStatusOfSaveExcel2.Text = "IDLE";
                labelStatusOfSaveServer2.Text = "IDLE";
                labelStatusOfSaveExcel2.ForeColor = Color.Black;
                labelStatusOfSaveServer2.ForeColor = Color.Black;
                anyAdapterSelected = true;
            }

            // Kiểm tra và bắt đầu test cho Adapter 3 nếu được chọn
            if (checkBoxTestAdapter3.Checked)
            {
                if (string.IsNullOrWhiteSpace(textBoxIDAdapter3.Text))
                {
                    MessageBox.Show("Thiếu ID của adapter 3!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ResetMinMaxValues(3);
                isFirstVoltage3 = true;
                isFirstCurrent3 = true;
                StartTest(3);
                labelStatusOfSaveExcel3.Text = "IDLE";
                labelStatusOfSaveServer3.Text = "IDLE";
                labelStatusOfSaveExcel3.ForeColor = Color.Black;
                labelStatusOfSaveServer3.ForeColor = Color.Black;
                anyAdapterSelected = true;
            }

            if (!anyAdapterSelected)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một adapter để test!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestartProcessTestAll_Click(object sender, EventArgs e)
        {
            // Dừng các test đang chạy cho các adapter được chọn
            if (checkBoxTestAdapter1.Checked && isTesting1)
            {
                testTimer1.Stop();
            }
            if (checkBoxTestAdapter2.Checked && isTesting2)
            {
                testTimer2.Stop();
            }
            if (checkBoxTestAdapter3.Checked && isTesting3)
            {
                testTimer3.Stop();
            }

            // Gọi lại logic Start All
            btnStartProcessTestAll_Click(sender, e);
        }

        private void btnStopProcessTestAll_Click(object sender, EventArgs e)
        {
            bool anyAdapterSelected = false;

            // Dừng test cho Adapter 1 nếu được chọn
            if (checkBoxTestAdapter1.Checked)
            {
                testTimer1.Stop();
                isTesting1 = false;
                labelTestControlStatus1.Text = "IDLE";
                labelTestControlStatus1.ForeColor = Color.Black;
                anyAdapterSelected = true;

                labelStatusOfSaveExcel1.Text = "IDLE";
                labelStatusOfSaveServer1.Text = "IDLE";
                labelStatusOfSaveExcel1.ForeColor = Color.Black;
                labelStatusOfSaveServer1.ForeColor = Color.Black;
            }

            // Dừng test cho Adapter 2 nếu được chọn
            if (checkBoxTestAdapter2.Checked)
            {
                testTimer2.Stop();
                isTesting2 = false;
                labelTestControlStatus2.Text = "IDLE";
                labelTestControlStatus2.ForeColor = Color.Black;
                anyAdapterSelected = true;

                labelStatusOfSaveExcel2.Text = "IDLE";
                labelStatusOfSaveServer2.Text = "IDLE";
                labelStatusOfSaveExcel2.ForeColor = Color.Black;
                labelStatusOfSaveServer2.ForeColor = Color.Black;
            }

            // Dừng test cho Adapter 3 nếu được chọn
            if (checkBoxTestAdapter3.Checked)
            {
                testTimer3.Stop();
                isTesting3 = false;
                labelTestControlStatus3.Text = "IDLE";
                labelTestControlStatus3.ForeColor = Color.Black;
                anyAdapterSelected = true;
                labelStatusOfSaveExcel3.Text = "IDLE";
                labelStatusOfSaveServer3.Text = "IDLE";
                labelStatusOfSaveExcel3.ForeColor = Color.Black;
                labelStatusOfSaveServer3.ForeColor = Color.Black;
            }

            // Kiểm tra nếu không có adapter nào được chọn
            if (!anyAdapterSelected)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một adapter để dừng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkBoxTestAdapter1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxTestAdapter2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxTestAdapter3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void labelNameFileConfigTest_Click(object sender, EventArgs e)
        {

        }

        private void API_Lark_TextChanged(object sender, EventArgs e)
        {

            // Kiểm tra URL hợp lệ
            bool isValidUrl = Uri.TryCreate(API_Lark.Text.Trim(), UriKind.Absolute, out Uri uriResult)
                              && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            // Cập nhật trạng thái checkbox
            checkBoxUpdateToLark.Enabled = isValidUrl;
            if (!isValidUrl)
            {
                checkBoxUpdateToLark.Checked = false; // Bỏ chọn nếu URL không hợp lệ
            }
            Properties.Settings.Default.APILark = API_Lark.Text.Trim();
            Properties.Settings.Default.Save();
        }

        private void label69_Click(object sender, EventArgs e)
        {

        }

        private async void buttonRetrySaveData1_Click(object sender, EventArgs e)
        {
            await RetryFailedRequestsForAdapter(1, textBoxIDAdapter1.Text);
        }

        private async void buttonRetrySaveData2_Click(object sender, EventArgs e)
        {
            await RetryFailedRequestsForAdapter(2, textBoxIDAdapter2.Text);
        }

        private async void buttonRetrySaveData3_Click(object sender, EventArgs e)
        {
            await RetryFailedRequestsForAdapter(2, textBoxIDAdapter2.Text);
        }
    }
}
