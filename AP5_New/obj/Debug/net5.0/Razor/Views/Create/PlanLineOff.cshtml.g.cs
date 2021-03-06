#pragma checksum "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b908b57efcb482bd2cd1f91bf4a3c3f2f853c594"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Create_PlanLineOff), @"mvc.1.0.view", @"/Views/Create/PlanLineOff.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b908b57efcb482bd2cd1f91bf4a3c3f2f853c594", @"/Views/Create/PlanLineOff.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb958e8af8d48387dc57e369fcfae206f0f20567", @"/Views/_ViewImports.cshtml")]
    public class Views_Create_PlanLineOff : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AP5_New.Models.PlanLineoff>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
  
    ViewData["Title"] = "計畫下線台數維護";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    <h2>計畫下線台數維護</h2>\r\n    <div class=\"text-danger\" id=\"erroMessage\">\r\n        ");
#nullable restore
#line 8 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
   Write(TempData["Message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 12 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
 using (Html.BeginForm("ModLineOffPlan", "Create", FormMethod.Post, new { id = "Form1" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"SearchConditionSection\" class=\"col-12\">\r\n        <table class=\"table table-bordered\">\r\n            <tr>\r\n                <td><b>日期</b></td>\r\n                <td>\r\n                    ");
#nullable restore
#line 20 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
               Write(Html.TextBoxFor(model => model.StartDt, new { id = "DateSearching" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td><b>廠別</b></td>\r\n                <td>\r\n                    ");
#nullable restore
#line 24 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
               Write(Html.DropDownListFor(model => model.PlantCode, (List<SelectListItem>)ViewBag.plantcode, string.Empty, new { id = "PlantCodeSearching" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td><b>直別</b></td>\r\n                <td>\r\n                    ");
#nullable restore
#line 28 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
               Write(Html.DropDownListFor(model => model.ShiftType, (List<SelectListItem>)ViewBag.shifttype, string.Empty, new { id = "ShiftTypeSearching" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td><b>下線台數</b></td>\r\n                <td>\r\n                    ");
#nullable restore
#line 32 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
               Write(Html.TextBoxFor(model => model.Lineoff, new { id = "Lineoff"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </td>
            </tr>
        </table>

        <div class=""row"">
            <div class=""col-2"">
                <button type=""submit"" class=""btn  btn-primary"" id=""SearchData"" name=""search"" value=""Search"">查詢</button>
            </div>
            <div class=""col-2"">
                <button type=""submit"" class=""btn btn-dark"" id=""ExportBtn"" name=""export"" value=""Export"">匯出資料</button>
            </div>
            <div class=""col-2"">
                <button type=""submit"" class=""btn btn-warning"" id=""deleteBtn"" name=""delete"" value=""Delete"" onclick=""return confirm('確定刪除?')"">刪除資料</button>
            </div>
        </div>
    </div>
");
#nullable restore
#line 49 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<div class=\"col-12\">\r\n");
#nullable restore
#line 52 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
     using (Html.BeginForm("ImportfromFile", "Create", FormMethod.Post, new { enctype = "multipart/form-data" }))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <input type=""file"" name=""files"" multiple />
        <button type=""submit"" class=""btn btn-info"" name=""submitType"" value=""Import"" id=""ImportBtn"">
            匯入資料
        </button>
        <button type=""submit"" class=""btn btn-info"" name=""submitType"" value=""SampleDownload"" id=""SampleDownloadBtn"">
            下載上傳格式
        </button>
");
#nullable restore
#line 62 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n<div id=\"SearchResultSection\">\r\n    <br />\r\n\r\n");
#nullable restore
#line 68 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
     if (ViewBag.SearchResult != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""table table-bordered"">
            <tr>
                <td>廠別</td>
                <td>直別</td>
                <td>計畫下線台數</td>
                <td>起始日期</td>
                <td>結束日期</td>
                <td>刪除</td>
            </tr>
");
#nullable restore
#line 79 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
             foreach (var item in (List<AP5_New.Models.PlanLineoff>)ViewBag.SearchResult)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 82 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
                   Write(item.PlantCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 83 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
                   Write(item.ShiftType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 84 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
                   Write(item.Lineoff);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 85 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
                   Write(item.StartDt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 86 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
                   Write(item.EndDt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td style=\"text-align:center\">\r\n");
#nullable restore
#line 88 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
                         using (Html.BeginForm("DeleteSingleData", "Create", FormMethod.Post))
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
                       Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <button type=\"submit\" name=\"key\"");
            BeginWriteAttribute("value", " value=\"", 3490, "\"", 3529, 3);
#nullable restore
#line 91 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
WriteAttributeValue("", 3498, item.PlantCode, 3498, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3513, ",", 3513, 1, true);
#nullable restore
#line 91 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
WriteAttributeValue("", 3514, item.ShiftType, 3514, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn  btn-danger\" onclick=\"return confirm(\'確定刪除?\')\">刪除</button>\r\n");
#nullable restore
#line 92 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 96 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </table>\r\n");
#nullable restore
#line 99 "D:\backup\Project\AP5_New\AP5_New\Views\Create\PlanLineOff.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        $(document).ready(function () {\r\n\r\n        });\r\n\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AP5_New.Models.PlanLineoff> Html { get; private set; }
    }
}
#pragma warning restore 1591
