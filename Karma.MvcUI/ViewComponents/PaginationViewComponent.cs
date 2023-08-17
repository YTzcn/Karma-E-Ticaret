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
                CurrentPage = productListViewModel.CurrentPage,
                ProductsCount = productListViewModel.ProductsCount,
            };

            if (productListViewModel.ProductsCount == 0)
            {
                model.Products = null;
                model.PageCount = 0;
                model.CurrentPage = 1;
                model.ProductsCount = 0;
            }

            return View(model);
        }

    }
}
