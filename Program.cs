using System;
using System.Windows.Forms;
using DMessager.Utils;

namespace DMessager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //projectSettings
            ResourcesManager.ProjectName = "DMessager";
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AuthForm());
            //Application.Run(new MainForm());
        }
    }
}