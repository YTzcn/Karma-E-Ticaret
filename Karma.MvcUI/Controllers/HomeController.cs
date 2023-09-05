using Karma.Business.Abstract;
using Karma.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Karma.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewstellerSubService _newstellerSubService;
        public HomeController(IMailService mailService, INewstellerSubService newstellerSubService)
        {
            _newstellerSubService = newstellerSubService;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NewstellerSubscribe(string Email)
        {
            var result = _newstellerSubService.IsExist(Email);
            if (!result)
            {
                _newstellerSubService.Add(new NewstellerSub { Email = Email, Active = true });
                if (!TempData.ContainsKey("message"))
                {
                    TempData.Add("message", "Haber Bültenimize Eklendiniz");
                }
                return RedirectToAction("Index");
            }
            if (!TempData.ContainsKey("alert"))
            {
                TempData.Add("alert", "Haber Bünteninde Zaten Eklisiniz");
            }

            return RedirectToAction("Index");
        }
    }
}
