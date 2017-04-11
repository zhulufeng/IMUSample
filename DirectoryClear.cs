using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IMUSample
{
    public partial class DirectoryClearDlg : Form
    {
        public DirectoryClearDlg()
        {
            InitializeComponent();
            DirectoryInfo dir = new DirectoryInfo(PathString.ClearDirectory);
            foreach (DirectoryInfo dChild in dir.GetDirectories("*"))
            {//如果用GetDirectories("ab*"),那么全部以ab开头的目录会被显示  
                checkListBox_DirList.Items.Add(dChild.ToString());

            }  
        }

        private void checkBox_SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkListBox_DirList.Items.Count; i++)
            {
                checkListBox_DirList.SetItemChecked(i, true);
            }
        }

        private void Btn_Del_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkListBox_DirList.CheckedItems.Count; i++)
            {
               // TBOX_Info.Text += checkList_DirList.CheckedItems[i].ToString() + "\r\n";
                DirectoryInfo dir = new DirectoryInfo(PathString.ClearDirectory + @"\" + checkListBox_DirList.CheckedItems[i].ToString());
                dir.Delete(true);
            }
            checkListBox_DirList.Items.Clear();
            DirectoryInfo dirinfo = new DirectoryInfo(PathString.ClearDirectory);
            foreach (DirectoryInfo dChild in dirinfo.GetDirectories("*"))
            {//如果用GetDirectories("ab*"),那么全部以ab开头的目录会被显示  
                checkListBox_DirList.Items.Add(dChild.ToString());
            }  
        }

        

        
    }
}
