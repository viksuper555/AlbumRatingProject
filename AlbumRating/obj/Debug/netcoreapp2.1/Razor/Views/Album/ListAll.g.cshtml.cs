#pragma checksum "C:\Programming\it-career\course-project\AlbumRatingProject\AlbumRating\Views\Album\ListAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55f033ae916eb482ad3ba89fba740da9de2176aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Album_ListAll), @"mvc.1.0.view", @"/Views/Album/ListAll.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Album/ListAll.cshtml", typeof(AspNetCore.Views_Album_ListAll))]
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
#line 1 "C:\Programming\it-career\course-project\AlbumRatingProject\AlbumRating\Views\_ViewImports.cshtml"
using AlbumRating;

#line default
#line hidden
#line 2 "C:\Programming\it-career\course-project\AlbumRatingProject\AlbumRating\Views\_ViewImports.cshtml"
using AlbumRating.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55f033ae916eb482ad3ba89fba740da9de2176aa", @"/Views/Album/ListAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aed492069a9d6a75bc646b21d7b300a21a9670d0", @"/Views/_ViewImports.cshtml")]
    public class Views_Album_ListAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AlbumRating.ViewModels.Models.IndexAllRatedAlbumsGloballyViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Programming\it-career\course-project\AlbumRatingProject\AlbumRating\Views\Album\ListAll.cshtml"
  
    ViewData["Title"] = "ListAll";

#line default
#line hidden
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(120, 33, true);
            WriteLiteral("\r\n<h2>All Albums</h2>\r\n\r\n<hr />\r\n");
            EndContext();
#line 10 "C:\Programming\it-career\course-project\AlbumRatingProject\AlbumRating\Views\Album\ListAll.cshtml"
 foreach (var a in Model.AlbumsWithRating.OrderByDescending(x => x.Value))
{
    string print = "";

    if(a.Key.TimesRated > 0)
    {
        print = $"{a.Key.Title} by {a.Key.Artist} | total rating {(double)a.Value/a.Key.TimesRated:F1} | Rated {a.Key.TimesRated} times";
    }
    else
    {
        print = $"{a.Key.Title} by {a.Key.Artist} | total rating 0 | Rated {a.Key.TimesRated} times";

    }


#line default
#line hidden
            BeginContext(572, 8, true);
            WriteLiteral("    <h4>");
            EndContext();
            BeginContext(581, 5, false);
#line 24 "C:\Programming\it-career\course-project\AlbumRatingProject\AlbumRating\Views\Album\ListAll.cshtml"
   Write(print);

#line default
#line hidden
            EndContext();
            BeginContext(586, 7, true);
            WriteLiteral("</h4>\r\n");
            EndContext();
#line 25 "C:\Programming\it-career\course-project\AlbumRatingProject\AlbumRating\Views\Album\ListAll.cshtml"

}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AlbumRating.ViewModels.Models.IndexAllRatedAlbumsGloballyViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
