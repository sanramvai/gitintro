using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonTagHelper.TageHelpers
{
    [HtmlTargetElement("email",Attributes="background-color")]
    public class EmailTagHelper:TagHelper
    {
        // The context parameter to Process(and ProcessAsync) contains information associated with the execution of the current HTML tag.

        //The output parameter to Process(and ProcessAsync) contains a stateful HTML element representative of the original source used to generate an HTML tag and content.
        private const string EmailDomain = "Yahoo.com";
        [HtmlAttributeName("receipent")]    
        public string MailTo { get; set; }
        public string BackgroundColor { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var address = MailTo + "@" + EmailDomain;
            output.Attributes.SetAttribute("href", "mailTo" + address);
            output.Attributes.Add("class", $"btn btn-{BackgroundColor}");
            output.Content.SetContent(address);
        }
    }
}
