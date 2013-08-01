using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using MetaData.Properties;

namespace MetaData
{
    public static class SendMail
    {

        public static void SendEmail(string title, string msg, string recipient)
        {
#if(DEBUG)
            return;
#endif

            MailMessage message = new MailMessage();

            message.From = new MailAddress(Properties.Settings.Default.MailAdress);

            message.To.Add(new MailAddress(recipient));

            message.Subject = title;
            message.Body = msg;

            SmtpClient smtp = new SmtpClient
            {
                Host = Settings.Default.MailHost,
                Port = Settings.Default.MailPort,
                EnableSsl = Settings.Default.MailSSL,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(Settings.Default.MailCredUser,Settings.Default.MailCredPass)
            };

            smtp.Send(message);
        }

        public static void SendEmailToAdmin(string title, string msg)
        {
            SendEmail(title, msg, Settings.Default.AdminMail);
        }

    }
}
