using Karma.Business.Abstract;
using Karma.MvcUI.Models.Them;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Karma.MvcUI.ViewComponents.IndexComponents
{
    public class ExclusiveDealViewComponent : ViewComponent
    {
        private readonly ICampaignService _campaignService;
        public ExclusiveDealViewComponent(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }
        public ViewViewComponentResult Invoke()
        {
            var products = _campaignService.GetAllActive();
            ExclusiveDealViewModel model = new ExclusiveDealViewModel
            {
                Products = products
            };
            return View(model);
        }
    }
}
