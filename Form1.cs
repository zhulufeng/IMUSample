using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Runtime.InteropServices;


namespace IMUSample
{
    public partial class Form1 : Form
    {
        delegate void UpdateDataEventHandler();
        UpdateDataEventHandler updateText;
        UpdateDataEventHandler updateInfoText;
        StreamWriter intDataSW ;
        StreamWriter doubleDataSW;//= new StreamWriter(PathString.IMUDataCurrentDirectory + @"\" + "imuDataDouble.txt");
        TimePara timePara = new TimePara();
        bool[] zoomed_flag = new bool[6];
        IMUData INSdata = new IMUData();
        int data_legth = 56;
        //定义联合体
        [StructLayout(LayoutKind.Explicit, Size = 4)]

        public struct Union
        {
            [FieldOffset(0)]
            public Byte b0;
            [FieldOffset(1)]
            public Byte b1;
            [FieldOffset(2)]
            public Byte b2;
            [FieldOffset(3)]
            public Byte b3;
            [FieldOffset(0)]
            public Int32 i;
            [FieldOffset(0)]
            public float f;

        }
        public Form1()
        {
            InitializeComponent();
            updateText = new UpdateDataEventHandler(showData);
            updateInfoText = new UpdateDataEventHandler(UpdateInfoText);
            IntializeChart();
            AddSeries(12);
            AddChartArea(6);
            INSdata.TotalCounter = 0;
            //MessageBox.Show(System.AppDomain.CurrentDomain.BaseDirectory);
            for (int i = 0; i < 13; i++)
            {
 //               IMUData.ListIMUdata[i].
            }
            //MessageBox.Show(DateTime.Now.ToString("yyyyMMdd-HHmmss"));
        }
        public void IntializeChart()
        {
            //图标的背景色
            chart.BackColor = Color.FromArgb(255, 0, 24, 55);//Color.SkyBlue;
            //图表背景色的渐变方式
            chart.BackGradientStyle = GradientStyle.None;//GradientStyle.None;
            //图表的边框线条颜色
            chart.BorderlineColor = Color.Black;
            //图表的边框线条样式
            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            //图表边框线条宽度
            chart.BorderlineWidth = 2;
            //图表边框的皮肤
            chart.BorderSkin.SkinStyle = BorderSkinStyle.None;
            //图表边框宽度
            chart.BorderSkin.BorderWidth = 0;
        }
        public void AddChartArea(int num)
        {
            for (int i = 0; i < num; i++)
            {
                chart.ChartAreas.Add(SetChartArea(i));
            }
        }
        /*************************************
        函数名：AddSeries
        创建日期：2019/10/25
        函数功能：添加数据线
        函数参数：
        	num
        返回值：void
        *************************************/
        public void AddSeries(int num)
        {
            for (int i = 0; i < num * 2; i++)
            {
                chart.Series.Add(SetSeries(i));
                if (i % 2 == 0)
                {
                    chart.Series[i].YAxisType = AxisType.Primary;
                }
                else
                {
                    chart.Series[i].YAxisType = AxisType.Secondary;
                }
            }
        }

        /*************************************
        函数名：SetSeries
        创建日期：2019/10/25
        函数功能：设置数据线格式
        函数参数：
        	index
        返回值：System.Windows.Forms.DataVisualization.Charting.Series
        *************************************/
        public Series SetSeries(int index)
        {
            Series series = new Series();
            //Series 的类型
            series.ChartType = SeriesChartType.Line;
            if (index % 2 == 0)
            {
                series.Color = Color.FromArgb(0xff, 0x32, 0xc5, 0xe9);//设置数据曲线的颜色
            }
            else
            {
                series.Color = Color.FromArgb(0xff, 0xff, 0x9f, 0x7f);//设置温度曲线的颜色
            }
            //Series线条阴影颜色
            series.ShadowColor = Color.Green;
            //阴影宽度
            series.ShadowOffset = 0;
            //是否显示数据说明
            series.IsVisibleInLegend = false;
            //线条上数据点上是否有数据显示
            series.IsValueShownAsLabel = false;
            //线条上的数据点标志类型
            series.MarkerStyle = MarkerStyle.None;
            //线条数据点的大小
            series.MarkerSize = 2;
            //Series 的边框颜色
            series.BorderColor = Color.Tomato;
            //Series线条的宽度
            series.BorderWidth = 2;

            return series;
        }
        /*************************************
        函数名：SetChartArea
        创建日期：2019/10/19
        函数功能：设置绘图区
        函数参数：
        	index
        返回值：System.Windows.Forms.DataVisualization.Charting.ChartArea
        *************************************/
        public ChartArea SetChartArea(int index)
        {
            ChartArea chartArea = new ChartArea();

            
            switch(index)
            {
                case 0:
                    chartArea.Name = "FogX";
                    chartArea.AxisY.Title = "X轴陀螺数据";
                    break;
                case 1:
                    chartArea.Name = "FogY";
                    chartArea.AxisY.Title = "Y轴陀螺数据";
                    break;
                case 2:
                    chartArea.Name = "FogZ";
                    chartArea.AxisY.Title = "Z轴陀螺数据";
                    break;
                case 3:
                    chartArea.Name = "AccX";
                    chartArea.AxisY.Title = "X轴加表数据";
                    break;
                case 4:
                    chartArea.Name = "AccY";
                    chartArea.AxisY.Title = "Y轴加表数据";
                    break;
                case 5:
                    chartArea.Name = "AccZ";
                    chartArea.AxisY.Title = "Z轴加表数据";
                    break;
            }
            //背景色
            chartArea.BackColor = Color.FromArgb(255, 4, 33, 65);
            //背景渐变方式
            chartArea.BackGradientStyle = GradientStyle.None;
            //边框颜色
            chartArea.BorderColor = Color.FromArgb(255, 4, 33, 65);
            //边框柱线条宽度
            chartArea.BorderWidth = 2;
            //边框线条样式
            chartArea.BorderDashStyle = ChartDashStyle.Solid;
            //阴影颜色
            chartArea.ShadowColor = Color.Transparent;


            //设置X轴和Y轴线条的颜色和宽度
            chartArea.AxisX.LineColor = Color.Black;//.FromArgb(64, 64, 64, 64);//
            chartArea.AxisX.LineWidth = 1;
            chartArea.AxisY.LineColor = Color.Black;//.FromArgb(64, 64, 64, 64);//
            chartArea.AxisY.LineWidth = 1;
            //设置x轴和Y轴的标题
            chartArea.AxisX.Title = "时间";
           
            chartArea.AxisY2.Title = "温度";
            chartArea.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            chartArea.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Regular);
            chartArea.AxisY2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            chartArea.AxisX.TitleForeColor = Color.FromArgb(255, 245, 254, 252);
            chartArea.AxisY.TitleForeColor = Color.FromArgb(0xff, 0x32, 0xc5, 0xe9);
            chartArea.AxisY2.TitleForeColor = Color.FromArgb(0xff, 0xff, 0x9f, 0x7f);
            //设置图表区网格横纵线条的颜色和宽度
            chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(255, 114, 175, 207);
            chartArea.AxisX.MajorGrid.LineWidth = 1;
            chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisY.MajorGrid.LineWidth = 1;

