using Karma.Business.Abstract;
using Karma.MvcUI.Identity.Business.Abstract;
using Karma.MvcUI.Identity.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Net.NetworkInformation;

namespace Karma.MvcUI.Identity.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly IMailService _mailService;
        public UserManager(UserManager<AppIdentityUser> userManager, IMailService mailService)
        {
            _userManager = userManager;
            _mailService = mailService;
        }
        public List<AppIdentityUser> GetAllUser()
        {
            return _userManager.Users.ToList();
        }

        public async Task<AppIdentityUser> GetByEmail(string Email)
        {
            return await _userManager.FindByEmailAsync(Email);
        }

        public async Task<AppIdentityUser> GetById(string UserId)
        {
            return await _userManager.FindByIdAsync(UserId);
        }

        public async Task<AppIdentityUser> GetByUserName(string UserName)
        {
            return await _userManager.FindByNameAsync(UserName);
        }

        public async Task<bool> SendResetPasswordMail(string UserId)
        {
            try
            {
                //string x = IPGlobalProperties.GetIPGlobalProperties().;
                var user = await GetById(UserId);
                var securityCode = await _userManager.GeneratePasswordResetTokenAsync(user);
                //var callBackUrl = x + "/ResetPassword/Security?userId=" + user.Id + "&code=" + securityCode;
                //_mailService.SendForgotPasswordMail(user.Email, callBackUrl);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }


        }
    }
}
