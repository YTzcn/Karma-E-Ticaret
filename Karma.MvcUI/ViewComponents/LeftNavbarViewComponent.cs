using Karma.Business.Abstract;
using Karma.Entities;
using Karma.Entities.Concrete;
using Karma.MvcUI.Models.Them;
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
        public ViewViewComponentResult Invoke(ProductListViewModel productListViewModel, string controller, string queryString)
        {
            var model = CreateLeftNavbarViewModel(productListViewModel, controller);
            return View(model);
        }

        private LeftNavbarViewModel CreateLeftNavbarViewModel(ProductListViewModel productListViewModel, string controller)
        {
            var model = new LeftNavbarViewModel
            {
                Categories = GetCategories(productListViewModel, controller),
                Brands = GetBrands(productListViewModel, controller),
                Colors = GetColors(productListViewModel, controller),
            };
            return model;
        }

        private List<Category> GetCategories(ProductListViewModel productListViewModel, string controller)
        {
            if (controller == "Ara")
            {
                var categories = productListViewModel.ExistCategoriesId;
                return categories.Select(category => _categoryService.GetById(category)).ToList();
            }
            else if (controller == "Kategori")
            {
                return _categoryService.GetAllActive().ToList();
            }
            else if (controller == "Ürün")
            {
                return _categoryService.GetAllActive().ToList();
            }
            return new List<Category>();
        }

        private List<Brand> GetBrands(ProductListViewModel productListViewModel, string controller)
        {
            var brands = new List<Brand>();
            if (controller == "Ara")
            {
                var brandIds = productListViewModel.ExistBrandsId;
                brands.AddRange(brandIds.Select(brandId => _brandService.GetById(brandId)));
            }
            else if (controller == "Kategori")
            {
                var productsInCategory = _productService.GetListByCategory(productListViewModel.CurrentCategory);
                var brandIds = productsInCategory.Select(x => x.BrandId).Distinct();
                brands.AddRange(brandIds.Select(brandId => _brandService.GetById(brandId)));
            }
            else if (controller == "Ürün")
            {
                var productBrands = _productService.GetAll().Select(x => x.BrandId).Distinct();
                brands.AddRange(productBrands.Select(brandId => _brandService.GetById(brandId)));
            }
            return brands;
        }

        private List<string> GetColors(ProductListViewModel productListViewModel, string controller)
        {
            var colors = new List<string>();
            if (controller == "Ara")
            {
                colors.AddRange(productListViewModel.ExistColors);
            }
            else if (controller == "Kategori")
            {
                var productsInCategory = _productService.GetListByCategory(productListViewModel.CurrentCategory);
                colors.AddRange(productsInCategory.Select(x => x.Color).Distinct());
            }
            else if (controller == "Ürün")
            {
                colors.AddRange(_productService.GetAll().Select(x => x.Color).Distinct());
            }
            return colors;
        }

    }

}
