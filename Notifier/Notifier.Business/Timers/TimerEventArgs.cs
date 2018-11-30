using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notifier.Common;

namespace Notifier.Business
{
    public class TimerEventArgs : EventArgs
    {
        public NotifierEnums.AlertKind AlertKind { get; set; }
        public DateTime DateTimeNow { get; set; }
        public DateTime DateTimeTarget { get; set; }
    }
}
