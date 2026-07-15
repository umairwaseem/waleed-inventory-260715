using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ncsln
{
    enum SoftwareType { Master, OfficeMaster, WorldStyle, OfficenOffice, OfficeEmpire};
    enum SetupVersions { Full, HBC, Manufacturing };
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.frmLogin());
            //if (Ncsln.Properties.Settings.Default.AppKey == "")
            //    Application.Run(new Forms.frmGetVerify());
            //else
            //    Application.Run(new Forms.frmLogin());
        }
    }
}
