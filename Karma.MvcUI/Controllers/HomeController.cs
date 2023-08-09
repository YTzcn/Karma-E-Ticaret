using Karma.Business.Abstract;
using Karma.MvcUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Karma.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryService _categoryService;
        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            ProductListViewModel model = new ProductListViewModel 
            {
                Categories = _categoryService.GetAllActive()
            };

            return View(model);
        }
    }
}
