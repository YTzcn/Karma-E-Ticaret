using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Karma.Business.Abstract;
using Karma.Entities.Concrete;

namespace Karma.Business.ValidationRules.FluentValidation
{
    public class CouponValidator : AbstractValidator<Coupon>
    {
        public CouponValidator()
        {
            RuleFor(x => x.IsActive).NotEmpty().WithMessage("Kupon Tek Kullanımlık Mı Boş Geçilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Kupon Değeri Boş Geçilemez");
            RuleFor(x => x.CouponCode).NotEmpty().WithMessage("Kupon Kodu Boş Geçilemez");
            RuleFor(x => x.ExpirationDate).NotEmpty().WithMessage("Son Kullanma Tarihi Boş Geçilemez Boş Geçilemez");

            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Kupon Değeri Sıfırdan Büyük Olmalı");
        }
    }
}
