﻿using System;
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
        StreamWriter intDataSW = new StreamWriter(PathString.IMUDataCurrentDirectory + @"\" + "imuDataInt.txt");
        public Form1()
        {
            InitializeComponent();
            updateText = new UpdateDataEventHandler(showData);
            //MessageBox.Show(System.AppDomain.CurrentDomain.BaseDirectory);

           // MessageBox.Show(DateTime.Now.ToString("yyyyMMdd-HHmmss"));
        }
        StreamWriter sw = new StreamWriter("data.txt");
        private void Btn_OpenSerial_Click(object sender, EventArgs e)
        {

            if (Btn_OpenSerial.Text == "打开串口...")
            {
                Btn_OpenSerial.Text = "关闭串口...";
                serialPort.Open();
            }
            else
            {
                Btn_OpenSerial.Text = "打开串口...";
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
            while (serialData.buffer.Count >= 40)
            {
                //Int32 index = 0;
                //Byte ch = 
                if (serialData.buffer[0] == 0xEB)
                {
                    if (serialData.buffer[1] == 0x80)
                    {
                        if (serialData.buffer[2] == 0x55)
                        {
                            if (serialData.buffer[3] == 0xAA)
                            {
                                IMUData.arrayIMUdata[0] = serialData.buffer[4] + serialData.buffer[5] * 256 + serialData.buffer[6] * 256 * 256 + serialData.buffer[7] * 256 * 256 * 256;
                                IMUData.arrayIMUdata[1] = serialData.buffer[8] + serialData.buffer[9] * 256 + serialData.buffer[10] * 256 * 256 + serialData.buffer[11] * 256 * 256 * 256;
                                IMUData.arrayIMUdata[2] = serialData.buffer[12] + serialData.buffer[13] * 256 + serialData.buffer[14] * 256 * 256 + serialData.buffer[15] * 256 * 256 * 256;
                                IMUData.arrayIMUdata[3] = serialData.buffer[17] + serialData.buffer[16] * 256;
                                IMUData.arrayIMUdata[4] = serialData.buffer[18];
                                IMUData.arrayIMUdata[5] = serialData.buffer[19];
                                IMUData.arrayIMUdata[6] = serialData.buffer[20] + serialData.buffer[21] * 256 + serialData.buffer[22] * 256 * 256 + serialData.buffer[23] * 256 * 256 * 256;

                                IMUData.arrayIMUdata[7] = serialData.buffer[24] + serialData.buffer[25] * 256 + serialData.buffer[26] * 256 * 256 + serialData.buffer[27] * 256 * 256 * 256;
                                IMUData.arrayIMUdata[8] = serialData.buffer[28] + serialData.buffer[29] * 256 + serialData.buffer[30] * 256 * 256 + serialData.buffer[31] * 256 * 256 * 256;
                                IMUData.arrayIMUdata[9] = serialData.buffer[32] + serialData.buffer[33] * 256 + serialData.buffer[34] * 256 * 256 + serialData.buffer[35] * 256 * 256 * 256;
                                IMUData.arrayIMUdata[10] = serialData.buffer[36] + serialData.buffer[37] * 256 + serialData.buffer[38] * 256 * 256 + serialData.buffer[39] * 256 * 256 * 256;
                                serialData.index++;
                                saveData();
                                serialData.buffer.RemoveRange(0, 40);
                                if (serialData.index >= 1000)
                                {
                                    //this.backgroundWorker1.RunWorkerAsync();
                                    this.Invoke(updateText);
                                    serialData.index = 0;
                                }

                            }
                            else
                            {
                                serialData.buffer.RemoveRange(0, 4);
                            }
                        }
                        else
                        {
                            serialData.buffer.RemoveRange(0, 3);
                        }
                    }
                    else
                    {
                        serialData.buffer.RemoveRange(0, 2);
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
            for (int i = 0; i < 11; i++)
            {
                sw.Write(IMUData.arrayIMUdata[i].ToString() + "\t");
            }
            sw.Write("\r\n");
        }
        private void showData()
        {
            ;
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
