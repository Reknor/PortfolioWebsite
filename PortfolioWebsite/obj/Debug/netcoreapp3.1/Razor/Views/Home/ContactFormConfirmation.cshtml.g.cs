#pragma checksum "C:\Users\barci\Downloads\temp\BartlomiejJagielloLab4ZadDom\PortfolioWebsite\Views\Home\ContactFormConfirmation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a5e2c0d3d146b82ed5ed68b16c35e9560a1c6d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ContactFormConfirmation), @"mvc.1.0.view", @"/Views/Home/ContactFormConfirmation.cshtml")]
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
#line 1 "C:\Users\barci\Downloads\temp\BartlomiejJagielloLab4ZadDom\PortfolioWebsite\Views\_ViewImports.cshtml"
using BartlomiejJagielloLab4ZadDom;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\barci\Downloads\temp\BartlomiejJagielloLab4ZadDom\PortfolioWebsite\Views\_ViewImports.cshtml"
using BartlomiejJagielloLab4ZadDom.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a5e2c0d3d146b82ed5ed68b16c35e9560a1c6d6", @"/Views/Home/ContactFormConfirmation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b3989857d655540084cf5824fe429795d5d063a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ContactFormConfirmation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\barci\Downloads\temp\BartlomiejJagielloLab4ZadDom\PortfolioWebsite\Views\Home\ContactFormConfirmation.cshtml"
  
    ViewData["Title"] = "Contact Confirmation";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<!-- Page used to show user that their message was sent -->\n<div>\n    <div>\n        <label>");
#nullable restore
#line 8 "C:\Users\barci\Downloads\temp\BartlomiejJagielloLab4ZadDom\PortfolioWebsite\Views\Home\ContactFormConfirmation.cshtml"
          Write(string.Format("Thank you {0} for contacting. I'll write back as soon as I can, provided you have given an email.", ViewBag.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\n    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
