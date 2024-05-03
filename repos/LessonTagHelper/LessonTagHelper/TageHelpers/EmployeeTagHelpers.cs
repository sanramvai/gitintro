using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTagHelper.Models
{
    [HtmlTargetElement("employee")]
    public class EmployeeTagHelpers:TagHelper
    {
        [HtmlAttributeName("Summary")]
        public string Summary { get; set; }
        [HtmlAttributeName("Job-Title")]
        public string JobTitle { get; set; }
        [HtmlAttributeName("Profile")]
        public string Profile { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "details";
            output.TagMode = TagMode.StartTagAndEndTag;
            var sb = new StringBuilder();
            sb.AppendFormat("<Summary>{0}</Summary>", this.Summary);
            sb.AppendFormat("<em>{0}</em>", this.JobTitle);
            sb.AppendFormat("<p>{0}</p>", this.Profile);
            sb.AppendFormat("<ul>");
            output.PreContent.SetHtmlContent(sb.ToString());
            output.PostContent.SetHtmlContent("</ul>");
        }
    }
}
