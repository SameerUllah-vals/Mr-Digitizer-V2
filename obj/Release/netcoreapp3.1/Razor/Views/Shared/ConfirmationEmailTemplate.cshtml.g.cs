#pragma checksum "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\ConfirmationEmailTemplate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a72e9f28788363ae065ab5083018bfb11baa6eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MrDigitizerV2.Pages.Shared.Views_Shared_ConfirmationEmailTemplate), @"mvc.1.0.view", @"/Views/Shared/ConfirmationEmailTemplate.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a72e9f28788363ae065ab5083018bfb11baa6eb", @"/Views/Shared/ConfirmationEmailTemplate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55697211469e15af8d5be182b260e33c0674a8fc", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_ConfirmationEmailTemplate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MrDigitizerV2.Models.EmailMeta>
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
#line 2 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\ConfirmationEmailTemplate.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a72e9f28788363ae065ab5083018bfb11baa6eb3808", async() => {
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
                WriteLiteral("@media screen {\r\n    ");
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
  }
  /**
   * Remove blue links for iOS devices.
   */
  a[x-apple-data-detectors] {
    font-family: inherit !important;
    font-size: inherit !important;
    font-weight: inherit !important;
    line-height: inherit !imp");
                WriteLiteral(@"ortant;
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
    line-height: 100%;
    text-decoration: none;
    border: 0;
    outline: none;
  }
  </style>

");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a72e9f28788363ae065ab5083018bfb11baa6eb7258", async() => {
                WriteLiteral("\r\n\r\n  <div class=\"preheader\" style=\"display: none; max-width: 0; max-height: 0; overflow: hidden; font-size: 1px; line-height: 1px; color: #fff; opacity: 0;\">\r\n");
#nullable restore
#line 102 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\ConfirmationEmailTemplate.cshtml"
         if (!string.IsNullOrEmpty(Model.Fullname)) { 

#line default
#line hidden
#nullable disable
                WriteLiteral("Hi ");
#nullable restore
#line 102 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\ConfirmationEmailTemplate.cshtml"
                                                          Write(Model.Fullname);

#line default
#line hidden
#nullable disable
                WriteLiteral(",");
#nullable restore
#line 102 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\ConfirmationEmailTemplate.cshtml"
                                                                                       }

#line default
#line hidden
#nullable disable
                WriteLiteral(@" Please confirm your email address to just continue using Anonymous Digitizing.
    </div>
  <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">

    <tr>
      <td align=""center"" bgcolor=""#e9ecef"">

        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
          <tr>
            <td align=""center"" valign=""top"" style=""padding: 36px 24px;"">
               <a");
                BeginWriteAttribute("href", " href=\"", 3151, "\"", 3175, 1);
#nullable restore
#line 112 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\ConfirmationEmailTemplate.cshtml"
WriteAttributeValue("", 3158, Model.WebsiteURL, 3158, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" target=\"_blank\" style=\"display: inline-block;\">\r\n                <img");
                BeginWriteAttribute("src", " src=\"", 3246, "\"", 3286, 2);
#nullable restore
#line 113 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\ConfirmationEmailTemplate.cshtml"
WriteAttributeValue("", 3252, Model.WebsiteURL, 3252, 19, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3271, "images/logo.png", 3271, 15, true);
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
#line 127 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\ConfirmationEmailTemplate.cshtml"
                                                          if (!string.IsNullOrEmpty(Model.Fullname)){

#line default
#line hidden
#nullable disable
                WriteLiteral("Dear ");
#nullable restore
#line 127 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\ConfirmationEmailTemplate.cshtml"
                                                                                                           Write(Model.Fullname);

#line default
#line hidden
#nullable disable
                WriteLiteral(",");
#nullable restore
#line 127 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\ConfirmationEmailTemplate.cshtml"
                                                                                                                                       }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"<br /> <br />Please confirm Your Email Address</h3>
            </td>
          </tr>
        </table>

      </td>
    </tr>

    <tr>
      <td align=""center"" bgcolor=""#e9ecef"">

        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">

          <tr>
            <td align=""left"" bgcolor=""#ffffff"" style=""padding: 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px; line-height: 24px;"">
               <p style=""margin: 0;"">Tap the button below to confirm your email address. If you didn't create an account with <a");
                BeginWriteAttribute("href", " href=\"", 4581, "\"", 4605, 1);
#nullable restore
#line 142 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\ConfirmationEmailTemplate.cshtml"
WriteAttributeValue("", 4588, Model.WebsiteURL, 4588, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">Anonymous Digitizing</a>, you can safely delete this email.</p>
            </td>
          </tr>
          <tr>
            <td align=""left"" bgcolor=""#ffffff"">
              <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
                <tr>
                  <td align=""center"" bgcolor=""#ffffff"" style=""padding: 12px;"">
                    <table border=""0"" cellpadding=""0"" cellspacing=""0"">
                      <tr>
                        <td align=""center"" bgcolor=""#663399"" style=""border-radius: 6px;"">
                          <a");
                BeginWriteAttribute("href", " href=\"", 5173, "\"", 5190, 1);
#nullable restore
#line 153 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\ConfirmationEmailTemplate.cshtml"
WriteAttributeValue("", 5180, Model.URL, 5180, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" target=""_blank"" style=""display: inline-block; padding: 16px 36px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px; color: #ffffff; text-decoration: none; border-radius: 6px;"">Confirm Now</a>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </table>
            </td>
          </tr>
          <tr>
            <td align=""left"" bgcolor=""#ffffff"" style=""padding: 24px; font-family: 'Source Sans Pro', Helvetica, Arial, sans-serif; font-size: 16px; line-height: 24px;"">
              <p style=""margin: 0;"">If that doesn't work, copy and paste the following link in your browser:</p>
              <p style=""margin: 0;""><a");
                BeginWriteAttribute("href", " href=\"", 5950, "\"", 5967, 1);
#nullable restore
#line 165 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\ConfirmationEmailTemplate.cshtml"
WriteAttributeValue("", 5957, Model.URL, 5957, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" target=\"_blank\">");
#nullable restore
#line 165 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\ConfirmationEmailTemplate.cshtml"
                                                                    Write(Model.URL);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</a></p>
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
              <p style=""margin: 0;"">You received this email because you have created an account in <a");
                BeginWriteAttribute("href", " href=\"", 6577, "\"", 6601, 1);
#nullable restore
#line 181 "C:\Users\bilal\Desktop\Sameer\Mr-Digitizer-V2\Views\Shared\ConfirmationEmailTemplate.cshtml"
WriteAttributeValue("", 6584, Model.WebsiteURL, 6584, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Anonymous Digitizing</a>. If you didn\'t create the account you can safely delete this email.</p>\r\n            </td>\r\n          </tr>\r\n\r\n        </table>\r\n      </td>\r\n    </tr>\r\n\r\n  </table>\r\n\r\n");
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