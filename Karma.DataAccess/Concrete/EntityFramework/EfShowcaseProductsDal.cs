using Karma.Core.DataAccess.EntityFramework;
using Karma.DataAccess.Abstract;
using Karma.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Karma.DataAccess.Concrete.EntityFramework
{
    public class EfShowcaseProductsDal : EfEntityRepositoryBase<ShowcaseProducts, KarmaContext>, IShowcaseProductsDal
    {
        public ShowcaseProducts GetWithProduct(Expression<Func<ShowcaseProducts, bool>> filter = null)
        {
            using (KarmaContext context = new KarmaContext())
            {
                var showcaseProduct = filter == null ? context.ShowcaseProducts.Include(x => x.Product).Include(x => x.Product.Images).FirstOrDefault() : context.ShowcaseProducts.Include(x => x.Product).Include(x => x.Product.Images).FirstOrDefault(filter);
                return showcaseProduct;
            }
        }
        public List<ShowcaseProducts> GetAllList(Expression<Func<ShowcaseProducts, bool>> filter = null)
        {
            using (KarmaContext context = new KarmaContext())
            {
                var list = filter == null ? context.ShowcaseProducts.Include(x => x.Product).Include(x => x.Product.Images).ToList() : context.ShowcaseProducts.Include((x => x.Product)).Include(x => x.Product.Images).Where(filter).ToList();
                return list;
            }
        }
    }
}
