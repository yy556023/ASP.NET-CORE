#pragma checksum "D:\Documents\repo\ASP.NET_Core_5\Lab0615\View_Layout\View_Layout\Views\Home\Page2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48bfd0ce3b0f71a691a887d2909f89da26fa5185"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Page2), @"mvc.1.0.view", @"/Views/Home/Page2.cshtml")]
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
#line 1 "D:\Documents\repo\ASP.NET_Core_5\Lab0615\View_Layout\View_Layout\Views\_ViewImports.cshtml"
using View_Layout;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Documents\repo\ASP.NET_Core_5\Lab0615\View_Layout\View_Layout\Views\_ViewImports.cshtml"
using View_Layout.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48bfd0ce3b0f71a691a887d2909f89da26fa5185", @"/Views/Home/Page2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ca81c8434dd2fa18aceba2a32111b594c03fdc4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Page2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Documents\repo\ASP.NET_Core_5\Lab0615\View_Layout\View_Layout\Views\Home\Page2.cshtml"
  
    ViewData["Title"] = "Page2";
    Layout = "~/Views/Shared/_MyLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Page2</h1>\r\n\r\n");
            DefineSection("MyScripts", async() => {
                WriteLiteral("\r\n    <script>\r\n            alert(\"");
#nullable restore
#line 11 "D:\Documents\repo\ASP.NET_Core_5\Lab0615\View_Layout\View_Layout\Views\Home\Page2.cshtml"
               Write(TempData["prompt"] ?? "Hello!");

#line default
#line hidden
#nullable disable
                WriteLiteral("\")\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
