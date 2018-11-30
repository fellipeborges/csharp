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
using Notifier.Common;
using Notifier.Models;
using System.IO;
using Notifier.Localization;

namespace Notifier.UI.Forms
{
    public partial class Alert : Form
    {
        public NotifierEnums.AlertKind AlertKind { get; set; }
        public DateTime DateTimeTarget { get; set; }
        public PostponeModel PostponeInfo { get; set; }
        
        private ConfigurationDetailModel _configurationDetailInstance;

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        public Alert()
        {
            InitializeComponent();
        }
        
        private void AlertForm_Load(object sender, EventArgs e)
        {
            ConfigureTopMost();
            FillLabels();
            LoadMinutesOnCombo();
            DefineConfigurationModel();
            SetObjectsBackgroundColor();
            LoadConfiguration();
            SetFormInitialPosition();
            ShowAlert();
            Program.InitilizationInstsance.SetIcon(true);
        }

        private void ConfigureTopMost()
        {
            this.TopLevel = true;
            this.TopMost = true;
        }

        private void LoadMinutesOnCombo()
        {
            string minutes = LocalizationManager.GetText("AlertForm_MinutesList");
            string[] minutesArray = minutes.Split(',');
            foreach (string s in minutesArray)
            {
                cboMinutesToWarnAgain.Items.Add(s);
            }
        }

        private void FillLabels()
        {
            btnPostpone.Text = LocalizationManager.GetText("AlertForm_PostponeButton");
            btnDiscard.Text = LocalizationManager.GetText("AlertForm_DiscardButton");
        }

        private void DefineConfigurationModel()
        {
            if (this.AlertKind == NotifierEnums.AlertKind.LunchLeaving)
            {
                _configurationDetailInstance = ConfigurationFIM.ConfigurationInstance.LunchLeaving;
            }
            else if (this.AlertKind == NotifierEnums.AlertKind.LunchReturning)
            {
                _configurationDetailInstance = ConfigurationFIM.ConfigurationInstance.LunchReturning;
            }
            else if (this.AlertKind == NotifierEnums.AlertKind.EndWorkDay)
            {
                _configurationDetailInstance = ConfigurationFIM.ConfigurationInstance.EndWorkDay;
            }
        }

        private void SetObjectsBackgroundColor()
        {
            panSuperiorLine.BackColor = returnColor();
            pictureBoxImage.BackColor = returnColor();
        }

        private Color returnColor()
        {
            Color lineColor;
            try
            {
                lineColor = ColorTranslator.FromHtml(_configurationDetailInstance.RgbColor);
            }
            catch (Exception)
            {
                lineColor = ColorTranslator.FromHtml(NotifierConstants.DEFAULT_COLOR_FOR_BACKGROUND);
            }
            return lineColor;
        }

        private void SetFormInitialPosition()
        {
            this.Location = new Point(9999, 9999);
        }

