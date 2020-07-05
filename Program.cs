using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IMUSample
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            String dt = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            //Initial(dt);
            Application.Run(new Form1());
        }
        static void Initial(String dt)
        {
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
            
        }
    }
}
