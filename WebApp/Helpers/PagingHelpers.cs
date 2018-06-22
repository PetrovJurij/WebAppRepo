using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using WebApp.Models;

namespace WebApp.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            TagBuilder rowDivTag = new TagBuilder("div");

            if (pageInfo.PageNumber > 1)
            {
                if(pageInfo.PageNumber > 2)
                {
                    TagBuilder toBeginTag = new TagBuilder("a");
                    toBeginTag.MergeAttribute("href", pageUrl(1));
                    toBeginTag.InnerHtml ="<<";
                    toBeginTag.AddCssClass("btn btn-default ");
                    toBeginTag.AddCssClass("col-xs-6");
                    result.Append(toBeginTag.ToString());
                }
                TagBuilder previousTag = new TagBuilder("a");
                previousTag.MergeAttribute("href", pageUrl(pageInfo.PageNumber - 1));
                previousTag.InnerHtml = "<";
                previousTag.AddCssClass("btn btn-default");
                previousTag.AddCssClass("col-xs-6");
                result.Append(previousTag.ToString());
            }

            TagBuilder currentPageTag = new TagBuilder("p");
            currentPageTag.InnerHtml = pageInfo.PageNumber.ToString();
            currentPageTag.AddCssClass("col-xs-6");
            result.Append(currentPageTag);

            if (pageInfo.PageNumber < pageInfo.TotalPages)
            {
                if (pageInfo.PageNumber < pageInfo.TotalPages-1)
                {
                    TagBuilder toEndTag = new TagBuilder("a");
                    toEndTag.MergeAttribute("href", pageUrl(pageInfo.TotalPages));
                    toEndTag.InnerHtml = ">>";
                    toEndTag.AddCssClass("btn btn-default");
                    toEndTag.AddCssClass("col-xs-6");
                    result.Append(toEndTag.ToString());
                }
                TagBuilder nextTag = new TagBuilder("a");
                nextTag.MergeAttribute("href", pageUrl(pageInfo.PageNumber + 1));
                nextTag.InnerHtml = ">";
                nextTag.AddCssClass("btn btn-default");
                nextTag.AddCssClass("col-xs-6");
                result.Append(nextTag.ToString());
            }

            rowDivTag.InnerHtml = result.ToString();
            rowDivTag.AddCssClass("row");


            return MvcHtmlString.Create(rowDivTag.ToString());
        }
    }
}