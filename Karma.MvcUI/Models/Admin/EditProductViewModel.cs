using Karma.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Karma.MvcUI
{
    public class EditProductViewModel
    {
        public Product Product { get; set; }
        public List<SelectListItem> BrandListItem { get; set; }
        public List<SelectListItem> CategoryListItem { get; set; }
        public bool IsUpcoming { get; set; }
    }
}