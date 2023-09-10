using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Caching;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Karma.Business.Abstract;
using Karma.Business.ValidationRules.FluentValidation;
using Karma.Core.Aspects.Postsharp;
using Karma.Core.Aspects.Postsharp.CacheAspects;
using Karma.Core.Aspects.Postsharp.LogAspects;
using Karma.Core.Aspects.Postsharp.ValidationAspects;
using Karma.Core.CrossCuttingConcerns.Caching.Microsoft;
using Karma.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Karma.Core.CrossCuttingConcerns.Validation.FluentValidation;
using Karma.DataAccess.Abstract;
using Karma.Entities.Concrete;

namespace Karma.Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    public class CouponManager : ICouponService
    {
        private readonly ICouponDal _couponDal;
        public CouponManager(ICouponDal couponDal)
        {
            _couponDal = couponDal;
        }
        [FluentValidationAspect(typeof(CouponValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(Coupon coupon)
        {
            if (_couponDal.Get(x => x.CouponCode == coupon.CouponCode) != null)
            {
                coupon.CouponCode = GenerateCouponCode(6);
            }
            ValidatorTool.FluentValidate(new CouponValidator(), coupon);

            _couponDal.Add(coupon);
        }
        [FluentValidationAspect(typeof(CouponValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Coupon coupon)
        {
            _couponDal.Delete(coupon);
        }
        [CacheAspect(typeof(MemoryCacheManager), 60)]
        public Coupon GetById(int Id)
        {
            return _couponDal.Get(x => x.Id == Id);
        }
        [CacheAspect(typeof(MemoryCacheManager), 60)]

        public List<Coupon> GetAll()
        {
            return _couponDal.GetList();
        }
        [FluentValidationAspect(typeof(CouponValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
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
        [CacheAspect(typeof(MemoryCacheManager), 60)]
        public Coupon GetByCouponCode(string Code)
        {
            return _couponDal.Get(c => c.CouponCode == Code && c.IsActive == true && c.ExpirationDate >= DateTime.Now);
        }
    }
}
