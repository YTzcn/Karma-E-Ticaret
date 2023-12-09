using Karma.Business.Abstract;
using Karma.MvcUI.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Karma.MvcUI.Controllers.Admin
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        public AdminController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Products()
        {
            var products = _productService.GetAll();
            AdminProductsViewModel model = new AdminProductsViewModel()
            {
                Products = products
            };
            return View(model);
        }
    }
}
