#pragma checksum "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52b8a9163c83196bae288d5f636c2e53a677b0a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MrDigitizerV2.Pages.Shared.Views_Shared_OrderEmailTemplate), @"mvc.1.0.view", @"/Views/Shared/OrderEmailTemplate.cshtml")]
namespace MrDigitizerV2.Pages.Shared
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
#line 1 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\_ViewImports.cshtml"
using MrDigitizerV2;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52b8a9163c83196bae288d5f636c2e53a677b0a2", @"/Views/Shared/OrderEmailTemplate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55697211469e15af8d5be182b260e33c0674a8fc", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_OrderEmailTemplate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MrDigitizerV2.Models.EmailMeta>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color: #e9ecef;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52b8a9163c83196bae288d5f636c2e53a677b0a23766", async() => {
                WriteLiteral(@"

    <meta charset=""utf-8"">
    <meta http-equiv=""x-ua-compatible"" content=""ie=edge"">
    <title>Email Confirmation</title>
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <style type=""text/css"">
        /**
           * Google webfonts. Recommended to include the .woff version for cross-client compatibility.
           */
        ");
                WriteLiteral("@media screen {\r\n            ");
                WriteLiteral(@"@font-face {
                font-family: 'Source Sans Pro';
                font-style: normal;
                font-weight: 400;
                src: local('Source Sans Pro Regular'), local('SourceSansPro-Regular'), url(https://fonts.gstatic.com/s/sourcesanspro/v10/ODelI1aHBYDBqgeIAH2zlBM0YzuT7MdOe03otPbuUS0.woff) format('woff');
            }

            ");
                WriteLiteral(@"@font-face {
                font-family: 'Source Sans Pro';
                font-style: normal;
                font-weight: 700;
                src: local('Source Sans Pro Bold'), local('SourceSansPro-Bold'), url(https://fonts.gstatic.com/s/sourcesanspro/v10/toadOcfmlt9b38dHJxOBGFkQc6VGVFSmCnC_l7QZG60.woff) format('woff');
            }
        }
        /**
           * Avoid browser level font resizing.
           * 1. Windows Mobile
           * 2. iOS / OSX
           */
        body,
        table,
        td,
        a {
            -ms-text-size-adjust: 100%; /* 1 */
            -webkit-text-size-adjust: 100%; /* 2 */
        }
        /**
           * Remove extra space added to tables and cells in Outlook.
           */
        table,
        td {
            mso-table-rspace: 0pt;
            mso-table-lspace: 0pt;
        }
        /**
           * Better fluid images in Internet Explorer.
           */
        img {
            -ms-interpolation-mode: bicubic;
  ");
                WriteLiteral(@"      }
        /**
           * Remove blue links for iOS devices.
           */
        a[x-apple-data-detectors] {
            font-family: inherit !important;
            font-size: inherit !important;
            font-weight: inherit !important;
            line-height: inherit !important;
            color: inherit !important;
            text-decoration: none !important;
        }
        /**
           * Fix centering issues in Android 4.4.
           */
        div[style*=""margin: 16px 0;""] {
            margin: 0 !important;
        }

        body {
            width: 100% !important;
            height: 100% !important;
            padding: 0 !important;
            margin: 0 !important;
        }
        /**
           * Collapse table borders to avoid space between cells.
           */
        table {
            border-collapse: collapse !important;
        }

        a {
            color: #663399;
        }

        img {
            height: auto;
       ");
                WriteLiteral("     line-height: 100%;\r\n            text-decoration: none;\r\n            border: 0;\r\n            outline: none;\r\n        }\r\n    </style>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52b8a9163c83196bae288d5f636c2e53a677b0a27895", async() => {
                WriteLiteral(@"

    <div class=""preheader"" style=""display: none; max-width: 0; max-height: 0; overflow: hidden; font-size: 1px; line-height: 1px; color: #fff; opacity: 0;"">
        Your order has been completed.
    </div>
    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">

        <tr>
            <td align=""center"" bgcolor=""#e9ecef"">

                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                    <tr>
                        <td align=""center"" valign=""top"" style=""padding: 36px 24px;"">
                            <a");
                BeginWriteAttribute("href", " href=\"", 3709, "\"", 3733, 1);
#nullable restore
#line 116 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
WriteAttributeValue("", 3716, Model.WebsiteURL, 3716, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" target=\"_blank\" style=\"display: inline-block;\">\r\n                                <img");
                BeginWriteAttribute("src", " src=\"", 3820, "\"", 3860, 2);
#nullable restore
#line 117 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
WriteAttributeValue("", 3826, Model.WebsiteURL, 3826, 19, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3845, "images/logo.png", 3845, 15, true);
                EndWriteAttribute();
                WriteLiteral(@" alt=""Logo"" border=""0"" width=""48"" style=""display: block; width: 48px; max-width: 48px; min-width: 48px;"">
                            </a>
                        </td>
                    </tr>
                </table>

            </td>
        </tr>

        <tr>
            <td align=""center"" bgcolor=""#e9ecef"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                    <tr>
                        <td align=""left"" bgcolor=""#ffffff"" style=""padding: 36px 24px 0; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; border-top: 3px solid #d4dadf;"">
                            <h3 style=""margin: 0; font-weight: 700;""> ");
#nullable restore
#line 131 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
                                                                       if (!string.IsNullOrEmpty(Model.Fullname))
                                {
                                    

#line default
#line hidden
#nullable disable
                WriteLiteral("Dear ");
#nullable restore
#line 133 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
                                          Write(Model.Fullname);

#line default
#line hidden
#nullable disable
                WriteLiteral(",");
#nullable restore
#line 133 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
                                                                      
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        </td>
                    </tr>
                </table>

            </td>
        </tr>

        <tr>
            <td align=""center"" bgcolor=""#e9ecef"">

                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">

                    <tr>
                        <td align=""left"" bgcolor=""#ffffff"" style=""padding: 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px;"">
                            <p style=""margin: 0;"">Your order has been completed please find the attachements.  Details are below</p>
                        </td>
                    </tr>
                    <tr>
                        <td align=""center"" bgcolor=""#e9ecef"">
                            <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                                <tr>
                                    <th align=""left"" bgcolor=""#ffffff"" style=""padding: 10px 10px 10");
                WriteLiteral(@"px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px;"">
                                        Type
                                    </th>
                                    <td align=""left"" bgcolor=""#ffffff"" style=""padding: 10px 10px 10px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px;"">
                                        ");
#nullable restore
#line 160 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
                                   Write(Model.OrderType);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    </td>

                                </tr>
                                <tr>
                                    <th align=""left"" bgcolor=""#ffffff"" style=""padding: 10px 10px 10px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px;"">
                                        Project
                                    </th>
                                    <td align=""left"" bgcolor=""#ffffff"" style=""padding: 10px 10px 10px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px;"">
                                        ");
#nullable restore
#line 169 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
                                   Write(Model.DesignName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    </td>

                                </tr>
                                <tr>
                                    <th align=""left"" bgcolor=""#ffffff"" style=""padding: 10px 10px 10px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px;"">
                                        Rate
                                    </th>
                                    <td align=""left"" bgcolor=""#ffffff"" class=""rate"" style=""padding: 10px 10px 10px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px;"">
                                        $");
#nullable restore
#line 178 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
                                    Write(Model.Rate);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    </td>

                                </tr>
                                <tr>
                                    <th align=""left"" bgcolor=""#ffffff"" style=""padding: 10px 10px 10px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px;"">
                                        Qty
                                    </th>
                                    <td align=""left"" bgcolor=""#ffffff"" class=""qty"" style=""padding: 10px 10px 10px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px;"">
                                        ");
#nullable restore
#line 187 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
                                   Write(Model.Qty);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    </td>

                                </tr>
                                <tr>
                                    <th align=""left"" bgcolor=""#ffffff"" style=""padding: 10px 10px 10px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px;"">
                                        Amount
                                    </th>
                                    <td align=""left"" class=""amount"" bgcolor=""#ffffff"" style=""padding: 10px 10px 10px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px;"">
                                        $");
#nullable restore
#line 196 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
                                     Write(Model.Rate * Model.Qty);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    </td>

                                </tr>
                                <tr>
                                    <th align=""left"" bgcolor=""#ffffff"" style=""padding: 10px 10px 10px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px;"">
                                        More Details
                                    </th>
                                    <td align=""left"" bgcolor=""#ffffff"" style=""padding: 10px 10px 10px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px;"">
                                        <a");
                BeginWriteAttribute("href", " href=\"", 9497, "\"", 9519, 1);
#nullable restore
#line 205 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
WriteAttributeValue("", 9504, Model.OrderURL, 9504, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 205 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
                                                             Write(Model.OrderURL);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</a>
                                    </td>

                                </tr>
                                <tr>
                                    <th align=""left"" bgcolor=""#ffffff"" style=""padding: 10px 10px 10px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px;"">
                                        Download files
                                    </th>
                                    <td align=""left"" bgcolor=""#ffffff"" style=""padding: 10px 10px 10px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px;"">
                                        <ul>
");
#nullable restore
#line 215 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
                                         foreach (var item in Model.OrderDocuments)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                <li><a");
                BeginWriteAttribute("href", " href=\"", 10370, "\"", 10428, 3);
#nullable restore
#line 217 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
WriteAttributeValue("", 10377, Model.WebsiteURL, 10377, 19, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 10396, "uploads/documents/", 10396, 18, true);
#nullable restore
#line 217 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
WriteAttributeValue("", 10414, item.FilePath, 10414, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("download", " download=\"", 10429, "\"", 10454, 1);
#nullable restore
#line 217 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
WriteAttributeValue("", 10440, item.FileName, 10440, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 217 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
                                                                                                                                       Write(item.FileName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></li>\r\n");
#nullable restore
#line 218 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
                                        }                       

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                        </ul>
                                    </td>

                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align=""left"" bgcolor=""#ffffff"" style=""padding: 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px; line-height: 24px;"">
                            <p style=""margin: 0;"">Please find the attachement. if you have any query feel free to contact us on orders@anonymousdigitizing.com.</p>
                        </td>
                    </tr>
                    <tr>
                        <td align=""left"" bgcolor=""#ffffff"" style=""padding: 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px; line-height: 24px;"">
                            <p style=""margin: 0;font-weight:bold"">Thanks & Regards<br /> <a");
                BeginWriteAttribute("href", " href=\"", 11504, "\"", 11528, 1);
#nullable restore
#line 233 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
WriteAttributeValue("", 11511, Model.WebsiteURL, 11511, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">Anonymous Digitizing</a></p>
                        </td>
                    </tr>
                </table>

            </td>
        </tr>

        <tr>
            <td align=""center"" bgcolor=""#e9ecef"" style=""padding: 24px;"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">

                    <tr>
                        <td align=""center"" bgcolor=""#e9ecef"" style=""padding: 12px 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 14px; line-height: 20px; color: #666;"">
                            <p style=""margin: 0;"">You received this email because you have ordered through <a");
                BeginWriteAttribute("href", " href=\"", 12216, "\"", 12240, 1);
#nullable restore
#line 247 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\OrderEmailTemplate.cshtml"
WriteAttributeValue("", 12223, Model.WebsiteURL, 12223, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Anonymous Digitizing</a></p>\r\n                        </td>\r\n                    </tr>\r\n\r\n                </table>\r\n            </td>\r\n        </tr>\r\n\r\n    </table>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MrDigitizerV2.Models.EmailMeta> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591