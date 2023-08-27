using System.Collections.Concurrent;
using System.Drawing.Printing;
using System.Drawing;
using Karma.Business.Abstract;
using Karma.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Karma.MvcUI.Models.Them;

namespace Karma.MvcUI.Controllers
{
    public class ÜrünController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        public ÜrünController(IProductService productService, IBrandService brandService, ICategoryService categoryService)
        {
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
        }
        public IActionResult Index(int page = 1, int pageSize = 12, string[] brands = null, string[] color = null, string upperValue = null, string lowerValue = null, string shorting = null, string categoryName = null)
        {
            ViewBag.BannerTitle = "Liste Görünümü";
            ViewBag.Brands = brands;
            ViewBag.CategoryName = categoryName;
            ViewBag.Shorting = shorting == null ? null : shorting;
            ViewBag.PageSize = pageSize;
            ViewBag.Color = color;
            ViewBag.lowerValue = lowerValue;
            ViewBag.upperValue = upperValue;
            ViewBag.BannerArea1 = "Ürünler";
            ViewBag.BannerArea2 = " Tüm Ürünler";

            ProductListViewModel model;
            var products = new List<Product>();
            var currentCategory = 0;
            if (!String.IsNullOrEmpty(categoryName))
            {
                currentCategory = categoryName != null ? _categoryService.Get(x => x.CategoryName.ToLower() == categoryName.ToLower()).CategoryId : 0;

            }
            var brandIds = _brandService.GetAllId(x => brands != null && brands.Contains(x.BrandName));
            products = _productService.GetByFilter(currentCategory, brandIds, color, lowerValue, upperValue, null);
            if (!string.IsNullOrEmpty(shorting))
            {
                products = shorting switch
                {
                    "Fiyat" => products.OrderBy(x => x.Price).ToList(),
                    "A-Z" => products.OrderBy(y => y.ProductName).ToList(),
                    _ => products
                };
            }
            var totalCount = products.Count;
            var pagedProducts = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var existCategories = products.Select(x => x.CategoryId).Distinct().ToList();
            var existColors = products.Select(x => x.Color).Distinct().ToList();
            var existBrandsId = products.Select(x => x.BrandId).Distinct().ToList();
            model = new ProductListViewModel
            {
                Categories = _categoryService.GetAllActive(),
                CurrentCategory = currentCategory,
                Products = pagedProducts,
                PageCount = (int)Math.Ceiling(totalCount / (double)pageSize),
                PageSize = pageSize,
                CurrentPage = page,
                ProductsCount = totalCount,
                ExistBrandsId = existBrandsId,
                ExistCategoriesId = existCategories,
                ExistColors = existColors

            };
            return View("ÜrünleriListele", model);
        }
        public IActionResult ÜrünleriListele(ProductListViewModel model)
        {

            return View(model);
        }
        public IActionResult Detay(string urunAdi)
        {
            var product = _productService.Get(x => x.ProductName == urunAdi.Replace('-', ' '));
            if (product != null)
            {
                var productCategory = _categoryService.Get(x => x.CategoryId == product.CategoryId).CategoryName;
                ProductDetailViewModel model = new ProductDetailViewModel()
                {
                    ProductDetail = product,
                    ProductCategory = productCategory
                };
                return View(model);
            }
            else
            {
                TempData.Add("alert", "İstenen Ürün Bulunamadı");
                return RedirectToAction("Index");
            }
        }

    }
}
