using System;
using System.Drawing;
using System.Windows.Forms;
using Notifier.Common;
using Notifier.Models;
using System.IO;
using static Notifier.Common.NotifierEnums;
using Notifier.Business;
using Notifier.Localization;

namespace Notifier.UI.UserControls
{
    public partial class ConfiguracoesUserControl : UserControl
    {
        private ConfigurationDetailModel _model;
        private AlertKind _alertKind;
        private bool _controlLoaded = false;
        private ConfiguracoesUserControlLabels _labels;

        public ConfiguracoesUserControl()
        {
            InitializeComponent();
        }

        private void ConfiguracoesUserControl_Load(object sender, EventArgs e)
        {
            EnableDisablecComponents();
            LoadGeneralLabels();
            LoadCombos();
        }

        private void LoadCombos()
        {
            //sound combo
            cboSound.Items.Add(LocalizationManager.GetText("Config_ComboItem_None"));
            cboSound.Items.Add(LocalizationManager.GetText("Config_ComboItem_Default"));
            cboSound.Items.Add(LocalizationManager.GetText("Config_ComboItem_Custom"));
            //image combo
            cboImage.Items.Add(LocalizationManager.GetText("Config_ComboItem_Default"));
            cboImage.Items.Add(LocalizationManager.GetText("Config_ComboItem_Custom"));
        }

        public void SetInitialInformation(ConfigurationDetailModel model, AlertKind alertKind, ConfiguracoesUserControlLabels labels)
        {
            _model = model;
            _alertKind = alertKind;
            _labels = labels;
            SetLabels();
            LoadSavedConfiguration();
            SetPictureBoxPreviewPosition();
            _controlLoaded = true;
        }

        private void SetPictureBoxPreviewPosition()
        {
            pictureBoxImage.Top = 24;
            pictureBoxImage.Left = 117;
        }

        private void SetLabels()
        {
            this.chkWarn.Text = _labels.Title;
            this.lnkTestAlert.Text = _labels.TestAlert;
            this.lblTime.Text = _labels.Time;
            this.lblWarnMe.Text = _labels.WarnMe;
            this.lblWarnMeAfter.Text = _labels.WarnMeAfter;
            this.lblColor.Text = _labels.Color;
            this.lblWarningSound.Text = _labels.WarnSound;
            this.lblWarningImage.Text = _labels.WarnImage;
        }

        public bool SaveConfiguration()
        {
            //validate it
            if (!_controlLoaded)
            {
                return false;
            }

            if (!ValidateForm())
            {
                return false;
            }

            //fill the properties
            _model.Active = (chkWarn.Checked == true);
            _model.HourMinute = dateTimePicker.Text;
            _model.MinutesToWarn = (int)(numMinutes.Value);
            _model.SoundAlertKind = (NotifierEnums.SoundAlertKind)cboSound.SelectedIndex;
            if (cboSound.SelectedIndex != (int)NotifierEnums.SoundAlertKind.Custom)
            {
                _model.SoundAlertCustomized = "";
            }
            _model.ImageKind = (NotifierEnums.ImageKind)cboImage.SelectedIndex;
            if (cboImage.SelectedIndex != (int)NotifierEnums.ImageKind.Custom)
            {
                _model.ImageCustomized = "";
            }
            _model.RgbColor = txtRgbColor.Text;


            //define it
            switch (_alertKind)
            {
                case AlertKind.LunchLeaving:
                    {
                        ConfigurationFIM.ConfigurationInstance.LunchLeaving = _model;
                        break;
                    }
                case AlertKind.EndWorkDay:
                    {
                        ConfigurationFIM.ConfigurationInstance.EndWorkDay = _model;
                        break;
                    }
            }

            //save it
            ConfigurationFIM.SaveConfigurationToFile();

            return true;
        }

