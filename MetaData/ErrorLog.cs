using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MetaData
{
    public static class ErrorLog
    {
        public static void LogError(string error) {
            try
            {
                checkFile();
                string errortolog = DateTime.Now.ToLongDateString() + " : " + error;
                File.AppendAllText(@"ErrorLog.txt", errortolog);
            }
            catch (Exception ex)
            {
                    // send mail?
            }
            
        }
        private static void checkFile()
        {
            if (!File.Exists("ErrorLog.txt"))
            {
                File.Create("ErrorLog.txt");
            }
        }
    }
}
