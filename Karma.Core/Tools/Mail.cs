using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Core.Tools
{
    public class Mail
    {
        string _receiverMail;
        string _subject;
        string _body;
        public Mail(string receiverMail, string subject, string body)
        {
            _body = body;
            _receiverMail = receiverMail;
            _subject = subject;
            Send(_receiverMail, _subject, _body);
        }
        public bool Send(string receiverMail, string subject, string body)
        {
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string senderEmail = "uygulamachatapp@gmail.com";
            string senderPassword = "xxeucbmgichvdnxa";
            try
            {
                using (SmtpClient smtpClient = new SmtpClient(smtpServer))
                {
                    smtpClient.Port = smtpPort;
                    smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    smtpClient.EnableSsl = true;

                    using (MailMessage mailMessage = new MailMessage(senderEmail, receiverMail))
                    {
                        mailMessage.Subject = subject;
                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true;

                        smtpClient.Send(mailMessage);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
