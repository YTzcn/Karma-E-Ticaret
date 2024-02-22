using Karma.Business.Abstract;
using Karma.DataAccess.Abstract;
using Karma.Entities.Concrete;

namespace Karma.Business.Concrete
{
    public class CampaignManager : ICampaignService
    {
        private readonly ICampaignProductDal _campaignProductDal;
        public CampaignManager(ICampaignProductDal campaignProductDal)
        {
            _campaignProductDal = campaignProductDal;
        }
        public void Add(CampaignProduct campaginProduct)
        {
            _campaignProductDal.Add(campaginProduct);
        }

        public void Delete(CampaignProduct campaignProduct)
        {
            _campaignProductDal.Delete(campaignProduct);
        }

        public List<CampaignProduct> GetAll()
        {
            return _campaignProductDal.GetAllList();
        }

        public CampaignProduct GetById(int id)
        {
            return _campaignProductDal.GetWithProduct(x => x.Id == id);
        }

        public void Update(CampaignProduct campaginProduct)
        {
            _campaignProductDal.Update(campaginProduct);
        }

        public List<CampaignProduct> GetAllActive()
        {
            return _campaignProductDal.GetAllList(x => x.Active == true);
        }
    }
}
