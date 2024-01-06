using Karma.Entities.Concrete;

namespace Karma.MvcUI
{
    public class OrdersViewModel
    {
        public IOrderedEnumerable<Order> Orders { get; set; }
    }
}