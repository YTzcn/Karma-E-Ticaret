using Karma.Entities.Concrete;

namespace Karma.MvcUI.Services
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
