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
    public class EfCampaignProductDal : EfEntityRepositoryBase<CampaignProduct, KarmaContext>, ICampaignProductDal
    {
        public CampaignProduct GetWithProduct(Expression<Func<CampaignProduct, bool>> filter = null)
        {
            using (KarmaContext context = new KarmaContext())
            {
                return context.CampaginProducts.Include(x => x.Product).Include(x => x.Product.Images).FirstOrDefault(filter);
            }
        }
        public List<CampaignProduct> GetAllList(Expression<Func<CampaignProduct, bool>> filter = null)
        {
            using (KarmaContext context = new KarmaContext())
            {
                return context.CampaginProducts.Include((x => x.Product)).Include(x => x.Product.Images).Where(filter).ToList();
            }
        }
    }
}