        private bool ValidateForm()
        {
            if (cboSound.SelectedIndex == (int)NotifierEnums.SoundAlertKind.Custom && string.IsNullOrEmpty(_model.SoundAlertCustomized))
            {
                MessageBox.Show(null, _labels.MessageForMissingSound, LocalizationManager.GetText("General_Attention"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnSoundBrowse.Focus();
                return false;
            }
            if (cboImage.SelectedIndex == (int)NotifierEnums.ImageKind.Custom && string.IsNullOrEmpty(_model.ImageCustomized))
            {
                MessageBox.Show(null, _labels.MessageForMissingImage, LocalizationManager.GetText("General_Attention"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnImageBrowse.Focus();
                return false;
            }
            return true;
        }

        private void LoadSavedConfiguration()
        {
            chkWarn.Checked = (_model.Active == true);
            dateTimePicker.Text = _model.HourMinute;
            numMinutes.Text = _model.MinutesToWarn.ToString();

            //Sound
            cboSound.SelectedIndex = _model.SoundAlertKind == NotifierEnums.SoundAlertKind.None ? 0 :
                                          _model.SoundAlertKind == NotifierEnums.SoundAlertKind.Default ? 1 : 2;
            string filePathSound = _model.SoundAlertCustomized;
            if (_model.SoundAlertKind == NotifierEnums.SoundAlertKind.Custom)
            {
                if (File.Exists(filePathSound))
                {
                    cboSound.Items[cboSound.SelectedIndex] = String.Format(LocalizationManager.GetText("Config_Custom_Sound"), Path.GetFileName(_model.SoundAlertCustomized));
                }
                else
                {
                    cboSound.SelectedIndex = (int)NotifierEnums.SoundAlertKind.Default;
                }
            }

            //Image
            cboImage.SelectedIndex = _model.ImageKind == NotifierEnums.ImageKind.Default ? 0 : 1;
            string filePathImage = _model.ImageCustomized;
            if (_model.ImageKind == NotifierEnums.ImageKind.Custom)
            {
                if (File.Exists(filePathImage))
                {
                    cboImage.Items[cboImage.SelectedIndex] = String.Format(LocalizationManager.GetText("Config_Custom_Image"), Path.GetFileName(_model.ImageCustomized));
                }
                else
                {
                    cboImage.SelectedIndex = (int)NotifierEnums.ImageKind.Default;
                }
            }

            //Color
            txtRgbColor.Text = _model.RgbColor;
        }

        private void chkWarn_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisablecComponents();
        }

        private void EnableDisablecComponents()
        {
            bool state = (chkWarn.Checked == true);
            lblTime.Enabled = state;
            dateTimePicker.Enabled = state;
            lblWarnMe.Enabled = state;
            lblWarnMeAfter.Enabled = state;
            numMinutes.Enabled = state;
            lblWarningSound.Enabled = state;
            cboSound.Enabled = state;
            btnSoundBrowse.Enabled = state && (cboSound.SelectedIndex == (int)NotifierEnums.SoundAlertKind.Custom);
            lblWarningImage.Enabled = state;
            cboImage.Enabled = state;
            lblColor.Enabled = state;
            txtRgbColor.Enabled = state;
            btnColorPicker.Enabled = state;
            btnImageBrowse.Enabled = state && (cboImage.SelectedIndex == (int)NotifierEnums.ImageKind.Custom);
            lnkTestAlert.Enabled = state;
            btnSoundTest.Enabled = state;
            btnImageTest.Enabled = state;
        }

        private void lnkTestAlert_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SaveConfiguration() == true)
            {
                TestAlert();
            }
        }

        private void TestAlert()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = Utilities.ReturnOnlyHour(dateTimePicker.Text);
            int minute = Utilities.ReturnOnlyMinute(dateTimePicker.Text);

            if (_alertKind == AlertKind.EndWorkDay)
            {
                hour = DateTime.Now.Hour;
                minute = DateTime.Now.Minute;
            }

            DateTime target = new DateTime(year, month, day, hour, minute, 0);

            TimerEventArgs timerEventArgs = new TimerEventArgs
            {
                AlertKind = _alertKind,
                DateTimeTarget = target
            };
            Program.InitilizationInstsance.ShowAlertForm(timerEventArgs);
        }

