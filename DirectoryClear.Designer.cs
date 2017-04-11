namespace IMUSample
{
    partial class DirectoryClearDlg
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
            this.checkListBox_DirList = new System.Windows.Forms.CheckedListBox();
            this.checkBox_SelectAll = new System.Windows.Forms.CheckBox();
            this.Btn_Del = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkListBox_DirList
            // 
            this.checkListBox_DirList.CheckOnClick = true;
            this.checkListBox_DirList.FormattingEnabled = true;
            this.checkListBox_DirList.HorizontalScrollbar = true;
            this.checkListBox_DirList.Location = new System.Drawing.Point(33, 44);
            this.checkListBox_DirList.Name = "checkListBox_DirList";
            this.checkListBox_DirList.ScrollAlwaysVisible = true;
            this.checkListBox_DirList.Size = new System.Drawing.Size(418, 544);
            this.checkListBox_DirList.TabIndex = 0;
            // 
            // checkBox_SelectAll
            // 
            this.checkBox_SelectAll.AutoSize = true;
            this.checkBox_SelectAll.Location = new System.Drawing.Point(44, 629);
            this.checkBox_SelectAll.Name = "checkBox_SelectAll";
            this.checkBox_SelectAll.Size = new System.Drawing.Size(162, 28);
            this.checkBox_SelectAll.TabIndex = 1;
            this.checkBox_SelectAll.Text = "Select All";
            this.checkBox_SelectAll.UseVisualStyleBackColor = true;
            this.checkBox_SelectAll.CheckedChanged += new System.EventHandler(this.checkBox_SelectAll_CheckedChanged);
            // 
            // Btn_Del
            // 
            this.Btn_Del.Location = new System.Drawing.Point(274, 617);
            this.Btn_Del.Name = "Btn_Del";
            this.Btn_Del.Size = new System.Drawing.Size(177, 52);
            this.Btn_Del.TabIndex = 2;
            this.Btn_Del.Text = "删除文件";
            this.Btn_Del.UseVisualStyleBackColor = true;
            this.Btn_Del.Click += new System.EventHandler(this.Btn_Del_Click);
            // 
            // DirectoryClearDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 704);
            this.Controls.Add(this.Btn_Del);
            this.Controls.Add(this.checkBox_SelectAll);
            this.Controls.Add(this.checkListBox_DirList);
            this.Name = "DirectoryClearDlg";
            this.Text = "清除文件夹";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkListBox_DirList;
        private System.Windows.Forms.CheckBox checkBox_SelectAll;
        private System.Windows.Forms.Button Btn_Del;
    }
}