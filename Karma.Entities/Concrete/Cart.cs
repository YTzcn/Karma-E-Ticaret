using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Entities.Concrete
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<CartLine>();
        }
        public decimal? _totalPrice;
        public List<CartLine> CartLines { get; set; }
        public decimal Total
        {
            get { return CartLines.Sum(c => c.Product.Price * c.Quantity); }
            set { _totalPrice = value; }
        }
        public string CouponCode { get; set; }
    }
}

