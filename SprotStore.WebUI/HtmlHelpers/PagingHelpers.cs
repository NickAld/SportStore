using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace SportsStore.WebUI.HtmlHelpers
{
    using System.Web.Mvc;
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, Models.PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            var totalPage = pagingInfo.TotalPage;
            for (int i=1; i<= totalPage; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                    tag.AddCssClass("selected");
                result.Append(tag.ToString());
            }

            return MvcHtmlString.Create(result.ToString());
        }
        
    }
}