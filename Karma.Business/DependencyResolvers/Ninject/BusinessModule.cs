using Karma.Business.Abstract;
using Karma.Business.Concrete;
using Karma.DataAccess;
using Karma.DataAccess.Abstract;
using Karma.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;

namespace Karma.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InTransientScope(); 
            Bind<IProductDal>().To<EfProductDal>().InTransientScope();

            Bind<ICategoryService>().To<CategoryManager>().InTransientScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InTransientScope();

            Bind<IImageService>().To<ImageManager>().InTransientScope();
            Bind<IImageDal>().To<EfImageDal>().InTransientScope();

            Bind<IBrandService>().To<BrandManager>().InTransientScope();
            Bind<IBrandDal>().To<EfBrandDal>().InTransientScope();

            Bind<ICommentService>().To<CommentManager>().InTransientScope();
            Bind<ICommentDal>().To<EfCommentDal>().InTransientScope();

            Bind<IContactService>().To<ContactMessageManager>().InTransientScope();
            Bind<IContactMessageDal>().To<EfContactMessageDal>().InTransientScope();

            Bind<INewstellerSubService>().To<NewstellerSubManager>().InTransientScope();
            Bind<INewstellerSubDal>().To<EfNewstellerSubDal>().InTransientScope();

            Bind<ICouponService>().To<CouponManager>().InSingletonScope();
            Bind<ICouponDal>().To<EfCouponDal>().InSingletonScope();
        }
    }
}
