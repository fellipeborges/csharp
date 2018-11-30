using System;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using Notifier.Business;
using Notifier.Common;
using System.Drawing;
using Notifier.UI.UserControls;
using Notifier.Localization;

namespace Notifier.UI.Forms
{
    public partial class ConfigurationForm : Form
    {
        bool _formLoaded = false;

        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            FillLabels();
            LoadGeneralSavedConfiguration();
            LoadPanelLunchLeaving();
            LoadPanelLunchReturning();
            LoadPanelEndOfWorkDay();
            _formLoaded = true;
        }

        private void FillLabels()
        {
            this.Text = string.Format("{0} - {1}", LocalizationManager.GetText("Config_FormTitle"), ConfigurationFIM.PublishVersion);
            lblGeneral.Text = LocalizationManager.GetText("Config_General");
            chkStartsWithWindows.Text = LocalizationManager.GetText("Config_StartWithWindows");
            chkUseAnimation.Text = LocalizationManager.GetText("Config_UseAnimation");
            lblLanguage.Text = LocalizationManager.GetText("Config_Language");
        }

        private void LoadPanelLunchLeaving()
        {
            ConfiguracoesUserControlLabels labels = new ConfiguracoesUserControlLabels();
            labels.Title = LocalizationManager.GetText("Config_LunchLeaving_Title");
            labels.TestAlert = LocalizationManager.GetText("Config_LunchLeaving_TestAlert");
            labels.Time = LocalizationManager.GetText("Config_LunchLeaving_Time");
            labels.WarnMe = LocalizationManager.GetText("Config_LunchLeaving_WarnMe");
            labels.WarnMeAfter = LocalizationManager.GetText("Config_LunchLeaving_WarnMeAfter");
            labels.Color = LocalizationManager.GetText("Config_LunchLeaving_Color");
            labels.WarnSound = LocalizationManager.GetText("Config_LunchLeaving_WarnSound");
            labels.WarnImage = LocalizationManager.GetText("Config_LunchLeaving_WarnImage");
            labels.MessageForMissingSound = LocalizationManager.GetText("Config_LunchLeaving_MessageForMissingSound");
            labels.MessageForMissingImage = LocalizationManager.GetText("Config_LunchLeaving_MessageForMissingImage");
            configLunchLeaving.SetInitialInformation(ConfigurationFIM.ConfigurationInstance.LunchLeaving, NotifierEnums.AlertKind.LunchLeaving, labels);
        }

        private void LoadPanelLunchReturning()
        {
            ConfiguracoesUserControlLabels labels = new ConfiguracoesUserControlLabels();
            labels.Title = LocalizationManager.GetText("Config_LunchReturning_Title");
            labels.TestAlert = LocalizationManager.GetText("Config_LunchReturning_TestAlert");
            labels.Time = LocalizationManager.GetText("Config_LunchReturning_Time");
            labels.WarnMe = LocalizationManager.GetText("Config_LunchReturning_WarnMe");
            labels.WarnMeAfter = LocalizationManager.GetText("Config_LunchReturning_WarnMeAfter");
            labels.Color = LocalizationManager.GetText("Config_LunchReturning_Color");
            labels.WarnSound = LocalizationManager.GetText("Config_LunchReturning_WarnSound");
            labels.WarnImage = LocalizationManager.GetText("Config_LunchReturning_WarnImage");
            labels.MessageForMissingSound = LocalizationManager.GetText("Config_LunchReturning_MessageForMissingSound");
            labels.MessageForMissingImage = LocalizationManager.GetText("Config_LunchReturning_MessageForMissingImage");
            configLunchReturning.SetInitialInformation(ConfigurationFIM.ConfigurationInstance.LunchReturning, NotifierEnums.AlertKind.LunchReturning, labels);
        }

