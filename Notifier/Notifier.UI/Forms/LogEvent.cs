using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Notifier.Business;
using System.Deployment.Application;

namespace Notifier.UI.Forms
{
    public partial class LogEvent : Form
    {
        public LogEvent()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
        }

        private void tmrLog_Tick(object sender, EventArgs e)
        {
            ReadLog();
        }

        private void ReadLog()
        {
            List<Guid> itemsToRemove = new List<Guid>();
            foreach (KeyValuePair<Guid, string> item in EventLogger.Logs)
            {
                txtLog.Text = item.Value.ToString() + "\r\n" + txtLog.Text;
                itemsToRemove.Add(item.Key);
            }
            foreach (Guid item in itemsToRemove)
            {
                EventLogger.RemoveLog(item);
            }
        }

        private void LogEvent_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("Event Logger - {0}", ConfigurationFIM.PublishVersion);
        }
    }
}