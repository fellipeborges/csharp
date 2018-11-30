using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notifier.Models;

namespace Notifier.Business
{
    public class PostponeTimer : Timer
    {
        public PostponeTimer(PostponeModel postponeModel)
        {
            int minutesToWarn = 0;
            base.OutputTimerLog = DebugInfo.IsDebugForPostponeTimerEnabled;
            base.Start(postponeModel.TimeToWarn.Hour,
                       postponeModel.TimeToWarn.Minute,
                       postponeModel.TimeToWarn.Second,
                       postponeModel.AlertKind,
                       minutesToWarn);
        }
    }
}
