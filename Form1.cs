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
        public Form1()
        {
            InitializeComponent();
            updateText = new UpdateDataEventHandler(showData);
            IMUData.TotalCounter = 0;
            //MessageBox.Show(System.AppDomain.CurrentDomain.BaseDirectory);

           // MessageBox.Show(DateTime.Now.ToString("yyyyMMdd-HHmmss"));
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
                MessageBox.Show("Hello!");
            }
            else if (Btn_OpenSerial.Text == "打开串口...")
            {
                Btn_OpenSerial.Text = "关闭串口...";
                serialPort.Open();
            }
            else
            {
                Btn_OpenSerial.Text = "再次打开串口...";
                intDataSW.Close();
                doubleDataSW.Close();
                serialPort.Close();
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
            while (serialData.buffer.Count >= 16)
            {
                //Int32 index = 0;
                //Byte ch = 
                if (serialData.buffer[0] == 0x80)
                {
                    CheckSumA = 0;
                    CheckSumB = 0;
                    for (int i = 1;i <= 14;i++)
                    {
                        CheckSumA = CheckSumA + serialData.buffer[i];
                    }
                    CheckSumB = serialData.buffer[16];
                   // MessageBox.Show("CheckSumA is :" + CheckSumA.ToString() + "\nCheckSumB is :" + CheckSumB.ToString());
                    if ((CheckSumA & 0x7F) == CheckSumB) 
                    {
                        serialData.buffer.CopyTo(0,IMUData.arrayOriginData, 0, 16);
                        IMUData.TotalCounter++;
                        for (int i = 0; i < 3; i++)
                        {
                            IMUData.intFogData[i] = (Convert.ToInt32(IMUData.arrayOriginData[4 * i + 1]) * 128 * 128 * 128 * 16 + Convert.ToInt32(IMUData.arrayOriginData[4 * i + 2])  * 128 * 128 * 16
                                                            + Convert.ToInt32(IMUData.arrayOriginData[4 * i + 3]) * 128 * 16 + Convert.ToInt32(IMUData.arrayOriginData[4 * i + 4])*16) / 16;
                            //IMUData.intAccData[i] = (Convert.ToInt32(IMUData.arrayOriginData[4 * i + 19]) * 128 * 128 * 128 + Convert.ToInt32(IMUData.arrayOriginData[4 * i + 18]) * 128 * 128
                            //                                + Convert.ToInt32(IMUData.arrayOriginData[4 * i + 17]) * 128 + Convert.ToInt32(IMUData.arrayOriginData[4 * i + 16]));
                            IMUData.intFogTmp[0]  = (IMUData.arrayOriginData[13] * 128 * 128 * 128 * 16 + IMUData.arrayOriginData[14] * 128 * 128 * 16) / (128 * 128 * 16);
                            //IMUData.intAccTmp[i]  = (IMUData.arrayOriginData[2 * i + 35] * 256 * 256 * 256 + IMUData.arrayOriginData[2 * i + 34] * 256 * 256) / 256 / 256;
                            IMUData.doubleFogData[i] = Convert.ToDouble(IMUData.intFogData[i]) / 1.0;
                            //IMUData.doubleAccData[i] = Convert.ToDouble(IMUData.intAccData[i]) / 1.0;
                            IMUData.doubleFogTmp[i] = Convert.ToDouble(IMUData.intFogTmp[i]) / 16.0;
                            IMUData.doubleAccTmp[i] = Convert.ToDouble(IMUData.intAccTmp[i]) / 16.0;
                        }
                        IMUData.Counter = IMUData.arrayOriginData[2];
                        //IMUData.Timer_cyc = IMUData.arrayOriginData[36] * 256 + IMUData.arrayOriginData[37];
                        IMUData.arrayIMUdata[0] = IMUData.Counter;
                        for (int i = 0; i < 3; i++)
                        {
                            IMUData.arrayIMUdata[1  + i]  = IMUData.doubleFogData[i];
                            IMUData.arrayIMUdata[4  + i]  = IMUData.doubleAccData[i];
                            IMUData.arrayIMUdata[7  + i]  = IMUData.doubleFogTmp[i];
                            IMUData.arrayIMUdata[10 + i] = IMUData.doubleAccTmp[i];
                        }
                        IMUData.arrayIMUdata[13] = IMUData.Counter;
                        IMUData.arrayIMUdata[14] = IMUData.Timer_cyc;
                        saveData();
                        if (IMUData.TotalCounter % 200 == 0)
                        {
                            this.Invoke(updateText);
                        }
                        serialData.buffer.RemoveRange(0, 16);

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
            sb.AppendFormat("{0:0000.000}",(Convert.ToDouble(IMUData.TotalCounter)) / 1000.0);
           for (int i = 1;i <= 12;i++)
           {
                if (IMUData.arrayIMUdata[i] >= 0)
                {
                    sb.AppendFormat("\t{0: 0.0000000e+000} ", IMUData.arrayIMUdata[i]);
                }
                else
                {
                    sb.AppendFormat("\t{0:0.0000000e+000} ", IMUData.arrayIMUdata[i]);
                }
            }
            sb.AppendFormat("\t{0:000} ", IMUData.arrayIMUdata[13]);
            sb.AppendFormat("\t{0:0000} ", IMUData.arrayIMUdata[14]);
            doubleDataSW.WriteLine(sb.ToString());
            sb.Clear();
        }
        private void showData()
        {
            tBox_FogX.Text = IMUData.doubleFogData[0].ToString();
            tBox_FogY.Text = IMUData.doubleFogData[1].ToString();
            tBox_FogZ.Text = IMUData.doubleFogData[2].ToString();

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

        
    }
}
