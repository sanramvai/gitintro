using FinalSportStore.Views.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalSportStore.Infrastructure
{
    [HtmlTargetElement("div",Attributes="page-model")]
    public class PageLinkTagHelper:TagHelper
    {
        private IUrlHelperFactory HelperFactory;
        public PageInfo PageModel { get; set; }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public string PageAction { get; set; }
        public string btncss { get; set; }
        public string botnSelected { get; set; }
        public string botnNotSelected { get; set; }
        [HtmlAttributeName(DictionaryAttributePrefix = "Page-Url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        

        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            HelperFactory = helperFactory;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //IUrlHelper defines the contract for the helper to build Urls
            //Gets an IUrlHelper for the request associated with context
            IUrlHelper urlhelper = HelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            for (int i = 1; i < PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                  tag.AddCssClass(btncss);

                tag.AddCssClass(i == PageModel.CurrentPage ? botnSelected : botnNotSelected);
                PageUrlValues["PageNo"] = i;
                tag.Attributes["href"] = urlhelper.Action(PageAction,PageUrlValues);
                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
