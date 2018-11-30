using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifier.Business
{
    public static class EventLogger
    {
        public static Dictionary<Guid, String> Logs;

        static EventLogger()
        {
            Logs = new Dictionary<Guid, string>();
        }

        public static void AddLog(string text)
        {
            Guid key = Guid.NewGuid();
            Logs.Add(key, text);
        }
        public static void RemoveLog(Guid key)
        {
            Logs.Remove(key);
        }

    }
}
