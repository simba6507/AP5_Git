#pragma checksum "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc04732cd41c2e60780477a0e0eeb0703331e93d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Container_Plan), @"mvc.1.0.view", @"/Views/Container/Plan.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc04732cd41c2e60780477a0e0eeb0703331e93d", @"/Views/Container/Plan.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb958e8af8d48387dc57e369fcfae206f0f20567", @"/Views/_ViewImports.cshtml")]
    public class Views_Container_Plan : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AP5_New.Models.ContainerMaster>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
  
    ViewData["Title"] = "下櫃計畫做成";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    <h2>下櫃計畫做成</h2>\r\n    <div class=\"text-danger\" id=\"erroMessage\">\r\n        ");
#nullable restore
#line 8 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
   Write(TempData["Message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 12 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
 using (Html.BeginForm("Plan", "Container", FormMethod.Post, new { id = "Form1" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"SearchConditionSection\" class=\"col-12\">\r\n        <table class=\"table table-bordered\">\r\n            <tr>\r\n                <td><b>下櫃日期</b></td>\r\n                <td>\r\n                    ");
#nullable restore
#line 20 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
               Write(Html.TextBoxFor(model => model.UnboxDate, new { id = "DateSearching", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td><b>碼頭代號</b></td>\r\n                <td>\r\n                    ");
#nullable restore
#line 24 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
               Write(Html.DropDownListFor(model => model.DockNo, (List<SelectListItem>)ViewBag.dockno, string.Empty, new { id = "UnboxAreaSearching", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                <td><b>廠別</b></td>\r\n                <td>\r\n                    ");
#nullable restore
#line 30 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
               Write(Html.DropDownListFor(model => model.PlantCode, (List<SelectListItem>)ViewBag.plantcode, string.Empty, new { id = "PlantCodeSearching", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td><b>國別</b></td>\r\n                <td>\r\n                    ");
#nullable restore
#line 34 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
               Write(Html.DropDownListFor(model => model.Country, (List<SelectListItem>)ViewBag.country, string.Empty, new { id = "CountrySearching", @class = "form-control" }));

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
            <div class=""col-2"">
                <button type=""button"" class=""btn btn-success"" data-toggle=""ajax-modal"" data-target=""#addModule"" data-url=""");
#nullable restore
#line 50 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
                                                                                                                     Write(Url.Action("NewContainer"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                    +新增Container\r\n                </button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 56 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<div class=\"col-12\">\r\n");
#nullable restore
#line 59 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
     using (Html.BeginForm("ImportfromFile", "Container", FormMethod.Post, new { enctype = "multipart/form-data" }))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <input type=""file"" name=""files"" multiple />
        <button type=""submit"" class=""btn btn-info"" name=""submitType"" value=""Import"" id=""ImportBtn"">
            匯入資料
        </button>
        <button type=""submit"" class=""btn btn-info"" name=""submitType"" value=""SampleDownload"" id=""SampleDownloadBtn"">
            下載匯入格式
        </button>
");
#nullable restore
#line 69 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n<div id=\"SearchResultSection\">\r\n    <br />\r\n\r\n");
#nullable restore
#line 75 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
     if (ViewBag.SearchResult != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""table table-bordered"">
            <thead>
                <tr>
                    <th>直別</th>
                    <th>計畫下櫃台數</th>
                    <th>貨櫃號碼</th>
                    <th>貨櫃連番</th>
                    <th>理論作業時間</th>
                    <th>碼頭代號</th>
                    <th>國別</th>
                    <th>備註</th>
                    <th>刪除</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 92 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
                 foreach (var item in (List<AP5_New.Models.ContainerMaster>)ViewBag.SearchResult)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 95 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
                       Write(item.ShiftType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 96 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
                       Write(item.LineoffCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 97 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
                       Write(item.ContainerNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 98 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
                       Write(item.ContainerRenban);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 99 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
                       Write(item.LogicalTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 100 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
                       Write(item.DockNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 101 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
                       Write(item.Country);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 102 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
                       Write(item.Mark);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"text-align:center\">\r\n                            <button type=\"button\" class=\"btn btn-success\" data-toggle=\"ajax-modal\" data-target=\"#editContainer\" data-url=\"");
#nullable restore
#line 104 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
                                                                                                                                     Write(Url.Action($"EditContainer/?containerNo={item.ContainerNo}&country={item.Country}&containerRenban={item.ContainerRenban}"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                編輯\r\n                            </button>\r\n");
#nullable restore
#line 107 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
                             using (Html.BeginForm("DeleteSingleData", "Container", FormMethod.Post))
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 109 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
                           Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <button type=\"submit\" name=\"key\"");
            BeginWriteAttribute("value", " value=\"", 4717, "\"", 4778, 5);
#nullable restore
#line 110 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
WriteAttributeValue("", 4725, item.ContainerNo, 4725, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4742, ",", 4742, 1, true);
#nullable restore
#line 110 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
WriteAttributeValue("", 4743, item.Country, 4743, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4756, ",", 4756, 1, true);
#nullable restore
#line 110 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
WriteAttributeValue("", 4757, item.ContainerRenban, 4757, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn  btn-danger\" onclick=\"return confirm(\'確定刪除?\')\">刪除</button>\r\n");
#nullable restore
#line 111 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 115 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 118 "D:\backup\Project\AP5_New\AP5_New\Views\Container\Plan.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n<div id=\"ModalArea\"</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function () {

            $('#DateSearching').datetimepicker({
                format: ""YYYYMMDD"",
                locale: ""zh-tw""
            });

            var ModalArea = $('#ModalArea');

            $('button[data-toggle=""ajax-modal""]').click(function () {

                var url = $(this).data('url');
                var decodedUrl = decodeURIComponent(url);
                $.get(decodedUrl).done(function (data) {
                    ModalArea.html(data);
                    ModalArea.find('.modal').modal('show');
                });
            })

            ModalArea.on('click', '[data-save=""modal""]', function (event) {
                var form = $(this).parents('.modal').find('form');
                var actionUrl = form.attr('action');
                var sendData = form.serialize();
                $.post(actionUrl, sendData).done(function (data) {
                    ModalArea.find('.modal').modal('hide'");
                WriteLiteral(");\r\n                    location.reload();\r\n                })\r\n            })\r\n        });\r\n\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AP5_New.Models.ContainerMaster> Html { get; private set; }
    }
}
#pragma warning restore 1591