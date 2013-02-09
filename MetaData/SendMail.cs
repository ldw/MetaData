using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace MetaData
{
    public static class SendMail
    {

        public static void SendEmail(string title, string msg, string recipient)
        {

            MailMessage message = new MailMessage();

            message.From = new MailAddress("icecastserverscorpio@gmail.com");

            message.To.Add(new MailAddress(recipient));

            message.Subject = title;
            message.Body = msg;

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("icecastserverscorpio@gmail.com", "")
            };

            smtp.Send(message);
        }

        public static void SendEmailToLDW(string title, string msg)
        {

            SendEmail(title, msg, "@hotmail.com");
        }

    }
}
