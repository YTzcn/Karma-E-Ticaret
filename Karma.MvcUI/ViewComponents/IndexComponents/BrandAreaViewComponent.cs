﻿using Karma.Business.Abstract;
using Karma.MvcUI.Models.Them;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Karma.MvcUI.ViewComponents.IndexComponents
{
    public class BrandAreaViewComponent : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        public BrandAreaViewComponent(IProductService productService, IBrandService brandService)
        {
            _productService = productService;
            _brandService = brandService;
        }
        public ViewViewComponentResult Invoke()
        {

            var Brands = _brandService.GetAll();
            BrandAreaViewModel model = new BrandAreaViewModel
            {
                Brands = Brands
            };
            return View(model);
        }
    }
}
