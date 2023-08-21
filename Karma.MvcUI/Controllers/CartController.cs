using Karma.Business.Abstract;
using Karma.MvcUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Karma.MvcUI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICartSessionService _cartSessionService;
        private readonly IProductService _productService;
        public CartController(IProductService productService, ICartService cartService, ICartSessionService cartSessionService)
        {
            _cartService = cartService;
            _productService = productService;
            _cartSessionService = cartSessionService;
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

    }
}
