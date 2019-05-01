using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Klad.Models
{
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PageViewModel PageModel { get; set; }
        public string PageAction { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "div";

            // набор ссылок будет представлять список ul
            TagBuilder tag = new TagBuilder("ul");
            tag.AddCssClass("pagination");

            // формируем три ссылки - на текущую, следующую и следующую2


            if (PageModel.PageNumber == 1)
            {
                TagBuilder currentItem = CreateTag(PageModel.PageNumber, urlHelper); //текущая
                tag.InnerHtml.AppendHtml(currentItem);

                if (PageModel.HasNextPage)
                {
                    TagBuilder nextItem = CreateTag(PageModel.PageNumber + 1, urlHelper);
                    tag.InnerHtml.AppendHtml(nextItem);
                }

                if (PageModel.HasNextTwoPage)
                {
                    TagBuilder nextItem2 = CreateTag(PageModel.PageNumber + 2, urlHelper);
                    tag.InnerHtml.AppendHtml(nextItem2);
                }

            }
            else if (PageModel.PageNumber == PageModel.TotalPages)
            {
                if (PageModel.HasPreviousTwoPage)
                {
                    TagBuilder prevItem = CreateTag(PageModel.PageNumber - 2, urlHelper);
                    tag.InnerHtml.AppendHtml(prevItem);
                }

                if (PageModel.HasPreviousPage)
                {
                    TagBuilder prevItem = CreateTag(PageModel.PageNumber - 1, urlHelper);
                    tag.InnerHtml.AppendHtml(prevItem);
                }

                TagBuilder currentItem = CreateTag(PageModel.PageNumber, urlHelper); //текущая
                tag.InnerHtml.AppendHtml(currentItem);
            }
            else
            {
                // создаем ссылку на предыдущую страницу, если она есть
                if (PageModel.HasPreviousPage)
                {
                    TagBuilder prevItem = CreateTag(PageModel.PageNumber - 1, urlHelper);
                    tag.InnerHtml.AppendHtml(prevItem);
                }

                TagBuilder currentItem = CreateTag(PageModel.PageNumber, urlHelper); //текущая
                tag.InnerHtml.AppendHtml(currentItem);

                // создаем ссылку на следующую страницу, если она есть
                if (PageModel.HasNextPage)
                {
                    TagBuilder nextItem = CreateTag(PageModel.PageNumber + 1, urlHelper);
                    tag.InnerHtml.AppendHtml(nextItem);
                }
            }

            output.Content.AppendHtml(tag);
        }

        TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
        {
            TagBuilder item = new TagBuilder("li");
            TagBuilder link = new TagBuilder("a");
            if (pageNumber == this.PageModel.PageNumber)
            {
                item.AddCssClass("active");
            }
            else
            {
                link.Attributes["href"] = urlHelper.Action(PageAction, new { page = pageNumber });
            }
            link.InnerHtml.Append(pageNumber.ToString());
            item.InnerHtml.AppendHtml(link);
            return item;
        }
    }

}
