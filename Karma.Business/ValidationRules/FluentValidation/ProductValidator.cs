using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Karma.Business.Abstract;
using Karma.DataAccess;
using Karma.Entities.Concrete;

namespace Karma.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Category.CategoryId).NotEmpty().WithMessage("Kategori Boş Geçilemez");
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün Adı Boş Geçilemez");
            RuleFor(x => x.Brand.BrandId).NotEmpty().WithMessage("Marka Boş Olamaz");
            RuleFor(x => x.Active).NotNull().WithMessage("Aktiflik Durumu Boş Olamaz");
            RuleFor(x => x.UnitInStock).NotNull().WithMessage("Stok Boş Geçilmez");
            RuleFor(x => x.Color).NotEmpty().WithMessage("Renk Boş Geçilmez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Alanı Boş Geçilmez");
            RuleFor(x => x.SubDescription).NotEmpty().WithMessage("Alt Açıklama Alanı Boş Geçilmez");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Ürün Id Boş Olamaz");

            //RuleFor(x => x.Spesifications.Width).NotEmpty().WithMessage("Ürün Genişliği Boş Geçilmez");
            //RuleFor(x => x.Spesifications.Weight).NotEmpty().WithMessage("Ürün Ağırlığı Boş Geçilmez");
            //RuleFor(x => x.Spesifications.Height).NotEmpty().WithMessage("Ürün Yüksekliği Boş Geçilmez");
            //RuleFor(x => x.Spesifications.Depth).NotEmpty().WithMessage("Ürün Derinliği Boş Geçilmez");
            //RuleFor(x => x.Spesifications.FreshnessDuration).NotEmpty().WithMessage("Ürün Taze Saklama Süresi Boş Geçilmez");
            //RuleFor(x => x.Spesifications.QualityCheck).NotEmpty().WithMessage("Ürün Kalite Kontrol Durumu Boş Geçilmez");
            //RuleFor(x => x.Spesifications.QuantityPerBox).NotEmpty().WithMessage("Kutu Adedi Kısmı Boş Geçilmez");
            //RuleFor(x => x.Spesifications.WhenPacketing).NotEmpty().WithMessage("Paketleme Türü (Makine/El) Boş Geçilmez");

            RuleFor(x => x.ProductName).Length(2, 50).WithMessage("Ürün Adı Minimum 2 Maksimum 50 Karakter Olmalıdır");

        }
    }
}
