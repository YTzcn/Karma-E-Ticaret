using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Karma.Entities;

namespace Karma.Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilmez");
            RuleFor(x => x.CategoryName).Length(2, 20).WithMessage("Kategori Adı Minimum 2 Maksimum 20 Karakter Olmalıdır");
            RuleFor(x => x.Active).NotEmpty().WithMessage("Aktiflik Durumu Mutlaka İşaretlenmelidir");
            //RuleFor(x => x.ImagePath).NotEmpty().WithMessage("Kategori Görseli Boş Geçilemez");
        }
    }
}
