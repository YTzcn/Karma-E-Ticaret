using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Abstract
{
    public interface IMailService
    {
        public bool SendTextMail(string receiverMail, string subject, string body);
        public bool SendWelcomeMail(string UserName);
        public bool SendRegisterConfirmMail(string recieverMail,string url);//
        public bool SendForgotPasswordMail(string recieverMail, string url);//
        public bool SendNewstellerMail(string receiverMail, string? imageUrl, string? message);
        public bool SendSummaryMail();

    }
}
