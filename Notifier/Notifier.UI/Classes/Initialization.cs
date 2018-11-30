using System;
using System.Windows.Forms;
using Notifier.Models;
using Notifier.Business;
using Notifier.Common;
using Notifier.Localization;

namespace Notifier.UI
{
    class Initialization
    {
        NotifyIcon _notifyIcon;
        ContextMenu _contextMenu;

        ITimer _lunchLeavingTimer;
        ITimer _lunchReturningTimer;
        ITimer _EndOfWorkDayTimer;
        ITimer _postponeTimer;
        
        System.Windows.Forms.Timer _checkEntranceTimeSettedTimer;

        public void ReadConfiguration()
        {
            if (Business.ConfigurationFIM.HasConfigurationFile() == false)
            {
                Forms.ConfigurationForm configForm = new Forms.ConfigurationForm();
                configForm.ShowDialog();
            }
            Business.ConfigurationFIM.ReadConfiguration();
        }

        public void SetLanguage()
        {
            LocalizationManager.Language = ConfigurationFIM.ConfigurationInstance.Language;
        }

        public void AddToTray()
        {
            CreateContextMenu();
            _notifyIcon = new NotifyIcon();
            SetIcon(false);
            _notifyIcon.Text = LocalizationManager.GetText("General_AppName");
            _notifyIcon.ContextMenu = _contextMenu;
            _notifyIcon.DoubleClick += menuItemConfig_Click;
            _notifyIcon.Visible = true;
        }

        internal void CheckEventLogger()
        {
            if (DebugInfo.IsDebugModeEnabled == true)
            {
                LoadEventLoggerForm();
            }
        }

        private void ConfigureEntranceBallonTip()
        {
            if (ConfigurationFIM.ConfigurationInstance.EndWorkDay.Active == true)
            {
                EntranceModel em = new EntranceManager().ReadEntranceOfDay(DateTime.Today);
                if (em.Exists == false) {
                    _notifyIcon.BalloonTipClicked += menuItemEntrance_Click;
                    _notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                    _notifyIcon.BalloonTipTitle = LocalizationManager.GetText("General_AppName");
                    _notifyIcon.BalloonTipText = LocalizationManager.GetText("Tray_ClickToInformArrivingTime");
                    _notifyIcon.ShowBalloonTip(99999999);
                }
            }
        }
        public void SetIcon(bool filledIcon)
        {
            if (filledIcon)
            {
                _notifyIcon.Icon = (System.Drawing.Icon)(Properties.Resources.IconAlertFilled);
            }
            else
            {
                _notifyIcon.Icon = (System.Drawing.Icon)(Properties.Resources.IconAlertUnfilled);
            }
        }

        private void CreateContextMenu()
        {
            _contextMenu = new ContextMenu();
            _contextMenu.MenuItems.Add(new MenuItem(LocalizationManager.GetText("Tray_Settings"), menuItemConfig_Click));
            if (DebugInfo.IsDebugModeEnabled == true)
            {
                _contextMenu.MenuItems.Add(new MenuItem(LocalizationManager.GetText("Tray_EventLogger"), menuItemEventLogger_Click));
            }
            HandleContextMenuForEntrance();
            _contextMenu.MenuItems.Add(new MenuItem("-"));
            _contextMenu.MenuItems.Add(new MenuItem(LocalizationManager.GetText("Tray_Exit"), menuItemSair_Click));
        }

        public void HandleContextMenuForEntrance()
        {
            const int MENU_KEY_ITEM_INDEX = 0;
            const string MENU_KEY_ITEM = "MENU_ITEM_ENTRANCE_ITEM";

            //remove button
            _contextMenu.MenuItems.RemoveByKey(MENU_KEY_ITEM);

            if (ConfigurationFIM.ConfigurationInstance.EndWorkDay.Active == true)
            {
                //add the button
                EntranceManager entranceManager = new EntranceManager();
                EntranceModel entranceModel = entranceManager.ReadEntranceOfDay(DateTime.Today);
                string menuText = "";
                if (entranceModel.Exists == false)
                {
                    menuText = LocalizationManager.GetText("Tray_InformEntranceTime");
                }
                else
                {
                    menuText = String.Format(LocalizationManager.GetText("Tray_ChangeEntranceTime"), entranceModel.HourMinute);
                }
                MenuItem menuItemEntrance = new MenuItem(menuText, menuItemEntrance_Click);
                menuItemEntrance.Name = MENU_KEY_ITEM;
                _contextMenu.MenuItems.Add(MENU_KEY_ITEM_INDEX, menuItemEntrance);
            }
        }

        private void menuItemEntrance_Click(object sender, EventArgs e)
        {
            Forms.SetEntrance sform = new Forms.SetEntrance();
            sform.ShowDialog();
        }

        private void menuItemSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuItemConfig_Click(object sender, EventArgs e)
        {
            Forms.ConfigurationForm cform = new Forms.ConfigurationForm();
            cform.ShowDialog();
        }
        private void menuItemEventLogger_Click(object sender, EventArgs e)
        {
            LoadEventLoggerForm();
        }

        private void LoadEventLoggerForm()
        {
            Forms.LogEvent eform = new Forms.LogEvent();
            eform.ShowDialog();
        }

        public void RemoveFromTray()
        {
            _notifyIcon.Visible = false;
            _notifyIcon.Icon = null;
            _notifyIcon = null;
        }

