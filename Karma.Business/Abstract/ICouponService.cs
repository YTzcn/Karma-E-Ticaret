﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.Entities.Concrete;

namespace Karma.Business.Abstract
{
    public interface ICouponService
    {
        public void Add(Coupon coupon);
        public void Update(Coupon coupon);
        public void Delete(Coupon coupon);
        public List<Coupon> GetAll();
        public Coupon GetById(int Id);
        public Coupon GetByCouponCode(string Code);
    }
}
