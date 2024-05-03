﻿using EmployeeTechManage.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTechManage.Infrastructure
{
    [HtmlTargetElement("div",Attributes="Page-Model")]
    public class PageLinkTagHelper:TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory _urlHelperFactory)
        {
            urlHelperFactory = _urlHelperFactory;
                
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string,object> PageUrlValues { get; set; }
                            = new Dictionary<string,object>();
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            for(int i=1;i<=PageModel.TotalPages;i++)
            {
                TagBuilder tag = new TagBuilder("a");
                PageUrlValues["empPage"] = i;


                tag.Attributes["href"] = urlHelper.Action(PageAction,PageUrlValues);
                tag.InnerHtml.Append(i.ToString());
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    result.InnerHtml.AppendHtml(tag);
                }
            }
            output.Content.AppendHtml(result.InnerHtml);

        }
    }
}