        public void CheckFolders()
        {
            Utilities utilities = new Utilities();
            
            //base folder
            if (!utilities.CheckCreateFolder(Business.FolderInfo.BaseFolder))
                return;

            //sounds folder
            if (!utilities.CheckCreateFolder(Business.FolderInfo.SoundsFolder))
                return;

            //images folder
            if (!utilities.CheckCreateFolder(Business.FolderInfo.ImagesFolder))
                return;

            //config folder
            if (!utilities.CheckCreateFolder(Business.FolderInfo.ConfigFolder))
                return;

            //entrance folder
            if (!utilities.CheckCreateFolder(Business.FolderInfo.EntranceFolder))
                return;
        }

        private void HandleTimersEvent(object o, TimerEventArgs e)
        {
            switch (e.AlertKind)
            {
                case NotifierEnums.AlertKind.LunchLeaving: {
                        _lunchLeavingTimer = null;
                        break;
                    }
                case NotifierEnums.AlertKind.LunchReturning:
                    {
                        _lunchReturningTimer = null;
                        break;
                    }
                case NotifierEnums.AlertKind.EndWorkDay:
                    {
                        _EndOfWorkDayTimer = null;
                        break;
                    }
            }
            ShowAlertForm(e);
        }

        public void StartTimers()
        {
            StartLunchLeavingTimer();
            StartLunchReturningTimer();
            StartEndOfWorkDayTimer();
            StartCheckEntranceTimeSettedTimer();
        }

        private void StartCheckEntranceTimeSettedTimer()
        {
            _checkEntranceTimeSettedTimer = new System.Windows.Forms.Timer();
            _checkEntranceTimeSettedTimer.Enabled = true;
            _checkEntranceTimeSettedTimer.Interval = 300000; //5 minutes
            _checkEntranceTimeSettedTimer.Tick += _checkEntranceTimeSettedTimer_Tick;
        }

        private void _checkEntranceTimeSettedTimer_Tick(object sender, EventArgs e)
        {
            ConfigureEntranceBallonTip();
            _checkEntranceTimeSettedTimer.Enabled = false;
            _checkEntranceTimeSettedTimer.Dispose();
        }

        private void StartLunchLeavingTimer()
        {
            if (_lunchLeavingTimer != null)
            {
                _lunchLeavingTimer.Stop();
            }
            //check if timer must be activated
            DateTime now = DateTime.Now;
            DateTime alarm = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, Business.ConfigurationFIM.ConfigurationInstance.LunchLeaving.HourOnly, Business.ConfigurationFIM.ConfigurationInstance.LunchLeaving.MinuteOnly, 0);

            if (alarm > now)
            {
                _lunchLeavingTimer = new LunchTimer();
                _lunchLeavingTimer.ShowAlertEvent += new EventHandler<TimerEventArgs>(HandleTimersEvent);
            }
        }

        private void StartLunchReturningTimer()
        {
            if (_lunchReturningTimer != null)
            {
                _lunchReturningTimer.Stop();
            }
            //check if timer must be activated
            DateTime now = DateTime.Now;
            DateTime alarm = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, ConfigurationFIM.ConfigurationInstance.LunchReturning.HourOnly, ConfigurationFIM.ConfigurationInstance.LunchReturning.MinuteOnly, 0);

            if (alarm > now)
            {
                _lunchReturningTimer = new LunchReturningTimer();
                _lunchReturningTimer.ShowAlertEvent += new EventHandler<TimerEventArgs>(HandleTimersEvent);
            }
        }

        private void StartEndOfWorkDayTimer()
        {
            if (_EndOfWorkDayTimer != null)
            {
                _EndOfWorkDayTimer.Stop();
            }
            //read the day's entrance time (if exists)
            EntranceModel entranceModel = new EntranceManager().ReadEntranceOfDay(DateTime.Now);
            if (entranceModel.Exists == false)
            {
                return;
            }
            TimeSpan entranceTimeSpan = new TimeSpan(entranceModel.HourOnly, entranceModel.MinuteOnly, 0);

            //calculate the leaving time
            TimeSpan hoursOfJob = new TimeSpan(ConfigurationFIM.ConfigurationInstance.EndWorkDay.HourOnly, ConfigurationFIM.ConfigurationInstance.EndWorkDay.MinuteOnly, 0);
            TimeSpan endOfWorkDayTime = entranceTimeSpan.Add(hoursOfJob);

            //check if timer must be activated
            DateTime alarm = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, endOfWorkDayTime.Hours, endOfWorkDayTime.Minutes, endOfWorkDayTime.Seconds);
            DateTime now = DateTime.Now;

            if (alarm > now)
            {
                _EndOfWorkDayTimer = new EndOfWorkDayTimer(alarm);
                _EndOfWorkDayTimer.ShowAlertEvent += new EventHandler<TimerEventArgs>(HandleTimersEvent);
            }
        }

        public void ShowAlertForm(TimerEventArgs e)
        {
            Forms.Alert form = new Forms.Alert();
            form.AlertKind = e.AlertKind;
            form.DateTimeTarget = e.DateTimeTarget;
            form.ShowDialog();
            if (form.PostponeInfo != null)
            {
                if (_postponeTimer != null)
                {
                    _postponeTimer.Stop();
                }
                _postponeTimer = new PostponeTimer((form.PostponeInfo));
                _postponeTimer.ShowAlertEvent += new EventHandler<TimerEventArgs>(HandleTimersEvent);
            }
        }
    }
}
