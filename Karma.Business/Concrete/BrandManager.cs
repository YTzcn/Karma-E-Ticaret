using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [FluentValidationAspect(typeof(BrandValidator))]
        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public List<Brand> GetList(Expression<Func<Brand, bool>> filter = null)
        {
            return _brandDal.GetList(filter);
        }

        public Brand Get(Expression<Func<Brand, bool>> filter = null)
        {
            return _brandDal.Get(filter);
        }
        [FluentValidationAspect(typeof(BrandValidator))]
        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }

        int[]? IBrandService.GetAllId(Expression<Func<Brand, bool>> filter)
        {
            var Ids = _brandDal.GetList(filter).Select(x => x.BrandId).ToArray();
            return Ids;
        }

        bool IBrandService.IsExist(Brand brandName)
        {
            bool exist = _brandDal.Get(x => x.BrandName == brandName.BrandName) != null ? true : false;
            return exist;
        }
    }
}
