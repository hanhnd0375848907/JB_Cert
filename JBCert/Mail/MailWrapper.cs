using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBCert.Mail
{
    public static class MailWrapper
    {

        public static void SendMail(string receiveName, string receiveEmail, string subject, MimeMessage mimeMessage)
        {
            try
            {
                var mailMessage = new MimeMessage();
                mailMessage.From.Add(new MailboxAddress("JBTech Notification", "notification@jbtech.vn"));
                mailMessage.To.Add(new MailboxAddress(receiveName, receiveEmail));
                mailMessage.Subject = subject;
                mailMessage.Body = mimeMessage.Body;

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Connect("pro06.emailserver.vn", 465, true);
                    smtpClient.Authenticate(Common.Common.NOTIFICATION_EMAIL, Common.Common.PASSWORD_NOTIFICATION_EMAIL);
                    smtpClient.Send(mailMessage);
                    smtpClient.Disconnect(true);
                }
            }
            catch
            {

            }
        }

    }
}
