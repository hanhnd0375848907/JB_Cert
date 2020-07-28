using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

    }
}
