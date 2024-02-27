using System.Collections.Concurrent;
using Humanizer;
using Karma.Business.Abstract;
using Karma.MvcUI.Models.Them;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Build.Framework;

namespace Karma.MvcUI.ViewComponents.IndexComponents
{
    public class BannerAreaViewComponent : ViewComponent
    {
        private readonly IShowcaseProductsService _showcaseProductsService;
        public BannerAreaViewComponent(IShowcaseProductsService showcaseProductsService)
        {
            _showcaseProductsService = showcaseProductsService;
        }
        public ViewViewComponentResult Invoke()
        {
            Random random = new Random();
            var Product = _showcaseProductsService.GetList();
            BannerAreaViewModel model = new BannerAreaViewModel
            {
                ProductList = Product,
            };
            return View(model);
        }
    }
}
