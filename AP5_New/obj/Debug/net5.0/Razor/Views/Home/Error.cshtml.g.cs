#pragma checksum "D:\backup\Project\AP5_New\AP5_New\Views\Home\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "943c4959a2d73f776396446d2e2e9e4ac8aa5918"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Error), @"mvc.1.0.view", @"/Views/Home/Error.cshtml")]
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
#line 1 "D:\backup\Project\AP5_New\AP5_New\Views\_ViewImports.cshtml"
using AP5_New;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\backup\Project\AP5_New\AP5_New\Views\_ViewImports.cshtml"
using AP5_New.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"943c4959a2d73f776396446d2e2e9e4ac8aa5918", @"/Views/Home/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb958e8af8d48387dc57e369fcfae206f0f20567", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AP5_New.Models.ErrorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 16 "D:\backup\Project\AP5_New\AP5_New\Views\Home\Error.cshtml"
  
    ViewBag.Title = "Error";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div align=\"center\" valign=\"center\">\r\n    <h1 class=\"text-danger\">系統錯誤</h1>\r\n</div>\r\n<h2>請聯絡系統管理員，RequestID: ");
#nullable restore
#line 22 "D:\backup\Project\AP5_New\AP5_New\Views\Home\Error.cshtml"
                   Write(Model.RequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 23 "D:\backup\Project\AP5_New\AP5_New\Views\Home\Error.cshtml"
 if (@ViewBag.ErrorMsg != null)
{
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>錯誤訊息: ");
#nullable restore
#line 26 "D:\backup\Project\AP5_New\AP5_New\Views\Home\Error.cshtml"
         Write(ViewBag.ErrorMsg);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 27 "D:\backup\Project\AP5_New\AP5_New\Views\Home\Error.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AP5_New.Models.ErrorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
