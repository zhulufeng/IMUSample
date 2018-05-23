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
        clsIMUCalidata IMUCalidata = new clsIMUCalidata();
        public Form1()
        {
            InitializeComponent();
            updateText = new UpdateDataEventHandler(showData);
            IMUData.TotalCounter = 0;
            IMUCalidata.GyroBias[0, 0] = 0.0063196;
            IMUCalidata.GyroBias[1, 0] = -0.00094812;
            IMUCalidata.GyroBias[2, 0] = 0.005944;


            IMUCalidata.GyroSF[0, 0] = 16384.56164;
            IMUCalidata.GyroSF[1, 0] = 16383.94156;
            IMUCalidata.GyroSF[2, 0] = 16383.93189;

            IMUCalidata.GyroMA[0,0] = 0.99994;
            IMUCalidata.GyroMA[0,1] = 3.69558e-5;
            IMUCalidata.GyroMA[0,2] = -0.000148733;

            IMUCalidata.GyroMA[1,0] = -3.50962e-5;
            IMUCalidata.GyroMA[1,1] = 1.0;
            IMUCalidata.GyroMA[1,2] = -1.99538e-5;

            IMUCalidata.GyroMA[2,0] = 0.000146702;
            IMUCalidata.GyroMA[2,1] = 8.84173e-6;
            IMUCalidata.GyroMA[2,2] = 0.99994;

            IMUCalidata.AccBias[0, 0] = 0.000229842;
            IMUCalidata.AccBias[1, 0] = 0.000316162;
            IMUCalidata.AccBias[2, 0] = -0.000265416;

            IMUCalidata.AccSF[0, 0] = 130984.6548;
            IMUCalidata.AccSF[1, 0] = 131099.1861;
            IMUCalidata.AccSF[2, 0] = 131111.8942;


            IMUCalidata.AccMA[0,0] = 0.99998;
            IMUCalidata.AccMA[0,1] = 0.000020976;
            IMUCalidata.AccMA[0,2] = -0.00086581;


            IMUCalidata.AccMA[1,0] = -0.00019498;
            IMUCalidata.AccMA[1,1] = 1.0;
            IMUCalidata.AccMA[1,2] = -0.000170978;


            IMUCalidata.AccMA[2,0] = 0.00020762;
            IMUCalidata.AccMA[2,1] = 0.000400105;
            IMUCalidata.AccMA[2,2] = 0.99998;
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
            int CheckSumA = 0;
            int CheckSumB = 0;
            while (serialData.buffer.Count >= 42)
            {
                //Int32 index = 0;
                //Byte ch = 
                if (serialData.buffer[0] == 0xA5 && serialData.buffer[10] == 0x00 && serialData.buffer[20] == 0x00 && serialData.buffer[27] == 0x00 && serialData.buffer[34] == 0x00)
                {
                    CheckSumA = 0;
                    CheckSumB = 0;
                    for (int i = 0;i <= 37;i++)
                    {
                        CheckSumA = CheckSumA + serialData.buffer[i];
                    }
                    CheckSumB = (serialData.buffer[41]) + (serialData.buffer[40] * 256) + (serialData.buffer[39] * 256 * 256) + (serialData.buffer[38] * 256 * 256 * 256);
                   // MessageBox.Show("CheckSumA is :" + CheckSumA.ToString() + "\nCheckSumB is :" + CheckSumB.ToString());
                    if (CheckSumA == CheckSumB)
                    {
                        serialData.buffer.CopyTo(0,IMUData.arrayOriginData, 0, 42);
                        IMUData.TotalCounter++;
                        for (int i = 0; i < 3; i++)
                        {
                            IMUData.intFogData[i] = (IMUData.arrayOriginData[3 * i + 1]  * 256 * 256 * 256 + IMUData.arrayOriginData[3 * i + 2] * 256 * 256 + IMUData.arrayOriginData[3 * i + 3] * 256) / 256;
                            IMUData.intAccData[i] = (IMUData.arrayOriginData[3 * i + 11] * 256 * 256 * 256 + IMUData.arrayOriginData[3 * i + 12] * 256 * 256 + IMUData.arrayOriginData[3 * i + 13] * 256) / 256;
                            IMUData.intFogTmp[i]  = (IMUData.arrayOriginData[2 * i + 21] * 256 * 256 * 256 + IMUData.arrayOriginData[2 * i + 22] * 256 * 256) / 256 / 256;
                            IMUData.intAccTmp[i]  = (IMUData.arrayOriginData[2 * i + 28] * 256 * 256 * 256 + IMUData.arrayOriginData[2 * i + 29] * 256 * 256) / 256 / 256;
                            IMUData.doubleFogData[i] = Convert.ToDouble(IMUData.intFogData[i]) / 1.0;
                            IMUData.doubleAccData[i] = Convert.ToDouble(IMUData.intAccData[i]) / 1.0;
                            IMUData.doubleFogTmp[i] = Convert.ToDouble(IMUData.intFogTmp[i]) / 256.0;
                            IMUData.doubleAccTmp[i] = Convert.ToDouble(IMUData.intAccTmp[i]) / 256.0;
                        }
                        IMUData.Counter = IMUData.arrayOriginData[35];
                        IMUData.Timer_cyc = IMUData.arrayOriginData[36] * 256 + IMUData.arrayOriginData[37];
                        IMUData.arrayIMUdata[0] = IMUData.Counter;
                        for (int i = 0; i < 3; i++)
                        {
                            IMUData.arrayIMUdata[1 + i] = IMUData.doubleFogData[i];
                            IMUData.arrayIMUdata[4 + i] = IMUData.doubleAccData[i];
                            IMUData.arrayIMUdata[7 + i] = IMUData.doubleFogTmp[i];
                            IMUData.arrayIMUdata[10 + i] = IMUData.doubleAccTmp[i];
                        }
                        IMUData.arrayIMUdata[13] = IMUData.Counter;
                        IMUData.arrayIMUdata[14] = IMUData.Timer_cyc;
                        saveData();
                        if (IMUData.TotalCounter % 1000 == 0)
                        {
                            this.Invoke(updateText);
                        }
                        serialData.buffer.RemoveRange(0, 42);

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
                try
                {
                    intDataSW.Write(IMUData.arrayOriginData[i].ToString("X2") + "\t");
                }
                catch (System.Exception ex)
                {
                    return;
                }
                
            }
            intDataSW.Write("\r\n");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0:0000.000}",(Convert.ToDouble(IMUData.TotalCounter)) / 200.0);
           for (int i = 1;i <= 6;i++)
           {
                if (IMUData.arrayIMUdata[i] >= 0)
                {
                    sb.AppendFormat("\t{0,8:######0} ", IMUData.arrayIMUdata[i]);
                }
                else
                {
                    sb.AppendFormat("\t{0,8:######0} ", IMUData.arrayIMUdata[i]);
                }
            }
            for (int i = 7; i <= 12; i++)
            {
                if (IMUData.arrayIMUdata[i] >= 0)
                {
                    sb.AppendFormat("\t{0,7:####.#0} ", IMUData.arrayIMUdata[i]);
                }
                else
                {
                    sb.AppendFormat("\t{0:7:####.#0} ", IMUData.arrayIMUdata[i]);
                }
            }
            sb.AppendFormat("\t{0:000} ", IMUData.arrayIMUdata[13]);
            sb.AppendFormat("\t{0:0000} ", IMUData.arrayIMUdata[14]);
            try
            {
                doubleDataSW.WriteLine(sb.ToString());
            }
            catch (System.Exception e)
            {
                return;
            }
            
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

        private void Btn_Smooth_Click(object sender, EventArgs e)
        {
            double smoothdata = Convert.ToDouble(tBox_Smoothdata.Text);
            StreamWriter SW_ConfigFile = new StreamWriter(PathString.IMUDataCurrentDirectory + @"\"+ "imuDataDouble" + tBox_Smoothdata.Text + "Smoothed.txt");
            StreamWriter SW_BCFile = new StreamWriter(PathString.IMUDataCurrentDirectory + @"\" + "imuDataDouble" + tBox_Smoothdata.Text + "Correctrd.txt");
            StreamReader SR_File = new StreamReader(PathString.IMUDataCurrentDirectory + @"\" + "imuDataDouble.txt");
            StringBuilder sb = new StringBuilder();
            StringBuilder sbdata = new StringBuilder();
            string dataLineIMU;//一行字符串
            string[] dataSplitIMU;//分割后字符串数组
            double[] dataIMU = new double[19];//浮点数组
            char[] rnSplitChar = new char[] { '\r', '\n' };//分割符号
            char[] trnSplitChar = new char[] { '\r', '\n', '\t', ' ' };
            double[] imudata = new double[12];
            double[] sumimudata = new double[12];
            double[] aveimudata = new double[12];
            Matrix AccPulse = new Matrix(3, 1);
            Matrix Accdata = new Matrix(3, 1);
            Matrix GyroPulse = new Matrix(3, 1);
            Matrix Gyrodata = new Matrix(3, 1);
            int count = 0;
            while (!SR_File.EndOfStream)
            {
                count++;
                dataLineIMU = SR_File.ReadLine();//读取一行
                dataSplitIMU = dataLineIMU.Split(trnSplitChar, StringSplitOptions.RemoveEmptyEntries);//开始分割
                for (int j = 0; j < dataSplitIMU.Length; j++)//赋值给一个浮点数组
                {
                    dataIMU[j] = Convert.ToDouble(dataSplitIMU[j]);
                }
                for (int i = 0; i < 12; i++)
                {
                    imudata[i] = dataIMU[i + 1];
                    //imudata[i + 3] = dataIMU[i + 4];
                }
                for (int i = 0; i < 12; i++)
                {
                    sumimudata[i] = sumimudata[i] + imudata[i];
                }
                if (count % Convert.ToInt32(smoothdata) == 0)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        aveimudata[i] = sumimudata[i] / smoothdata;
                        sumimudata[i] = 0;
                    }
                    for (int i = 0;i < 3;i++)
                    {
                        AccPulse[i, 0] = aveimudata[i + 3];
                        GyroPulse[i, 0] = aveimudata[i + 0];
                    }
                    Accdata = IMUCalidata.AccMA.Multiply(AccPulse.MtxDivid(IMUCalidata.AccSF) - IMUCalidata.AccBias).Multiply(9.8);
                    Gyrodata = IMUCalidata.GyroMA.Multiply(GyroPulse.MtxDivid(IMUCalidata.GyroSF) - IMUCalidata.GyroBias).Multiply(Math.PI/180.0);
                    sb.AppendFormat("{0,8:0000.000}\t", Convert.ToDouble(count) * 0.01);
                    for (int j = 0; j < 6; j++)
                    {
                        sb.AppendFormat("{0,9:######0.0} ", aveimudata[j]);
                    }
                    for (int j = 6; j < 12; j++)
                    {
                        sb.AppendFormat("{0,8:###0.##0} ", aveimudata[j]);
                    }
                    SW_ConfigFile.WriteLine(sb.ToString());
                    sb.Clear();
                    sbdata.AppendFormat("{0,8:0000.000}\t", Convert.ToDouble(count) * 0.01);
                    for (int j = 0; j < 3; j++)
                    {
                        sbdata.AppendFormat("{0,12:##0.#######0} ", Accdata[j,0]);
                    }
                    for (int j = 0; j < 3; j++)
                    {
                        sbdata.AppendFormat("{0,12:##0.#######0} ", Gyrodata[j,0]);
                    }
                    SW_BCFile.WriteLine(sbdata.ToString());
                    sbdata.Clear();
                }

            }
            SW_ConfigFile.Close();
            SR_File.Close();
            SW_BCFile.Close();
            MessageBox.Show("IMUdata!\nThe Number of Line is:" + count.ToString());

        }
    }
}
