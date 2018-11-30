using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notifier.Common;

namespace Notifier.Models
{
    public class PostponeModel
    {
        public DateTime TimeToWarn { get; set; }
        public NotifierEnums.AlertKind AlertKind { get; set; }
    }
}
