using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Core.DataAccess.EntityFramework;
using Karma.DataAccess.Abstract;
using Karma.Entities.Concrete;

namespace Karma.DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, KarmaContext>, IBrandDal
    {
        bool IBrandDal.IsExsit(Brand brand)
        {
            using (var context = new KarmaContext())
            {
                bool exist = context.Brands.Where(x => x.BrandName== brand.BrandName) != null ? true : false;
                return exist;
            }
        }
    }
}
