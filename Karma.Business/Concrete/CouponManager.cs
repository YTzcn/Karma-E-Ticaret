using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Karma.Business.Abstract;
using Karma.DataAccess.Abstract;
using Karma.Entities.Concrete;

namespace Karma.Business.Concrete
{
    public class CouponManager : ICouponService
    {
        private readonly ICouponDal _couponDal;
        public CouponManager(ICouponDal couponDal)
        {
            _couponDal = couponDal;
        }
        public void Add(Coupon coupon)
        {
            string code = GenerateCouponCode(6);
            if (_couponDal.Get(x => x.CouponCode == code) != null)
            {
                code = GenerateCouponCode(6);
            }
            coupon.CouponCode = code;
            _couponDal.Add(coupon);
        }

        public void Delete(Coupon coupon)
        {
            _couponDal.Delete(coupon);
        }

        public Coupon Get(Expression<Func<Coupon, bool>> filter = null)
        {
            return _couponDal.Get(filter);
        }

        public List<Coupon> GetList(Expression<Func<Coupon, bool>> filter = null)
        {
            return _couponDal.GetList(filter);
        }

        public void Update(Coupon coupon)
        {
            _couponDal.Update(coupon);
        }
        static string GenerateCouponCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var couponCode = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                couponCode.Append(chars[index]);
            }

            return couponCode.ToString();
        }
    }
}