        //Dropshadow
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= NotifierConstants.DROPSHADOW;
                return cp;
            }
        }

        private void AlertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.InitilizationInstsance.SetIcon(false);
        }

        private void MoveToFormPosition()
        {
            Rectangle workingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            int finalLeft = workingArea.Width - this.Width - 10;
            int finalTop = workingArea.Height - this.Height - 10;

            if (ConfigurationFIM.ConfigurationInstance.UseAnimation == true)
            {
                int initialTop = finalTop + this.Height;
                this.Location = new Point(finalLeft, initialTop);
                int currentTop = initialTop;
                while (currentTop > finalTop)
                {
                    currentTop = currentTop - 3;
                    this.Location = new Point(finalLeft, currentTop);
                    Application.DoEvents();
                }
            }
            else
            {
                this.Location = new Point(finalLeft, finalTop);
            }
        }

        private void LoadConfiguration()
        {
            int minutesToWarnAgain = 5;
            minutesToWarnAgain = _configurationDetailInstance.MinutesToWarnAgain;
            if (minutesToWarnAgain < 1 || minutesToWarnAgain > 10)
            {
                minutesToWarnAgain = 5;
            }
            cboMinutesToWarnAgain.SelectedIndex = (minutesToWarnAgain - 1);
        }

        private void ShowAlert()
        {
            SetLabels();
            SetSound();
        }

        private void SetLabels()
        {
            //Calculate the quantity of minutes between now and the alarm time
            //int hourOnly = _configurationDetailInstance.HourOnly;
            //int minuteOnly = _configurationDetailInstance.MinuteOnly;
            string timeFormatedHHMM = GetFormatedTarget();
            int hourOnly = Utilities.ReturnOnlyHour(timeFormatedHHMM);
            int minuteOnly = Utilities.ReturnOnlyMinute(timeFormatedHHMM);
            TimeSpan span = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hourOnly, minuteOnly, 0) - new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            int qtyMinutes = (int)span.TotalMinutes;

            //Define the text based on the qty of minutes
            string descriptionPart1 = "";
            if (qtyMinutes == 0)
            {
                descriptionPart1 = LocalizationManager.GetText("AlertForm_ItsNowThe");
            }
            else if (qtyMinutes == 1)
            {
                descriptionPart1 = LocalizationManager.GetText("AlertForm_MissingOneMinuteFor");
            }
            else if (qtyMinutes > 1)
            {
                descriptionPart1 = String.Format(LocalizationManager.GetText("AlertForm_MissingXMinutesFor"), qtyMinutes);
            }
            else if (qtyMinutes == -1)
            {
                descriptionPart1 = LocalizationManager.GetText("AlertForm_YouAreOneMinuteLateFor");
            }
            else
            {
                descriptionPart1 = String.Format(LocalizationManager.GetText("AlertForm_YouAreXMinutesLateFor"), (qtyMinutes * -1));
            }

            //Define the texts
            string title = "";
            string descriptionPart2 = "";

            if (this.AlertKind == NotifierEnums.AlertKind.LunchLeaving)
            {
                title = String.Format(LocalizationManager.GetText("AlertForm_LunchLeavingTitle"), timeFormatedHHMM);
                descriptionPart2 = LocalizationManager.GetText("AlertForm_LunchLeavingDescription");
            }
            else if (this.AlertKind == NotifierEnums.AlertKind.LunchReturning)
            {
                title = String.Format(LocalizationManager.GetText("AlertForm_LunchReturningTitle"), timeFormatedHHMM);
                descriptionPart2 = LocalizationManager.GetText("AlertForm_LunchReturningDescription");
            }
            else if (this.AlertKind == NotifierEnums.AlertKind.EndWorkDay)
            {
                title = String.Format(LocalizationManager.GetText("AlertForm_EndOfWorkDayTitle"), timeFormatedHHMM);
                descriptionPart2 = LocalizationManager.GetText("AlertForm_EndOfWorkDayDescription");
            }
            lblTitle.Text = title;
            lblDescription.Text = descriptionPart1 + " " + descriptionPart2;
        }

        //
        private string GetFormatedTarget()
        {
            string timeFormated = Utilities.FormatWithTwoDigits(this.DateTimeTarget.Hour);
            timeFormated += ":";
            timeFormated += Utilities.FormatWithTwoDigits(this.DateTimeTarget.Minute);
            return timeFormated;
        }

        private void SetImage()
        {
            string customImage = "";
            customImage = _configurationDetailInstance.ImageCustomized;
            if (File.Exists(customImage))
            {
                pictureBoxImage.ImageLocation = customImage;
            }
            else
            {
                pictureBoxImage.Image = Properties.Resources.ImgAlertInverted;
            }
            Application.DoEvents();
            pictureBoxImage.Visible = true;
        }

        private void SetSound()
        {
            Notifier.UI.Classes.SoundPlayer.PlaySound(_configurationDetailInstance);
        }

        private void btnPostpone_Click(object sender, EventArgs e)
        {
            Postpone();
        }

        private void Postpone()
        {
            int minutesToWarnAgain = cboMinutesToWarnAgain.SelectedIndex + 1;

            //configuration
            _configurationDetailInstance.MinutesToWarnAgain = minutesToWarnAgain;
            ConfigurationFIM.SaveConfigurationToFile();

            //postpone info
            PostponeModel postponeInfo = new PostponeModel
            {
                TimeToWarn = DateTime.Now.AddMinutes(minutesToWarnAgain),
                AlertKind = this.AlertKind
            };

            this.PostponeInfo = postponeInfo;
            this.Close();
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            Discard();
        }

        private void Discard()
        {
            this.Close();
        }

        private void tmrFormPosition_Tick(object sender, EventArgs e)
        {
            tmrFormPosition.Enabled = false;
            MoveToFormPosition();
            //after moving to position, enable the timer which shows the image
            tmrSetImage.Enabled = true;
        }

        private void tmrSetImage_Tick(object sender, EventArgs e)
        {
            tmrSetImage.Enabled = false;
            SetImage();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Discard();
        }

    }
}
