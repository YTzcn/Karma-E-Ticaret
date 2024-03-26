using Karma.MvcUI.Identity.DAL;

namespace Karma.MvcUI.Identity.Business.Abstract
{
    public interface IUserService
    {
        List<AppIdentityUser> GetAllUser();
        Task<AppIdentityUser> GetById(string UserId);
        Task<AppIdentityUser> GetByUserName(string UserName);
        Task<AppIdentityUser> GetByEmail(string Email);
        Task<bool> SendResetPasswordMail(string UserId);

    }
}
