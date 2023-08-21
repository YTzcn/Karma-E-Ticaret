using Karma.Business.Abstract;
using Karma.MvcUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

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
        public IActionResult AddToCart(int productId)
        {
            var productToBeAdded = _productService.Get(x => x.ProductId == productId);
            var cart = _cartSessionService.GetCart();
            _cartService.AddCart(cart, productToBeAdded);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", string.Format("Ürününüz {0} Sepete Eklendi ", productToBeAdded.ProductName));
            return RedirectToAction("Index", "Ürün");
        }
        public IActionResult RemoveFromCart(int productId)
        {
            var productToBeRemoved = _productService.Get(y => y.ProductId == productId);
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", string.Format("Ürün {0} Başarıyla Sepetten Silindi", productToBeRemoved.ProductName));
            return RedirectToAction("Index", "Sepet");
        }
        [HttpPost]
        public JsonResult UpdateProductInCart(int productId, int quantity)
        {
            var cart = _cartSessionService.GetCart();
            var cartProduct = cart.CartLines.FirstOrDefault(x => x.Product.ProductId == productId);
            cartProduct.Quantity = quantity;
            decimal endPrice = cartProduct.Product.Price * quantity;
            cart._totalPrice = cart.CartLines.Sum(c => c.Product.Price * c.Quantity);
            CartJsonViewModel model = new CartJsonViewModel
            {
                EndPrice = endPrice,
                CartTotal = cart.Total
            };
            _cartSessionService.SetCart(cart);
            return Json(model);
        }
        [HttpPost]
        public JsonResult CouponControl(string couponCode)
        {
            var cart = _cartSessionService.GetCart();

            decimal? price = _couponService.Get(c => c.CouponCode == couponCode && c.IsActive == true && c.ExpirationDate >= DateTime.Now)?.Price;
            if (price != null)
            {
                cart._totalPrice -= price;
                cart.CouponCode = couponCode;
                decimal? cartTotal = cart._totalPrice;
                _cartSessionService.SetCart(cart);
                CouponResultViewModel model = new CouponResultViewModel
                {
                    DiscountPrice = price,
                    CartTotal = cartTotal,
                    originalTotal = cart.Total
                };
                return Json(model);
            }
            else
            {
                TempData.Add("message", "Kupon Kodu Yanlış Ya Da Tarihi Geçmiş");
                return Json(null);
            }
        }
    }
}
