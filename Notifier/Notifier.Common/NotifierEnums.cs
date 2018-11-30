using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifier.Common
{
    public class NotifierEnums
    {
        public enum ConfigurationKind
        {
            LunchLeaving = 0,
            LunchReturning = 1,
            EndWorkDay = 2
        }
        public enum SoundAlertKind
        {
            None = 0,
            Default = 1,
            Custom = 2
        }
        public enum ImageKind
        {
            Default = 0,
            Custom = 1
        }

        public enum AlertKind
        {
            LunchLeaving = 0,
            LunchReturning = 1,
            EndWorkDay = 2
        }
        public enum Language
        {
            enUs = 0,
            ptBr = 1,
            ptGueto = 2
        }
    }
}
