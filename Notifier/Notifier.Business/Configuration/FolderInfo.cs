using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifier.Business
{
    public static class FolderInfo
    {
        private static string _baseFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Notifier.FB\\";

        static FolderInfo()
        {
        }

        public static string BaseFolder
        {
            get
            {
                return _baseFolder + "Data";
            }
        }

        public static string ConfigFolder
        {
            get
            {
                return BaseFolder + "\\Config";
            }
        }
        public static string EntranceFolder
        {
            get
            {
                return BaseFolder + "\\Entrance";
            }
        }
        public static string SoundsFolder
        {
            get
            {
                return BaseFolder + "\\Sounds";
            }
        }
        public static string ImagesFolder
        {
            get
            {
                return BaseFolder + "\\Images";
            }
        }

    }
}
