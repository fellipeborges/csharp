using System.Configuration;

namespace Notifier.Business
{
    public static class DebugInfo
    {

        public static bool IsDebugModeEnabled
        {
            get
            {
                return (ConfigurationManager.AppSettings["EventLoggerEnabled"] == "1");
            }
        }

        public static bool IsDebugForLunchLeavingEnabled
        {
            get
            {
                return (ConfigurationManager.AppSettings["DebugForLunchLeavingEnabled"] == "1");
            }
        }

        public static bool IsDebugForLunchReturningEnabled
        {
            get
            {
                return (ConfigurationManager.AppSettings["DebugForLunchReturningEnabled"] == "1");
            }
        }

        public static bool IsDebugForEndOfWorkDayEnabled
        {
            get
            {
                return (ConfigurationManager.AppSettings["DebugForEndOfWorkDayEnabled"] == "1");
            }
        }
        public static bool IsDebugForPostponeTimerEnabled
        {
            get
            {
                return (ConfigurationManager.AppSettings["DebugForPostponeTimerEnabled"] == "1");
            }
        }

    }
}
