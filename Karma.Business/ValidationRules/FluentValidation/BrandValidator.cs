using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Karma.Business.Abstract;
using Karma.DataAccess.Abstract;
using Karma.Entities.Concrete;

namespace Karma.Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        private readonly IBrandDal _brandDal;
        public BrandValidator(IBrandDal brandDal)
        {
            _brandDal = brandDal;
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("Marka Adı Boş Geçilemez");
            RuleFor(x => x.Active).NotEmpty().WithMessage("Aktiflik Durumu Boş Geçilemez");
            RuleFor(x => x.BrandName).MustAsync(async (name, cancellation) =>
            {
                bool exists = _brandDal.IsExsit(new Brand { BrandName = name });
                return exists;
            }).WithMessage("Marka Daha Önce Kayıt Edilmiş Lütfen Farklı Bir Marka Adı Giriniz");
        }
    }
}
