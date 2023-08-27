using Karma.Entities.Concrete;

namespace Karma.MvcUI.Models.Them
{
    public class PaymentViewModel
    {
        public Cart Cart { get; set; }
        public decimal? DiscountPrice { get; set; }
    }
}