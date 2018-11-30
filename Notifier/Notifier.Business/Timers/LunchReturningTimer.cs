using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifier.Business
{
    public class LunchReturningTimer: Timer
    {
        public LunchReturningTimer()
        {
            if (ConfigurationFIM.ConfigurationInstance.LunchReturning.Active == true)
            {
                int targetSecond = 0;
                base.OutputTimerLog = DebugInfo.IsDebugForLunchReturningEnabled;
                base.Start(ConfigurationFIM.ConfigurationInstance.LunchReturning.HourOnly,
                            ConfigurationFIM.ConfigurationInstance.LunchReturning.MinuteOnly,
                            targetSecond,
                            Common.NotifierEnums.AlertKind.LunchReturning,
                            ConfigurationFIM.ConfigurationInstance.LunchReturning.MinutesToWarn);
            }
        }
    }
}
