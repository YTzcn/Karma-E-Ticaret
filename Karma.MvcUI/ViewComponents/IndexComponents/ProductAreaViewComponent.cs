using System.Collections.Concurrent;
using Karma.Business.Abstract;
using Karma.MvcUI.Models.Them;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Karma.MvcUI.ViewComponents.IndexComponents
{
    public class ProductAreaViewComponent : ViewComponent
    {
        private readonly IProductService _productService;
        public ProductAreaViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        public ViewViewComponentResult Invoke()
        {
            Random random = new Random();
            var products1 = _productService.GetAll().OrderBy(x => x.AddedDate).Take(8).ToList();
            var products2 = _productService.GetUpcomingProducts().Take(8).ToList();
            ProductAreaViewModel model = new ProductAreaViewModel
            {
                products1 = products1,
                products2 = products2,
            };
            return View(model);
        }
    }
}
