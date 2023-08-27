using Karma.MvcUI.Identity;
using Karma.MvcUI.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Karma.MvcUI.Controllers
{
    public class SecurityController : Controller
    {
        private UserManager<AppIdentityUser> _userManager;
        private SignInManager<AppIdentityUser> _signInManager;
        public SecurityController(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(string.Empty, "Epostanı kontrol et");
                    return View(model);
                }
            }
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);//1 false olan kısım beni hatırla 2. kısım hatalı şifre girişinde giriş engelleme  
            if (result.Succeeded)
            {
                if (!TempData.ContainsKey("message"))
                {
                    TempData.Add("message", "Giriş Başarılı Reisim");
                }
                return RedirectToAction("Index", "Ürün");
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new AppIdentityUser
            {
                Email = model.Email,
                UserName = model.UserName,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var confirmationCode = _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callBackUrl = Url.Action("ConfirmEmail", "Security", new { userId = user.Id, code = confirmationCode });
                //mail gönderme işlemi yapılacak link üstte 
                return RedirectToAction("Login");
            }
            return View(model);
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                if (!TempData.ContainsKey("alert"))
                {
                    TempData.Add("alert", "Email Doğrulaması Başarısız Geçersiz Link");
                }
                return RedirectToAction("Login");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                if (!TempData.ContainsKey("alert"))
                {
                    TempData.Add("alert", "Kullanıcı Bulunamadı");
                }
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                if (!TempData.ContainsKey("message"))
                {
                    TempData.Add("message", "Mail Doğrulaması Başarılı");
                }
                return RedirectToAction("Login");
            }
            if (!TempData.ContainsKey("alert"))
            {
                TempData.Add("alert", "Email Doğrulaması Başarısız ");
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                return View(Email);
            }
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                if (!TempData.ContainsKey("alert"))
                {
                    TempData.Add("alert", "Bu Epostaya Sahip Bir Kullanıcı Bulunamadı");
                }
                return View();
            }
            var confirmationCode = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callBackUrl = Url.Action("ResetPassword", "Security", new { userId = user.Id, code = confirmationCode });
            //mail at callbackurli
            if (!TempData.ContainsKey("alert"))
            {
                TempData.Add("alert", "Şifre Yenileme Maili E Postana Gönderildi");
            }
            return RedirectToAction("Login", "Home");
        }
        public IActionResult ResetPassword(string userId, string code)
        {
            if (userId == null || code == null)
            {
                if (!TempData.ContainsKey("alert"))
                {
                    TempData.Add("alert", "Geçersiz Link");
                    return RedirectToAction("Login");
                }
            }
            var model = new ResetPasswordViewModel { Code = code };
            return View(model);

        }
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                if (!TempData.ContainsKey("alert"))
                {
                    TempData.Add("alert", "Bu Epostaya Sahip Bir Kullanıcı Bulunamadı");
                }
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                if (!TempData.ContainsKey("message"))
                {
                    TempData.Add("message", "Şifre Başarıyla Güncellendi");
                }
                return RedirectToAction("Login");
            }
            else
            {
                if (!TempData.ContainsKey("alert"))
                {
                    TempData.Add("alert", "Şifre Güncellenirken Hata Oluştu");
                    return View(model);
                }
            }

            return View(model);
        }
        public IActionResult ResetPasswordConfirm()
        {
            return View();
        }
        public IActionResult ForgortPasswordConfirm()
        {
            return View();
        }
    }
}
