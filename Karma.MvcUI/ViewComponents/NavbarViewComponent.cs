using Karma.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Karma.MvcUI.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public NavbarViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public ViewViewComponentResult Invoke()
        {
            var categories = _categoryService.GetAllActive();
            return View(categories);
        }
    }
}
