using Karma.MvcUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Karma.MvcUI.Controllers
{
    public class ÜrünController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ÜrünleriListele(ProductListViewModel model)
        {
            return View(model);
        }
    }
}
