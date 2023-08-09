using System.Drawing.Printing;
using System.Reflection.Metadata.Ecma335;
using Karma.Business.Abstract;
using Karma.Business.Concrete;
using Karma.Entities.Concrete;
using Karma.MvcUI.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index(string? categoryName, int page = 1, int pageSize = 12, string[] brandName = null, string[] color = null, string upperValue = null, string lowerValue = null)
        {

            if (String.IsNullOrEmpty(categoryName))
            {
                ProductListViewModel model = new ProductListViewModel
                {
                    Categories = _categoryService.GetAllActive()
                };
                return View(model);
            }
            else
            {
                var id = _categoryService.Get(x => x.CategoryName.Trim().ToLower() == categoryName.ToLower()).CategoryId;
                var brandId = _brandService.GetAllId(x => brandName.Contains(x.BrandName));
                var products = new List<Product>();
                if (!(brandName.Length == 0) || !(color.Length == 0) || upperValue != null || lowerValue != null)
                {
                    products = _productService.GetByFilter(brandId, color, lowerValue, upperValue);
                }
                else
                {
                    products = _productService.GetByCategoryId(id);
                }
                //products = _productService.GetByFilter(brandId, color, lowerValue, upperValue).Where(x => x.CategoryId == id).ToList();

                ProductListViewModel model = new ProductListViewModel
                {
                    Categories = _categoryService.GetAllActive(),
                    Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                    PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),
                    PageSize = pageSize,
                    CurrentPage = page

                };
                return View("ÜrünleriListele", model);
            }

        }


    }
}
