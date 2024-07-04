using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace NewsDemo.Common
{
    public static class EmailHelper
    {
        public static void SendMail(string to, string subject, string body)
        {
            try
            {
                // to = "vipul.tatvasoft2017@gmail.com";
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(ConfigItems.DisplayEmailSender);
                    mail.To.Add(to);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient(ConfigItems.SMTPHost, ConfigItems.SMTPPort);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(ConfigItems.EmailSender, ConfigItems.EmailPassword);
                    smtp.EnableSsl = ConfigItems.IsSMTPEnableSsl;
                    smtp.Send(mail);
                }
            }
            catch (Exception) // ex)
            {
                // throw;
            }
        }
    }
}
