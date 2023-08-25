using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Entities.Concrete;

namespace Karma.Business.Abstract
{
    public interface ICartService
    {
        void AddCart(Cart cart, Product product, int? quantity);
        void RemoveFromCart(Cart cart, int productId);
        void RemoveCart(Cart cart);
        List<CartLine> List(Cart cart);
    }
}
