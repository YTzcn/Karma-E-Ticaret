using Karma.Entities.Concrete;

namespace Karma.Business.Abstract
{
    public interface ICampaignService
    {
        List<CampaignProduct> GetAll();
        CampaignProduct GetById(int id);
        void Add(CampaignProduct campaginProduct);
        void Update(CampaignProduct campaginProduct);
        void Delete(CampaignProduct campaignProduct);
        List<CampaignProduct> GetAllActive();
    }
}
