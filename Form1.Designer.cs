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
            this.tBox_AccT = new System.Windows.Forms.TextBox();
            this.tBox_FogX = new System.Windows.Forms.TextBox();
            this.tBox_FogY = new System.Windows.Forms.TextBox();
            this.tBox_FogZ = new System.Windows.Forms.TextBox();
            this.tBox_FogT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_Info = new System.Windows.Forms.TextBox();
            this.Btn_Pos0_First = new System.Windows.Forms.Button();
            this.Btn_Pos2 = new System.Windows.Forms.Button();
            this.Btn_Pos1 = new System.Windows.Forms.Button();
            this.Btn_Pos3 = new System.Windows.Forms.Button();
            this.Btn_Pos4 = new System.Windows.Forms.Button();
            this.Btn_Pos5 = new System.Windows.Forms.Button();
            this.Btn_Pos6 = new System.Windows.Forms.Button();
            this.Btn_Pos7 = new System.Windows.Forms.Button();
            this.Btn_Pos8 = new System.Windows.Forms.Button();
            this.Btn_Pos0_Last = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_OpenSerial
            // 
            this.Btn_OpenSerial.Location = new System.Drawing.Point(173, 47);
            this.Btn_OpenSerial.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_OpenSerial.Name = "Btn_OpenSerial";
            this.Btn_OpenSerial.Size = new System.Drawing.Size(121, 50);
            this.Btn_OpenSerial.TabIndex = 1;
            this.Btn_OpenSerial.Text = "打开串口";
            this.Btn_OpenSerial.UseVisualStyleBackColor = true;
            this.Btn_OpenSerial.Click += new System.EventHandler(this.Btn_OpenSerial_Click);
            // 
            // InfoBox
            // 
            this.InfoBox.BackColor = System.Drawing.SystemColors.Menu;
            this.InfoBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InfoBox.Location = new System.Drawing.Point(8, 35);
            this.InfoBox.Margin = new System.Windows.Forms.Padding(2);
            this.InfoBox.Multiline = true;
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InfoBox.Size = new System.Drawing.Size(160, 130);
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1148, 26);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItem_SerialCfg
            // 
            this.MenuItem_SerialCfg.Name = "MenuItem_SerialCfg";
            this.MenuItem_SerialCfg.Size = new System.Drawing.Size(100, 24);
            this.MenuItem_SerialCfg.Text = "串口设置(&S)";
            this.MenuItem_SerialCfg.Click += new System.EventHandler(this.MenuItem_SerialCfg_Click);
            // 
            // MenuItem_FileOperation
            // 
            this.MenuItem_FileOperation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_SaveAs,
            this.MenuItem_DataClear});
            this.MenuItem_FileOperation.Name = "MenuItem_FileOperation";
            this.MenuItem_FileOperation.Size = new System.Drawing.Size(99, 24);
            this.MenuItem_FileOperation.Text = "文件操作(&F)";
            // 
            // MenuItem_SaveAs
            // 
            this.MenuItem_SaveAs.Name = "MenuItem_SaveAs";
            this.MenuItem_SaveAs.Size = new System.Drawing.Size(194, 26);
            this.MenuItem_SaveAs.Text = "文件另存(&S)";
            // 
            // MenuItem_DataClear
            // 
            this.MenuItem_DataClear.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_ClearDirectory,
            this.MenuItem_ClearFile});
            this.MenuItem_DataClear.Name = "MenuItem_DataClear";
            this.MenuItem_DataClear.Size = new System.Drawing.Size(194, 26);
            this.MenuItem_DataClear.Text = "数据文件清除(&C)";
            // 
            // MenuItem_ClearDirectory
            // 
            this.MenuItem_ClearDirectory.Name = "MenuItem_ClearDirectory";
            this.MenuItem_ClearDirectory.Size = new System.Drawing.Size(180, 26);
            this.MenuItem_ClearDirectory.Text = "清除文件夹(&D)";
            this.MenuItem_ClearDirectory.Click += new System.EventHandler(this.MenuItem_ClearDirectory_Click);
            // 
            // MenuItem_ClearFile
            // 
            this.MenuItem_ClearFile.Name = "MenuItem_ClearFile";
            this.MenuItem_ClearFile.Size = new System.Drawing.Size(180, 26);
            this.MenuItem_ClearFile.Text = "清除文件(&F)";
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // tBox_AccX
            // 
            this.tBox_AccX.Location = new System.Drawing.Point(714, 63);
            this.tBox_AccX.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_AccX.Name = "tBox_AccX";
            this.tBox_AccX.Size = new System.Drawing.Size(117, 25);
            this.tBox_AccX.TabIndex = 6;
            // 
            // tBox_AccY
            // 
            this.tBox_AccY.Location = new System.Drawing.Point(714, 97);
            this.tBox_AccY.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_AccY.Name = "tBox_AccY";
            this.tBox_AccY.Size = new System.Drawing.Size(117, 25);
            this.tBox_AccY.TabIndex = 6;
            // 
            // tBox_AccZ
            // 
            this.tBox_AccZ.Location = new System.Drawing.Point(714, 130);
            this.tBox_AccZ.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_AccZ.Name = "tBox_AccZ";
            this.tBox_AccZ.Size = new System.Drawing.Size(117, 25);
            this.tBox_AccZ.TabIndex = 6;
            // 
            // tBox_AccT
            // 
            this.tBox_AccT.Location = new System.Drawing.Point(714, 163);
            this.tBox_AccT.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_AccT.Name = "tBox_AccT";
            this.tBox_AccT.Size = new System.Drawing.Size(117, 25);
            this.tBox_AccT.TabIndex = 6;
            // 
            // tBox_FogX
            // 
            this.tBox_FogX.Location = new System.Drawing.Point(483, 63);
            this.tBox_FogX.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_FogX.Name = "tBox_FogX";
            this.tBox_FogX.Size = new System.Drawing.Size(117, 25);
            this.tBox_FogX.TabIndex = 6;
            // 
            // tBox_FogY
            // 
            this.tBox_FogY.Location = new System.Drawing.Point(483, 97);
            this.tBox_FogY.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_FogY.Name = "tBox_FogY";
            this.tBox_FogY.Size = new System.Drawing.Size(117, 25);
            this.tBox_FogY.TabIndex = 6;
            // 
            // tBox_FogZ
            // 
            this.tBox_FogZ.Location = new System.Drawing.Point(483, 130);
            this.tBox_FogZ.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_FogZ.Name = "tBox_FogZ";
            this.tBox_FogZ.Size = new System.Drawing.Size(117, 25);
            this.tBox_FogZ.TabIndex = 6;
            // 
            // tBox_FogT
            // 
            this.tBox_FogT.Location = new System.Drawing.Point(483, 163);
            this.tBox_FogT.Margin = new System.Windows.Forms.Padding(2);
            this.tBox_FogT.Name = "tBox_FogT";
            this.tBox_FogT.Size = new System.Drawing.Size(117, 25);
            this.tBox_FogT.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(424, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "FogX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "FogY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 132);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "FogZ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(424, 163);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "FogT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(650, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "AccX";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(650, 102);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "AccY";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(650, 133);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "AccZ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(650, 164);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "AccT";
            // 
            // textBox_Info
            // 
            this.textBox_Info.Location = new System.Drawing.Point(11, 181);
            this.textBox_Info.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Info.Multiline = true;
            this.textBox_Info.Name = "textBox_Info";
            this.textBox_Info.Size = new System.Drawing.Size(360, 483);
            this.textBox_Info.TabIndex = 8;
            // 
            // Btn_Pos0_First
            // 
            this.Btn_Pos0_First.Location = new System.Drawing.Point(376, 219);
            this.Btn_Pos0_First.Name = "Btn_Pos0_First";
            this.Btn_Pos0_First.Size = new System.Drawing.Size(160, 40);
            this.Btn_Pos0_First.TabIndex = 10;
            this.Btn_Pos0_First.Text = "位置0-静止状态";
            this.Btn_Pos0_First.UseVisualStyleBackColor = true;
            this.Btn_Pos0_First.Click += new System.EventHandler(this.Btn_Pos0_First_Click);
            // 
            // Btn_Pos2
            // 
            this.Btn_Pos2.Location = new System.Drawing.Point(376, 309);
            this.Btn_Pos2.Name = "Btn_Pos2";
            this.Btn_Pos2.Size = new System.Drawing.Size(160, 40);
            this.Btn_Pos2.TabIndex = 10;
            this.Btn_Pos2.Text = "位置2-静止状态";
            this.Btn_Pos2.UseVisualStyleBackColor = true;
            this.Btn_Pos2.Click += new System.EventHandler(this.Btn_Pos2_Click);
            // 
            // Btn_Pos1
            // 
            this.Btn_Pos1.Location = new System.Drawing.Point(376, 264);
            this.Btn_Pos1.Name = "Btn_Pos1";
            this.Btn_Pos1.Size = new System.Drawing.Size(160, 40);
            this.Btn_Pos1.TabIndex = 10;
            this.Btn_Pos1.Text = "位置1-静止状态";
            this.Btn_Pos1.UseVisualStyleBackColor = true;
            this.Btn_Pos1.Click += new System.EventHandler(this.Btn_Pos1_Click);
            // 
            // Btn_Pos3
            // 
            this.Btn_Pos3.Location = new System.Drawing.Point(376, 354);
            this.Btn_Pos3.Name = "Btn_Pos3";
            this.Btn_Pos3.Size = new System.Drawing.Size(160, 40);
            this.Btn_Pos3.TabIndex = 11;
            this.Btn_Pos3.Text = "位置3-静止状态";
            this.Btn_Pos3.UseVisualStyleBackColor = true;
            this.Btn_Pos3.Click += new System.EventHandler(this.Btn_Pos3_Click);
            // 
            // Btn_Pos4
            // 
            this.Btn_Pos4.Location = new System.Drawing.Point(376, 399);
            this.Btn_Pos4.Name = "Btn_Pos4";
            this.Btn_Pos4.Size = new System.Drawing.Size(160, 40);
            this.Btn_Pos4.TabIndex = 12;
            this.Btn_Pos4.Text = "位置4-静止状态";
            this.Btn_Pos4.UseVisualStyleBackColor = true;
            this.Btn_Pos4.Click += new System.EventHandler(this.Btn_Pos4_Click);
            // 
            // Btn_Pos5
            // 
            this.Btn_Pos5.Location = new System.Drawing.Point(376, 444);
            this.Btn_Pos5.Name = "Btn_Pos5";
            this.Btn_Pos5.Size = new System.Drawing.Size(160, 40);
            this.Btn_Pos5.TabIndex = 13;
            this.Btn_Pos5.Text = "位置5-静止状态";
            this.Btn_Pos5.UseVisualStyleBackColor = true;
            this.Btn_Pos5.Click += new System.EventHandler(this.Btn_Pos5_Click);
            // 
            // Btn_Pos6
            // 
            this.Btn_Pos6.Location = new System.Drawing.Point(376, 489);
            this.Btn_Pos6.Name = "Btn_Pos6";
            this.Btn_Pos6.Size = new System.Drawing.Size(160, 40);
            this.Btn_Pos6.TabIndex = 14;
            this.Btn_Pos6.Text = "位置6-静止状态";
            this.Btn_Pos6.UseVisualStyleBackColor = true;
            this.Btn_Pos6.Click += new System.EventHandler(this.Btn_Pos6_Click);
            // 
            // Btn_Pos7
            // 
            this.Btn_Pos7.Location = new System.Drawing.Point(376, 534);
            this.Btn_Pos7.Name = "Btn_Pos7";
            this.Btn_Pos7.Size = new System.Drawing.Size(160, 40);
            this.Btn_Pos7.TabIndex = 15;
            this.Btn_Pos7.Text = "位置7-静止状态";
            this.Btn_Pos7.UseVisualStyleBackColor = true;
            this.Btn_Pos7.Click += new System.EventHandler(this.Btn_Pos7_Click);
            // 
            // Btn_Pos8
            // 
            this.Btn_Pos8.Location = new System.Drawing.Point(376, 579);
            this.Btn_Pos8.Name = "Btn_Pos8";
            this.Btn_Pos8.Size = new System.Drawing.Size(160, 40);
            this.Btn_Pos8.TabIndex = 16;
            this.Btn_Pos8.Text = "位置8-静止状态";
            this.Btn_Pos8.UseVisualStyleBackColor = true;
            this.Btn_Pos8.Click += new System.EventHandler(this.Btn_Pos8_Click);
            // 
            // Btn_Pos0_Last
            // 
            this.Btn_Pos0_Last.Location = new System.Drawing.Point(376, 624);
            this.Btn_Pos0_Last.Name = "Btn_Pos0_Last";
            this.Btn_Pos0_Last.Size = new System.Drawing.Size(160, 40);
            this.Btn_Pos0_Last.TabIndex = 17;
            this.Btn_Pos0_Last.Text = "位置0-静止状态";
            this.Btn_Pos0_Last.UseVisualStyleBackColor = true;
            this.Btn_Pos0_Last.Click += new System.EventHandler(this.Btn_Pos0_Last_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(173, 116);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(121, 49);
            this.button11.TabIndex = 18;
            this.button11.Text = "开始标定...";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1148, 683);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.Btn_Pos0_Last);
            this.Controls.Add(this.Btn_Pos8);
            this.Controls.Add(this.Btn_Pos7);
            this.Controls.Add(this.Btn_Pos6);
            this.Controls.Add(this.Btn_Pos5);
            this.Controls.Add(this.Btn_Pos4);
            this.Controls.Add(this.Btn_Pos3);
            this.Controls.Add(this.Btn_Pos1);
            this.Controls.Add(this.Btn_Pos2);
            this.Controls.Add(this.Btn_Pos0_First);
            this.Controls.Add(this.textBox_Info);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBox_FogT);
            this.Controls.Add(this.tBox_AccT);
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
            this.Text = "简易标定采集软件";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.TextBox tBox_AccT;
        private System.Windows.Forms.TextBox tBox_FogX;
        private System.Windows.Forms.TextBox tBox_FogY;
        private System.Windows.Forms.TextBox tBox_FogZ;
        private System.Windows.Forms.TextBox tBox_FogT;
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
        private System.Windows.Forms.Button Btn_Pos0_First;
        private System.Windows.Forms.Button Btn_Pos2;
        private System.Windows.Forms.Button Btn_Pos1;
        private System.Windows.Forms.Button Btn_Pos3;
        private System.Windows.Forms.Button Btn_Pos4;
        private System.Windows.Forms.Button Btn_Pos5;
        private System.Windows.Forms.Button Btn_Pos6;
        private System.Windows.Forms.Button Btn_Pos7;
        private System.Windows.Forms.Button Btn_Pos8;
        private System.Windows.Forms.Button Btn_Pos0_Last;
        private System.Windows.Forms.Button button11;
    }
}

