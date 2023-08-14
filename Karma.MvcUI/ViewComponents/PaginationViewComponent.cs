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
                Products = productListViewModel.Products,
                PageCount = productListViewModel.PageCount,
                PageSize = productListViewModel.PageSize,
                CurrentPage = productListViewModel.CurrentPage
            };
            return View(model);
        }
    }
}
