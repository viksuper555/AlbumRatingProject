namespace AlbumRating.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AlbumRating.Services.Contracts;
    using AlbumRating.ViewModels.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Responsible for handling all views in the Genre folder
    /// </summary>

    [Authorize]
    public class GenreController : Controller
    {
        /// <summary>
        /// Allows communication with the <c>AlbumService class</c>
        /// </summary>
        private readonly IGenreService service;

        /// <summary>
        /// Initializes a new instance of the GenreController class.
        /// Gets called by the StartUp class.
        /// </summary>
        /// <param name="service">A required service for the class.</param>
        public GenreController(IGenreService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Redirects to the Create page in the Genre folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// Allows a signed in User to add a Genre to the database.
        /// The User must be signed in.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        [HttpPost]
        public IActionResult Create(string name)
        {
            if(this.service.CreateGenre(name) == 0)
            {
                return (this.RedirectToAction("GenreAlreadyAdded", new { error = $"Genre {name} is already in the database"}));
            }

            return this.RedirectToAction("ListAll", "Album");
        }

        /// <summary>
        /// Notifies the User that the Genre they tried to add to the database is already in it.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult GenreAlreadyAdded(string error)
        {
            var viewModel = new FailMessageViewModel();
            viewModel.Error = error;
            return this.View(viewModel);
        }
    }
}