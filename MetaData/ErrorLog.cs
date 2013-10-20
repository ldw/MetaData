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
                string errortolog = DateTime.Now.ToShortDateString()+ " - " + DateTime.Now.ToShortTimeString() + " : " + error + Environment.NewLine;
                File.AppendAllText(@"ErrorLog.txt", errortolog);
            }
            catch (Exception ex)
            {
                    // send mail?
            }
            
        }

    }
}
