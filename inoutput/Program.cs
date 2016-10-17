using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using log4net.Config;

namespace inoutput
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
            SetConfig();
            Application.Run(new frmMain());
        }

        private static void SetConfig()
        {
            XmlConfigurator.Configure(new FileInfo("log4net.xml"));
        }
    }
}
