using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notifier.Models;
using Notifier.Common;
using System.IO;

namespace Notifier.UI.Classes
{
    public static class SoundPlayer
    {
        public static void PlaySound(ConfigurationDetailModel configurationDetailInstance)
        {
            string customSound = "";
            bool soundEnabled = false;

            customSound = configurationDetailInstance.SoundAlertCustomized;
            soundEnabled = configurationDetailInstance.SoundAlertKind != NotifierEnums.SoundAlertKind.None;

            if (soundEnabled)
            {
                Stream str = Properties.Resources.SoundAlert;
                if (File.Exists(customSound))
                {
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(customSound);
                    snd.Play();
                }
                else
                {
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                }
            }
        }
    }
}
