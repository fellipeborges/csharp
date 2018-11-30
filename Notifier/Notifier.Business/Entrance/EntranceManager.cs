using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notifier.Models;
using System.IO;

namespace Notifier.Business
{
    public class EntranceManager
    {   
        public EntranceModel ReadEntranceOfDay(DateTime date)
        {
            string fileForDate = GetFileName(date);
            EntranceModel entranceModelReturn = new EntranceModel();
            if (File.Exists(fileForDate) == false)
            {
                entranceModelReturn.Exists = false;
                entranceModelReturn.HourMinute = "";
            }
            else
            {
                entranceModelReturn.Exists = true;
                string[] fileContent = ReadTextFile(fileForDate);
                entranceModelReturn.HourMinute = fileContent[0];
            }
            return entranceModelReturn;
        }

        private string[] ReadTextFile(string fileFullPath)
        {
            string[] lines = File.ReadAllLines(fileFullPath);
            return lines;
        }


        private string GetFileName(DateTime date)
        {
            string fileName = String.Format("Entrance-{0}-{1}-{2}.txt", date.Year, date.Month, date.Day);
            string fileFullPath = FolderInfo.EntranceFolder + "\\" + fileName;
            return fileFullPath;
        }

        public bool SetEntranceOfDay(string time, DateTime date)
        {
            string fileForDate = GetFileName(date);
            DeleteEntranceOfDay(date);
            if (time != "")
            {
                StreamWriter stw = File.CreateText(fileForDate);
                stw.Write(time);
                stw.Close();
                stw.Dispose();
            }
            return true;
        }

        public bool DeleteEntranceOfDay(DateTime date)
        {
            string fileForDate = GetFileName(date);
            if (File.Exists(fileForDate) == true)
            {
                File.Delete(fileForDate);
            }
            return true;
        }
    }
}
