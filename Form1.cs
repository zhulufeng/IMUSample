using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace IMUSample
{
    public partial class Form1 : Form
    {
        delegate void UpdateDataEventHandler();
        UpdateDataEventHandler updateText;
        StreamWriter intDataSW = new StreamWriter(PathString.IMUDataCurrentDirectory + @"\" + "imuDataByte.txt");
        StreamWriter doubleDataSW = new StreamWriter(PathString.IMUDataCurrentDirectory + @"\" + "imuDataDouble.txt");
        System.Timers.Timer timer;
        bool Senddata_Enable;
        int SumTime;
        //定义委托
        public delegate void SetControlValue();

        public Form1()
        {
            InitializeComponent();
            updateText = new UpdateDataEventHandler(showData);
            IMUData.TotalCounter = 0;
            Senddata_Enable = false;
            SumTime = Convert.ToInt32(tBox_FogZ.Text);
            //InitTimer();
            //MessageBox.Show(System.AppDomain.CurrentDomain.BaseDirectory);

            // MessageBox.Show(DateTime.Now.ToString("yyyyMMdd-HHmmss"));
        }

        private void InitTimer()
        {
            //设置定时间隔(毫秒为单位)
            //int interval = SumTime;
            timer = new System.Timers.Timer(SumTime);
            //设置执行一次（false）还是一直执行(true)
            timer.AutoReset = true;
            //设置是否执行System.Timers.Timer.Elapsed事件
            timer.Enabled = true;
            //绑定Elapsed事件
            timer.Elapsed += new System.Timers.ElapsedEventHandler(TimerUp);
        }

        /// <summary>
        /// Timer类执行定时到点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerUp(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                //currentCount += 1;
                this.Invoke(new SetControlValue(senddata));
            }
            catch (Exception ex)
            {
                MessageBox.Show("执行定时到点事件失败:" + ex.Message);
            }
        }
        private void senddata()
        {
            byte [] data = new byte[1];
            data[0] = 0x00;
            if (serialPort.IsOpen && Senddata_Enable)
            {
                serialPort.Write(data, 0, 1);
            }
            
        }
        private void Btn_OpenSerial_Click(object sender, EventArgs e)
        {

            if (Btn_OpenSerial.Text == "再次打开串口...")
            {
                Btn_OpenSerial.Text = "关闭串口...";
                
                String dt = DateTime.Now.ToString("yyyyMMdd-HHmmss");
                PathString.IMUDataCurrentDirectory = PathString.IMUDataBaseDirectory + @"\" + "imudata" + dt;
                if (!Directory.Exists(PathString.IMUDataBaseDirectory))
                {
                    Directory.CreateDirectory(PathString.IMUDataBaseDirectory);
                    Directory.CreateDirectory(PathString.IMUDataCurrentDirectory);
                }
                else
                {
                    Directory.CreateDirectory(PathString.IMUDataCurrentDirectory);
                }
                intDataSW = new StreamWriter(PathString.IMUDataCurrentDirectory + @"\" + "imuDataByte.txt");
                doubleDataSW = new StreamWriter(PathString.IMUDataCurrentDirectory + @"\" + "imuDataDouble.txt");
                serialPort.Open();
                IMUData.TotalCounter = 0;
                IMUData.Avedata = 0;
                SumTime = Convert.ToInt32(tBox_FogZ.Text);
                InitTimer();
                MessageBox.Show("Hello!");
            }
            else if (Btn_OpenSerial.Text == "打开串口...")
            {
                Btn_OpenSerial.Text = "关闭串口...";
                IMUData.TotalCounter = 0;
                IMUData.Avedata = 0;
                SumTime = Convert.ToInt32(tBox_FogZ.Text);
                InitTimer();
                serialPort.Open();
            }
            else
            {
                Btn_OpenSerial.Text = "再次打开串口...";
                intDataSW.Close();
                doubleDataSW.Close();
                serialPort.Close();
                timer.Stop();
                timer.Enabled = false;
                timer.Dispose();
            }
           
        }

 


        private void MenuItem_SerialCfg_Click(object sender, EventArgs e)
        {
            FrmSerialCfg serialCfgDlg = new FrmSerialCfg();
            if (serialCfgDlg.ShowDialog() != DialogResult.Cancel)
            {
                InfoBox.Text = "串口号：" + serialParameter.comName + "\r\n";
                InfoBox.Text += "波特率：" + serialParameter.baudRate + "\r\n";
                InfoBox.Text += "数据位：" + serialParameter.dataBit + "\r\n";
                InfoBox.Text += "停止位：" + serialParameter.stopBit + "\r\n";
                InfoBox.Text += "校验位：" + serialParameter.parityBit + "\r\n";

                serialPort.PortName = serialParameter.comName;
                serialPort.BaudRate = int.Parse(serialParameter.baudRate);
                serialPort.DataBits = Convert.ToInt32(serialParameter.dataBit);
                switch (serialParameter.stopBit)
                {
                    case "1":
                        serialPort.StopBits = StopBits.One;
                        break;
                    case "1.5":
                        serialPort.StopBits = StopBits.OnePointFive;
                        break;
                    case "2":
                        serialPort.StopBits = StopBits.Two;
                        break;
                    default:
                        serialPort.StopBits = StopBits.One;
                        break;
                }
                switch (serialParameter.parityBit)
                {
                    case "odd":
                        serialPort.Parity = Parity.Odd;
                        break;
                    case "even":
                        serialPort.Parity = Parity.Even;
                        break;
                    case "none":
                        serialPort.Parity = Parity.None;
                        break;
                    default:
                        serialPort.Parity = Parity.None;
                        break;
                }
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int n = serialPort.BytesToRead;
            byte[] readBuffer = new byte[n];
            byte[] buf = new byte[n];
            serialPort.Read(readBuffer, 0, n);
            serialData.buffer.AddRange(readBuffer);
            UInt32 CheckSumA = 0;
            UInt32 CheckSumB = 0;
            UInt32 CheckSumC = 0;
            UInt32 CheckSumD = 0;
            while (serialData.buffer.Count >= 10)
            {
                //Int32 index = 0;
                //Byte ch = 
                if (serialData.buffer[0] == 0x80)
                {
                    CheckSumA = 0;
                    CheckSumB = 0;
                    CheckSumC = 0;
                    CheckSumD = 0;
                    for (int i = 1;i <= 5;i++)
                    {
                        CheckSumA = CheckSumA ^ serialData.buffer[i];
                    }
                    CheckSumC = Convert.ToUInt32(serialData.buffer[7]) ^ Convert.ToUInt32(serialData.buffer[8]);
                    CheckSumB = Convert.ToUInt32(serialData.buffer[6]);
                    CheckSumD = Convert.ToUInt32(serialData.buffer[9]);

                    //MessageBox.Show("CheckSumA is :" + CheckSumA.ToString() + "\nCheckSumB is :" + CheckSumB.ToString());
                    if (CheckSumA == CheckSumB && CheckSumC == CheckSumD)
                    {
                        serialData.buffer.CopyTo(0,IMUData.arrayOriginData, 0, 10);
                        IMUData.TotalCounter++;
                        IMUData.intFogData[0] = (IMUData.arrayOriginData[1] + IMUData.arrayOriginData[2] * 128 + IMUData.arrayOriginData[3] * 128 * 128
                            + IMUData.arrayOriginData[4] * 128 * 128 * 128 + IMUData.arrayOriginData[5] * 128 * 128 * 128 * 128);
                        IMUData.intFogTmp[0] = IMUData.arrayOriginData[7] + IMUData.arrayOriginData[8] * 128;
                        IMUData.doubleFogTmp[0] = Convert.ToDouble(IMUData.intFogTmp[0]) / 16.0;
                        //                         for (int i = 0; i < 3; i++)
                        //                         {
                        //                             IMUData.intFogData[i] = (IMUData.arrayOriginData[3 * i + 1]  * 256 * 256 * 256 + IMUData.arrayOriginData[3 * i + 2] * 256 * 256 + IMUData.arrayOriginData[3 * i + 3] * 256) / 256;
                        //                             IMUData.intAccData[i] = (IMUData.arrayOriginData[3 * i + 11] * 256 * 256 * 256 + IMUData.arrayOriginData[3 * i + 12] * 256 * 256 + IMUData.arrayOriginData[3 * i + 13] * 256) / 256;
                        //                             IMUData.intFogTmp[i]  = (IMUData.arrayOriginData[2 * i + 21] * 256 * 256 * 256 + IMUData.arrayOriginData[2 * i + 22] * 256 * 256) / 256 / 256;
                        //                             IMUData.intAccTmp[i]  = (IMUData.arrayOriginData[2 * i + 28] * 256 * 256 * 256 + IMUData.arrayOriginData[2 * i + 29] * 256 * 256) / 256 / 256;
                        //                             IMUData.doubleFogData[i] = Convert.ToDouble(IMUData.intFogData[i]) / 16384.0;
                        //                             IMUData.doubleAccData[i] = Convert.ToDouble(IMUData.intAccData[i]) / 131072.0;
                        //                             IMUData.doubleFogTmp[i] = Convert.ToDouble(IMUData.intFogTmp[i]) / 256.0;
                        //                             IMUData.doubleAccTmp[i] = Convert.ToDouble(IMUData.intAccTmp[i]) / 256.0;
                        //                         }
                        //                         IMUData.Counter = IMUData.arrayOriginData[35];
                        //                         IMUData.Timer_cyc = IMUData.arrayOriginData[36] * 256 + IMUData.arrayOriginData[37];
                        //                         IMUData.arrayIMUdata[0] = IMUData.Counter;
                        //                         for (int i = 0; i < 3; i++)
                        //                         {
                        //                             IMUData.arrayIMUdata[1 + i] = IMUData.doubleFogData[i];
                        //                             IMUData.arrayIMUdata[4 + i] = IMUData.doubleAccData[i];
                        //                             IMUData.arrayIMUdata[7 + i] = IMUData.doubleFogTmp[i];
                        //                             IMUData.arrayIMUdata[10 + i] = IMUData.doubleAccTmp[i];
                        //                         }
                        //                         IMUData.arrayIMUdata[13] = IMUData.Counter;
                        //                         IMUData.arrayIMUdata[14] = IMUData.Timer_cyc;
                        if (IMUData.TotalCounter > 1)
                        {
                            IMUData.Avedata = IMUData.Avedata / Convert.ToDouble(IMUData.TotalCounter - 1) * Convert.ToDouble(IMUData.TotalCounter - 2) +
                                Convert.ToDouble(IMUData.intFogData[0]) / Convert.ToDouble(IMUData.TotalCounter - 1);
                            saveData();
                        }
                        
                        if (IMUData.TotalCounter % (200) == 0)
                        {
                            this.Invoke(updateText);
                        }
                        serialData.buffer.RemoveRange(0, 10);

                    }
                    else
                    {
                        serialData.buffer.RemoveRange(0, 1);
                    }
                }
                else
                {
                    serialData.buffer.RemoveRange(0, 1);
                }
               
            }
        }
        private void saveData()
        {
            for (int i = 0; i < IMUData.arrayOriginData.Length; i++)
            {
                intDataSW.Write(IMUData.arrayOriginData[i].ToString("X2") + "\t");
            }
            intDataSW.Write("\r\n");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0:0000.000}",(Convert.ToDouble(IMUData.TotalCounter)) );
            sb.AppendFormat("\t{0:#####0}", IMUData.intFogData[0]);
            sb.AppendFormat("\t{0:00.000} ", IMUData.doubleFogTmp[0]);
            sb.AppendFormat("\t{0:###0} ", IMUData.intFogTmp[0]);
            doubleDataSW.WriteLine(sb.ToString());
            sb.Clear();
        }
        private void showData()
        {
            tBox_FogX.Text = IMUData.intFogData[0].ToString();
            tBox_FogY.Text = IMUData.Avedata.ToString();
           // tBox_FogZ.Text = IMUData.doubleFogData[2].ToString();

            tBox_AccX.Text = IMUData.doubleAccData[0].ToString();
            tBox_AccY.Text = IMUData.doubleAccData[1].ToString();
            tBox_AccZ.Text = IMUData.doubleAccData[2].ToString();

            tBox_FogxT.Text = IMUData.doubleFogTmp[0].ToString();
            tBox_FogyT.Text = IMUData.doubleFogTmp[1].ToString();
            tBox_FogzT.Text = IMUData.doubleFogTmp[2].ToString();

            tBox_AccxT.Text = IMUData.doubleAccTmp[0].ToString();
            tBox_AccyT.Text = IMUData.doubleAccTmp[1].ToString();
            tBox_AcczT.Text = IMUData.doubleAccTmp[2].ToString();

            tBox_Counter.Text = IMUData.TotalCounter.ToString();
            tBox_Timer.Text = IMUData.Timer_cyc.ToString();
        }

        private void MenuItem_ClearDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderBwsDlg = new FolderBrowserDialog();
            if (ConfigOperation.CheckConfig("DefaultDirectory"))
            {
                FolderBwsDlg.SelectedPath = ConfigOperation.GetConfig("DefaultDirectory");
            }
            if (FolderBwsDlg.ShowDialog() == DialogResult.OK)
            {
                PathString.ClearDirectory = FolderBwsDlg.SelectedPath.ToString();
                ConfigOperation.SetConfig("DefaultDirectory", FolderBwsDlg.SelectedPath.ToString());
            }
            DirectoryClearDlg DirClrDlg = new DirectoryClearDlg();
            
            if(DirClrDlg.ShowDialog() != DialogResult.Cancel)
            {
                
            }
        }

        private void Btn_Senddata_Click(object sender, EventArgs e)
        {
            if (Senddata_Enable == false)
            {
                Senddata_Enable = true;
                Btn_Senddata.Text = "关闭发数...";
                this.Invoke(updateText);
            } 
            else
            {
                Senddata_Enable = false;
                Btn_Senddata.Text = "开始发数...";

            }
            
        }
    }
}