        private void LoadPanelEndOfWorkDay()
        {
            ConfiguracoesUserControlLabels labels = new ConfiguracoesUserControlLabels();
            labels.Title = LocalizationManager.GetText("Config_EndOfWorkDay_Title");
            labels.TestAlert = LocalizationManager.GetText("Config_EndOfWorkDay_TestAlert");
            labels.Time = LocalizationManager.GetText("Config_EndOfWorkDay_Time");
            labels.WarnMe = LocalizationManager.GetText("Config_EndOfWorkDay_WarnMe");
            labels.WarnMeAfter = LocalizationManager.GetText("Config_EndOfWorkDay_WarnMeAfter");
            labels.Color = LocalizationManager.GetText("Config_EndOfWorkDay_Color");
            labels.WarnSound = LocalizationManager.GetText("Config_EndOfWorkDay_WarnSound");
            labels.WarnImage = LocalizationManager.GetText("Config_EndOfWorkDay_WarnImage");
            labels.MessageForMissingSound = LocalizationManager.GetText("Config_EndOfWorkDay_MessageForMissingSound");
            labels.MessageForMissingImage = LocalizationManager.GetText("Config_EndOfWorkDay_MessageForMissingImage");
            configEndOfDay.SetInitialInformation(ConfigurationFIM.ConfigurationInstance.EndWorkDay, NotifierEnums.AlertKind.EndWorkDay, labels);
        }
        

        private void LoadGeneralSavedConfiguration()
        {
            chkStartsWithWindows.Checked = (ConfigurationFIM.ConfigurationInstance.StartWithWindows == true);
            chkUseAnimation.Checked = (ConfigurationFIM.ConfigurationInstance.UseAnimation == true);
            cboLanguage.SelectedIndex = (int)(ConfigurationFIM.ConfigurationInstance.Language);
        }

        private bool SaveConfig()
        {
            if (!_formLoaded)
            {
                return false;
            }
            
            //save the configuration
            if (SaveConfiguration() == false)
            {
                return false;
            }

            //handle the windows startup setting
            HandleWindowsStartup();

            //re-initialize timers
            Program.InitilizationInstsance.StartTimers();

            //Handle the "set entrance time" of the context menu
            Program.InitilizationInstsance.HandleContextMenuForEntrance();

            return true;
        }

        private void HandleWindowsStartup()
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (ConfigurationFIM.ConfigurationInstance.StartWithWindows)
            {
                rkApp.SetValue(NotifierConstants.APP_KEYNAME, Application.ExecutablePath.ToString());
            }
            else
            {
                rkApp.DeleteValue(NotifierConstants.APP_KEYNAME, false);
            }
        }

        private bool SaveConfiguration()
        {
            ConfigurationFIM.ConfigurationInstance.StartWithWindows = (chkStartsWithWindows.Checked == true);
            ConfigurationFIM.ConfigurationInstance.UseAnimation = (chkUseAnimation.Checked == true);
            ConfigurationFIM.ConfigurationInstance.Language = (NotifierEnums.Language)(cboLanguage.SelectedIndex);
            ConfigurationFIM.SaveConfigurationToFile();

            if (configLunchLeaving.SaveConfiguration() == false)
            {
                return false;
            }
            if (configLunchReturning.SaveConfiguration() == false)
            {
                return false;
            }
            if (configEndOfDay.SaveConfiguration() == false)
            {
                return false;
            }

            return true;
        }        

        private void ConfigurationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SaveConfig() == false)
            {
                e.Cancel = true;
            }
        }

        private void cboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_formLoaded)
            {
                return;
            }
            //if it's the same language it's already set, does not show the message
            if ((int)ConfigurationFIM.ConfigurationInstance.Language == (int)cboLanguage.SelectedIndex)
            {
                return;
            }
            MessageBox.Show(this, LocalizationManager.GetText("Config_ChangeLanguageMessage"), LocalizationManager.GetText("General_Attention"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chkUseAnimation_CheckedChanged(object sender, EventArgs e)
        {
            SaveConfig();
        }
    }
}
