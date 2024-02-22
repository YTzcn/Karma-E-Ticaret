using Karma.Core.DataAccess;
using Karma.Entities.Concrete;
using System.Linq.Expressions;

namespace Karma.DataAccess.Abstract
{
    public interface ICampaignProductDal : IEntityRepository<CampaignProduct>
    {
        public CampaignProduct GetWithProduct(Expression<Func<CampaignProduct, bool>> filter = null);
        public List<CampaignProduct> GetAllList(Expression<Func<CampaignProduct, bool>> filter = null);

    }
}
