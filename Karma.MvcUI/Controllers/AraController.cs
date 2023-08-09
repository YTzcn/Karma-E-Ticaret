using Microsoft.AspNetCore.Mvc;

namespace Karma.MvcUI.Controllers
{
    public class AraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
