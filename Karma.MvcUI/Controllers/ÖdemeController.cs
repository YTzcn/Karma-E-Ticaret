using Karma.Business.Abstract;
using Karma.MvcUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Karma.MvcUI.Controllers
{
    public class ÖdemeController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICartSessionService _cartSessionService;
        private readonly IProductService _productService;
        private readonly ICouponService _couponService;
        public ÖdemeController(IProductService productService, ICartService cartService, ICartSessionService cartSessionService, ICouponService couponService)
        {
            _cartService = cartService;
            _productService = productService;
            _cartSessionService = cartSessionService;
            _couponService = couponService;
        }
        public IActionResult Index(string? x)
        {
            bool first = true;
            var cart = _cartSessionService.GetCart();
            decimal? couponPrice = _couponService.Get(x => x.CouponCode == cart.CouponCode)?.Price;
            PaymentViewModel model = new PaymentViewModel()
            {
                Cart = cart,
                DiscountPrice = couponPrice,
            }
            ; if (x == "true")
            {
                TempData.Add("message", "Ödemeniz başarıyla gerçekleşti.");
                _cartService.RemoveCart(cart);
                _cartSessionService.SetCart(cart);
                return RedirectToAction("Index","Home");
            }
            else
            {
                if (first == true)
                {
                    first = false;
                    return View(model);
                }
                else
                {
                    TempData.Add("alert", "Ödemede Hata Meydana Geldi Lütfen Tekrar Deneyin");
                    return View(model);
                }

            }
        }
    }
}
