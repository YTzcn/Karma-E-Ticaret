using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.Business.Abstract;
using Karma.Business.ValidationRules.FluentValidation;
using Karma.Core.Aspects.Postsharp;
using Karma.Core.Aspects.Postsharp.CacheAspects;
using Karma.Core.Aspects.Postsharp.ExceptionsAspects;
using Karma.Core.Aspects.Postsharp.ValidationAspects;
using Karma.Core.CrossCuttingConcerns.Caching.Microsoft;
using Karma.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Karma.Core.CrossCuttingConcerns.Validation.FluentValidation;
using Karma.DataAccess.Abstract;
using Karma.Entities.Concrete;

namespace Karma.Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [FluentValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]

        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
        }

        [FluentValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }
        [CacheAspect(typeof(MemoryCacheManager), 60)]

        public List<Brand> GetAll()
        {
            return _brandDal.GetList();
        }
        [CacheAspect(typeof(MemoryCacheManager), 60)]

        public Brand GetById(int Id)
        {
            return _brandDal.Get(x => x.BrandId == Id);
        }
        [FluentValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
        [CacheAspect(typeof(MemoryCacheManager), 60)]
        public int[]? GetAllId(string[] brands)
        {
            var Ids = _brandDal.GetList(x => x.Active == true && brands.Contains(x.BrandName)).Select(x => x.BrandId).ToArray();
            return Ids;
        }
        [FluentValidationAspect(typeof(BrandValidator))]
        public bool IsExist(Brand brandName)
        {
            bool exist = _brandDal.Get(x => x.BrandName == brandName.BrandName) != null ? true : false;
            return exist;
        }
    }
}
