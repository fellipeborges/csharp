using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Resources;
using Notifier.Common;

namespace Notifier.Localization
{
    public static class LocalizationManager
    {
        public static NotifierEnums.Language Language { get; set; }

        public static string GetText(string key)
        {
            string ret = "";
            switch (Language)
            {
                case NotifierEnums.Language.enUs: default:
                    {
                       ret = Resources.en_us.ResourceManager.GetString(key);
                        break;
                    }
                case NotifierEnums.Language.ptBr:
                    {
                        ret = Resources.pt_br.ResourceManager.GetString(key);
                        break;
                    }
                case NotifierEnums.Language.ptGueto:
                    {
                        ret = Resources.pt_gueto.ResourceManager.GetString(key);
                        break;
                    }
            }
            if (ret == null)
            {
                return key;
            }
            else
            {
                return ret;
            }
        }
    }
}
