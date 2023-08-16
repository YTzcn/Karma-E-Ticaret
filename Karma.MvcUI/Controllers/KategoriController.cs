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
            ViewBag.Brands = brands;
            ViewBag.Shorting = shorting == null ? null : shorting;
            ViewBag.PageSize = pageSize;
            ViewBag.Color = color;
            ViewBag.lowerValue = lowerValue;
            ViewBag.upperValue = upperValue;

            if (String.IsNullOrEmpty(categoryName))
            {
                ProductListViewModel model = new ProductListViewModel
                {
                    Categories = _categoryService.GetAllActive()
                };
                return View(model);
            }
            else
            {//aferin aferin çalış tüm kodları bi anda silsem nabarsın 
                var CurrentCategoryId = _categoryService.Get(x => x.CategoryName.Trim().ToLower() == categoryName.ToLower()).CategoryId;
                var brandId = _brandService.GetAllId(x => brands.Contains(x.BrandName));
                var products = new List<Product>();
                if (!(brands.Length == 0) || !(color.Length == 0) || upperValue != null || lowerValue != null)
                {
                    products = _productService.GetByFilter(CurrentCategoryId, brandId, color, lowerValue, upperValue).Distinct().ToList();
                }
                else
                {
                    products = _productService.GetByCategoryId(CurrentCategoryId).Distinct().ToList();
                }
                switch (shorting)
                {
                    case "Fiyat":
                        products = products.OrderBy(x => x.Price).Distinct().ToList();
                        break;
                    case "A-Z":
                        products = products.OrderBy(y => y.ProductName).Distinct().ToList();
                        break;
                    default:
                        products = products;
                        break;
                }
                ProductListViewModel model = new ProductListViewModel
                {
                    CurrentCategory = CurrentCategoryId,
                    Categories = _categoryService.GetAllActive(),
                    Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                    PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),
                    PageSize = pageSize,
                    CurrentPage = page,
                    ProductsCount = products.Count

                };
                return View("ÜrünleriListele", model);
            }

        }


    }
}
