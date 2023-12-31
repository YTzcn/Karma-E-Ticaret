﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Business.Abstract;
using Karma.Entities.Concrete;

namespace Karma.Business.Concrete
{
    public class CartService : ICartService
    {
        public void AddCart(Cart cart, Product product, int? quantity)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (cartLine != null)
            {
                cartLine.Quantity++;
                return;
            }
            cart.CartLines.Add(new CartLine { Product = product, Quantity = (int)quantity });
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }

        public void RemoveFromCart(Cart cart, int productId)
        {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId));
        }
        public void RemoveCart(Cart cart)
        {
            cart.CartLines.Clear();
        }
    }
}
