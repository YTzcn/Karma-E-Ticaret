using System.Xml.Schema;
using Karma.Business.Abstract;
using Karma.MvcUI.Models.Them;
using Karma.MvcUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;

namespace Karma.MvcUI.Controllers
{
    public class SepetController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICartSessionService _cartSessionService;
        private readonly IProductService _productService;
        private readonly ICouponService _couponService;
        public SepetController(IProductService productService, ICartService cartService, ICartSessionService cartSessionService, ICouponService couponService)
        {
            _cartService = cartService;
            _productService = productService;
            _cartSessionService = cartSessionService;
            _couponService = couponService;

        }
        public IActionResult Index()
        {

            var cart = _cartSessionService.GetCart();
            CartViewModel model = new CartViewModel
            {
                Cart = cart
            };
            return View(model);
        }
        public IActionResult AddToCart(int productId, int? quantity = 1)
        {
            var productToBeAdded = _productService.GetById(productId);
            var cart = _cartSessionService.GetCart();
            _cartService.AddCart(cart, productToBeAdded, quantity);
            _cartSessionService.SetCart(cart);
            if (!TempData.ContainsKey("message"))
            {
                TempData.Add("message", string.Format("Ürününüz {0} Sepete Eklendi ", productToBeAdded.ProductName));

            }
            return RedirectToAction("Index", "Ürün");
        }
        public IActionResult RemoveFromCart(int productId)
        {
            ViewBag.BannerTitle = "Sepetim";
            ViewBag.BannerArea1 = "Sepet";
            ViewBag.BannerArea2 = "Sepet Detayları";
            var productToBeRemoved = _productService.GetById(productId);
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            if (!String.IsNullOrEmpty(cart.CouponCode))
            {
                var couponCode = _couponService.Get(x => x.CouponCode == cart.CouponCode).Price;
                if (cart.Total < couponCode)
                {
                    _cartSessionService.SetCart(cart);
                    RemoveCoupon();
                    if (!TempData.ContainsKey("alert"))
                    {
                        TempData.Add("alert", string.Format("Sepetin güncel tutarı aktif kupondan küçük olduğu için kupon kaldırıldı."));
                        return RedirectToAction("Index", "Sepet");

                    }
                }
            }
            _cartSessionService.SetCart(cart);
            if (!TempData.ContainsKey("alert"))
            {
                TempData.Add("message", string.Format("Ürün {0} Başarıyla Sepetten Silindi", productToBeRemoved.ProductName));
            }


            return RedirectToAction("Index", "Sepet");
        }
        [HttpPost]
        public JsonResult UpdateProductInCart(int productId, int quantity)
        {

            var cart = _cartSessionService.GetCart();
            var cartProduct = cart.CartLines.FirstOrDefault(x => x.Product.ProductId == productId);
            cartProduct.Quantity = quantity;
            decimal endPrice = cartProduct.Product.Price * quantity;
            CartJsonViewModel model = new CartJsonViewModel
            {
                EndPrice = endPrice,
                CartTotal = cart.Total
            };
            if (quantity == 0)
            {
                RemoveFromCart(productId);
            }
            if (!String.IsNullOrEmpty(cart.CouponCode))
            {
                var couponCode = _couponService.Get(x => x.CouponCode == cart.CouponCode).Price;
                if (cart.Total < couponCode)
                {
                    _cartSessionService.SetCart(cart);
                    RemoveCoupon();
                    if (!TempData.ContainsKey("alert"))
                    {
                        TempData.Add("alert", string.Format("Sepetin güncel tutarı aktif kupondan küçük olduğu için kupon kaldırıldı."));
                        var json = new
                        {
                            message = "Başarılı",
                            redirectTo = Url.Action("Index", "Sepet")
                        };
                        return Json(json);
                    }
                }
            }
            _cartSessionService.SetCart(cart);

            return Json(model);
        }
        public JsonResult RemoveCoupon()
        {
            var cart = _cartSessionService.GetCart();
            cart._totalPrice = cart.Total;
            cart.CouponCode = "";
            CouponResultViewModel model = new CouponResultViewModel
            {
                CartTotal = cart.Total,
                originalTotal = cart.Total,
            };
            _cartSessionService.SetCart(cart);
            return Json(model);
        }
        [HttpPost]
        public JsonResult CouponControl(string couponCode)
        {
            var cart = _cartSessionService.GetCart();
            CouponResultViewModel model;
            decimal? price = _couponService.Get(c => c.CouponCode == couponCode && c.IsActive == true && c.ExpirationDate >= DateTime.Now)?.Price;
            if (price > cart.Total)
            {
                model = new CouponResultViewModel()
                {
                    Message = "Kupon Değeri Sepet Tutarından Büyük. Kupon Bu Alışverişte Kullanılamaz"
                };
                return Json(model);
            }
            else if (price == null)
            {
                model = new CouponResultViewModel()
                {
                    Message = "Geçersiz Kupon Kodu"
                };
                return Json(model);
            }
            else
            {
                cart._totalPrice = cart.Total - price;
                cart.CouponCode = couponCode;
                decimal? cartTotal = cart._totalPrice;
                model = new CouponResultViewModel
                {
                    DiscountPrice = price,
                    CartTotal = cartTotal,
                    originalTotal = cart.Total
                };
                _cartSessionService.SetCart(cart);
                return Json(model);
            }
        }
    }
}
