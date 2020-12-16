namespace IMUSample
{
    partial class FrmSerialCfg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_OK = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.cmbox_SerialNum = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbox_BaudRate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbox__DataBit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbox_StopBit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbox_ParityBit = new System.Windows.Forms.ComboBox();
            this.textBox_imu_id = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButton_HighFreq = new System.Windows.Forms.CheckBox();
            this.radioButton_hexenable = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_updrate = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_isTest = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Btn_OK
            // 
            this.Btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Btn_OK.Location = new System.Drawing.Point(155, 64);
            this.Btn_OK.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_OK.Name = "Btn_OK";
            this.Btn_OK.Size = new System.Drawing.Size(58, 22);
            this.Btn_OK.TabIndex = 0;
            this.Btn_OK.Text = "确定(&O)";
            this.Btn_OK.UseVisualStyleBackColor = true;
            this.Btn_OK.Click += new System.EventHandler(this.Btn_OK_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_Cancel.Location = new System.Drawing.Point(155, 120);
            this.Btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(58, 22);
            this.Btn_Cancel.TabIndex = 1;
            this.Btn_Cancel.Text = "取消(&C)";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // cmbox_SerialNum
            // 
            this.cmbox_SerialNum.FormattingEnabled = true;
            this.cmbox_SerialNum.Location = new System.Drawing.Point(63, 45);
            this.cmbox_SerialNum.Margin = new System.Windows.Forms.Padding(2);
            this.cmbox_SerialNum.Name = "cmbox_SerialNum";
            this.cmbox_SerialNum.Size = new System.Drawing.Size(62, 20);
            this.cmbox_SerialNum.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "串口号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "波特率";
            // 
            // cmbox_BaudRate
            // 
            this.cmbox_BaudRate.FormattingEnabled = true;
            this.cmbox_BaudRate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "115200",
            "230400",
            "460800",
            "614400",
            "921600"});
            this.cmbox_BaudRate.Location = new System.Drawing.Point(63, 73);
            this.cmbox_BaudRate.Margin = new System.Windows.Forms.Padding(2);
            this.cmbox_BaudRate.Name = "cmbox_BaudRate";
            this.cmbox_BaudRate.Size = new System.Drawing.Size(62, 20);
            this.cmbox_BaudRate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "数据位";
            // 
            // cmbox__DataBit
            // 
            this.cmbox__DataBit.FormattingEnabled = true;
            this.cmbox__DataBit.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cmbox__DataBit.Location = new System.Drawing.Point(63, 101);
            this.cmbox__DataBit.Margin = new System.Windows.Forms.Padding(2);
            this.cmbox__DataBit.Name = "cmbox__DataBit";
            this.cmbox__DataBit.Size = new System.Drawing.Size(62, 20);
            this.cmbox__DataBit.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 130);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "停止位";
            // 
            // cmbox_StopBit
            // 
            this.cmbox_StopBit.FormattingEnabled = true;
            this.cmbox_StopBit.Items.AddRange(new object[] {
            "0.5",
            "1",
            "1.5",
            "2"});
            this.cmbox_StopBit.Location = new System.Drawing.Point(63, 129);
            this.cmbox_StopBit.Margin = new System.Windows.Forms.Padding(2);
            this.cmbox_StopBit.Name = "cmbox_StopBit";
            this.cmbox_StopBit.Size = new System.Drawing.Size(62, 20);
            this.cmbox_StopBit.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 158);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "校验位";
            // 
            // cmbox_ParityBit
            // 
            this.cmbox_ParityBit.FormattingEnabled = true;
            this.cmbox_ParityBit.Items.AddRange(new object[] {
            "odd",
            "none",
            "even"});
            this.cmbox_ParityBit.Location = new System.Drawing.Point(63, 157);
            this.cmbox_ParityBit.Margin = new System.Windows.Forms.Padding(2);
            this.cmbox_ParityBit.Name = "cmbox_ParityBit";
            this.cmbox_ParityBit.Size = new System.Drawing.Size(62, 20);
            this.cmbox_ParityBit.TabIndex = 10;
            // 
            // textBox_imu_id
            // 
            this.textBox_imu_id.Location = new System.Drawing.Point(72, 11);
            this.textBox_imu_id.Name = "textBox_imu_id";
            this.textBox_imu_id.Size = new System.Drawing.Size(100, 21);
            this.textBox_imu_id.TabIndex = 14;
            this.textBox_imu_id.Text = "001";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "惯组编号";
            // 
            // radioButton_HighFreq
            // 
            this.radioButton_HighFreq.AutoSize = true;
            this.radioButton_HighFreq.Location = new System.Drawing.Point(16, 238);
            this.radioButton_HighFreq.Name = "radioButton_HighFreq";
            this.radioButton_HighFreq.Size = new System.Drawing.Size(96, 16);
            this.radioButton_HighFreq.TabIndex = 16;
            this.radioButton_HighFreq.Text = "测试常温静态";
            this.radioButton_HighFreq.UseVisualStyleBackColor = true;
            // 
            // radioButton_hexenable
            // 
            this.radioButton_hexenable.AutoSize = true;
            this.radioButton_hexenable.Location = new System.Drawing.Point(16, 260);
            this.radioButton_hexenable.Name = "radioButton_hexenable";
            this.radioButton_hexenable.Size = new System.Drawing.Size(132, 16);
            this.radioButton_hexenable.TabIndex = 17;
            this.radioButton_hexenable.Text = "是否保存16进制数据";
            this.radioButton_hexenable.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 188);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "更新率";
            // 
            // comboBox_updrate
            // 
            this.comboBox_updrate.FormattingEnabled = true;
            this.comboBox_updrate.Items.AddRange(new object[] {
            "400",
            "200",
            "100",
            "50"});
            this.comboBox_updrate.Location = new System.Drawing.Point(63, 185);
            this.comboBox_updrate.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_updrate.Name = "comboBox_updrate";
            this.comboBox_updrate.Size = new System.Drawing.Size(62, 20);
            this.comboBox_updrate.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 216);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "测试状态";
            // 
            // comboBox_isTest
            // 
            this.comboBox_isTest.FormattingEnabled = true;
            this.comboBox_isTest.Items.AddRange(new object[] {
            "测试状态",
            "出厂状态"});
            this.comboBox_isTest.Location = new System.Drawing.Point(63, 213);
            this.comboBox_isTest.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_isTest.Name = "comboBox_isTest";
            this.comboBox_isTest.Size = new System.Drawing.Size(85, 20);
            this.comboBox_isTest.TabIndex = 20;
            // 
            // FrmSerialCfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 283);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox_isTest);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox_updrate);
            this.Controls.Add(this.radioButton_hexenable);
            this.Controls.Add(this.radioButton_HighFreq);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_imu_id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbox_ParityBit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbox_StopBit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbox__DataBit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbox_BaudRate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbox_SerialNum);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_OK);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmSerialCfg";
            this.Text = "串口配置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_OK;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.ComboBox cmbox_SerialNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbox_BaudRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbox__DataBit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbox_StopBit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbox_ParityBit;
        private System.Windows.Forms.TextBox textBox_imu_id;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox radioButton_HighFreq;
        private System.Windows.Forms.CheckBox radioButton_hexenable;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_updrate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox_isTest;
    }
}