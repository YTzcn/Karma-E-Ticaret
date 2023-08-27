namespace Karma.MvcUI.Models.Them
{
    public class CouponResultViewModel
    {
        public decimal? DiscountPrice { get; set; }
        public decimal? CartTotal { get; set; }
        public decimal originalTotal { get; set; }
        public string Message { get; set; }
    }
}