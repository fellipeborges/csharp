using System;
using System.Threading;
using System.Diagnostics;
using Notifier.Common;

namespace Notifier.Business
{
    public abstract class Timer : ITimer
    {
        public event EventHandler<TimerEventArgs> ShowAlertEvent;

        public bool OutputTimerLog { get; set; }

        DateTime _dateTimeTarget;
        int _targetHour;
        int _targetMinute;
        int _targetSecond;
        NotifierEnums.AlertKind _alertKind;
        System.Threading.Timer _tmrTimer;
        int _minutesToWarn = 1;

        public void Start(int targetHour, int targetMinute, int targetSecond, NotifierEnums.AlertKind alertKind, int minutesToWarn)
        {
            _targetHour = targetHour;
            _targetMinute = targetMinute;
            _targetSecond = targetSecond;
            _minutesToWarn = minutesToWarn *-1;
            _alertKind = alertKind;
            _dateTimeTarget = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, _targetHour, _targetMinute, _targetSecond);
            _tmrTimer = new System.Threading.Timer(this._tmrTimer_Tick, null, 0, 1000);
        }

        public void Stop()
        {
            if (_tmrTimer != null)
            {
                _tmrTimer.Dispose();
            }
        }
        
        public void TriggerShowEvent(TimerEventArgs e)
        {
            EventHandler<TimerEventArgs> handler = ShowAlertEvent;
            if (null != handler) handler(this, e);
        }

        private void _tmrTimer_Tick(object sender)
        {
            //DateTime now = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            DateTime now = DateTime.Now;
            DateTime check = _dateTimeTarget.AddMinutes(_minutesToWarn);

            LogStuff(String.Format("Comparing {0} with {1} - {2}", now, check, _alertKind));
            
            if (now >= check)
            {
                LogStuff(String.Format("Event triggered - {0}", _alertKind));
                _tmrTimer.Dispose();
                TimerEventArgs e = new TimerEventArgs { AlertKind = _alertKind, DateTimeNow = now, DateTimeTarget = _dateTimeTarget };
                TriggerShowEvent(e);
            }
            GC.Collect();
        }

        private void LogStuff(string text)
        {
            if (this.OutputTimerLog == true)
            {
                EventLogger.AddLog(text);
            }
        }
    }
}
