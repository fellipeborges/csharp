using Notifier.Common;

namespace Notifier.Models
{
    public class ConfigurationDetailModel
    {
        public NotifierEnums.ConfigurationKind ConfigurationKind { get; set; }
        public bool Active { get; set; }
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
        public int MinutesToWarn { get; set; }
        public int MinutesToWarnAgain { get; set; }
        public NotifierEnums.SoundAlertKind SoundAlertKind { get; set; }
        public string SoundAlertCustomized { get; set; }
        public NotifierEnums.ImageKind ImageKind { get; set; }
        public string ImageCustomized { get; set; }
        public string RgbColor { get; set; }
    }
}
