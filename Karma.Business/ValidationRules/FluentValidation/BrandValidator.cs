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
       
        public BrandValidator()
        {
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("Marka Adı Boş Geçilemez");
            RuleFor(x => x.Active).NotEmpty().WithMessage("Aktiflik Durumu Boş Geçilemez");
           
        }
    }
}
