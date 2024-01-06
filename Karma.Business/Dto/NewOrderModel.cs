using Karma.Entities.Concrete;

namespace Karma.MvcUI
{
    public class NewOrderModel
    {
        public string UserId { get; set; }
        public Cart? Detail { get; set; }
        public decimal Total { get; set; }
    }
}