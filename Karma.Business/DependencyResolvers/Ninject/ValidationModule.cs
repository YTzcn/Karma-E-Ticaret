using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Karma.Business.ValidationRules.FluentValidation;
using Karma.Entities;
using Karma.Entities.Concrete;
using Ninject.Modules;

namespace Karma.Business.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope();
            Bind<IValidator<Image>>().To<ImageValidator>().InSingletonScope();
            Bind<IValidator<Category>>().To<CategoryValidator>().InSingletonScope();
            Bind<IValidator<Coupon>>().To<CouponValidator>().InSingletonScope();
            Bind<IValidator<Brand>>().To<BrandValidator>().InSingletonScope();
        }
    }
}
