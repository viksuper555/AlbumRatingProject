#pragma checksum "C:\Users\viksu\Desktop\AlbumRatingProject\AlbumRating\Views\User\ViewAllRated.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "039d03722d78d6920bb18eeaeb9d2c0a9730e6d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_ViewAllRated), @"mvc.1.0.view", @"/Views/User/ViewAllRated.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/ViewAllRated.cshtml", typeof(AspNetCore.Views_User_ViewAllRated))]
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
#line 1 "C:\Users\viksu\Desktop\AlbumRatingProject\AlbumRating\Views\_ViewImports.cshtml"
using AlbumRating;

#line default
#line hidden
#line 2 "C:\Users\viksu\Desktop\AlbumRatingProject\AlbumRating\Views\_ViewImports.cshtml"
using AlbumRating.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"039d03722d78d6920bb18eeaeb9d2c0a9730e6d1", @"/Views/User/ViewAllRated.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aed492069a9d6a75bc646b21d7b300a21a9670d0", @"/Views/_ViewImports.cshtml")]
    public class Views_User_ViewAllRated : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AlbumRating.ViewModels.Models.IndexAllRatedAlbumsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(67, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\viksu\Desktop\AlbumRatingProject\AlbumRating\Views\User\ViewAllRated.cshtml"
  
    ViewData["Title"] = "View";

#line default
#line hidden
            BeginContext(109, 42, true);
            WriteLiteral("\r\n<h2>Your Rated Albums</h2>\r\n\r\n<hr />\r\n\r\n");
            EndContext();
#line 11 "C:\Users\viksu\Desktop\AlbumRatingProject\AlbumRating\Views\User\ViewAllRated.cshtml"
 foreach (var a in Model.RatedAlbums.OrderByDescending(x => x.Rating))
{
    var album = Model.Albums.Find(x => x.AlbumId == a.AlbumId);

    string print = $"{album.Title} by {album.Artist} | rated: {a.Rating} / {Model.maxRating}";


#line default
#line hidden
            BeginContext(391, 8, true);
            WriteLiteral("    <h4>");
            EndContext();
            BeginContext(400, 5, false);
#line 17 "C:\Users\viksu\Desktop\AlbumRatingProject\AlbumRating\Views\User\ViewAllRated.cshtml"
   Write(print);

#line default
#line hidden
            EndContext();
            BeginContext(405, 7, true);
            WriteLiteral("</h4>\r\n");
            EndContext();
#line 18 "C:\Users\viksu\Desktop\AlbumRatingProject\AlbumRating\Views\User\ViewAllRated.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AlbumRating.ViewModels.Models.IndexAllRatedAlbumsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
