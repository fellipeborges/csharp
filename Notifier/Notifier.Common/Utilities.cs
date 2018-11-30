using System;
using System.IO;
using System.Linq;
using System.Drawing;

namespace Notifier.Common
{
    public class Utilities
    {
        public bool CheckCreateFolder(string path)
        {
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
            return true;
        }

        public static Color ConvertToRGB(string hexColor)
        {
            double red, green, blue;
            hexColor = hexColor.Replace("#", "");
            red = Val("&H" + hexColor.Substring(0, 2));
            green = Val("&H" + hexColor.Substring(2, 2));
            blue = Val("&H" + hexColor.Substring(4, 2));
            return Color.FromArgb((int)red, (int)green, (int)blue);
        }

        public static Double Val(string value)
        {
            String result = String.Empty;
            foreach (char c in value)
            {
                if (Char.IsNumber(c) || (c.Equals('.') && result.Count(x => x.Equals('.')) == 0))
                    result += c;
                else if (!c.Equals(' '))
                    return String.IsNullOrEmpty(result) ? 0 : Convert.ToDouble(result);
            }
            return String.IsNullOrEmpty(result) ? 0 : Convert.ToDouble(result);
        }

        public static int ReturnOnlyHour(string hourMinute)
        {
            if (!string.IsNullOrEmpty(hourMinute))
            {
                return int.Parse(hourMinute.Substring(0, 2).ToString());
            }
            else
            {
                return 0;
            }
        }

        public static int ReturnOnlyMinute(string hourMinute)
        {
            if (!string.IsNullOrEmpty(hourMinute))
            {
                return int.Parse(hourMinute.Substring(3, 2).ToString());
            }
            else
            {
                return 0;
            }
        }

        public static string FormatWithTwoDigits(int number)
        {
            string formatedNumber = number.ToString();
            if (formatedNumber.Length == 1)
            {
                formatedNumber = "0" + formatedNumber;
            }
            return formatedNumber;
        }
    }
}
