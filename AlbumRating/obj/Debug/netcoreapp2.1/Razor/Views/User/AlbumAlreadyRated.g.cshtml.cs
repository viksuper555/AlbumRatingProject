#pragma checksum "C:\Users\viksu\Desktop\AlbumRatingProject\AlbumRating\Views\User\AlbumAlreadyRated.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38e1f4bb24b07e811c684bbf2865a8165c1cdfaf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_AlbumAlreadyRated), @"mvc.1.0.view", @"/Views/User/AlbumAlreadyRated.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/AlbumAlreadyRated.cshtml", typeof(AspNetCore.Views_User_AlbumAlreadyRated))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38e1f4bb24b07e811c684bbf2865a8165c1cdfaf", @"/Views/User/AlbumAlreadyRated.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aed492069a9d6a75bc646b21d7b300a21a9670d0", @"/Views/_ViewImports.cshtml")]
    public class Views_User_AlbumAlreadyRated : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AlbumRating.ViewModels.Models.FailMessageViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(59, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\viksu\Desktop\AlbumRatingProject\AlbumRating\Views\User\AlbumAlreadyRated.cshtml"
  
    ViewData["Title"] = "AlbumAlreadyRated";

#line default
#line hidden
            BeginContext(114, 6, true);
            WriteLiteral("\r\n<h2>");
            EndContext();
            BeginContext(121, 11, false);
#line 7 "C:\Users\viksu\Desktop\AlbumRatingProject\AlbumRating\Views\User\AlbumAlreadyRated.cshtml"
Write(Model.Error);

#line default
#line hidden
            EndContext();
            BeginContext(132, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AlbumRating.ViewModels.Models.FailMessageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
