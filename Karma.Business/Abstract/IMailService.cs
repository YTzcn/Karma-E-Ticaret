    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Entities.Concrete;

namespace Karma.Business.Abstract
{
    public interface IMailService
    {
        public bool SendTextMail(string receiverMail, string subject, string message);//
        public bool SendWelcomeMail(string receiverMail, string UserName);//
        public bool SendRegisterConfirmMail(string recieverMail, string url);//
        public bool SendForgotPasswordMail(string recieverMail, string url);//
        public bool SendNewstellerMail(string receiverMail, string? imageUrl, string? message, string routeLink);//
        public bool SendSummaryMail(string receiverMail, Cart cart,decimal? discountPrice);

    }
}