            //启用X游标，以支持局部区域选择放大
            chartArea.CursorX.IsUserEnabled = true;
            chartArea.CursorX.IsUserSelectionEnabled = true;
            chartArea.CursorX.LineColor = Color.Pink;
            chartArea.CursorX.IntervalType = DateTimeIntervalType.Auto;
            chartArea.AxisX.ScaleView.Zoomable = false;
            chartArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;//启用X轴滚动条按钮
            chartArea.AxisY.ScaleView.Zoomable = false;

            chartArea.AxisY.LabelStyle.Format = "#########0.0";
            chartArea.AxisY2.LabelStyle.Format = "##0.0000";
            chartArea.AxisY.LabelStyle.ForeColor = Color.FromArgb(255, 146, 175, 207);
            chartArea.AxisY2.LabelStyle.ForeColor = Color.FromArgb(255, 146, 175, 207);
            chartArea.AxisX.LabelStyle.ForeColor = Color.FromArgb(255, 151, 167, 186);
            if (index >= 3)
            {
                chartArea.AxisY.LabelStyle.Format = "##0.0000000";
                chartArea.AxisY2.LabelStyle.Format = "##0.0000";
                chartArea.AxisY.LabelStyle.ForeColor = Color.FromArgb(255, 146, 175, 207);
                chartArea.AxisY2.LabelStyle.ForeColor = Color.FromArgb(255, 146, 175, 207);
                chartArea.AxisX.LabelStyle.ForeColor = Color.FromArgb(255, 151, 167, 186);
            }
            

            return chartArea;
        }

