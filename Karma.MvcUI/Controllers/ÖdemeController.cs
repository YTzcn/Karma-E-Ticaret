using System.Collections.Generic;
using Karma.Business.Abstract;
using Karma.Entities.Concrete;
using Karma.MvcUI.Models.Them;
using Karma.MvcUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using Karma.MvcUI.Identity.DAL;

namespace Karma.MvcUI.Controllers
{
    [Authorize]
    public class ÖdemeController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICartSessionService _cartSessionService;
        private readonly IMailService _mailService;
        private readonly ICouponService _couponService;
        private readonly IOrderService _orderService;
        private readonly UserManager<AppIdentityUser> _userManager;

        public ÖdemeController(UserManager<AppIdentityUser> userManager, IProductService productService, ICartService cartService, ICartSessionService cartSessionService, ICouponService couponService, IMailService mailService, IOrderService orderService)
        {
            _cartService = cartService;
            _mailService = mailService;
            _cartSessionService = cartSessionService;
            _couponService = couponService;
            _orderService = orderService;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {

            var cart = _cartSessionService.GetCart();
            decimal? couponPrice = _couponService.GetByCouponCode(cart.CouponCode)?.Price;
            PaymentViewModel model = new PaymentViewModel()
            {
                Cart = cart,
                DiscountPrice = couponPrice,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(string? x)
        {
            var id = _userManager.GetUserId(HttpContext.User);
            var cart = _cartSessionService.GetCart();
            decimal? couponPrice = _couponService.GetByCouponCode(cart.CouponCode)?.Price;
            PaymentViewModel model = new PaymentViewModel()
            {
                Cart = cart,
                DiscountPrice = couponPrice,
            };
            if (x == "true")
            {
                TempData.Add("message", "Ödemeniz başarıyla gerçekleşti.");
                NewOrderModel order = new NewOrderModel()
                {
                    UserId = id,
                    Detail = cart,
                    Total = cart.Total,
                };
                _orderService.Add(order);
                _mailService.SendSummaryMail("yahyatezcan.yahya@gmail.com", cart, couponPrice);
                _cartService.RemoveCart(cart);
                _cartSessionService.SetCart(cart);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData.Add("alert", "Ödemede Hata Meydana Geldi Lütfen Tekrar Deneyin");
                return View(model);
            }
        }
    }
}
