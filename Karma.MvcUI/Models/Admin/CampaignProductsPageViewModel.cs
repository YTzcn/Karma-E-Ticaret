using Karma.Entities.Concrete;

namespace Karma.MvcUI
{
    internal class CampaignProductsPageViewModel
    {
        public List<Product> Products { get; set; }
        public List<CampaignProduct> CampaignedProducts { get; set; }
    }
}