        private void DrawIMUData()
        {
            for (int index = 0; index < 6; index++)
            {
                timePara.drawIndexTime[index]++;
                if (!zoomed_flag[index])
                {
                    switch (index)
                    {
                        case 0:
                            chart.ChartAreas[index].AxisY.Maximum = (INSdata.ListFogxData_1s.Max() + 100);
                            chart.ChartAreas[index].AxisY.Minimum = (INSdata.ListFogxData_1s.Min() - 100);
                            chart.ChartAreas[index].AxisY2.Maximum = INSdata.ListTemFogxData_1s.Max() + 1;
                            chart.ChartAreas[index].AxisY2.Minimum = INSdata.ListTemFogxData_1s.Min() - 1;

                            chart.ChartAreas[index].AxisX.Interval = (INSdata.ListFogxData_1s.Count / 20 + 1);
                            chart.ChartAreas[index].AxisX.ScaleView.Size = INSdata.ListFogxData_1s.Count * 1.1;
                            chart.ChartAreas[index].AxisX.ScaleView.Position = 0.0;
                            chart.ChartAreas[index].CursorX.SelectionStart = chart.ChartAreas[index].CursorX.SelectionEnd = 0.0;
                            chart.ChartAreas[index].CursorX.Position = -1;
                            break;

                        case 1:
                            chart.ChartAreas[index].AxisY.Maximum = (INSdata.ListFogyData_1s.Max() + 100);
                            chart.ChartAreas[index].AxisY.Minimum = (INSdata.ListFogyData_1s.Min() - 100);
                            chart.ChartAreas[index].AxisY2.Maximum = INSdata.ListTemFogyData_1s.Max() + 1;
                            chart.ChartAreas[index].AxisY2.Minimum = INSdata.ListTemFogyData_1s.Min() - 1;

                            chart.ChartAreas[index].AxisX.Interval = (INSdata.ListFogyData_1s.Count / 20 + 1);
                            chart.ChartAreas[index].AxisX.ScaleView.Size = INSdata.ListFogyData_1s.Count * 1.1;
                            chart.ChartAreas[index].AxisX.ScaleView.Position = 0.0;
                            chart.ChartAreas[index].CursorX.SelectionStart = chart.ChartAreas[index].CursorX.SelectionEnd = 0.0;
                            chart.ChartAreas[index].CursorX.Position = -1;
                            break;

                        case 2:
                            chart.ChartAreas[index].AxisY.Maximum = (INSdata.ListFogzData_1s.Max() + 100);
                            chart.ChartAreas[index].AxisY.Minimum = (INSdata.ListFogzData_1s.Min() - 100);
                            chart.ChartAreas[index].AxisY2.Maximum = INSdata.ListTemFogzData_1s.Max() + 1;
                            chart.ChartAreas[index].AxisY2.Minimum = INSdata.ListTemFogzData_1s.Min() - 1;

                            chart.ChartAreas[index].AxisX.Interval = (INSdata.ListFogzData_1s.Count / 20 + 1);
                            chart.ChartAreas[index].AxisX.ScaleView.Size = INSdata.ListFogzData_1s.Count * 1.1;
                            chart.ChartAreas[index].AxisX.ScaleView.Position = 0.0;
                            chart.ChartAreas[index].CursorX.SelectionStart = chart.ChartAreas[index].CursorX.SelectionEnd = 0.0;
                            chart.ChartAreas[index].CursorX.Position = -1;
                            break;
                        case 3:
                            chart.ChartAreas[index].AxisY.Maximum = INSdata.ListAccxData_1s.Max() + 0.0001;
                            chart.ChartAreas[index].AxisY.Minimum = INSdata.ListAccxData_1s.Min() - 0.0001;
                            chart.ChartAreas[index].AxisY2.Maximum = INSdata.ListTemAccxData_1s.Max() + 1;
                            chart.ChartAreas[index].AxisY2.Minimum = INSdata.ListTemAccxData_1s.Min() - 1;

                            chart.ChartAreas[index].AxisX.Interval = (INSdata.ListAccxData_1s.Count / 20 + 1);
                            chart.ChartAreas[index].AxisX.ScaleView.Size = INSdata.ListAccxData_1s.Count * 1.1;
                            chart.ChartAreas[index].AxisX.ScaleView.Position = 0.0;
                            chart.ChartAreas[index].CursorX.SelectionStart = chart.ChartAreas[index].CursorX.SelectionEnd = 0.0;
                            chart.ChartAreas[index].CursorX.Position = -1;
                            break;

                        case 4:
                            chart.ChartAreas[index].AxisY.Maximum = INSdata.ListAccyData_1s.Max() + 0.0001;
                            chart.ChartAreas[index].AxisY.Minimum = INSdata.ListAccyData_1s.Min() - 0.0001;
                            chart.ChartAreas[index].AxisY2.Maximum = INSdata.ListTemAccyData_1s.Max() + 1;
                            chart.ChartAreas[index].AxisY2.Minimum = INSdata.ListTemAccyData_1s.Min() - 1;

                            chart.ChartAreas[index].AxisX.Interval = (INSdata.ListAccyData_1s.Count / 20 + 1);
                            chart.ChartAreas[index].AxisX.ScaleView.Size = INSdata.ListAccyData_1s.Count * 1.1;
                            chart.ChartAreas[index].AxisX.ScaleView.Position = 0.0;
                            chart.ChartAreas[index].CursorX.SelectionStart = chart.ChartAreas[index].CursorX.SelectionEnd = 0.0;
                            chart.ChartAreas[index].CursorX.Position = -1;
                            break;

                        case 5:
                            chart.ChartAreas[index].AxisY.Maximum = INSdata.ListAcczData_1s.Max() + 0.0001;
                            chart.ChartAreas[index].AxisY.Minimum = INSdata.ListAcczData_1s.Min() - 0.0001;
                            chart.ChartAreas[index].AxisY2.Maximum = INSdata.ListTemAcczData_1s.Max() + 1;
                            chart.ChartAreas[index].AxisY2.Minimum = INSdata.ListTemAcczData_1s.Min() - 1;

                            chart.ChartAreas[index].AxisX.Interval = (INSdata.ListAcczData_1s.Count / 20 + 1);
                            chart.ChartAreas[index].AxisX.ScaleView.Size = INSdata.ListAcczData_1s.Count * 1.1;
                            chart.ChartAreas[index].AxisX.ScaleView.Position = 0.0;
                            chart.ChartAreas[index].CursorX.SelectionStart = chart.ChartAreas[index].CursorX.SelectionEnd = 0.0;
                            chart.ChartAreas[index].CursorX.Position = -1;
                            break;
                        default:
                            break;
                    }
                   

                }
                chart.Series[2 * index].ChartArea = chart.ChartAreas[index].Name;
                chart.Series[2 * index + 1].ChartArea = chart.ChartAreas[index].Name;
                if (index < 3)
                {
                    chart.Series[2 * index].Points.AddXY(timePara.drawIndexTime[index], INSdata.data_1s[index + 1]);
                    chart.Series[2 * index + 1].Points.AddXY(timePara.drawIndexTime[index], INSdata.data_1s[index + 1 + 6]);
                }
                else 
                {
                    chart.Series[2 * index].Points.AddXY(timePara.drawIndexTime[index], INSdata.data_1s[index + 1]);
                    chart.Series[2 * index + 1].Points.AddXY(timePara.drawIndexTime[index], INSdata.data_1s[index + 1 + 6]);
                }
            }
        }
        private void Btn_OpenSerial_Click(object sender, EventArgs e)
        {

            if (Btn_OpenSerial.Text == "再次打开串口...")
            {
                Btn_OpenSerial.Text = "关闭串口...";
                INSdata.TotalCounter = 0;
                String dt = DateTime.Now.ToString("yyyyMMdd-HHmmss");
                PathString.IMUDataCurrentDirectory = PathString.IMUDataBaseDirectory + @"\" + serialParameter.IMU_id + "_imudata" + dt;
                if (!Directory.Exists(PathString.IMUDataBaseDirectory))
                {
                    Directory.CreateDirectory(PathString.IMUDataBaseDirectory);
                    Directory.CreateDirectory(PathString.IMUDataCurrentDirectory);
                }
                else
                {
                    Directory.CreateDirectory(PathString.IMUDataCurrentDirectory);
                }
                if (serialParameter.isSaveHex)
                {
                    intDataSW = new StreamWriter(PathString.IMUDataCurrentDirectory + @"\" + "imuDataByte.txt");
                }
               
                doubleDataSW = new StreamWriter(PathString.IMUDataCurrentDirectory + @"\" + "imuDataDouble.txt");
                for (int i = 0; i < 6; i++)
                {
                    timePara.drawIndexTime.Add(0);
                }
                AddSeries(12);
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                serialPort.Open();
                Btn_SendInitialData.Enabled = true;
//                 timePara.drawIndexTime.Clear();
//                 //chart.DataBind();
//                 for (int i = 0; i < 6; i++)
//                 {
//                     timePara.drawIndexTime.Add(0);
//                     chart.Series.Clear();
//                     INSdata.ListFogxData_1s.Clear();
//                     INSdata.ListFogyData_1s.Clear();
//                     INSdata.ListFogzData_1s.Clear();
//                     INSdata.ListAccxData_1s.Clear();
//                     INSdata.ListAccyData_1s.Clear();
//                     INSdata.ListAcczData_1s.Clear();
//                     INSdata.ListTemFogxData_1s.Clear();
//                     INSdata.ListTemFogyData_1s.Clear();
//                     INSdata.ListTemFogzData_1s.Clear();
//                     INSdata.ListTemAccxData_1s.Clear();
//                     INSdata.ListTemAccyData_1s.Clear();
//                     INSdata.ListTemAcczData_1s.Clear();
//                 }
                
                //MessageBox.Show("Hello!");
            }
            else if (Btn_OpenSerial.Text == "打开串口...")
            {
                INSdata.TotalCounter = 0;
                Btn_OpenSerial.Text = "关闭串口...";
                String dt = DateTime.Now.ToString("yyyyMMdd-HHmmss");
                PathString.IMUDataCurrentDirectory = PathString.IMUDataBaseDirectory + @"\" + serialParameter.IMU_id + "_imudata" + dt;
                if (!Directory.Exists(PathString.IMUDataBaseDirectory))
                {
                    Directory.CreateDirectory(PathString.IMUDataBaseDirectory);
                    Directory.CreateDirectory(PathString.IMUDataCurrentDirectory);
                }
                else
                {
                    Directory.CreateDirectory(PathString.IMUDataCurrentDirectory);
                }
                if (serialParameter.isSaveHex)
                {
                    intDataSW = new StreamWriter(PathString.IMUDataCurrentDirectory + @"\" + "imuDataByte.txt");
                }

                doubleDataSW = new StreamWriter(PathString.IMUDataCurrentDirectory + @"\" + "imuDataDouble.txt");
                for (int i = 0; i < 6; i++)
                {
                    timePara.drawIndexTime.Add(0);
                }
                AddSeries(12);
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                serialPort.Open();
                Btn_SendInitialData.Enabled = true;

                // AddSeries(12);
            }
            else
            {
                Btn_OpenSerial.Text = "再次打开串口...";
                timePara.drawIndexTime.Clear();
                //chart.DataBind();
//                 for (int i = 0; i < 6; i++)
//                 {
//                     timePara.drawIndexTime.Add(0);
//                     
//                 }
                chart.Series.Clear();
                INSdata.TotalCounter = 0;
                INSdata.ListFogxData_1s.Clear();
                INSdata.ListFogyData_1s.Clear();
                INSdata.ListFogzData_1s.Clear();
                INSdata.ListAccxData_1s.Clear();
                INSdata.ListAccyData_1s.Clear();
                INSdata.ListAcczData_1s.Clear();
                INSdata.ListTemFogxData_1s.Clear();
                INSdata.ListTemFogyData_1s.Clear();
                INSdata.ListTemFogzData_1s.Clear();
                INSdata.ListTemAccxData_1s.Clear();
                INSdata.ListTemAccyData_1s.Clear();
                INSdata.ListTemAcczData_1s.Clear();
                if (serialParameter.isSaveHex)
                {
                    intDataSW.Close();
                }
                doubleDataSW.Close();
                serialPort.Close();
                Btn_SendInitialData.Enabled = false;
            }
           
        }

 


        private void MenuItem_SerialCfg_Click(object sender, EventArgs e)
        {
            FrmSerialCfg serialCfgDlg = new FrmSerialCfg();
            if (serialCfgDlg.ShowDialog() != DialogResult.Cancel)
            {
                textBox_Info.Text = "串口号：" + serialParameter.comName + "\r\n";
                textBox_Info.Text += "波特率：" + serialParameter.baudRate + "\r\n";
                textBox_Info.Text += "数据位：" + serialParameter.dataBit + "\r\n";
                textBox_Info.Text += "停止位：" + serialParameter.stopBit + "\r\n";
                textBox_Info.Text += "校验位：" + serialParameter.parityBit + "\r\n";
                textBox_Info.Text += "************"  + "\r\n";
                if (serialParameter.isHighFreq)
                {
                    textBox_Info.Text += "常温静态测试，文件按采样频率保存！" + "\r\n";
                }
                else
                {
                    textBox_Info.Text += "不是常温静态测试，文件按1Hz保存！" + "\r\n";
                }
                if (serialParameter.isSaveHex)
                {
                    textBox_Info.Text += "保存16进制源码" + "\r\n";
                }
                else
                {
                    textBox_Info.Text += "不保存16进制源码" + "\r\n";
                }
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
            if (!serialPort.IsOpen)
            {
                return;
            }
            int n = serialPort.BytesToRead;
            byte[] readBuffer = new byte[n];
            byte[] buf = new byte[n];
            serialPort.Read(readBuffer, 0, n);
            serialData.buffer.AddRange(readBuffer);
            UInt32 CheckSumA = 0;
            UInt32 CheckSumB = 0;
            while ((serialData.buffer.Count >= 6 && serialData.buffer[0] == 0xEB && serialData.buffer[1] == 0x90)|| serialData.buffer.Count >= data_legth)
            {
                //Int32 index = 0;
                //Byte ch = 
                if (serialData.buffer[0] == 0xEB && serialData.buffer[1] == 0x90)
                {
                    CheckSumA = 0;
                    for (int i = 2; i < 5; i++)
                    {
                        CheckSumA = CheckSumA + serialData.buffer[i];
                    }
                    CheckSumB = serialData.buffer[5];
                    if ((CheckSumA & 0xff) == CheckSumB)
                    {
                        serialData.buffer.CopyTo(0, INSdata.arrayStatusData, 0, 6);
                        this.Invoke(updateInfoText);
                        serialData.buffer.RemoveRange(0, 6);
                    }
                    else
                    {
                        serialData.buffer.RemoveRange(0, 6);
                    }
                }
                else if (serialData.buffer[0] == 0x5A && serialData.buffer[1] == 0xA5)
                {
                    CheckSumA = 0;
                    CheckSumB = 0;
                    for (int i = 3;i < 53;i++)
                    {
                        CheckSumA = CheckSumA + serialData.buffer[i];
                    }
                    CheckSumB = serialData.buffer[54];
                   // MessageBox.Show("CheckSumA is :" + CheckSumA.ToString() + "\nCheckSumB is :" + CheckSumB.ToString());
                    if ((CheckSumA & 0xff) == CheckSumB && serialData.buffer[55] == 0x55) 
                    {
                        serialData.buffer.CopyTo(0,INSdata.arrayOriginData, 0, data_legth);
                        INSdata.TotalCounter++;
                        INSdata.nav_state = INSdata.arrayOriginData[2];
                        Union[] trdata = new Union[3];
                        for (int i = 0; i < 3; i++)
                        {
                            INSdata.intAttData[i] = Convert.ToInt32(Convert.ToInt32(INSdata.arrayOriginData[4 * i + 6]) * 256 * 256 * 256 + Convert.ToInt32(INSdata.arrayOriginData[4 * i + 5]) * 256 * 256
                                 + Convert.ToInt32(INSdata.arrayOriginData[4 * i + 4]) * 256 + Convert.ToInt32(INSdata.arrayOriginData[4 * i + 3]));


                            INSdata.intFogData[i] = (Convert.ToInt32(INSdata.arrayOriginData[4 * i + 18]) * 256 * 256 * 256 + Convert.ToInt32(INSdata.arrayOriginData[4 * i + 17])  * 256 * 256
                                                            + Convert.ToInt32(INSdata.arrayOriginData[4 * i + 16]) * 256  + Convert.ToInt32(INSdata.arrayOriginData[4 * i + 15]));


                            INSdata.intAccData[i] = (Convert.ToInt32(INSdata.arrayOriginData[4 * i + 30]) * 256 * 256 * 256 + Convert.ToInt32(INSdata.arrayOriginData[4 * i + 29]) * 256 * 256
                                                             + Convert.ToInt32(INSdata.arrayOriginData[4 * i + 28]) * 256 + Convert.ToInt32(INSdata.arrayOriginData[4 * i + 27]));


                            INSdata.intfpData[i]  = (Convert.ToInt32(INSdata.arrayOriginData[4 * i + 42]) * 256 * 256 * 256 + Convert.ToInt32(INSdata.arrayOriginData[4 * i + 41]) * 256 * 256
                                                             + Convert.ToInt32(INSdata.arrayOriginData[4 * i + 40]) * 256 + Convert.ToInt32(INSdata.arrayOriginData[4 * i + 39]));
                            INSdata.intFogTmp[i]  = (INSdata.arrayOriginData[52] * 256 * 256 * 256 + INSdata.arrayOriginData[51] * 256 * 256) / 256 / 256;
                            INSdata.intAccTmp[i]  = (INSdata.arrayOriginData[52] * 256 * 256 * 256 + INSdata.arrayOriginData[51] * 256 * 256) / 256 / 256;
                            INSdata.doubleFogData[i] = Convert.ToDouble(INSdata.intFogData[i]) / 10000.0;
                            INSdata.doubleAttData[i] = Convert.ToDouble(INSdata.intAttData[i]) / 1000.0;
                            INSdata.doubleAccData[i] = Convert.ToDouble(INSdata.intAccData[i]) / 10000.0;
                            INSdata.doublefpData[i] = Convert.ToDouble(INSdata.intAccData[i]) / 10000.0;
                            INSdata.doubleFogTmp[i] = Convert.ToDouble(INSdata.intFogTmp[i]) / 100.0;
                            INSdata.doubleAccTmp[i] = Convert.ToDouble(INSdata.intAccTmp[i]) / 100.0;
//                             trdata[i].b0 = INSdata.arrayOriginData[i * 4 + 16];
//                             trdata[i].b1 = INSdata.arrayOriginData[i * 4 + 17];
//                             trdata[i].b2 = INSdata.arrayOriginData[i * 4 + 18];
//                             trdata[i].b3 = INSdata.arrayOriginData[i * 4 + 19];
// 
// //                             trdata[i].b0 = INSdata.arrayOriginData[i * 4 + 19];
// //                             trdata[i].b1 = INSdata.arrayOriginData[i * 4 + 18];
// //                             trdata[i].b2 = INSdata.arrayOriginData[i * 4 + 17];
// //                             trdata[i].b3 = INSdata.arrayOriginData[i * 4 + 16];
//                            INSdata.floatAccData[i] = trdata[i].f;

                        }
                        

                        INSdata.Counter = INSdata.arrayOriginData[2];
                        //INSdata.Timer_cyc = INSdata.arrayOriginData[36] * 256 + INSdata.arrayOriginData[37];
                        INSdata.arrayIMUdata[0] = INSdata.Counter;
                        for (int i = 0; i < 3; i++)
                        {
                            INSdata.arrayIMUdata[1  + i]  = INSdata.doubleFogData[i];
                            INSdata.arrayIMUdata[4  + i]  = INSdata.doubleAccData[i];
                            INSdata.arrayIMUdata[7  + i]  = INSdata.doubleFogTmp[i];
                            INSdata.arrayIMUdata[10 + i]  = INSdata.doubleAccTmp[0];
                            INSdata.arrayIMUdata[13 + i]  = INSdata.doubleAttData[i];
                            INSdata.arrayIMUdata[16 + i]  = INSdata.doublefpData[i];
                        }

                        INSdata.ListFogxData.Add(INSdata.arrayIMUdata[1]);
                        INSdata.ListFogyData.Add(INSdata.arrayIMUdata[2]);
                        INSdata.ListFogzData.Add(INSdata.arrayIMUdata[3]);
                        INSdata.ListAccxData.Add(INSdata.arrayIMUdata[4]);
                        INSdata.ListAccyData.Add(INSdata.arrayIMUdata[5]);
                        INSdata.ListAcczData.Add(INSdata.arrayIMUdata[6]);

                        INSdata.ListTemFogxData.Add(INSdata.arrayIMUdata[7]);
                        INSdata.ListTemFogyData.Add(INSdata.arrayIMUdata[8]);
                        INSdata.ListTemFogzData.Add(INSdata.arrayIMUdata[9]);
                        INSdata.ListTemAccxData.Add(INSdata.arrayIMUdata[10]);
                        INSdata.ListTemAccyData.Add(INSdata.arrayIMUdata[11]);
                        INSdata.ListTemAcczData.Add(INSdata.arrayIMUdata[12]);
                        INSdata.ListAttxData.Add(INSdata.arrayIMUdata[14]);
                        INSdata.ListAttyData.Add(INSdata.arrayIMUdata[13]);
                        INSdata.ListAttzData.Add(INSdata.arrayIMUdata[15]);
                        INSdata.ListfpxData.Add(INSdata.arrayIMUdata[16]);
                        INSdata.ListfpyData.Add(INSdata.arrayIMUdata[17]);
                        INSdata.ListfpzData.Add(INSdata.arrayIMUdata[18]);
                        INSdata.arrayIMUdata[19] = INSdata.Counter;
                        INSdata.arrayIMUdata[20] = INSdata.Timer_cyc;
                        if (serialParameter.isHighFreq )
                        {
                            saveData(INSdata.arrayIMUdata);
                        }
                        
                        if (INSdata.TotalCounter % 400 == 0 && INSdata.TotalCounter > 400 )
                        {
                            INSdata.ListFogxData_1s.Add(INSdata.ListFogxData.ToArray().Average());
                            INSdata.ListFogyData_1s.Add(INSdata.ListFogyData.ToArray().Average());
                            INSdata.ListFogzData_1s.Add(INSdata.ListFogzData.ToArray().Average());

                            INSdata.data_1s[1] = INSdata.ListFogxData.ToArray().Average();
                            INSdata.data_1s[2] = INSdata.ListFogyData.ToArray().Average();
                            INSdata.data_1s[3] = INSdata.ListFogzData.ToArray().Average();

                             
                            INSdata.ListAccxData_1s.Add(INSdata.ListAccxData.ToArray().Average());
                            INSdata.ListAccyData_1s.Add(INSdata.ListAccyData.ToArray().Average());
                            INSdata.ListAcczData_1s.Add(INSdata.ListAcczData.ToArray().Average());

                            INSdata.data_1s[4] = INSdata.ListAccxData.ToArray().Average();
                            INSdata.data_1s[5] = INSdata.ListAccyData.ToArray().Average();
                            INSdata.data_1s[6] = INSdata.ListAcczData.ToArray().Average();
                            ////////////////////////温度
                            INSdata.ListTemFogxData_1s.Add(INSdata.ListTemFogxData.ToArray().Average());
                            INSdata.ListTemFogyData_1s.Add(INSdata.ListTemFogyData.ToArray().Average());
                            INSdata.ListTemFogzData_1s.Add(INSdata.ListTemFogzData.ToArray().Average());

                            INSdata.data_1s[7] = INSdata.ListTemFogxData.ToArray().Average();
                            INSdata.data_1s[8] = INSdata.ListTemFogyData.ToArray().Average();
                            INSdata.data_1s[9] = INSdata.ListTemFogzData.ToArray().Average();


                            INSdata.ListTemAccxData_1s.Add(INSdata.ListTemAccxData.ToArray().Average());
                            INSdata.ListTemAccyData_1s.Add(INSdata.ListTemAccyData.ToArray().Average());
                            INSdata.ListTemAcczData_1s.Add(INSdata.ListTemAcczData.ToArray().Average());

                            INSdata.data_1s[10] = INSdata.ListTemAccxData.ToArray().Average();
                            INSdata.data_1s[11] = INSdata.ListTemAccyData.ToArray().Average();
                            INSdata.data_1s[12] = INSdata.ListTemAcczData.ToArray().Average();

                            INSdata.data_1s[13] = INSdata.ListAttxData.ToArray().Average();
                            INSdata.data_1s[14] = INSdata.ListAttyData.ToArray().Average();
                            INSdata.data_1s[15] = INSdata.ListAttzData.ToArray().Average();

                            INSdata.data_1s[16] = INSdata.ListfpxData.ToArray().Average();
                            INSdata.data_1s[17] = INSdata.ListfpyData.ToArray().Average();
                            INSdata.data_1s[18] = INSdata.ListfpzData.ToArray().Average();

                            INSdata.data_1s[19] = INSdata.Counter;
                            INSdata.data_1s[20] = INSdata.Timer_cyc;

                            INSdata.ListFogxData.Clear();
                            INSdata.ListFogyData.Clear();
                            INSdata.ListFogzData.Clear();
                            INSdata.ListAccxData.Clear();
                            INSdata.ListAccyData.Clear();
                            INSdata.ListAcczData.Clear();
                            INSdata.ListAttxData.Clear();
                            INSdata.ListAttyData.Clear();
                            INSdata.ListAttzData.Clear();

                            INSdata.ListTemFogxData.Clear();
                            INSdata.ListTemFogyData.Clear();
                            INSdata.ListTemFogzData.Clear();
                            INSdata.ListTemAccxData.Clear();
                            INSdata.ListTemAccyData.Clear();
                            INSdata.ListTemAcczData.Clear();
                            if (!serialParameter.isHighFreq)
                            {
                                saveData(INSdata.data_1s);
                            }
                            
                            this.Invoke(updateText);
                        }
                        serialData.buffer.RemoveRange(0, data_legth);

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
        /*************************************
    函数名：CalculateStdDev
    创建日期：2019/11/02
    函数功能：计算数组标准差 std = sqrt(sum((value(i)-ave(value))^2))/(N-1)
    函数参数：value
    返回值：double 标准差结果
    *************************************/
        private double CalculateStdDev(List<double> value)
        {
            double std_data = 0.0;
            double ave_data = 0.0;
            double sum_data = 0.0;
            if (value.Count > 1)
            {
                ave_data = value.ToArray().Average();
                sum_data = value.ToArray().Sum(data => Math.Pow((data - ave_data), 2));
                std_data = Math.Sqrt(sum_data / (value.Count - 1));

            }
            return std_data;
        }
        private void saveData(double [] Datalist)
        {
            if (serialParameter.isSaveHex)
            {
                for (int i = 0; i < INSdata.arrayOriginData.Length; i++)
                {
                    intDataSW.Write(INSdata.arrayOriginData[i].ToString("X2") + "\t");
                }
                intDataSW.Write("\r\n");
            }           
           
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0:0000.000}\t",(Convert.ToDouble(INSdata.TotalCounter)) / 400.0);
            sb.Append(DateTime.Now.ToString("HH:mm:ss:fff:ffffff"));
            //sb.AppendFormat("{0:0000.000}",(Convert.ToDouble(INSdata.TotalCounter)) / 100.0);
            for (int i = 1;i <= 18;i++)
           {
                if (i >= 0 && i <= 3)
                {
                    if (Datalist[i] >= 0)
                    {
                        sb.AppendFormat("\t{0: ##0.00000000} ", Datalist[i]);
                    }
                    else
                    {
                        sb.AppendFormat("\t{0:##0.00000000} ", Datalist[i]);
                    }
                }
                if (i >= 4 && i <= 6)
                {
                    if (Datalist[i] >= 0)
                    {
                        sb.AppendFormat("\t{0: ##0.00000000} ", Datalist[i]);
                    }
                    else
                    {
                        sb.AppendFormat("\t{0:###0.00000000} ", Datalist[i]);
                    }
                }
                if (i >= 7)
                {
                    if (Datalist[i] >= 0)
                    {
                        sb.AppendFormat("\t{0: ##0.0000} ", Datalist[i]);
                    }
                    else
                    {
                        sb.AppendFormat("\t{0:###0.0000} ", Datalist[i]);
                    }
                }
                
            }
            sb.AppendFormat("\t{0:000} ", Datalist[16]);
            sb.AppendFormat("\t{0:0000} ", Datalist[17]);
            doubleDataSW.WriteLine(sb.ToString());
            sb.Clear();
        }
        private void UpdateInfoText()
        {
            if (INSdata.arrayStatusData[4] == 0x03)
            {
                textBox_Info.Text += "位置信息装订成功！" + "\r\n" + "收到的回传码是：";
            }
            if (INSdata.arrayStatusData[4] == 0x05)
            {
                textBox_Info.Text += "位置信息装订失败！" + "\r\n" + "收到的回传码是：";
            }
           
            for (int i = 0; i < 6; i++)
            {
                textBox_Info.Text += INSdata.arrayStatusData[i].ToString("X2") + " ";
            }
        }
        private void showData()
        {
            tBox_FogX.Text = INSdata.data_1s[1].ToString();
            tBox_FogY.Text = INSdata.data_1s[2].ToString();
            tBox_FogZ.Text = INSdata.data_1s[3].ToString();
            tBox_Fogx_Com.Text = (INSdata.data_1s[1]).ToString();
            tBox_Fogy_Com.Text = (INSdata.data_1s[2]).ToString();
            tBox_Fogz_Com.Text = (INSdata.data_1s[3]).ToString();

            tBox_Fogx_Std.Text = (CalculateStdDev(INSdata.ListFogxData_1s)).ToString("##0.000000");
            tBox_Fogy_Std.Text = (CalculateStdDev(INSdata.ListFogyData_1s)).ToString("##0.000000");
            tBox_Fogz_Std.Text = (CalculateStdDev(INSdata.ListFogzData_1s)).ToString("##0.000000");

            tBox_Fogx_ave.Text = (INSdata.ListFogxData_1s.ToArray().Average()).ToString("##0.000000");
            tBox_Fogy_ave.Text = (INSdata.ListFogyData_1s.ToArray().Average()).ToString("##0.000000");
            tBox_Fogz_ave.Text = (INSdata.ListFogzData_1s.ToArray().Average()).ToString("##0.000000");

            tBox_AccX.Text = INSdata.data_1s[4].ToString();
            tBox_AccY.Text = INSdata.data_1s[5].ToString();
            tBox_AccZ.Text = INSdata.data_1s[6].ToString();

            tBox_Accx_Com.Text = (INSdata.data_1s[4]).ToString("##0.00000000");
            tBox_Accy_Com.Text = (INSdata.data_1s[5]).ToString("##0.00000000");
            tBox_Accz_Com.Text = (INSdata.data_1s[6]).ToString("##0.00000000");

            tBox_Accx_Std.Text = (CalculateStdDev(INSdata.ListAccxData_1s)).ToString("##0.00000000");
            tBox_Accy_Std.Text = (CalculateStdDev(INSdata.ListAccyData_1s)).ToString("##0.00000000");
            tBox_Accz_Std.Text = (CalculateStdDev(INSdata.ListAcczData_1s)).ToString("##0.00000000");

            tBox_Accx_ave.Text = (INSdata.ListAccxData_1s.ToArray().Average()).ToString("##0.000000");
            tBox_Accy_ave.Text = (INSdata.ListAccyData_1s.ToArray().Average()).ToString("##0.000000");
            tBox_Accz_ave.Text = (INSdata.ListAcczData_1s.ToArray().Average()).ToString("##0.000000");

            tBox_FogxT.Text = INSdata.doubleFogTmp[0].ToString();
            tBox_FogyT.Text = INSdata.doubleFogTmp[1].ToString();
            tBox_FogzT.Text = INSdata.doubleFogTmp[2].ToString();

            tBox_fpx.Text = INSdata.data_1s[16].ToString();
            tBox_fpy.Text = INSdata.data_1s[17].ToString();
            tBox_fpz.Text = INSdata.data_1s[18].ToString();

            tBox_Pitch.Text = (INSdata.doubleAttData[0]).ToString("###0.0000");
            tBox_Roll.Text =  (INSdata.doubleAttData[1]).ToString("###0.0000");
            tBox_Yaw.Text =   (INSdata.doubleAttData[2]).ToString("###0.0000");


            tBox_Counter.Text = (INSdata.TotalCounter / 400.0).ToString();
            tBox_Timer.Text = INSdata.nav_state.ToString();

            DrawIMUData();
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

        private void Btn_SendInitialData_Click(object sender, EventArgs e)
        {
            double init_lati, init_longti, init_height;
            
            int checksum = 0;
            byte[] Sendbuff = new byte[18];
            Union[] trdata = new Union[3];
            if (rBtn_SendInt.Checked)
            {
                init_lati = Convert.ToDouble(tBox_InitLati.Text);
                init_longti = Convert.ToDouble(tBox_InitLongti.Text);
                init_height = Convert.ToDouble(tBox_InitHeight.Text);
                trdata[0].i = Convert.ToInt32(init_lati * 1e6);
                trdata[1].i = Convert.ToInt32(init_longti * 1e6);
                trdata[2].i = Convert.ToInt32(init_height * 100);

                Sendbuff[0] = 0x5A;
                Sendbuff[1] = 0xA5;
                Sendbuff[2] = 0x03;

                for (int i = 0; i < 3; i++)
                {
                    Sendbuff[3 + 4 * i] = trdata[i].b0;
                    Sendbuff[4 + 4 * i] = trdata[i].b1;
                    Sendbuff[5 + 4 * i] = trdata[i].b2;
                    Sendbuff[6 + 4 * i] = trdata[i].b3;
                }
                for (int i = 2; i < 15; i++)
                {
                    checksum += Sendbuff[i];
                }
                Sendbuff[15] = Convert.ToByte(checksum & 0xFF);
                Sendbuff[16] = 0x55;
                INSdata.TotalCounter = 0;
                if (!serialPort.IsOpen)
                {
                    Btn_OpenSerial.Text = "关闭串口...";
                    serialPort.Open();
                }

                textBox_Info.Text += "发送的纬度是：" + init_lati.ToString() + "\r\n";
                textBox_Info.Text += "发送的经度是：" + init_longti.ToString() + "\r\n";
                textBox_Info.Text += "发送的高度是：" + init_height.ToString() + "\r\n";
                textBox_Info.Text += "对应数据码是：" + "\r\n";
                serialPort.Write(Sendbuff, 0, 17);
//                 for (int i = 0; i < Sendbuff.Length; i++)
//                 {
//                     textBox_Info.Text += "0x" + Sendbuff[i].ToString("X2") + " ";
//                 }
                for (int i = 0; i < 17; i++)
                {
                    textBox_Info.Text += Sendbuff[i].ToString("X2") + " ";
                }
            }

            if (rBtn_SendFloat.Checked)
            {
                trdata[0].f = Convert.ToSingle(tBox_InitLati.Text);
                trdata[1].f = Convert.ToSingle(tBox_InitLongti.Text);
                trdata[2].f = Convert.ToSingle(tBox_InitHeight.Text);

                Sendbuff[0] = 0xEB;
                Sendbuff[1] = 0x90;
                Sendbuff[2] = 0x01;
                Sendbuff[3] = 0x0C;
                for (int i = 0; i < 3; i++)
                {
                    Sendbuff[4 + 4 * i] = trdata[i].b0;
                    Sendbuff[5 + 4 * i] = trdata[i].b1;
                    Sendbuff[6 + 4 * i] = trdata[i].b2;
                    Sendbuff[7 + 4 * i] = trdata[i].b3;
                }
                for (int i = 2; i < 16; i++)
                {
                    checksum += Sendbuff[i];
                }
                Sendbuff[16] = Convert.ToByte(checksum & 0xFF);
                Sendbuff[17] = Convert.ToByte(checksum>>8 & 0xFF);
                INSdata.TotalCounter = 0;
                if (!serialPort.IsOpen)
                {
                    Btn_OpenSerial.Text = "关闭串口...";
                    serialPort.Open();
                }

                textBox_Info.Text += "发送的纬度是：" + tBox_InitLati.Text +"\r\n";
                textBox_Info.Text += "发送的经度是：" + tBox_InitLongti.Text +"\r\n";
                textBox_Info.Text += "发送的高度是：" + tBox_InitHeight.Text + "\r\n";
                textBox_Info.Text += "对应数据码是：" + "\r\n";
                serialPort.Write(Sendbuff, 0, 18);
//                 for (int i = 0; i < Sendbuff.Length; i++)
//                 {
//                     textBox_Info.Text += "0x" + Sendbuff[i].ToString("X2") + " ";
//                 }
                for (int i = 0; i < 18; i++)
                {
                    textBox_Info.Text += Sendbuff[i].ToString("X2") + " ";
                }
            }
            
            textBox_Info.Text += "\r\n";
            //让文本框获取焦点 
            this.textBox_Info.Focus();
            //设置光标的位置到文本尾 
            this.textBox_Info.Select(this.textBox_Info.Text.Length, 0);
            //滚动到控件光标处 
            this.textBox_Info.ScrollToCaret();
        }

        
    }
}
