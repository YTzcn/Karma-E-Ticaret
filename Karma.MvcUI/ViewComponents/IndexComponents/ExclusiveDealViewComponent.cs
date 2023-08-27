using Karma.Business.Abstract;
using Karma.MvcUI.Models.Them;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Karma.MvcUI.ViewComponents.IndexComponents
{
    public class ExclusiveDealViewComponent : ViewComponent
    {
        private readonly IProductService _productService;
        public ExclusiveDealViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        public ViewViewComponentResult Invoke()
        {
            Random random = new Random();
            var Products = _productService.GetList().OrderBy(x => random.Next()).Take(3).ToList();
            ExclusiveDealViewModel model = new ExclusiveDealViewModel
            {
                Products = Products
            };
            return View(model);
        }
    }
}
