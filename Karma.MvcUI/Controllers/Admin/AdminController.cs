using System.IO;
using Karma.Business.Abstract;
using Karma.Entities;
using Karma.Entities.Concrete;
using Karma.MvcUI.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Karma.MvcUI.Controllers.Admin
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        private readonly IImageService _imageService;
        public AdminController(IProductService productService, IBrandService brandService, ICategoryService categoryService, IImageService imageService)
        {
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
            _imageService = imageService;
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
        [HttpGet]
        public IActionResult DeleteImage(int id, int productId)
        {
            try
            {
                _imageService.DeactiveImage(id);
                return Redirect("~/Admin/Edit/" + productId);
            }
            catch (Exception)
            {

                return Json(BadRequest());
            }

        }
        [HttpPost]
        public IActionResult UploadImage(int ProductId, string url, IFormFile file)
        {

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), file.FileName);
            using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                file.CopyTo(stream);
            }
            Image image = new Image()
            {
                Url = filePath,
                ProductId = ProductId
            };
            _imageService.Add(image);
            System.IO.File.Delete(filePath);
            return Redirect("~/Admin/Edit/" + ProductId);
        }
    }
}
