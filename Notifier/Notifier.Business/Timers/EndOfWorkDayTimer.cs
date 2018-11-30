using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifier.Business
{
    public class EndOfWorkDayTimer: Timer
    {
        public EndOfWorkDayTimer(DateTime timeToWarn)
        {
            if (ConfigurationFIM.ConfigurationInstance.EndWorkDay.Active == true)
            {
                int targetSecond = 0;
                base.OutputTimerLog = DebugInfo.IsDebugForEndOfWorkDayEnabled;
                base.Start(timeToWarn.Hour,
                           timeToWarn.Minute,
                           targetSecond,
                           Common.NotifierEnums.AlertKind.EndWorkDay,
                           ConfigurationFIM.ConfigurationInstance.EndWorkDay.MinutesToWarn);
            }
        }
    }
}
