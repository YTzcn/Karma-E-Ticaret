using Karma.Business.Abstract;
using Karma.Entities;
using Karma.Entities.Concrete;
using Karma.MvcUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Karma.MvcUI.ViewComponents
{
    public class LeftNavbarViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        public LeftNavbarViewComponent(ICategoryService categoryService, IBrandService brandService)
        {
            _categoryService = categoryService;
            _brandService = brandService;
        }
        public ViewViewComponentResult Invoke(ProductListViewModel productListViewModel, string Route)
        {
            List<Category> categoryList = new List<Category>();
            List<Brand> brandList = new List<Brand>();
            if (Route == "Ara")
            {
                var categories = productListViewModel.Products.Select(x => x.CategoryId).Distinct();
                foreach (var category in categories)
                {
                    categoryList.Add(_categoryService.Get(x => x.CategoryId == category));
                }
            }
            else
            {
                categoryList.AddRange(_categoryService.GetAll());
            }
            var colorList = productListViewModel.Products.Select(x => x.Color).Distinct().ToList();
            var brands = productListViewModel.Products.Select(x => x.BrandId).Distinct().ToList();
            foreach (var brand in brands)
            {
                brandList.Add(_brandService.Get(x => x.BrandId == brand));
            }
            LeftNavbarViewModel model = new LeftNavbarViewModel
            {
                Categories = categoryList,
                Brands = brandList,
                Colors = colorList,

            };
            return View(model);
        }
    }
}
