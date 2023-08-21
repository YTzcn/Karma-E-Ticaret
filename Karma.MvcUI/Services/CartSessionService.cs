using Karma.Entities.Concrete;
using Karma.MvcUI.ExtensionMethods;

namespace Karma.MvcUI.Services
{
    public class CartSessionService : ICartSessionService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public CartSessionService(IHttpContextAccessor contextAccessor)
        {

            _contextAccessor = contextAccessor;

        }
        public Cart GetCart()
        {
            Cart cartToCheck = _contextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            if (cartToCheck == null)
            {
                _contextAccessor.HttpContext.Session.SetObject("cart", new Cart());
                cartToCheck = _contextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            }
            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            _contextAccessor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}
