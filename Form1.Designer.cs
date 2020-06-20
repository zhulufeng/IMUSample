namespace IMUSample
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.Btn_OpenSerial = new System.Windows.Forms.Button();
            this.InfoBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItem_SerialCfg = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_FileOperation = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_DataClear = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_ClearDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_ClearFile = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.tBox_AccX = new System.Windows.Forms.TextBox();
            this.tBox_AccY = new System.Windows.Forms.TextBox();
            this.tBox_AccZ = new System.Windows.Forms.TextBox();
            this.tBox_AccxT = new System.Windows.Forms.TextBox();
            this.tBox_FogX = new System.Windows.Forms.TextBox();
            this.tBox_FogY = new System.Windows.Forms.TextBox();
            this.tBox_FogZ = new System.Windows.Forms.TextBox();
            this.tBox_FogxT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_Info = new System.Windows.Forms.TextBox();
            this.tBox_FogzT = new System.Windows.Forms.TextBox();
            this.tBox_FogyT = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tBox_AccyT = new System.Windows.Forms.TextBox();
            this.tBox_AcczT = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tBox_Counter = new System.Windows.Forms.TextBox();
            this.tBox_Timer = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tBox_Fogz_Com = new System.Windows.Forms.TextBox();
            this.tBox_Fogy_Com = new System.Windows.Forms.TextBox();
            this.tBox_Fogx_Com = new System.Windows.Forms.TextBox();
            this.tBox_Fogz_Std = new System.Windows.Forms.TextBox();
            this.tBox_Fogy_Std = new System.Windows.Forms.TextBox();
            this.tBox_Fogx_Std = new System.Windows.Forms.TextBox();
            this.tBox_Accz_Std = new System.Windows.Forms.TextBox();
            this.tBox_Accy_Std = new System.Windows.Forms.TextBox();
            this.tBox_Accx_Std = new System.Windows.Forms.TextBox();
            this.tBox_Accz_Com = new System.Windows.Forms.TextBox();
            this.tBox_Accy_Com = new System.Windows.Forms.TextBox();
            this.tBox_Accx_Com = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_OpenSerial
            // 
            this.Btn_OpenSerial.Location = new System.Drawing.Point(888, 50);
            this.Btn_OpenSerial.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_OpenSerial.Name = "Btn_OpenSerial";
            this.Btn_OpenSerial.Size = new System.Drawing.Size(74, 22);
            this.Btn_OpenSerial.TabIndex = 1;
            this.Btn_OpenSerial.Text = "打开串口...";
            this.Btn_OpenSerial.UseVisualStyleBackColor = true;
            this.Btn_OpenSerial.Click += new System.EventHandler(this.Btn_OpenSerial_Click);
            // 
            // InfoBox
            // 
            this.InfoBox.BackColor = System.Drawing.SystemColors.Menu;
            this.InfoBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InfoBox.Location = new System.Drawing.Point(6, 28);
            this.InfoBox.Margin = new System.Windows.Forms.Padding(2);
            this.InfoBox.Multiline = true;
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InfoBox.Size = new System.Drawing.Size(114, 162);
            this.InfoBox.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_SerialCfg,
            this.MenuItem_FileOperation});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1281, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItem_SerialCfg
            // 
            this.MenuItem_SerialCfg.Name = "MenuItem_SerialCfg";
            this.MenuItem_SerialCfg.Size = new System.Drawing.Size(83, 22);
            this.MenuItem_SerialCfg.Text = "串口设置(&S)";
            this.MenuItem_SerialCfg.Click += new System.EventHandler(this.MenuItem_SerialCfg_Click);
            // 
            // MenuItem_FileOperation
            // 
            this.MenuItem_FileOperation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_SaveAs,
            this.MenuItem_DataClear});
            this.MenuItem_FileOperation.Name = "MenuItem_FileOperation";
            this.MenuItem_FileOperation.Size = new System.Drawing.Size(82, 22);
            this.MenuItem_FileOperation.Text = "文件操作(&F)";
            // 
            // MenuItem_SaveAs
            // 
            this.MenuItem_SaveAs.Name = "MenuItem_SaveAs";
            this.MenuItem_SaveAs.Size = new System.Drawing.Size(164, 22);
            this.MenuItem_SaveAs.Text = "文件另存(&S)";
            // 
            // MenuItem_DataClear
            // 
            this.MenuItem_DataClear.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_ClearDirectory,
            this.MenuItem_ClearFile});
            this.MenuItem_DataClear.Name = "MenuItem_DataClear";
            this.MenuItem_DataClear.Size = new System.Drawing.Size(164, 22);
            this.MenuItem_DataClear.Text = "数据文件清除(&C)";
            // 
            // MenuItem_ClearDirectory
            // 
            this.MenuItem_ClearDirectory.Name = "MenuItem_ClearDirectory";
            this.MenuItem_ClearDirectory.Size = new System.Drawing.Size(153, 22);
            this.MenuItem_ClearDirectory.Text = "清除文件夹(&D)";
            this.MenuItem_ClearDirectory.Click += new System.EventHandler(this.MenuItem_ClearDirectory_Click);
            // 
            // MenuItem_ClearFile
            // 
            this.MenuItem_ClearFile.Name = "MenuItem_ClearFile";
            this.MenuItem_ClearFile.Size = new System.Drawing.Size(153, 22);
            this.MenuItem_ClearFile.Text = "清除文件(&F)";
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // tBox_AccX
            // 
            this.tBox_AccX.Location = new System.Drawing.Point(363, 145);
            this.tBox_AccX.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_AccX.Name = "tBox_AccX";
            this.tBox_AccX.Size = new System.Drawing.Size(89, 21);
            this.tBox_AccX.TabIndex = 6;
            // 
            // tBox_AccY
            // 
            this.tBox_AccY.Location = new System.Drawing.Point(363, 172);
            this.tBox_AccY.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_AccY.Name = "tBox_AccY";
            this.tBox_AccY.Size = new System.Drawing.Size(89, 21);
            this.tBox_AccY.TabIndex = 6;
            // 
            // tBox_AccZ
            // 
            this.tBox_AccZ.Location = new System.Drawing.Point(363, 198);
            this.tBox_AccZ.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_AccZ.Name = "tBox_AccZ";
            this.tBox_AccZ.Size = new System.Drawing.Size(89, 21);
            this.tBox_AccZ.TabIndex = 6;
            // 
            // tBox_AccxT
            // 
            this.tBox_AccxT.Location = new System.Drawing.Point(724, 144);
            this.tBox_AccxT.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_AccxT.Name = "tBox_AccxT";
            this.tBox_AccxT.Size = new System.Drawing.Size(89, 21);
            this.tBox_AccxT.TabIndex = 6;
            // 
            // tBox_FogX
            // 
            this.tBox_FogX.Location = new System.Drawing.Point(363, 59);
            this.tBox_FogX.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_FogX.Name = "tBox_FogX";
            this.tBox_FogX.Size = new System.Drawing.Size(89, 21);
            this.tBox_FogX.TabIndex = 6;
            // 
            // tBox_FogY
            // 
            this.tBox_FogY.Location = new System.Drawing.Point(363, 86);
            this.tBox_FogY.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_FogY.Name = "tBox_FogY";
            this.tBox_FogY.Size = new System.Drawing.Size(89, 21);
            this.tBox_FogY.TabIndex = 6;
            // 
            // tBox_FogZ
            // 
            this.tBox_FogZ.Location = new System.Drawing.Point(363, 112);
            this.tBox_FogZ.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_FogZ.Name = "tBox_FogZ";
            this.tBox_FogZ.Size = new System.Drawing.Size(89, 21);
            this.tBox_FogZ.TabIndex = 6;
            // 
            // tBox_FogxT
            // 
            this.tBox_FogxT.Location = new System.Drawing.Point(724, 58);
            this.tBox_FogxT.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_FogxT.Name = "tBox_FogxT";
            this.tBox_FogxT.Size = new System.Drawing.Size(89, 21);
            this.tBox_FogxT.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "FogX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "FogY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "FogZ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(680, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "FogXT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 150);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "AccX";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 176);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "AccY";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(315, 201);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "AccZ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(676, 148);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "AccXT";
            // 
            // textBox_Info
            // 
            this.textBox_Info.Location = new System.Drawing.Point(132, 34);
            this.textBox_Info.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Info.Multiline = true;
            this.textBox_Info.Name = "textBox_Info";
            this.textBox_Info.Size = new System.Drawing.Size(179, 179);
            this.textBox_Info.TabIndex = 8;
            // 
            // tBox_FogzT
            // 
            this.tBox_FogzT.Location = new System.Drawing.Point(724, 111);
            this.tBox_FogzT.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_FogzT.Name = "tBox_FogzT";
            this.tBox_FogzT.Size = new System.Drawing.Size(89, 21);
            this.tBox_FogzT.TabIndex = 9;
            // 
            // tBox_FogyT
            // 
            this.tBox_FogyT.Location = new System.Drawing.Point(724, 85);
            this.tBox_FogyT.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_FogyT.Name = "tBox_FogyT";
            this.tBox_FogyT.Size = new System.Drawing.Size(89, 21);
            this.tBox_FogyT.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(680, 115);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "FogZT";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(680, 89);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "FogYT";
            // 
            // tBox_AccyT
            // 
            this.tBox_AccyT.Location = new System.Drawing.Point(724, 171);
            this.tBox_AccyT.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_AccyT.Name = "tBox_AccyT";
            this.tBox_AccyT.Size = new System.Drawing.Size(89, 21);
            this.tBox_AccyT.TabIndex = 6;
            // 
            // tBox_AcczT
            // 
            this.tBox_AcczT.Location = new System.Drawing.Point(724, 199);
            this.tBox_AcczT.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_AcczT.Name = "tBox_AcczT";
            this.tBox_AcczT.Size = new System.Drawing.Size(89, 21);
            this.tBox_AcczT.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(854, 121);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 7;
            this.label11.Text = "Counter";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(676, 175);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 7;
            this.label12.Text = "AccYT";
            // 
            // tBox_Counter
            // 
            this.tBox_Counter.Location = new System.Drawing.Point(922, 114);
            this.tBox_Counter.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_Counter.Name = "tBox_Counter";
            this.tBox_Counter.Size = new System.Drawing.Size(89, 21);
            this.tBox_Counter.TabIndex = 6;
            // 
            // tBox_Timer
            // 
            this.tBox_Timer.Location = new System.Drawing.Point(922, 145);
            this.tBox_Timer.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_Timer.Name = "tBox_Timer";
            this.tBox_Timer.Size = new System.Drawing.Size(89, 21);
            this.tBox_Timer.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(857, 152);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 7;
            this.label13.Text = "Timer";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(676, 203);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 12);
            this.label14.TabIndex = 7;
            this.label14.Text = "AccZT";
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Location = new System.Drawing.Point(0, 258);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(1281, 573);
            this.chart.TabIndex = 12;
            this.chart.Text = "chart1";
            // 
            // tBox_Fogz_Com
            // 
            this.tBox_Fogz_Com.Location = new System.Drawing.Point(465, 112);
            this.tBox_Fogz_Com.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_Fogz_Com.Name = "tBox_Fogz_Com";
            this.tBox_Fogz_Com.Size = new System.Drawing.Size(89, 21);
            this.tBox_Fogz_Com.TabIndex = 13;
            // 
            // tBox_Fogy_Com
            // 
            this.tBox_Fogy_Com.Location = new System.Drawing.Point(465, 86);
            this.tBox_Fogy_Com.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_Fogy_Com.Name = "tBox_Fogy_Com";
            this.tBox_Fogy_Com.Size = new System.Drawing.Size(89, 21);
            this.tBox_Fogy_Com.TabIndex = 14;
            // 
            // tBox_Fogx_Com
            // 
            this.tBox_Fogx_Com.Location = new System.Drawing.Point(465, 59);
            this.tBox_Fogx_Com.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_Fogx_Com.Name = "tBox_Fogx_Com";
            this.tBox_Fogx_Com.Size = new System.Drawing.Size(89, 21);
            this.tBox_Fogx_Com.TabIndex = 15;
            // 
            // tBox_Fogz_Std
            // 
            this.tBox_Fogz_Std.Location = new System.Drawing.Point(567, 111);
            this.tBox_Fogz_Std.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_Fogz_Std.Name = "tBox_Fogz_Std";
            this.tBox_Fogz_Std.Size = new System.Drawing.Size(89, 21);
            this.tBox_Fogz_Std.TabIndex = 16;
            // 
            // tBox_Fogy_Std
            // 
            this.tBox_Fogy_Std.Location = new System.Drawing.Point(567, 85);
            this.tBox_Fogy_Std.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_Fogy_Std.Name = "tBox_Fogy_Std";
            this.tBox_Fogy_Std.Size = new System.Drawing.Size(89, 21);
            this.tBox_Fogy_Std.TabIndex = 17;
            // 
            // tBox_Fogx_Std
            // 
            this.tBox_Fogx_Std.Location = new System.Drawing.Point(567, 58);
            this.tBox_Fogx_Std.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_Fogx_Std.Name = "tBox_Fogx_Std";
            this.tBox_Fogx_Std.Size = new System.Drawing.Size(89, 21);
            this.tBox_Fogx_Std.TabIndex = 18;
            // 
            // tBox_Accz_Std
            // 
            this.tBox_Accz_Std.Location = new System.Drawing.Point(566, 198);
            this.tBox_Accz_Std.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_Accz_Std.Name = "tBox_Accz_Std";
            this.tBox_Accz_Std.Size = new System.Drawing.Size(89, 21);
            this.tBox_Accz_Std.TabIndex = 22;
            // 
            // tBox_Accy_Std
            // 
            this.tBox_Accy_Std.Location = new System.Drawing.Point(566, 172);
            this.tBox_Accy_Std.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_Accy_Std.Name = "tBox_Accy_Std";
            this.tBox_Accy_Std.Size = new System.Drawing.Size(89, 21);
            this.tBox_Accy_Std.TabIndex = 23;
            // 
            // tBox_Accx_Std
            // 
            this.tBox_Accx_Std.Location = new System.Drawing.Point(566, 145);
            this.tBox_Accx_Std.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_Accx_Std.Name = "tBox_Accx_Std";
            this.tBox_Accx_Std.Size = new System.Drawing.Size(89, 21);
            this.tBox_Accx_Std.TabIndex = 24;
            // 
            // tBox_Accz_Com
            // 
            this.tBox_Accz_Com.Location = new System.Drawing.Point(464, 199);
            this.tBox_Accz_Com.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_Accz_Com.Name = "tBox_Accz_Com";
            this.tBox_Accz_Com.Size = new System.Drawing.Size(89, 21);
            this.tBox_Accz_Com.TabIndex = 19;
            // 
            // tBox_Accy_Com
            // 
            this.tBox_Accy_Com.Location = new System.Drawing.Point(464, 173);
            this.tBox_Accy_Com.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_Accy_Com.Name = "tBox_Accy_Com";
            this.tBox_Accy_Com.Size = new System.Drawing.Size(89, 21);
            this.tBox_Accy_Com.TabIndex = 20;
            // 
            // tBox_Accx_Com
            // 
            this.tBox_Accx_Com.Location = new System.Drawing.Point(464, 146);
            this.tBox_Accx_Com.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_Accx_Com.Name = "tBox_Accx_Com";
            this.tBox_Accx_Com.Size = new System.Drawing.Size(89, 21);
            this.tBox_Accx_Com.TabIndex = 21;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(376, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 25;
            this.label15.Text = "当前值";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(477, 34);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 25;
            this.label16.Text = "补偿值";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(575, 34);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 25;
            this.label17.Text = "稳定性";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1281, 830);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tBox_Accz_Std);
            this.Controls.Add(this.tBox_Accy_Std);
            this.Controls.Add(this.tBox_Accx_Std);
            this.Controls.Add(this.tBox_Accz_Com);
            this.Controls.Add(this.tBox_Accy_Com);
            this.Controls.Add(this.tBox_Accx_Com);
            this.Controls.Add(this.tBox_Fogz_Std);
            this.Controls.Add(this.tBox_Fogy_Std);
            this.Controls.Add(this.tBox_Fogx_Std);
            this.Controls.Add(this.tBox_Fogz_Com);
            this.Controls.Add(this.tBox_Fogy_Com);
            this.Controls.Add(this.tBox_Fogx_Com);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tBox_FogyT);
            this.Controls.Add(this.tBox_FogzT);
            this.Controls.Add(this.textBox_Info);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBox_FogxT);
            this.Controls.Add(this.tBox_Timer);
            this.Controls.Add(this.tBox_Counter);
            this.Controls.Add(this.tBox_AcczT);
            this.Controls.Add(this.tBox_AccyT);
            this.Controls.Add(this.tBox_AccxT);
            this.Controls.Add(this.tBox_FogZ);
            this.Controls.Add(this.tBox_AccZ);
            this.Controls.Add(this.tBox_FogY);
            this.Controls.Add(this.tBox_FogX);
            this.Controls.Add(this.tBox_AccY);
            this.Controls.Add(this.tBox_AccX);
            this.Controls.Add(this.InfoBox);
            this.Controls.Add(this.Btn_OpenSerial);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Timer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_OpenSerial;
        private System.Windows.Forms.TextBox InfoBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_SerialCfg;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.TextBox tBox_AccX;
        private System.Windows.Forms.TextBox tBox_AccY;
        private System.Windows.Forms.TextBox tBox_AccZ;
        private System.Windows.Forms.TextBox tBox_AccxT;
        private System.Windows.Forms.TextBox tBox_FogX;
        private System.Windows.Forms.TextBox tBox_FogY;
        private System.Windows.Forms.TextBox tBox_FogZ;
        private System.Windows.Forms.TextBox tBox_FogxT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_FileOperation;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_SaveAs;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_DataClear;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_ClearDirectory;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_ClearFile;
        private System.Windows.Forms.TextBox textBox_Info;
        private System.Windows.Forms.TextBox tBox_FogzT;
        private System.Windows.Forms.TextBox tBox_FogyT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tBox_AccyT;
        private System.Windows.Forms.TextBox tBox_AcczT;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tBox_Counter;
        private System.Windows.Forms.TextBox tBox_Timer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.TextBox tBox_Fogz_Com;
        private System.Windows.Forms.TextBox tBox_Fogy_Com;
        private System.Windows.Forms.TextBox tBox_Fogx_Com;
        private System.Windows.Forms.TextBox tBox_Fogz_Std;
        private System.Windows.Forms.TextBox tBox_Fogy_Std;
        private System.Windows.Forms.TextBox tBox_Fogx_Std;
        private System.Windows.Forms.TextBox tBox_Accz_Std;
        private System.Windows.Forms.TextBox tBox_Accy_Std;
        private System.Windows.Forms.TextBox tBox_Accx_Std;
        private System.Windows.Forms.TextBox tBox_Accz_Com;
        private System.Windows.Forms.TextBox tBox_Accy_Com;
        private System.Windows.Forms.TextBox tBox_Accx_Com;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}

