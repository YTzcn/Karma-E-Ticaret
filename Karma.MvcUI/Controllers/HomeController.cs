using Karma.Business.Abstract;
using Karma.MvcUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Karma.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ICategoryService categoryService)
        {
            
        }
        public IActionResult Index()
        {
            

            return View();
        }
    }
}
