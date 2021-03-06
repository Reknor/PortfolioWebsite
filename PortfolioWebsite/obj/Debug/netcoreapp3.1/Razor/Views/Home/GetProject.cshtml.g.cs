#pragma checksum "C:\Users\barci\Downloads\temp\BartlomiejJagielloLab4ZadDom\PortfolioWebsite\Views\Home\GetProject.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "932aefbc942457e403995347139d8b6035430c97"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_GetProject), @"mvc.1.0.view", @"/Views/Home/GetProject.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"932aefbc942457e403995347139d8b6035430c97", @"/Views/Home/GetProject.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b3989857d655540084cf5824fe429795d5d063a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_GetProject : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BartlomiejJagielloLab4ZadDom.Models.ProjectViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\barci\Downloads\temp\BartlomiejJagielloLab4ZadDom\PortfolioWebsite\Views\Home\GetProject.cshtml"
  
    ViewData["Title"] = Model.Name;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n<!-- Show project with all details -->\n<div class=\"project\">\n    <h2>");
#nullable restore
#line 9 "C:\Users\barci\Downloads\temp\BartlomiejJagielloLab4ZadDom\PortfolioWebsite\Views\Home\GetProject.cshtml"
   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\n    <h4>");
#nullable restore
#line 10 "C:\Users\barci\Downloads\temp\BartlomiejJagielloLab4ZadDom\PortfolioWebsite\Views\Home\GetProject.cshtml"
   Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n    <!-- Take all project images -->\n");
#nullable restore
#line 12 "C:\Users\barci\Downloads\temp\BartlomiejJagielloLab4ZadDom\PortfolioWebsite\Views\Home\GetProject.cshtml"
     foreach (var photo in Model.Photos)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <img");
            BeginWriteAttribute("src", " src=\"", 387, "\"", 412, 1);
#nullable restore
#line 14 "C:\Users\barci\Downloads\temp\BartlomiejJagielloLab4ZadDom\PortfolioWebsite\Views\Home\GetProject.cshtml"
WriteAttributeValue("", 393, Url.Content(photo), 393, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 413, "\"", 430, 1);
#nullable restore
#line 14 "C:\Users\barci\Downloads\temp\BartlomiejJagielloLab4ZadDom\PortfolioWebsite\Views\Home\GetProject.cshtml"
WriteAttributeValue("", 419, Model.Name, 419, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n        <hr />\n");
#nullable restore
#line 16 "C:\Users\barci\Downloads\temp\BartlomiejJagielloLab4ZadDom\PortfolioWebsite\Views\Home\GetProject.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    <br />\n    <!-- Add your own comment -->\n    <h2>");
#nullable restore
#line 20 "C:\Users\barci\Downloads\temp\BartlomiejJagielloLab4ZadDom\PortfolioWebsite\Views\Home\GetProject.cshtml"
   Write(Html.ActionLink("Add comment", "AddComment", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\n    <br />\n    <!-- Comments section -->\n    <h2>Comments</h2>\n");
#nullable restore
#line 24 "C:\Users\barci\Downloads\temp\BartlomiejJagielloLab4ZadDom\PortfolioWebsite\Views\Home\GetProject.cshtml"
     foreach (var comment in Model.Comments)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <label>");
#nullable restore
#line 26 "C:\Users\barci\Downloads\temp\BartlomiejJagielloLab4ZadDom\PortfolioWebsite\Views\Home\GetProject.cshtml"
          Write(comment.Nick);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\n        <br />\n        <label>");
#nullable restore
#line 28 "C:\Users\barci\Downloads\temp\BartlomiejJagielloLab4ZadDom\PortfolioWebsite\Views\Home\GetProject.cshtml"
          Write(comment.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\n        <br />\n        <hr />\n");
#nullable restore
#line 31 "C:\Users\barci\Downloads\temp\BartlomiejJagielloLab4ZadDom\PortfolioWebsite\Views\Home\GetProject.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BartlomiejJagielloLab4ZadDom.Models.ProjectViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
