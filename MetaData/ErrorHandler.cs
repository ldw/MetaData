using System;
using System.Collections.Generic;
using System.Text;

namespace MetaData
{
    public static class ErrorHandler
    {
        public static DateTime LastErrorSend;

        public static void HandleTheErrorIfTimeInterval(string error)
        {
            //write in txt log file
            ErrorLog.LogError(error);
            //send a mail (last error mail was more than 2 hours ago)
            if ((DateTime.Now - LastErrorSend).TotalHours > 2)
            {
                SendMail.SendEmailToLDW("ERROR", error);
                LastErrorSend = DateTime.Now;
            }
        }
        public static void HandleTheError(string error)
        {
            ErrorLog.LogError(error);
            SendMail.SendEmailToLDW("ERROR", error);
            LastErrorSend = DateTime.Now;
        }
        public static void LogErrorInTXT(string error)
        {
            LogErrorInTXT(error);
        }
    }
}
