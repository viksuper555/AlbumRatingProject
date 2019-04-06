namespace AlbumRating.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using AlbumRating.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Responsible for handling all views in the Home folder.
    /// </summary>
    /// 

    public class HomeController : Controller
    {
        /// <summary>
        /// The main page of the website.
        /// Redirects to the Index page in the Home folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Contains info about the website.
        /// Redirects to the About page in the Home folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult About()
        {
            this.ViewData["Message"] = "AlbumRating";

            return this.View();
        }

        /// <summary>
        /// Contains contact info about the site owners/ developers.
        /// Redirects to the Contact page in the Home folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult Contact()
        {
            this.ViewData["Message"] = "AlbumRating contact page.";

            return this.View();
        }

        /// <summary>
        /// Contains info about the privacy policy of the website.
        /// Redirects to the Privacy page in the Home folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult Privacy()
        {
            return this.View();
        }

        /// <summary>
        /// Alerts the user of any Errors.
        /// Redirects to the Error page in the Shared folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}