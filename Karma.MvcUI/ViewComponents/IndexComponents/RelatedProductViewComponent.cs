using Karma.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Karma.MvcUI.ViewComponents.IndexComponents
{
    public class RelatedProductViewComponent : ViewComponent
    {
        private readonly IProductService _productService;
        public RelatedProductViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        public ViewViewComponentResult Invoke()
        {
            Random random = new Random();
            var products = _productService.GetList().OrderBy(x => random.Next()).Take(9).ToList();
            RelatedProductViewModel model = new RelatedProductViewModel
            {
                Products = products
            };
            return View(model);
        }
    }
}
