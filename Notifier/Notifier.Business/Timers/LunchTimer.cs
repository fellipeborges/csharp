using System;
using System.Threading;

namespace Notifier.Business
{
    public class LunchTimer: Timer
    {
        public LunchTimer()
        {
            if (ConfigurationFIM.ConfigurationInstance.LunchLeaving.Active == true)
            {
                int targetSecond = 0;
                base.OutputTimerLog = DebugInfo.IsDebugForLunchLeavingEnabled;
                base.Start(ConfigurationFIM.ConfigurationInstance.LunchLeaving.HourOnly,
                            ConfigurationFIM.ConfigurationInstance.LunchLeaving.MinuteOnly,
                            targetSecond,
                            Common.NotifierEnums.AlertKind.LunchLeaving, 
                            ConfigurationFIM.ConfigurationInstance.LunchLeaving.MinutesToWarn);
            }
        }
    }
}
