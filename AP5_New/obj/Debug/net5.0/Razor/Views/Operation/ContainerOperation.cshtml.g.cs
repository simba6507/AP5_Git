#pragma checksum "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91a4c7cf49111cfb30aa1d80dd2754b011dc53bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Operation_ContainerOperation), @"mvc.1.0.view", @"/Views/Operation/ContainerOperation.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91a4c7cf49111cfb30aa1d80dd2754b011dc53bd", @"/Views/Operation/ContainerOperation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb958e8af8d48387dc57e369fcfae206f0f20567", @"/Views/_ViewImports.cshtml")]
    public class Views_Operation_ContainerOperation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AP5_New.Models.ContainerMaster>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"text-center\" style=\"font-size:3rem;font-weight:bold\">\r\n    <p>下櫃作業</p>\r\n</div>\r\n\r\n\r\n");
#nullable restore
#line 8 "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml"
 using (Html.BeginForm("ContainerOperation", "Operation", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""container-fluid placeholders"">
        <div class=""row"" id=""SearchSection"">
            <div class=""col-xs-10 col-md-3"">
                <h3>現在時間</h3>
                <p id=""showDateTime"" style=""font-size:1.3rem"">
                </p>
            </div>
            <div class=""col-xs-10 col-md-2"">
                <h3>廠別</h3>
                <p>
                    ");
#nullable restore
#line 21 "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml"
               Write(Html.DropDownListFor(model => model.PlantCode, (List<SelectListItem>)ViewBag.plantcode, new { @id = "plantCode", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n            <div class=\"col-xs-10 col-md-2\">\r\n                <h3>碼頭代號</h3>\r\n                <p>\r\n                    ");
#nullable restore
#line 27 "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml"
               Write(Html.DropDownListFor(model => model.DockNo, (List<SelectListItem>)ViewBag.dockno, new { @id = "dockNo", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </p>
            </div>
            <div class=""col-xs-10 col-md-3"">
                <div id=""actualCount_part"" style=""font-size:3rem;font-weight:bold"">
                    <text style=""font-size:1.6rem;"">下線台數</text>
                    <text id=""actualCount_text""></text>
                </div>
            </div>
            <div class=""col-xs-10 col-md-2"">
                <button type=""submit"" name=""search"" value=""Search"" style=""font-size:35px;"" class=""btn btn-primary"" id=""SearchBtn"">查詢</button>
            </div>
        </div>
    </div>
");
            WriteLiteral("    <br />\r\n");
#nullable restore
#line 43 "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml"
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
                    <th>貨櫃編號</th>
                    <th>貨櫃連番</th>
                    <th>理論作業時間</th>
                    <th>碼頭代號</th>
                    <th>國別</th>
                    <th>備註</th>
                    <th>狀態</th>
                </tr>
            </thead>
            <tbody id=""dataTable"">
");
#nullable restore
#line 60 "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml"
                 foreach (var item in (List<AP5_New.Models.ContainerMaster>)ViewBag.SearchResult)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr class=\"data\">\r\n                        <td>");
#nullable restore
#line 63 "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml"
                       Write(item.ShiftType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 64 "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml"
                       Write(item.LineoffCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 65 "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml"
                       Write(item.ContainerNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 66 "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml"
                       Write(item.ContainerRenban);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 67 "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml"
                       Write(item.LogicalTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 68 "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml"
                       Write(item.DockNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 69 "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml"
                       Write(item.Country);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 70 "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml"
                       Write(item.Mark);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 71 "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml"
                       Write(item.ContainerStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 73 "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 76 "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""text-center"">
        <button type=""submit"" name=""start"" value=""Start"" class=""btn btn-primary"" style=""font-size:35px;"" id=""startOpBtn"">開始下櫃</button>
        <button type=""submit"" name=""end"" value=""End"" class=""btn btn-success"" style=""font-size:35px;"" id=""endOpBtn"">結束下櫃</button>
    </div>
");
#nullable restore
#line 82 "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">



        $(document).ready(function () {

            window.onload = ShowDateTime;
            setInterval(getActualCount, 1000);
            setInterval(meetCount, 1000);

            function getActualCount() {
                let plantCode = $(""#plantCode"").val();
                $.ajax({
                    type: 'POST',
                    data: { plantCode: plantCode },
                    url: """);
#nullable restore
#line 100 "D:\backup\Project\AP5_New\AP5_New\Views\Operation\ContainerOperation.cshtml"
                     Write(Url.Action("GetLineOff", "Operation"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                    dataType: ""json"",
                    success: function (result) {
                        $(""#actualCount_text"").remove();
                        $(""#actualCount_part"").append('<text id=""actualCount_text"">' + result.actualCount + '</text>');
                        window.actualCount = $('#actualCount').text();
                    },
                    error: function (xhr, textStatus, error) {
                    }
                });
            }

            function meetCount() {
                let actualCount = parseInt($('#actualCount_text').text());
                let count = parseInt($('#dataTable').find('td:eq(1)').text().trim());
                //console.log($('#actualCount_text').text());
                if (count <= actualCount) {
                    // $('#startOpBtn').prop('disabled', false);
                    if ($('#dataTable').find('td:eq(8)').text() == ""下櫃中"") {
                        $('#startOpBtn').prop('disabled', true);
               ");
                WriteLiteral(@"         $('#endOpBtn').prop('disabled', false);
                    }
                    if($('#dataTable').find('td:eq(8)').text() == ""未下櫃"") {
                        $('#startOpBtn').prop('disabled', false);
                        $('#endOpBtn').prop('disabled', true);
                    }
                    light();
                } else {
                    $('#startOpBtn').prop('disabled', true);
                    $('#endOpBtn').prop('disabled', true);
                    //console.log('123')
                };
            }

            //實際台數與計畫台數吻合的話
            var x = 0;
            function light() {
                var darkThemeSelected =
                    localStorage.getItem(""darkSwitch"") !== null &&
                    localStorage.getItem(""darkSwitch"") === ""dark"";
                darkSwitch.checked = darkThemeSelected;
                if (darkSwitch.checked) {
                    if (x % 2 == 0) {
                        $('#dataTable  tr:first-child').css({ ""back");
                WriteLiteral(@"ground-color"": ""yellow"", ""color"": ""black"" });
                        x++;
                    } else {
                        $('#dataTable  tr:first-child').css({ ""background-color"": ""#2e2e2e"", ""color"": ""black"" });
                        x--;
                    }
                } else {
                    if (x % 2 == 0) {
                        $('#dataTable  tr:first-child').css({ ""background-color"": ""yellow"", ""color"": ""black"" });
                        x++;
                    } else {
                        $('#dataTable  tr:first-child').css({ ""background-color"": ""white"", ""color"": ""black"" });
                        x--;
                    }
                }


            }

        });

    </script>
");
            }
            );
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
