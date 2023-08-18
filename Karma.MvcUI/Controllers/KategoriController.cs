using System.Drawing.Printing;
using System.Reflection.Metadata.Ecma335;
using Karma.Business.Abstract;
using Karma.Business.Concrete;
using Karma.Entities.Concrete;
using Karma.MvcUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Karma.MvcUI.Controllers
{
    public class KategoriController : Controller
    {
        private ICategoryService _categoryService;
        private IProductService _productService;
        private IBrandService _brandService;
        public KategoriController(ICategoryService categoryService, IProductService productService, IBrandService brandService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _brandService = brandService;
        }
        public IActionResult Index(string? categoryName, int page = 1, int pageSize = 12, string[] brands = null, string[] color = null, string upperValue = null, string lowerValue = null, string shorting = null)
        {
            ViewBag.BannerTitle = "Liste Görünümü";
            ViewBag.Brands = brands;
            ViewBag.Shorting = shorting;
            ViewBag.PageSize = pageSize;
            ViewBag.Color = color;
            ViewBag.LowerValue = lowerValue;
            ViewBag.UpperValue = upperValue;
            ViewBag.BannerArea1 = "Kategori";
            ViewBag.BannerArea2 = categoryName;

            ProductListViewModel model;

            if (String.IsNullOrEmpty(categoryName))
            {
                model = new ProductListViewModel
                {
                    Categories = _categoryService.GetAllActive()
                };
                return View(model);
            }
            else
            {
                var currentCategory = _categoryService.Get(x => x.CategoryName.ToLower() == categoryName.ToLower()).CategoryId;
                var brandIds = _brandService.GetAllId(x => brands != null && brands.Contains(x.BrandName));
                var products = _productService.GetByCategoryId(currentCategory);

                if (brandIds.Length > 0 || color?.Length > 0 || upperValue != null || lowerValue != null)
                {
                    products = _productService.GetByFilter(currentCategory, brandIds, color, lowerValue, upperValue, null);
                }

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

                model = new ProductListViewModel
                {
                    Categories = _categoryService.GetAllActive(),
                    CurrentCategory = currentCategory,
                    Products = pagedProducts,
                    PageCount = (int)Math.Ceiling(totalCount / (double)pageSize),
                    PageSize = pageSize,
                    CurrentPage = page,
                    ProductsCount = totalCount
                };
            }

            return View("ÜrünleriListele", model);
        }


    }
}
