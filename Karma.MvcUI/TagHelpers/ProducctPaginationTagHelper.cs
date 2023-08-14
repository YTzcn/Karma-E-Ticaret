using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Karma.MvcUI.TagHelpers
{
    [HtmlTargetElement("product-list-pager")]
    public class ProducctPaginationTagHelper : TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }
        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }
        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreElement.SetHtmlContent("<div class='pagination'>");
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= PageCount; i++)
            {
                sb.AppendFormat("<a name='page' onclick='submitForm()' name='page' data-value=\"{2}\" class='{0}' href='{1}'>{2}</a>", i == CurrentPage ? "active" : "", "?page=" + i, i);

            }
            output.Content.SetHtmlContent(sb.ToString());
            output.PostContent.SetHtmlContent("</div>");

            base.Process(context, output);

        }
    }
}
