using Karma.Entities.Concrete;

namespace Karma.MvcUI
{
    internal class OrderModel
    {
        public Cart? Order { get; set; }
        public int OrderId { get; set; }
    }
}