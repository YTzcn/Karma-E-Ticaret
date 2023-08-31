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
        //private readonly IProductDal _productDal;
        public ProductValidator(/*IProductDal productDal*/)
        {
            //_productDal = productDal;
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori Boş Geçilemez");
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün Adı Boş Geçilemez");
            RuleFor(x => x.BrandId).NotEmpty().WithMessage("Marka Boş Olamaz");
            RuleFor(x => x.Active).NotEmpty().WithMessage("Aktiflik Durumu Boş Olamaz");
            RuleFor(x => x.UnitInStock).NotEmpty().WithMessage("Stok Boş Geçilmez");
            RuleFor(x => x.Color).NotEmpty().WithMessage("Renk Boş Geçilmez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Alanı Boş Geçilmez");
            RuleFor(x => x.SubDescription).NotEmpty().WithMessage("Alt Açıklama Alanı Boş Geçilmez");

            RuleFor(x => x.Spesifications.Width).NotEmpty().WithMessage("Ürün Genişliği Boş Geçilmez");
            RuleFor(x => x.Spesifications.Weight).NotEmpty().WithMessage("Ürün Ağırlığı Boş Geçilmez");
            RuleFor(x => x.Spesifications.Height).NotEmpty().WithMessage("Ürün Yüksekliği Boş Geçilmez");
            RuleFor(x => x.Spesifications.Depth).NotEmpty().WithMessage("Ürün Derinliği Boş Geçilmez");
            RuleFor(x => x.Spesifications.FreshnessDuration).NotEmpty().WithMessage("Ürün Taze Saklama Süresi Boş Geçilmez");
            RuleFor(x => x.Spesifications.QualityCheck).NotEmpty().WithMessage("Ürün Kalite Kontrol Durumu Boş Geçilmez");
            RuleFor(x => x.Spesifications.QuantityPerBox).NotEmpty().WithMessage("Kutu Adedi Kısmı Boş Geçilmez");
            RuleFor(x => x.Spesifications.WhenPacketing).NotEmpty().WithMessage("Paketleme Türü (Makine/El) Boş Geçilmez");

            RuleFor(x => x.ProductName).Length(2, 50).WithMessage("Ürün Adı Minimum 2 Maksimum 50 Karakter Olmalıdır");
            //RuleFor(x => x.ProductName).MustAsync(async (name, cancellation) =>
            //{
            //    bool exists = _productDal.IsExsit(new Product { ProductName = name });
            //    return exists;
            //}).WithMessage("Aynı Ürün Adına Sahip Ürün Var Lütfen Farklı Bir Ürün Adı Girin");

        }
    }
}
