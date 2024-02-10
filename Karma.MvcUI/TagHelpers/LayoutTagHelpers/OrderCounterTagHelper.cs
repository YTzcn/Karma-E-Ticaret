using Karma.Business.Abstract;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace Karma.MvcUI.TagHelpers.LayoutTagHelpers
{
    [HtmlTargetElement("order-counter")]
    public class OrderCounterTagHelper : TagHelper
    {
        private readonly IOrderService _orderService;
        public OrderCounterTagHelper(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreElement.SetHtmlContent("<li class=\"menu-item\">");
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("<a href=\"~/Admin/Orders\" class=\"menu-link\">\r\n                <i class=\"menu-icon tf-icons bx bxs-cart\"></i>\r\n                <div data-i18n=\"Analytics\">Siparişler - <span class=\"badge bg-danger rounded-pill\">{0}</span> </div>\r\n            </a>\r\n      ", _orderService.GetAll(1).Count);
            output.Content.SetHtmlContent(stringBuilder.ToString());
            output.PostContent.SetHtmlContent("</li");
            base.Process(context, output);
        }
    }
}
