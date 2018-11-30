using System.Text;
using System.IO;
using System.Xml.Serialization;
using Notifier.Models;
using Notifier.Common;
using System.Deployment.Application;

namespace Notifier.Business
{
    public static class ConfigurationFIM
    {
        public static ConfigurationModel ConfigurationInstance;

        static ConfigurationFIM()
        {
            ConfigurationInstance = new ConfigurationModel();
            ReadConfiguration();
        }
        
        private static string GetConfigurationFileFullPath()
        {
            return FolderInfo.ConfigFolder + "\\Configuration.xml";
        }

        public static bool HasConfigurationFile()
        {
            return File.Exists(GetConfigurationFileFullPath());
        }

        public static string PublishVersion
        {
            get{ 
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);
                }
                else
                {
                    return "0.0.0.0";
                }
            }
        }
        
        public static bool ReadConfiguration()
        {
            //check if config file already exists. If so, serializes it.
            ConfigurationFIM.ConfigurationInstance = new ConfigurationModel();
            if (File.Exists(GetConfigurationFileFullPath()) == true)
            {
                ReadConfigurationFromFile();
            }
            else
            {
                LoadDefaultConfiguration();
                SaveConfigurationToFile();
            }
            return true;
        }

        public static void SaveConfigurationToFile()
        {
            string configFile = GetConfigurationFileFullPath();
            XmlSerializer xsSubmit = new XmlSerializer(typeof(ConfigurationModel));
            using (StringWriter sww = new StringWriter())
            using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(sww))
            {
                xsSubmit.Serialize(writer, ConfigurationFIM.ConfigurationInstance);
                var xml = sww.ToString();
                File.WriteAllText(configFile, xml, Encoding.Unicode);
            }
        }

        private static void ReadConfigurationFromFile()
        {
            string configFile = GetConfigurationFileFullPath();
            string xml = File.ReadAllText(configFile);
            XmlSerializer serializer = new XmlSerializer(typeof(ConfigurationModel));
            MemoryStream memStream = new MemoryStream(Encoding.Unicode.GetBytes(xml));
            ConfigurationFIM.ConfigurationInstance = (ConfigurationModel)serializer.Deserialize(memStream);
        }

        private static void LoadDefaultConfiguration()
        {
            //general
            ConfigurationFIM.ConfigurationInstance.StartWithWindows = true;
            ConfigurationFIM.ConfigurationInstance.UseAnimation = false;
            ConfigurationFIM.ConfigurationInstance.Language = NotifierEnums.Language.ptBr;

            //lunch leaving
            ConfigurationFIM.ConfigurationInstance.LunchLeaving.ConfigurationKind = NotifierEnums.ConfigurationKind.LunchLeaving;
            ConfigurationFIM.ConfigurationInstance.LunchLeaving.HourMinute = "12:00";
            ConfigurationFIM.ConfigurationInstance.LunchLeaving.Active = true;
            ConfigurationFIM.ConfigurationInstance.LunchLeaving.MinutesToWarn = 5;
            ConfigurationFIM.ConfigurationInstance.LunchLeaving.MinutesToWarnAgain = 2;
            ConfigurationFIM.ConfigurationInstance.LunchLeaving.SoundAlertKind = NotifierEnums.SoundAlertKind.Default;
            ConfigurationFIM.ConfigurationInstance.LunchLeaving.ImageKind = NotifierEnums.ImageKind.Default;
            ConfigurationFIM.ConfigurationInstance.LunchLeaving.RgbColor = NotifierConstants.DEFAULT_COLOR_FOR_ALERT;


            //lunch returning
            ConfigurationFIM.ConfigurationInstance.LunchReturning.ConfigurationKind = NotifierEnums.ConfigurationKind.LunchReturning;
            ConfigurationFIM.ConfigurationInstance.LunchReturning.HourMinute = "13:15";
            ConfigurationFIM.ConfigurationInstance.LunchReturning.Active = true;
            ConfigurationFIM.ConfigurationInstance.LunchReturning.MinutesToWarn = 5;
            ConfigurationFIM.ConfigurationInstance.LunchReturning.MinutesToWarnAgain = 2;
            ConfigurationFIM.ConfigurationInstance.LunchReturning.SoundAlertKind = NotifierEnums.SoundAlertKind.Default;
            ConfigurationFIM.ConfigurationInstance.LunchReturning.ImageKind = NotifierEnums.ImageKind.Default;
            ConfigurationFIM.ConfigurationInstance.LunchReturning.RgbColor = NotifierConstants.DEFAULT_COLOR_FOR_ALERT;

            ////end of work day
            ConfigurationFIM.ConfigurationInstance.EndWorkDay.ConfigurationKind = NotifierEnums.ConfigurationKind.EndWorkDay;
            ConfigurationFIM.ConfigurationInstance.EndWorkDay.HourMinute = "09:30";
            ConfigurationFIM.ConfigurationInstance.EndWorkDay.Active = true;
            ConfigurationFIM.ConfigurationInstance.EndWorkDay.MinutesToWarn = 5;
            ConfigurationFIM.ConfigurationInstance.EndWorkDay.MinutesToWarnAgain = 2;
            ConfigurationFIM.ConfigurationInstance.EndWorkDay.SoundAlertKind = NotifierEnums.SoundAlertKind.Default;
            ConfigurationFIM.ConfigurationInstance.EndWorkDay.ImageKind = NotifierEnums.ImageKind.Default;
            ConfigurationFIM.ConfigurationInstance.EndWorkDay.RgbColor = NotifierConstants.DEFAULT_COLOR_FOR_ALERT;
        }
    }
}
