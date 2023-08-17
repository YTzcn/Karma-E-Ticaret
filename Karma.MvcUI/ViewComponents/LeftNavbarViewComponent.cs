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
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        public LeftNavbarViewComponent(ICategoryService categoryService, IBrandService brandService, IProductService productService)
        {
            _categoryService = categoryService;
            _brandService = brandService;
            _productService = productService;
        }
        public ViewViewComponentResult Invoke(ProductListViewModel productListViewModel, string Controller, string queryString)
        {
            List<Category> categoryList = new List<Category>();
            List<Brand> brandList = new List<Brand>();
            var colorList = new List<string>();
            var brands = new List<int>();
            if (Controller == "Ara")
            {
                var categories = productListViewModel.ExistCategoriesId;
                categoryList.AddRange(categories.Select(category => _categoryService.Get(x => x.CategoryId == category)));
                colorList = productListViewModel.ExistColors;
                brands = productListViewModel.ExistBrandsId;
                brandList.AddRange(brands.Select(brand => _brandService.Get(x => x.BrandId == brand)));
            }
            else
            {
                categoryList.AddRange(_categoryService.GetAllActive());

                colorList = _productService.GetAll(x => x.CategoryId == productListViewModel.CurrentCategory)
                                             .Select(x => x.Color)
                                             .Distinct()
                                             .ToList();
                brands = _productService.GetAll(x => x.CategoryId == productListViewModel.CurrentCategory)
                                            .Select(x => x.BrandId)
                                            .Distinct()
                                            .ToList();
                brandList.AddRange(brands.Select(brand => _brandService.Get(x => x.BrandId == brand)));
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
