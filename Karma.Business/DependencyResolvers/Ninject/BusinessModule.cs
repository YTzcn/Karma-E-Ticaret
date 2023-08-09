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
            //Bind<IProductService>().To<ProductManager>().InTransientScope();
            //Bind<IProductDal>().To<EfProductDal>().InTransientScope();

            //Bind<ICategoryService>().To<CategoryManager>().InTransientScope();
            //Bind<ICategoryDal>().To<EfCategoryDal>().InTransientScope();

            //Bind<IImageService>().To<ImageManager>().InTransientScope();
            //Bind<IImageDal>().To<EfImageDal>().InTransientScope();
        }
    }
}
