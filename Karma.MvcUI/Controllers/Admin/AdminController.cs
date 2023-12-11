using System.Reflection.Metadata.Ecma335;
using Karma.Business.Abstract;
using Karma.Entities.Concrete;
using Karma.MvcUI.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Karma.MvcUI.Controllers.Admin
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        public AdminController(IProductService productService, IBrandService brandService, ICategoryService categoryService)
        {
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
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
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var product = _productService.GetById(Id);
            var brands = _brandService.GetAll();
            var categories = _categoryService.GetAll();
            EditProductViewModel model = new EditProductViewModel()
            {
                Product = product,
                BrandListItem = (from x in brands
                                 select new SelectListItem
                                 {
                                     Value = x.BrandId.ToString(),
                                     Text = x.BrandName
                                 }).ToList(),
                CategoryListItem = (from x in categories
                                    select new SelectListItem
                                    {
                                        Value = x.CategoryId.ToString(),
                                        Text = x.CategoryName
                                    }).ToList()
            };
            return View(model);

        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _productService.Update(product);
            return RedirectToAction("Products");
        }
        public IActionResult DecreasingProducts()
        {
            var products = _productService.GetProductLessThan5Quantity();
            AdminProductsViewModel model = new AdminProductsViewModel()
            {
                Products = products
            };
            return View(model);
        }
        public IActionResult OutOfStock()
        {
            var products = _productService.OutOfStock();
            AdminProductsViewModel model = new AdminProductsViewModel()
            {
                Products = products
            };
            return View(model);
        }
    }
}
