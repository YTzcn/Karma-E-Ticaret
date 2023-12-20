using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Karma.Entities;

namespace Karma.Business.ValidationRules.FluentValidation
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            //RuleFor(X => X.PublicId).NotEmpty().WithMessage("Public Id Boş Olamaz");
            //RuleFor(X => X.Url).NotEmpty().WithMessage("Url Boş Olamaz");
        }
    }
}
