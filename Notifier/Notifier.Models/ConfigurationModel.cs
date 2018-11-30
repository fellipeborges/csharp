using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notifier.Common;


namespace Notifier.Models
{
    public class ConfigurationModel
    {
        private ConfigurationDetailModel _LunchLeaving = new ConfigurationDetailModel();
        private ConfigurationDetailModel _LunchReturning = new ConfigurationDetailModel();
        private ConfigurationDetailModel _EndWorkDay = new ConfigurationDetailModel();

        public bool StartWithWindows { get; set; }
        public bool UseAnimation { get; set; }
        public NotifierEnums.Language Language { get; set; }

        public ConfigurationDetailModel LunchLeaving
        {
            get { return _LunchLeaving; }
            set { _LunchLeaving = value; }
        }
        public ConfigurationDetailModel LunchReturning
        {
            get { return _LunchReturning; }
            set { _LunchReturning = value; }
        }
        public ConfigurationDetailModel EndWorkDay
        {
            get { return _EndWorkDay; }
            set { _EndWorkDay = value; }
        }
    }
}
