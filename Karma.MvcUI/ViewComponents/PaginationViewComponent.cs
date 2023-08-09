using Karma.Business.Abstract;
using Karma.MvcUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Karma.MvcUI.ViewComponents
{
    public class PaginationViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke(ProductListViewModel productListViewModel, int page = 1, int pageSize = 12)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = productListViewModel.Products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling(productListViewModel.Products.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentPage = page
            };
            return View(model);
        }
    }
}
