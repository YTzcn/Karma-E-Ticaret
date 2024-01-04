using Karma.Business.Abstract;
using Karma.Entities;
using Karma.Entities.Concrete;
using Karma.MvcUI.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

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
        public IActionResult UploadImage(int ProductId, IFormFile file)
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
        [HttpGet]
        public IActionResult AddProduct()
        {
            var brands = _brandService.GetAll();
            var categories = _categoryService.GetAll();
            EditProductViewModel model = new EditProductViewModel()
            {
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
        public IActionResult AddProduct(Product product)
        {
            try
            {
                _productService.Add(product);
                int ProductId = _productService.GetByProductName(product.ProductName).ProductId;
                return Redirect("~/Admin/Edit/" + ProductId);
            }
            catch (Exception ex)
            {
                TempData.Add("bilgi", "Yükleme Sırasında Hata : " + ex.Message);
                return RedirectToAction("AddProduct");
                throw;
            }
        }
        [HttpGet]
        public IActionResult AddProductImage(int productId)
        {
            return View(productId);
        }
        [HttpGet]
        public IActionResult Categories()
        {
            var categories = _categoryService.GetAllActive();
            AdminCategoriesViewModel model = new AdminCategoriesViewModel()
            {
                AllCategories = categories
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult CategoryEdit(int CategoryId)
        {
            var category = _categoryService.GetById(CategoryId);
            CategoryEditViewModel model = new CategoryEditViewModel()
            {
                Category = category
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult CategoryEdit(Category category)
        {
            var Category = _categoryService.GetById(category.CategoryId);
            Category.Active = category.Active;
            Category.CategoryName = category.CategoryName;
            _categoryService.Update(Category);
            return RedirectToAction("Categoryies");
        }
        [HttpGet]
        public IActionResult DeleteCategoryImage(int categoryId)
        {
            try
            {

                var category = _categoryService.GetById(categoryId);
                System.IO.File.Delete(category.ImagePath);
                category.ImagePath = "";
                _categoryService.Update(category);
                return Redirect("~/Admin/CategoryEdit?categoryId=" + categoryId);
            }
            catch (Exception ex)
            {

                return Json(BadRequest());
            }

        }
        [HttpPost]
        public IActionResult UploadCategoryImage(int categoryId, IFormFile file)
        {

            var filePath = Path.Combine("wwwroot\\KarmaUI\\img\\kategori", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                file.CopyTo(stream);
            }
            var category = _categoryService.GetById(categoryId);
            category.ImagePath = filePath;
            _categoryService.Update(category);
            return Redirect("~/Admin/CategoryEdit?categoryId=" + categoryId);
        }
    }
}
