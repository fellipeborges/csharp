using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Notifier.Business;
using Notifier.Common;

namespace Notifier.UI
{
    static class Program
    {
        public static Initialization InitilizationInstsance
        {
            get
            {
                return _init;
            }
        }

        private static Initialization _init;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Notifier.UI.Forms.TestForm a = new Forms.TestForm();
            //a.ShowDialog();
            //Application.Exit();
            //return;

            //initialization
            _init = new Initialization();
            _init.CheckFolders();
            _init.ReadConfiguration();
            _init.SetLanguage();
            _init.AddToTray();
            _init.StartTimers();
            _init.CheckEventLogger();

            Application.Run();



        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            if (_init != null)
            {
                _init.RemoveFromTray();
            }
        }
    }
}
