using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Karma.Business.Abstract;
using Karma.Business.ValidationRules.FluentValidation;
using Karma.Core.Aspects.Postsharp;
using Karma.Core.Aspects.Postsharp.ValidationAspects;
using Karma.Core.CrossCuttingConcerns.Validation.FluentValidation;
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
        [FluentValidationAspect(typeof(CouponValidator))]
        public void Add(Coupon coupon)
        {
            if (_couponDal.Get(x => x.CouponCode == coupon.CouponCode) != null)
            {
                coupon.CouponCode = GenerateCouponCode(6);
            }
            ValidatorTool.FluentValidate(new CouponValidator(), coupon);

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
        [FluentValidationAspect(typeof(CouponValidator))]
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
