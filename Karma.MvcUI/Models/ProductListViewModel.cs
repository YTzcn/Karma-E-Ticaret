using Karma.Entities;
using Karma.Entities.Concrete;

namespace Karma.MvcUI.Models
{
    public class ProductListViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; } = 12;
        public int CurrentPage { get; set; } = 1;
        public int CurrentCategory { get; set; }
        public int ProductsCount { get; set; }
        public List<int> ExistCategoriesId { get; set; }
        public List<string> ExistColors { get; set; }
        public List<int> ExistBrandsId { get; set; }
    }
}