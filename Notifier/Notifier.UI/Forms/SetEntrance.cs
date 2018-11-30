using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Notifier.Business;
using Notifier.Models;
using System.Text.RegularExpressions;
using Notifier.Common;
using Notifier.Localization;

namespace Notifier.UI.Forms
{
    public partial class SetEntrance : Form
    {
        bool _formLoaded = false;
        string _previousTimeFilled = "";

        public SetEntrance()
        {
            InitializeComponent();
        }

        private void SetEntrance_Load(object sender, EventArgs e)
        {
            FillLabels();
            LoadCurrentEntranceTime();
            _formLoaded = true;
        }

        private void FillLabels()
        {
            this.Text = LocalizationManager.GetText("SetEntrance_FormTitle");
            btnSet.Text = LocalizationManager.GetText("SetEntrance_SetButton");
        }

        private void LoadCurrentEntranceTime()
        {
            EntranceModel entranceModel = new EntranceManager().ReadEntranceOfDay(DateTime.Today);
            string timeToFill = "";
            if (entranceModel.Exists == true)
            {
                timeToFill = entranceModel.HourMinute;
                _previousTimeFilled = entranceModel.HourMinute;
            }
            else
            {
                timeToFill = Utilities.FormatWithTwoDigits(DateTime.Now.Hour) + ":" + Utilities.FormatWithTwoDigits(DateTime.Now.Minute);
            }
            txtMaskedTime.Text = timeToFill;
        }
        
        private bool SaveConfig()
        {
            if (!_formLoaded)
            {
                return false;
            }

            if (ValidateFields() == false)
            {
                return false;
            }

            if (SaveEntranceTime() == false)
            {
                return false;
            }

            //re-initialize timers
            Program.InitilizationInstsance.StartTimers();

            //Handle the "set entrance time" of the context menu
            Program.InitilizationInstsance.HandleContextMenuForEntrance();

            return true;
        }

        private bool ValidateFields()
        {
            //time set
            if (txtMaskedTime.Text != "")
            {
                if (IsValidTime(txtMaskedTime.Text) == false)
                {
                    MessageBox.Show(this, LocalizationManager.GetText("SetEntrance_Alert_InformValidTime"), LocalizationManager.GetText("General_Attention"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMaskedTime.Focus();
                    return false;
                }
            }
            return true;
        }

        private bool IsValidTime(string thetime)
        {
            Regex checktime = new Regex("^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$");
            return checktime.IsMatch(thetime);
        }

        private bool SaveEntranceTime()
        {
            EntranceManager entranceManager = new EntranceManager();
            if (entranceManager.SetEntranceOfDay(txtMaskedTime.Text, DateTime.Today) == false)
            {
                return false;
            }
            return true;
        }

        private void FormatTime()
        {
            if (txtMaskedTime.Text.Length == 4)
            {
                txtMaskedTime.Text = "0" + txtMaskedTime.Text;
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (_previousTimeFilled != txtMaskedTime.Text)
            {
                if (SaveConfig() == true)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
        private void txtMaskedTime_Validating(object sender, CancelEventArgs e)
        {
            FormatTime();
        }

        private void txtMaskedTime_TextChanged(object sender, EventArgs e)
        {
            SuggestLeavingTime();
        }

        private void SuggestLeavingTime()
        {
            string suggestedText = "";
            if (IsValidTime(txtMaskedTime.Text) == true && txtMaskedTime.Text.Length == 5)
            {
                TimeSpan entranceTime = new TimeSpan(Utilities.ReturnOnlyHour(txtMaskedTime.Text), Utilities.ReturnOnlyMinute(txtMaskedTime.Text), 0);
                TimeSpan workingTime = new TimeSpan(ConfigurationFIM.ConfigurationInstance.EndWorkDay.HourOnly, ConfigurationFIM.ConfigurationInstance.EndWorkDay.MinuteOnly, 0);
                TimeSpan leavingTime = entranceTime + workingTime;
                suggestedText = String.Format(LocalizationManager.GetText("SetEntrance_Alert_YouShouldLeaveAt"), Utilities.FormatWithTwoDigits(leavingTime.Hours) + ":" + Utilities.FormatWithTwoDigits(leavingTime.Minutes));
            }
            lblLeavingSuggestion.Text = suggestedText;
        }
        
    }
}
