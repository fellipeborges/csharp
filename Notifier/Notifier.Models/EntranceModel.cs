using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notifier.Common;

namespace Notifier.Models
{
    public class EntranceModel
    {
        public bool Exists { get; set; }
        public string HourMinute { get; set; }

        public int HourOnly
        {
            get
            {
                return Utilities.ReturnOnlyHour(this.HourMinute);
            }
        }
        public int MinuteOnly
        {
            get
            {
                return Utilities.ReturnOnlyMinute(this.HourMinute);
            }
        }
    }
}
