using Karma.Entities.Concrete;
using Karma.MvcUI.Identity.DAL;

namespace Karma.MvcUI
{
    public class OrderGeneralModel
    {
        public IOrderedEnumerable<Order> Orders { get; set; }
        public List<Task<AppIdentityUser>> UserNames { get; set; }
    }
}