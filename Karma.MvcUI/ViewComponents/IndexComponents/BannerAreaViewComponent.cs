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
        private readonly IProductService _productService;
        public BannerAreaViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        public ViewViewComponentResult Invoke()
        {
            Random random = new Random();
            var Product = _productService.GetAll().Where(x => x.Images.Count != 0).OrderBy(x => random.Next()).Take(5).ToList();
            foreach (var item in Product)
            {
                if (item.ProductName.Length > 20)
                {
                    item.ProductName = item.ProductName.Substring(0, 20) + "...";
                }
            }
            BannerAreaViewModel model = new BannerAreaViewModel
            {
                ProductList = Product,
            };
            return View(model);
        }
    }
}
