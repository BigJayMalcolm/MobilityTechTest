#pragma checksum "/Users/jamiemalcolm/Documents/GitHub/MobilityTechTest/MobilityTechTest/Views/Home/Forecast.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53e9aa6d359647bac842e631e18641dfc106acc5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Forecast), @"mvc.1.0.view", @"/Views/Home/Forecast.cshtml")]
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
#line 1 "/Users/jamiemalcolm/Documents/GitHub/MobilityTechTest/MobilityTechTest/Views/_ViewImports.cshtml"
using React.AspNet;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/jamiemalcolm/Documents/GitHub/MobilityTechTest/MobilityTechTest/Views/_ViewImports.cshtml"
using MobilityTechTest;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/jamiemalcolm/Documents/GitHub/MobilityTechTest/MobilityTechTest/Views/_ViewImports.cshtml"
using MobilityTechTest.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53e9aa6d359647bac842e631e18641dfc106acc5", @"/Views/Home/Forecast.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18a9e026cf7627713c7b78a5d850eeab12018148", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Forecast : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MobilityTechTest.Models.CurrentWeatherModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/jamiemalcolm/Documents/GitHub/MobilityTechTest/MobilityTechTest/Views/Home/Forecast.cshtml"
  
    ViewData["Title"] = "Forecast";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 6 "/Users/jamiemalcolm/Documents/GitHub/MobilityTechTest/MobilityTechTest/Views/Home/Forecast.cshtml"
Write(Html.React("Forecast", new
{
    data = Model,
    url = Url.Action("Index")
}));

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MobilityTechTest.Models.CurrentWeatherModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
