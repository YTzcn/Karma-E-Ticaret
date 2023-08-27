using Karma.Entities;
using Karma.Entities.Concrete;

namespace Karma.MvcUI.Models.Them
{
    public class LeftNavbarViewModel
    {

        public List<Category> Categories { get; set; }
        public List<Brand> Brands { get; set; }
        public List<string> Colors { get; set; }
    }
}