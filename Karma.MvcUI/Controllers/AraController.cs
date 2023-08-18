using Karma.Business.Abstract;
using Karma.DataAccess;
using Karma.Entities.Concrete;
using Karma.MvcUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Karma.MvcUI.Controllers
{
    public class AraController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        public AraController(IProductService productService, ICategoryService categoryService, IBrandService brandService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
        }
        public IActionResult Index(string key, int page = 1, int pageSize = 12, string[] brands = null, string[] color = null, string upperValue = null, string lowerValue = null, string shorting = null, string categoryName = null)
        {
            ViewBag.BannerTitle = "Liste Görünümü";
            ViewBag.Brands = brands;
            ViewBag.CategoryName = categoryName;
            ViewBag.Key = key;
            ViewBag.Shorting = shorting == null ? null : shorting;
            ViewBag.PageSize = pageSize;
            ViewBag.Color = color;
            ViewBag.lowerValue = lowerValue;
            ViewBag.upperValue = upperValue;
            ViewBag.BannerArea1 = "Ara";
            ViewBag.BannerArea2 = key;

            ProductListViewModel model;
            var products = new List<Product>();
            var currentCategory = 0;
            if (!String.IsNullOrEmpty(categoryName))
            {
                currentCategory = categoryName != null ? _categoryService.Get(x => x.CategoryName.ToLower() == categoryName.ToLower()).CategoryId : 0;

            }
            var brandIds = _brandService.GetAllId(x => brands != null && brands.Contains(x.BrandName));
            products = _productService.GetByFilter(currentCategory, brandIds, color, lowerValue, upperValue, key);
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
                ExistCategoriesId = existCategories,
                ExistColors = existColors,
                ExistBrandsId = existBrandsId,
                CurrentCategory = currentCategory,
                Products = pagedProducts,
                PageCount = (int)Math.Ceiling(totalCount / (double)pageSize),
                PageSize = pageSize,
                CurrentPage = page,
                ProductsCount = totalCount
            };
            return View("ÜrünleriListele", model);
        }
    }
}