        private void PickColor(TextBox textBox)
        {
            colorDialog.ShowDialog();
            if (colorDialog.Color != null)
            {
                textBox.Text = ColorTranslator.ToHtml(colorDialog.Color);
                textBox.ForeColor = colorDialog.Color;
            }
            else
            {
                textBox.Text = NotifierConstants.DEFAULT_COLOR_FOR_TEXT;
                textBox.ForeColor = ColorTranslator.FromHtml(NotifierConstants.DEFAULT_COLOR_FOR_TEXT);
            }
        }

        private void btnColorPicker_Click(object sender, EventArgs e)
        {
            PickColor(txtRgbColor);
        }

        private void cboSound_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSoundBrowse.Enabled = (chkWarn.CheckState == CheckState.Checked) && (cboSound.SelectedIndex == (int)NotifierEnums.SoundAlertKind.Custom) ;
            btnSoundTest.Enabled = (chkWarn.CheckState == CheckState.Checked) && ((cboSound.SelectedIndex == (int)NotifierEnums.SoundAlertKind.Custom) || (cboSound.SelectedIndex == (int)NotifierEnums.SoundAlertKind.Default));
        }

        private void cboImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnImageBrowse.Enabled = (chkWarn.CheckState == CheckState.Checked) && (cboImage.SelectedIndex == (int)NotifierEnums.ImageKind.Custom);
            btnImageTest.Enabled = (chkWarn.CheckState == CheckState.Checked);
        }

        private bool SelectCustomFile(ComboBox combo, string filter, int enumerationCustom, int enumerationDefault, string folderDestination, SelectType selectType, ref string filePath)
        {
            string fileOrigin = "";
            string fileNameToReplace = "";

            if (selectType == SelectType.FileSystem)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = filter;
                openFileDialog.InitialDirectory = FolderInfo.ImagesFolder;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileOrigin = openFileDialog.FileName;
                }
            }
            else
            {
                Forms.ImageSearch formImageSearch = new Forms.ImageSearch();
                formImageSearch.ShowDialog();
                fileOrigin = formImageSearch.SelectedFile;
                fileNameToReplace = formImageSearch.SelectedName;
            }

            if (fileOrigin != "" && File.Exists(fileOrigin))
            {
                string fileName = Path.GetFileName(fileOrigin);
                if (fileNameToReplace != "")
                {
                    fileName = fileName.Replace(Path.GetFileNameWithoutExtension(fileOrigin), fileNameToReplace);
                }
                filePath = folderDestination + "\\" + fileName;
                if (File.Exists(filePath) == true)
                {
                    File.Delete(filePath);
                }
                File.Copy(fileOrigin, filePath, true);

                combo.Items[combo.SelectedIndex] = String.Format(LocalizationManager.GetText("Config_Custom"), fileName);
                return true;
            }
            else
            {
                combo.SelectedIndex = enumerationDefault;
                return false;
            }
        }

        private void btnSoundBrowse_Click(object sender, EventArgs e)
        {
            SelectCustomSoundFile();
        }

        private void btnImageBrowse_Click(object sender, EventArgs e)
        {
            Point ptLowerLeft = new Point(0, btnImageBrowse.Height);
            ptLowerLeft = btnImageBrowse.PointToScreen(ptLowerLeft);
            contextMenuImageFinder.Show(ptLowerLeft);
        }

        private void SelectCustomSoundFile()
        {
            string fileName = "";
            if (SelectCustomFile(cboSound,
                        LocalizationManager.GetText("Config_File_Types_Sound") + "|*.wav",
                        (int)NotifierEnums.SoundAlertKind.Custom,
                        (int)NotifierEnums.SoundAlertKind.Default,
                        FolderInfo.SoundsFolder,
                        SelectType.FileSystem,
                        ref fileName) == true)
            {
                if (string.IsNullOrEmpty(fileName) == false)
                {
                    _model.SoundAlertCustomized = fileName;
                }
            }
            else
            {
                _model.SoundAlertCustomized = "";
            }
        }

        private void SelectCustomImageFile(SelectType selectType)
        {
            string fileName = "";
            if (SelectCustomFile(cboImage,
                        LocalizationManager.GetText("Config_File_Types_Image") + "| *.jpg; *.jpeg; *.gif; *.png",
                        (int)NotifierEnums.ImageKind.Custom,
                        (int)NotifierEnums.ImageKind.Default,
                        FolderInfo.ImagesFolder,
                        selectType,
                        ref fileName) == true)
            {
                if (string.IsNullOrEmpty(fileName) == false)
                {
                    _model.ImageCustomized = fileName;
                }
            }
            else
            {
                cboImage.SelectedIndex = (int)NotifierEnums.ImageKind.Default;
                _model.ImageCustomized = "";
            }
        }

        private void btnImageTest_Click(object sender, EventArgs e)
        {
            if (pictureBoxImage.Visible == true)
            {
                UnpreviewImage();
            }
            else
            {
                PreviewImage();
            }
        }

        private void PreviewImage()
        {
            string filePath = _model.ImageCustomized;
            if (File.Exists(filePath) == true && _model.ImageKind == ImageKind.Custom)
            {
                pictureBoxImage.Load(filePath);
                
            }
            else
            {
                pictureBoxImage.Image = Properties.Resources.ImgAlertInverted;
            }
            pictureBoxImage.BackColor = returnColor();
            pictureBoxImage.Visible = true;
        }

        private Color returnColor()
        {
            Color lineColor;
            try
            {
                lineColor = ColorTranslator.FromHtml(txtRgbColor.Text);
            }
            catch (Exception)
            {
                lineColor = ColorTranslator.FromHtml(NotifierConstants.DEFAULT_COLOR_FOR_BACKGROUND);
            }
            return lineColor;
        }

        private void UnpreviewImage()
        {
            pictureBoxImage.Visible = false;
        }

        private void btnImageTest_Leave(object sender, EventArgs e)
        {
            UnpreviewImage();
        }

        private void LoadGeneralLabels()
        {
            toolTipGeneral.SetToolTip(btnColorPicker, LocalizationManager.GetText("Config_Select_Color"));
            toolTipGeneral.SetToolTip(btnImageBrowse, LocalizationManager.GetText("Config_Browse_Image"));
            toolTipGeneral.SetToolTip(btnSoundBrowse, LocalizationManager.GetText("Config_Browse_Sound"));
            toolTipGeneral.SetToolTip(btnImageTest, LocalizationManager.GetText("Config_View_Image"));
            toolTipGeneral.SetToolTip(btnSoundTest, LocalizationManager.GetText("Config_Test_Sound"));
            toolTipGeneral.SetToolTip(lnkTestAlert, LocalizationManager.GetText("Config_Test_Alert"));
            toolStripMenuItemFileSystem.Text = LocalizationManager.GetText("Config_SelectFile_FileSystem");
            toolStripMenuItemGifSearcher.Text = LocalizationManager.GetText("Config_SelectFile_GifSearcher");
        }

        private void btnSoundTest_Click(object sender, EventArgs e)
        {
            PlaySound();
        }

        private void PlaySound()
        {
            SaveConfiguration();
            Notifier.UI.Classes.SoundPlayer.PlaySound(_model);
        }

        private void toolStripMenuItemFileSystem_Click(object sender, EventArgs e)
        {
            SelectCustomImageFile(SelectType.FileSystem);
        }

        private void toolStripMenuItemGifSearcher_Click(object sender, EventArgs e)
        {
            SelectCustomImageFile(SelectType.GifSearcher);
        }
    }

    public class ConfiguracoesUserControlLabels
    {
        public string Title { get; set; }
        public string TestAlert { get; set; }
        public string Time { get; set; }
        public string WarnMe { get; set; }
        public string WarnMeAfter { get; set; }
        public string Color { get; set; }
        public string WarnSound { get; set; }
        public string WarnImage { get; set; }
        public string MessageForMissingSound { get; set; }
        public string MessageForMissingImage { get; set; }
    }

    internal enum SelectType
    {
        FileSystem = 1,
        GifSearcher = 2
    }
}
