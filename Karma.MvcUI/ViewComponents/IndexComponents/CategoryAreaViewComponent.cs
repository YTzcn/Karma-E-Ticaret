using System.Collections.Concurrent;
using Karma.Business.Abstract;
using Karma.MvcUI.Models.Them;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Karma.MvcUI.ViewComponents.IndexComponents
{
    public class CategoryAreaViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public CategoryAreaViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public ViewViewComponentResult Invoke()
        {
            var categories = _categoryService.GetAllActive();
            CategoriesViewModel model = new CategoriesViewModel
            {
                Categories = categories,
            };
            return View(model);
        }
    }
}
