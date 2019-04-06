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
    /// Responsible for handling all views in the User folder
    /// </summary>

    [Authorize]
    public class UserController : Controller
    {
        /// <summary>
        /// Allows communication with the <c>AlbumService class</c>
        /// </summary>
        private IAlbumsService albumService;

        /// <summary>
        /// Allows communication with the <c>GenreService class</c>
        /// </summary>
        private IGenreService genreService;

        /// <summary>
        /// Allows communication with the <c>UserService class</c>
        /// </summary>
        private IUserService userService;

        /// <summary>
        /// Initializes a new instance of the UserController class.
        /// Gets called by the StartUp class.
        /// </summary>
        /// <param name="userService">A required service for the class.</param>
        /// <param name="albumService">A required service for the class.</param>
        /// <param name="genreService">A required service for the class.</param>
        public UserController(IUserService userService, IAlbumsService albumService, IGenreService genreService)
        {
            this.albumService = albumService;
            this.genreService = genreService;
            this.userService = userService;
        }

        /// <summary>
        /// Redirects to the Rate page in the User folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult Rate()
        {
            var viewModel = new RateAlbumViewModel();
            viewModel.Albums = this.albumService.GetAll();
            return this.View(viewModel);
        }

        /// <summary>
        /// Allows a signed in User to Score an Album with a rating from 1 to 5.
        /// The User must be signed in.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        [HttpPost]
        public IActionResult Rate(int albumId, int rating)
        {
            var viewModel = new RateAlbumViewModel();
            viewModel.Albums = this.albumService.GetAll();

            var currentUserName = this.User.Identity.Name;
            var currentUser = this.userService.GetUserByName(currentUserName);

            if (this.userService.RateAlbum(albumId, rating, currentUser.UserId) == 0)
            {
                var alreadyRated = viewModel.Albums.FirstOrDefault(x => x.AlbumId == albumId);
                return (this.RedirectToAction("AlbumAlreadyRated", new { error = $"You've already rated {alreadyRated.Title} by {alreadyRated.Artist}" }));

            }

            return this.RedirectToAction("ListAll", "Album");
        }

        /// <summary>
        /// Notifies the User that they've already rated the Album the tried to rate.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult AlbumAlreadyRated(string error)
        {
            var viewModel = new FailMessageViewModel();
            viewModel.Error = error;
            return this.View(viewModel); ;
        }

        /// <summary>
        /// Displays all the Albums rated by the User.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult ViewAllRated()
        {
            var currentUserName = this.User.Identity.Name;
            var currentUser = this.userService.GetUserByName(currentUserName);

            var viewModel = new IndexAllRatedAlbumsViewModel();
            viewModel.RatedAlbums = this.userService.GetAllRated(currentUser.UserId).OrderBy(x=> x.Rating).ToList();
            viewModel.Albums = this.albumService.GetAll();
            return this.View(viewModel);
        }
    }
}