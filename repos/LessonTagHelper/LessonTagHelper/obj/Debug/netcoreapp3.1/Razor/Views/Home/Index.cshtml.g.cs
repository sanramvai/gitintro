#pragma checksum "C:\Users\sandh\source\repos\LessonTagHelper\LessonTagHelper\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75dc39783ad0452ef797bd54dab2812596c9fe97"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\sandh\source\repos\LessonTagHelper\LessonTagHelper\Views\_ViewImports.cshtml"
using LessonTagHelper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sandh\source\repos\LessonTagHelper\LessonTagHelper\Views\_ViewImports.cshtml"
using LessonTagHelper.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75dc39783ad0452ef797bd54dab2812596c9fe97", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1b99fd2a9fd67b9cfb6104659169f731b5b850a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EmployeeViewModel>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::LessonTagHelper.Models.EmployeeTagHelpers __LessonTagHelper_Models_EmployeeTagHelpers;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div>\r\n");
#nullable restore
#line 3 "C:\Users\sandh\source\repos\LessonTagHelper\LessonTagHelper\Views\Home\Index.cshtml"
 foreach (var employee in Model.Employees)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("employee", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "75dc39783ad0452ef797bd54dab2812596c9fe973330", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\sandh\source\repos\LessonTagHelper\LessonTagHelper\Views\Home\Index.cshtml"
         foreach (var friend in employee.Friends)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <friend");
                BeginWriteAttribute("name", " name=\"", 291, "\"", 310, 1);
#nullable restore
#line 10 "C:\Users\sandh\source\repos\LessonTagHelper\LessonTagHelper\Views\Home\Index.cshtml"
WriteAttributeValue("", 298, friend.Name, 298, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 11 "C:\Users\sandh\source\repos\LessonTagHelper\LessonTagHelper\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    ");
            }
            );
            __LessonTagHelper_Models_EmployeeTagHelpers = CreateTagHelper<global::LessonTagHelper.Models.EmployeeTagHelpers>();
            __tagHelperExecutionContext.Add(__LessonTagHelper_Models_EmployeeTagHelpers);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 5 "C:\Users\sandh\source\repos\LessonTagHelper\LessonTagHelper\Views\Home\Index.cshtml"
           WriteLiteral(employee.Name);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __LessonTagHelper_Models_EmployeeTagHelpers.Summary = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("summary", __LessonTagHelper_Models_EmployeeTagHelpers.Summary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 6 "C:\Users\sandh\source\repos\LessonTagHelper\LessonTagHelper\Views\Home\Index.cshtml"
             WriteLiteral(employee.JobTitle);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __LessonTagHelper_Models_EmployeeTagHelpers.JobTitle = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("job-title", __LessonTagHelper_Models_EmployeeTagHelpers.JobTitle, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 7 "C:\Users\sandh\source\repos\LessonTagHelper\LessonTagHelper\Views\Home\Index.cshtml"
           WriteLiteral(employee.Profile);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __LessonTagHelper_Models_EmployeeTagHelpers.Profile = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("profile", __LessonTagHelper_Models_EmployeeTagHelpers.Profile, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 13 "C:\Users\sandh\source\repos\LessonTagHelper\LessonTagHelper\Views\Home\Index.cshtml"
}  

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EmployeeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591