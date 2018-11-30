using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notifier.Common;

namespace Notifier.Business
{
    public interface ITimer
    {
        event EventHandler<TimerEventArgs> ShowAlertEvent;
        void Start(int targetHour, int targetMinute, int targetSecond, NotifierEnums.AlertKind alertKind, int minutesToWarn);

        void Stop();

        void TriggerShowEvent(TimerEventArgs e);
    }
}
