#pragma checksum "C:\Users\anrgr\Source\Repos\tickets-selling-company\project\tickets_selling\Views\Home\Main.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02f2c04d766975f45c2a1b9ce345c62acfbc187d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Main), @"mvc.1.0.view", @"/Views/Home/Main.cshtml")]
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
#line 1 "C:\Users\anrgr\Source\Repos\tickets-selling-company\project\tickets_selling\Views\_ViewImports.cshtml"
using tickets_selling;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\anrgr\Source\Repos\tickets-selling-company\project\tickets_selling\Views\_ViewImports.cshtml"
using tickets_selling.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02f2c04d766975f45c2a1b9ce345c62acfbc187d", @"/Views/Home/Main.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7296af2ee45334f3b1fd1b5bb03ffb486ed7386", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Main : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Domain.Entities.Route>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\anrgr\Source\Repos\tickets-selling-company\project\tickets_selling\Views\Home\Main.cshtml"
   ViewData["Title"] = "Main"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    <h1>Минский автовокзал онлайн</h1>\r\n    <p>Теперь Вы можете покупать билеты не выходя из дома</p>\r\n\r\n\r\n    <div id=\"search-part\">\r\n");
#nullable restore
#line 10 "C:\Users\anrgr\Source\Repos\tickets-selling-company\project\tickets_selling\Views\Home\Main.cshtml"
         using (Html.BeginForm("GetRoutesByNamesAndDate", "Route", FormMethod.Get))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>Откуда: ");
#nullable restore
#line 12 "C:\Users\anrgr\Source\Repos\tickets-selling-company\project\tickets_selling\Views\Home\Main.cshtml"
      Write(Html.TextBox("departureName", "Minsk"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p>Куда: ");
#nullable restore
#line 13 "C:\Users\anrgr\Source\Repos\tickets-selling-company\project\tickets_selling\Views\Home\Main.cshtml"
                    Write(Html.TextBox("destinationName", "Vitebsk"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
            WriteLiteral("                                <p>Дата: ");
#nullable restore
#line 15 "C:\Users\anrgr\Source\Repos\tickets-selling-company\project\tickets_selling\Views\Home\Main.cshtml"
                                    Write(Html.TextBox("departureDate", "20.07.2015"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n");
            WriteLiteral("                                                <input type=\"submit\" value=\"Поиск\" />");
#nullable restore
#line 17 "C:\Users\anrgr\Source\Repos\tickets-selling-company\project\tickets_selling\Views\Home\Main.cshtml"
                                                                                     }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Domain.Entities.Route> Html { get; private set; }
    }
}
#pragma warning restore 1591
