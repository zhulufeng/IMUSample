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
        StreamWriter intDataSW ;
        StreamWriter doubleDataSW;//= new StreamWriter(PathString.IMUDataCurrentDirectory + @"\" + "imuDataDouble.txt");
        StreamWriter CaliDataSW;
        TimePara timePara = new TimePara();
        bool[] zoomed_flag = new bool[6];
        bool rate_flag = false;
        double G0 = 9.8221625;
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
            IntializeChart();
            AddSeries(12);
            AddChartArea(6);
            IMUData.TotalCounter = 0;
            IMUData.Fogx_SF = 2263936.861;
            IMUData.Fogy_SF = 2263936.861;
            IMUData.Fogz_SF = 2263936.861;
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
                            chart.ChartAreas[index].AxisY.Maximum = (IMUData.ListFogxData_1s.ToArray().Max() + 100) * IMUData.Fogx_SF;
                            chart.ChartAreas[index].AxisY.Minimum = (IMUData.ListFogxData_1s.ToArray().Min() - 100) * IMUData.Fogx_SF;
                            chart.ChartAreas[index].AxisY2.Maximum = IMUData.ListTemFogxData_1s.ToArray().Max() + 1;
                            chart.ChartAreas[index].AxisY2.Minimum = IMUData.ListTemFogxData_1s.ToArray().Min() - 1;

                            chart.ChartAreas[index].AxisX.Interval = (IMUData.ListFogxData_1s.Count / 20 + 1);
                            chart.ChartAreas[index].AxisX.ScaleView.Size = IMUData.ListFogxData_1s.Count * 1.1;
                            chart.ChartAreas[index].AxisX.ScaleView.Position = 0.0;
                            chart.ChartAreas[index].CursorX.SelectionStart = chart.ChartAreas[index].CursorX.SelectionEnd = 0.0;
                            chart.ChartAreas[index].CursorX.Position = -1;
                            break;

                        case 1:
                            chart.ChartAreas[index].AxisY.Maximum = (IMUData.ListFogyData_1s.ToArray().Max() + 100) * IMUData.Fogy_SF;
                            chart.ChartAreas[index].AxisY.Minimum = (IMUData.ListFogyData_1s.ToArray().Min() - 100) * IMUData.Fogy_SF;
                            chart.ChartAreas[index].AxisY2.Maximum = IMUData.ListTemFogyData_1s.ToArray().Max() + 1;
                            chart.ChartAreas[index].AxisY2.Minimum = IMUData.ListTemFogyData_1s.ToArray().Min() - 1;

                            chart.ChartAreas[index].AxisX.Interval = (IMUData.ListFogyData_1s.Count / 20 + 1);
                            chart.ChartAreas[index].AxisX.ScaleView.Size = IMUData.ListFogyData_1s.Count * 1.1;
                            chart.ChartAreas[index].AxisX.ScaleView.Position = 0.0;
                            chart.ChartAreas[index].CursorX.SelectionStart = chart.ChartAreas[index].CursorX.SelectionEnd = 0.0;
                            chart.ChartAreas[index].CursorX.Position = -1;
                            break;

                        case 2:
                            chart.ChartAreas[index].AxisY.Maximum = (IMUData.ListFogzData_1s.ToArray().Max() + 100) * IMUData.Fogz_SF;
                            chart.ChartAreas[index].AxisY.Minimum = (IMUData.ListFogzData_1s.ToArray().Min() - 100) * IMUData.Fogz_SF;
                            chart.ChartAreas[index].AxisY2.Maximum = IMUData.ListTemFogzData_1s.ToArray().Max() + 1;
                            chart.ChartAreas[index].AxisY2.Minimum = IMUData.ListTemFogzData_1s.ToArray().Min() - 1;

                            chart.ChartAreas[index].AxisX.Interval = (IMUData.ListFogzData_1s.Count / 20 + 1);
                            chart.ChartAreas[index].AxisX.ScaleView.Size = IMUData.ListFogzData_1s.Count * 1.1;
                            chart.ChartAreas[index].AxisX.ScaleView.Position = 0.0;
                            chart.ChartAreas[index].CursorX.SelectionStart = chart.ChartAreas[index].CursorX.SelectionEnd = 0.0;
                            chart.ChartAreas[index].CursorX.Position = -1;
                            break;
                        case 3:
                            chart.ChartAreas[index].AxisY.Maximum = IMUData.ListAccxData_1s.ToArray().Max() + 0.0001;
                            chart.ChartAreas[index].AxisY.Minimum = IMUData.ListAccxData_1s.ToArray().Min() - 0.0001;
                            chart.ChartAreas[index].AxisY2.Maximum = IMUData.ListTemAccxData_1s.ToArray().Max() + 1;
                            chart.ChartAreas[index].AxisY2.Minimum = IMUData.ListTemAccxData_1s.ToArray().Min() - 1;

                            chart.ChartAreas[index].AxisX.Interval = (IMUData.ListAccxData_1s.Count / 20 + 1);
                            chart.ChartAreas[index].AxisX.ScaleView.Size = IMUData.ListAccxData_1s.Count * 1.1;
                            chart.ChartAreas[index].AxisX.ScaleView.Position = 0.0;
                            chart.ChartAreas[index].CursorX.SelectionStart = chart.ChartAreas[index].CursorX.SelectionEnd = 0.0;
                            chart.ChartAreas[index].CursorX.Position = -1;
                            break;

                        case 4:
                            chart.ChartAreas[index].AxisY.Maximum = IMUData.ListAccyData_1s.ToArray().Max() + 0.0001;
                            chart.ChartAreas[index].AxisY.Minimum = IMUData.ListAccyData_1s.ToArray().Min() - 0.0001;
                            chart.ChartAreas[index].AxisY2.Maximum = IMUData.ListTemAccyData_1s.ToArray().Max() + 1;
                            chart.ChartAreas[index].AxisY2.Minimum = IMUData.ListTemAccyData_1s.ToArray().Min() - 1;

                            chart.ChartAreas[index].AxisX.Interval = (IMUData.ListAccyData_1s.Count / 20 + 1);
                            chart.ChartAreas[index].AxisX.ScaleView.Size = IMUData.ListAccyData_1s.Count * 1.1;
                            chart.ChartAreas[index].AxisX.ScaleView.Position = 0.0;
                            chart.ChartAreas[index].CursorX.SelectionStart = chart.ChartAreas[index].CursorX.SelectionEnd = 0.0;
                            chart.ChartAreas[index].CursorX.Position = -1;
                            break;

                        case 5:
                            chart.ChartAreas[index].AxisY.Maximum = IMUData.ListAcczData_1s.ToArray().Max() + 0.0001;
                            chart.ChartAreas[index].AxisY.Minimum = IMUData.ListAcczData_1s.ToArray().Min() - 0.0001;
                            chart.ChartAreas[index].AxisY2.Maximum = IMUData.ListTemAcczData_1s.ToArray().Max() + 1;
                            chart.ChartAreas[index].AxisY2.Minimum = IMUData.ListTemAcczData_1s.ToArray().Min() - 1;

                            chart.ChartAreas[index].AxisX.Interval = (IMUData.ListAcczData_1s.Count / 20 + 1);
                            chart.ChartAreas[index].AxisX.ScaleView.Size = IMUData.ListAcczData_1s.Count * 1.1;
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
                    chart.Series[2 * index].Points.AddXY(timePara.drawIndexTime[index], IMUData.data_1s[index + 1] * 0.0017);
                    chart.Series[2 * index + 1].Points.AddXY(timePara.drawIndexTime[index], IMUData.data_1s[index + 1 + 6]);
                }
                else 
                {
                    chart.Series[2 * index].Points.AddXY(timePara.drawIndexTime[index], IMUData.data_1s[index + 1]);
                    chart.Series[2 * index + 1].Points.AddXY(timePara.drawIndexTime[index], IMUData.data_1s[index + 1 + 6]);
                }
            }
        }
        private void Btn_OpenSerial_Click(object sender, EventArgs e)
        {

            if (Btn_OpenSerial.Text == "再次打开串口...")
            {
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
                CaliDataSW = new StreamWriter(PathString.IMUDataCurrentDirectory + @"\" + "imuDataCalidata.txt");
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
//                 timePara.drawIndexTime.Clear();
//                 //chart.DataBind();
//                 for (int i = 0; i < 6; i++)
//                 {
//                     timePara.drawIndexTime.Add(0);
//                     chart.Series.Clear();
//                     IMUData.ListFogxData_1s.Clear();
//                     IMUData.ListFogyData_1s.Clear();
//                     IMUData.ListFogzData_1s.Clear();
//                     IMUData.ListAccxData_1s.Clear();
//                     IMUData.ListAccyData_1s.Clear();
//                     IMUData.ListAcczData_1s.Clear();
//                     IMUData.ListTemFogxData_1s.Clear();
//                     IMUData.ListTemFogyData_1s.Clear();
//                     IMUData.ListTemFogzData_1s.Clear();
//                     IMUData.ListTemAccxData_1s.Clear();
//                     IMUData.ListTemAccyData_1s.Clear();
//                     IMUData.ListTemAcczData_1s.Clear();
//                 }
                
                //MessageBox.Show("Hello!");
            }
            else if (Btn_OpenSerial.Text == "打开串口...")
            {
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
                IMUData.TotalCounter = 0;
                IMUData.ListFogxData_1s.Clear();
                IMUData.ListFogyData_1s.Clear();
                IMUData.ListFogzData_1s.Clear();
                IMUData.ListAccxData_1s.Clear();
                IMUData.ListAccyData_1s.Clear();
                IMUData.ListAcczData_1s.Clear();
                IMUData.ListTemFogxData_1s.Clear();
                IMUData.ListTemFogyData_1s.Clear();
                IMUData.ListTemFogzData_1s.Clear();
                IMUData.ListTemAccxData_1s.Clear();
                IMUData.ListTemAccyData_1s.Clear();
                IMUData.ListTemAcczData_1s.Clear();
                if (serialParameter.isSaveHex)
                {
                    intDataSW.Close();
                }
                doubleDataSW.Close();
                CaliDataSW.Close();
                serialPort.Close();
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
            int n = serialPort.BytesToRead;
            byte[] readBuffer = new byte[n];
            byte[] buf = new byte[n];
            serialPort.Read(readBuffer, 0, n);
            serialData.buffer.AddRange(readBuffer);
            UInt32 CheckSumA = 0;
            UInt32 CheckSumB = 0;
            while (serialData.buffer.Count >= 42)
            {
                //Int32 index = 0;
                //Byte ch = 
                if (serialData.buffer[0] == 0xAA && serialData.buffer[1] == 0xAA)
                {
                    CheckSumA = 0;
                    CheckSumB = 0;
                    for (int i = 4;i <= 39;i++)
                    {
                        CheckSumA = CheckSumA ^ serialData.buffer[i];
                    }
                    CheckSumB = serialData.buffer[40];
                   // MessageBox.Show("CheckSumA is :" + CheckSumA.ToString() + "\nCheckSumB is :" + CheckSumB.ToString());
                    if ((CheckSumA & 0xff) == CheckSumB && serialData.buffer[41] == 0xBB) 
                    {
                        serialData.buffer.CopyTo(0,IMUData.arrayOriginData, 0, 42);
                        IMUData.TotalCounter++;
                        Union[] trdata = new Union[3];
                        for (int i = 0; i < 3; i++)
                        {
                            IMUData.intFogData[i] = (Convert.ToInt32(IMUData.arrayOriginData[4 * i + 7]) * 256 * 256 * 256 + Convert.ToInt32(IMUData.arrayOriginData[4 * i + 6])  * 256 * 256
                                                            + Convert.ToInt32(IMUData.arrayOriginData[4 * i + 5]) * 256  + Convert.ToInt32(IMUData.arrayOriginData[4 * i + 4]));
//                             IMUData.intAccData[i] = (Convert.ToInt32(IMUData.arrayOriginData[4 * i + 19]) * 256 * 256 * 256 + Convert.ToInt32(IMUData.arrayOriginData[4 * i + 18]) * 256 * 256
//                                                             + Convert.ToInt32(IMUData.arrayOriginData[4 * i + 17]) * 256 + Convert.ToInt32(IMUData.arrayOriginData[4 * i + 16]));
                            IMUData.intFogTmp[i]  = (IMUData.arrayOriginData[2 * i + 29] * 256 * 256 * 256 + IMUData.arrayOriginData[2 * i + 28] * 256 * 256) / 256 / 256;
                            IMUData.intAccTmp[i]  = (IMUData.arrayOriginData[2 * i + 35] * 256 * 256 * 256 + IMUData.arrayOriginData[2 * i + 34] * 256 * 256) / 256 / 256;
                            IMUData.doubleFogData[i] = Convert.ToDouble(IMUData.intFogData[i]) / 1.0;
                            IMUData.doubleAccData[i] = Convert.ToDouble(IMUData.intAccData[i]) / 1.0;
                            IMUData.doubleFogTmp[i] = Convert.ToDouble(IMUData.intFogTmp[i]) / 16.0;
                            IMUData.doubleAccTmp[i] = Convert.ToDouble(IMUData.intAccTmp[i]) / 16.0;
                            trdata[i].b0 = IMUData.arrayOriginData[i * 4 + 16];
                            trdata[i].b1 = IMUData.arrayOriginData[i * 4 + 17];
                            trdata[i].b2 = IMUData.arrayOriginData[i * 4 + 18];
                            trdata[i].b3 = IMUData.arrayOriginData[i * 4 + 19];

//                             trdata[i].b0 = IMUData.arrayOriginData[i * 4 + 19];
//                             trdata[i].b1 = IMUData.arrayOriginData[i * 4 + 18];
//                             trdata[i].b2 = IMUData.arrayOriginData[i * 4 + 17];
//                             trdata[i].b3 = IMUData.arrayOriginData[i * 4 + 16];
                            IMUData.floatAccData[i] = trdata[i].f;

                        }
                        

                        IMUData.Counter = IMUData.arrayOriginData[2];
                        //IMUData.Timer_cyc = IMUData.arrayOriginData[36] * 256 + IMUData.arrayOriginData[37];
                        IMUData.arrayIMUdata[0] = IMUData.Counter;
                        for (int i = 0; i < 3; i++)
                        {
                            IMUData.arrayIMUdata[1  + i]  = IMUData.doubleFogData[i];
                            IMUData.arrayIMUdata[4  + i]  = IMUData.floatAccData[i];
                            IMUData.arrayIMUdata[7  + i]  = IMUData.doubleFogTmp[i];
                            IMUData.arrayIMUdata[10 + i]  = IMUData.doubleAccTmp[0];
                        }

                        IMUData.ListFogxData.Add(IMUData.arrayIMUdata[1]);
                        IMUData.ListFogyData.Add(IMUData.arrayIMUdata[2]);
                        IMUData.ListFogzData.Add(IMUData.arrayIMUdata[3]);
                        IMUData.ListAccxData.Add(IMUData.arrayIMUdata[4]);
                        IMUData.ListAccyData.Add(IMUData.arrayIMUdata[5]);
                        IMUData.ListAcczData.Add(IMUData.arrayIMUdata[6]);

                        IMUData.ListTemFogxData.Add(IMUData.arrayIMUdata[7]);
                        IMUData.ListTemFogyData.Add(IMUData.arrayIMUdata[8]);
                        IMUData.ListTemFogzData.Add(IMUData.arrayIMUdata[9]);
                        IMUData.ListTemAccxData.Add(IMUData.arrayIMUdata[10]);
                        IMUData.ListTemAccyData.Add(IMUData.arrayIMUdata[11]);
                        IMUData.ListTemAcczData.Add(IMUData.arrayIMUdata[12]);

                        IMUData.arrayIMUdata[13] = IMUData.Counter;
                        IMUData.arrayIMUdata[14] = IMUData.Timer_cyc;
                        if (serialParameter.isHighFreq)
                        {
                            saveData(IMUData.arrayIMUdata);
                        }
                        
                        if (IMUData.TotalCounter % 400 == 0)
                        {
                            IMUData.ListFogxData_1s.Add(IMUData.ListFogxData.ToArray().Sum());
                            IMUData.ListFogyData_1s.Add(IMUData.ListFogyData.ToArray().Sum());
                            IMUData.ListFogzData_1s.Add(IMUData.ListFogzData.ToArray().Sum());

                            IMUData.data_1s[1] = IMUData.ListFogxData.ToArray().Sum();
                            IMUData.data_1s[2] = IMUData.ListFogyData.ToArray().Sum();
                            IMUData.data_1s[3] = IMUData.ListFogzData.ToArray().Sum();

                             
                            IMUData.ListAccxData_1s.Add(IMUData.ListAccxData.ToArray().Average());
                            IMUData.ListAccyData_1s.Add(IMUData.ListAccyData.ToArray().Average());
                            IMUData.ListAcczData_1s.Add(IMUData.ListAcczData.ToArray().Average());

                            IMUData.data_1s[4] = IMUData.ListAccxData.ToArray().Average();
                            IMUData.data_1s[5] = IMUData.ListAccyData.ToArray().Average();
                            IMUData.data_1s[6] = IMUData.ListAcczData.ToArray().Average();
                            ////////////////////////温度
                            IMUData.ListTemFogxData_1s.Add(IMUData.ListTemFogxData.ToArray().Average());
                            IMUData.ListTemFogyData_1s.Add(IMUData.ListTemFogyData.ToArray().Average());
                            IMUData.ListTemFogzData_1s.Add(IMUData.ListTemFogzData.ToArray().Average());

                            IMUData.data_1s[7] = IMUData.ListTemFogxData.ToArray().Average();
                            IMUData.data_1s[8] = IMUData.ListTemFogyData.ToArray().Average();
                            IMUData.data_1s[9] = IMUData.ListTemFogzData.ToArray().Average();


                            IMUData.ListTemAccxData_1s.Add(IMUData.ListTemAccxData.ToArray().Average());
                            IMUData.ListTemAccyData_1s.Add(IMUData.ListTemAccyData.ToArray().Average());
                            IMUData.ListTemAcczData_1s.Add(IMUData.ListTemAcczData.ToArray().Average());

                            IMUData.data_1s[10] = IMUData.ListTemAccxData.ToArray().Average();
                            IMUData.data_1s[11] = IMUData.ListTemAccyData.ToArray().Average();
                            IMUData.data_1s[12] = IMUData.ListTemAcczData.ToArray().Average();

                            IMUData.data_1s[13] = IMUData.Counter;
                            IMUData.data_1s[14] = IMUData.Timer_cyc;

                            IMUData.ListFogxData.Clear();
                            IMUData.ListFogyData.Clear();
                            IMUData.ListFogzData.Clear();
                            IMUData.ListAccxData.Clear();
                            IMUData.ListAccyData.Clear();
                            IMUData.ListAcczData.Clear();

                            IMUData.ListTemFogxData.Clear();
                            IMUData.ListTemFogyData.Clear();
                            IMUData.ListTemFogzData.Clear();
                            IMUData.ListTemAccxData.Clear();
                            IMUData.ListTemAccyData.Clear();
                            IMUData.ListTemAcczData.Clear();
                            if (!serialParameter.isHighFreq)
                            {
                                saveData(IMUData.data_1s);
                            }
                            
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
                for (int i = 0; i < IMUData.arrayOriginData.Length; i++)
                {
                    intDataSW.Write(IMUData.arrayOriginData[i].ToString("X2") + "\t");
                }
                intDataSW.Write("\r\n");
            }           
           
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0:0000.000}",(Convert.ToDouble(IMUData.TotalCounter)) / 400.0);
            for (int i = 1;i <= 12;i++)
            {
                if (i >= 0 && i <= 3)
                {
                    if (Datalist[i] >= 0)
                    {
                        sb.AppendFormat("\t{0: #####000} ", Datalist[i]);
                    }
                    else
                    {
                        sb.AppendFormat("\t{0:#####000} ", Datalist[i]);
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
            sb.AppendFormat("\t{0:000} ", Datalist[13]);
            sb.AppendFormat("\t{0:0000} ", Datalist[14]);
            doubleDataSW.WriteLine(sb.ToString());
            sb.Clear();
            sb.AppendFormat("{0:0000.000}", (Convert.ToDouble(IMUData.TotalCounter)));
            for (int i = 1; i <= 6; i++)
            {
                if (i >= 0 && i <= 3)
                {
                    if (Datalist[i] >= 0)
                    {
                        sb.AppendFormat("\t{0: #####000} ", Datalist[i]);
                    }
                    else
                    {
                        sb.AppendFormat("\t{0:#####000} ", Datalist[i]);
                    }
                }
                if (i >= 4 && i <= 6)
                {
                    if (Datalist[i] >= 0)
                    {
                        sb.AppendFormat("\t{0: ##0.00000000} ", Datalist[i] * G0);
                    }
                    else
                    {
                        sb.AppendFormat("\t{0:###0.00000000} ", Datalist[i] * G0);
                    }
                }
            }
            if (rate_flag)
            {
                sb.Append("\t" + "1");
            }
            else
            {
                sb.Append("\t" + "0");
            }
            CaliDataSW.WriteLine(sb.ToString());
            sb.Clear();
        }
        private void showData()
        {
            tBox_FogX.Text = IMUData.data_1s[1].ToString();
            tBox_FogY.Text = IMUData.data_1s[2].ToString();
            tBox_FogZ.Text = IMUData.data_1s[3].ToString();
            tBox_Fogx_Com.Text = (IMUData.data_1s[1] * IMUData.Fogx_SF).ToString();
            tBox_Fogy_Com.Text = (IMUData.data_1s[2] * IMUData.Fogy_SF).ToString();
            tBox_Fogz_Com.Text = (IMUData.data_1s[3] * IMUData.Fogz_SF).ToString();

            tBox_Fogx_Std.Text = (CalculateStdDev(IMUData.ListFogxData_1s) * IMUData.Fogx_SF).ToString("##0.000000");
            tBox_Fogy_Std.Text = (CalculateStdDev(IMUData.ListFogyData_1s) * IMUData.Fogy_SF).ToString("##0.000000");
            tBox_Fogz_Std.Text = (CalculateStdDev(IMUData.ListFogzData_1s) * IMUData.Fogz_SF).ToString("##0.000000");

            tBox_Fogx_ave.Text = (IMUData.ListFogxData_1s.ToArray().Average() * IMUData.Fogx_SF).ToString("##0.000000");
            tBox_Fogy_ave.Text = (IMUData.ListFogyData_1s.ToArray().Average() * IMUData.Fogy_SF).ToString("##0.000000");
            tBox_Fogz_ave.Text = (IMUData.ListFogzData_1s.ToArray().Average() * IMUData.Fogz_SF).ToString("##0.000000");

            tBox_AccX.Text = IMUData.floatAccData[0].ToString();
            tBox_AccY.Text = IMUData.floatAccData[1].ToString();
            tBox_AccZ.Text = IMUData.floatAccData[2].ToString();

            tBox_Accx_Com.Text = (IMUData.data_1s[4] * 1.0).ToString("##0.00000000");
            tBox_Accy_Com.Text = (IMUData.data_1s[5] * 1.0).ToString("##0.00000000");
            tBox_Accz_Com.Text = (IMUData.data_1s[6] * 1.0).ToString("##0.00000000");

            tBox_Accx_Std.Text = (CalculateStdDev(IMUData.ListAccxData_1s) * 1.0).ToString("##0.00000000");
            tBox_Accy_Std.Text = (CalculateStdDev(IMUData.ListAccyData_1s) * 1.0).ToString("##0.00000000");
            tBox_Accz_Std.Text = (CalculateStdDev(IMUData.ListAcczData_1s) * 1.0).ToString("##0.00000000");

            tBox_Accx_ave.Text = (IMUData.ListAccxData_1s.ToArray().Average() * 1.0).ToString("##0.000000");
            tBox_Accy_ave.Text = (IMUData.ListAccyData_1s.ToArray().Average() * 1.0).ToString("##0.000000");
            tBox_Accz_ave.Text = (IMUData.ListAcczData_1s.ToArray().Average() * 1.0).ToString("##0.000000");

            tBox_FogxT.Text = IMUData.doubleFogTmp[0].ToString();
            tBox_FogyT.Text = IMUData.doubleFogTmp[1].ToString();
            tBox_FogzT.Text = IMUData.doubleFogTmp[2].ToString();

            tBox_AccxT.Text = IMUData.doubleAccTmp[0].ToString();
            tBox_AccyT.Text = IMUData.doubleAccTmp[1].ToString();
            tBox_AcczT.Text = IMUData.doubleAccTmp[2].ToString();

            tBox_Counter.Text = (IMUData.TotalCounter / 400).ToString();
            tBox_Timer.Text = IMUData.Timer_cyc.ToString();

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

        private void Btn_Set_SF_Click(object sender, EventArgs e)
        {
            IMUData.Fogx_SF = 3600.0 / Convert.ToDouble(tBox_Fog_SFX.Text);
            IMUData.Fogy_SF = 3600.0 / Convert.ToDouble(tBox_Fog_SFY.Text);
            IMUData.Fogz_SF = 3600.0 / Convert.ToDouble(tBox_Fog_SFZ.Text);
            IMUData.Fog_SF[0] = Convert.ToDouble(tBox_Fog_SFX.Text);
            IMUData.Fog_SF[1] = Convert.ToDouble(tBox_Fog_SFY.Text);
            IMUData.Fog_SF[2] = Convert.ToDouble(tBox_Fog_SFZ.Text);

        }

        private void Btn_CaliStatus_Click(object sender, EventArgs e)
        {
            if(Btn_CaliStatus.Text == "进入转动状态")
            {
                rate_flag = true;
                Btn_CaliStatus.Text = "进入静止状态";
                tBox_CaliInfo.Text = "由静止状态进入转动状态，标志位由0变1";
            }
            else
            {
                rate_flag = false;
                Btn_CaliStatus.Text = "进入转动状态";
                tBox_CaliInfo.Text = "由转动状态进入静止状态，标志位由1变0";
            }
        }
    }
}
