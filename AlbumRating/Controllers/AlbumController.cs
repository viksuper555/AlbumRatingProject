namespace AlbumRating.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AlbumRating.Data.Models;
    using AlbumRating.Services;
    using AlbumRating.Services.Contracts;
    using AlbumRating.ViewModels.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Responsible for handling all views in the Album folder
    /// </summary>

    [Authorize]
    public class AlbumController : Controller
    {
        /// <summary>
        /// Allows communication with the <c>AlbumService class</c>
        /// </summary>
        private readonly IAlbumsService albumService;

        /// <summary>
        /// Allows communication with the <c>GenreService class</c>
        /// </summary>
        private readonly IGenreService genreService;

        /// <summary>
        /// Allows communication with the <c>UserService class</c>
        /// </summary>
        private readonly IUserService userService;

        /// <summary>
        /// Initializes a new instance of the AlbumController class.
        /// Gets called by the StartUp class.
        /// </summary>
        /// <param name="userService">A required service for the class.</param>
        /// <param name="albumService">A required service for the class.</param>
        /// <param name="genreService">A required service for the class.</param>
        public AlbumController(IUserService userService, IAlbumsService albumService, IGenreService genreService)
        {
            this.albumService = albumService;
            this.genreService = genreService;
            this.userService = userService;
        }

        /// <summary>
        /// Lists information about all Albums in the database
        /// Doesn't require the user to be logged in to be displayed
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        [AllowAnonymous]
        public IActionResult ListAll()
        {
            var viewModel = new IndexAllRatedAlbumsGloballyViewModel();
            viewModel.Albums = this.albumService.GetAll();

            var rated = this.albumService.GetAllRatings();

            rated = rated.OrderBy(x => x.AlbumId).ToList(); // list with all albums that have ratings
            viewModel.Albums = viewModel.Albums.OrderBy(x => x.AlbumId).ToList(); // list with all albums in db

            foreach (var album in viewModel.Albums)
            {
                foreach (var user in this.userService.GetAll())
                {
                    var a = rated.FirstOrDefault(x => x.AlbumId == album.AlbumId && x.UserId == user.UserId);
                    if (a != null)
                    {
                        if (!viewModel.AlbumsWithRating.Keys.Contains<Album>(a.Album))
                        {
                            viewModel.AlbumsWithRating.Add(a.Album, a.Rating);
                        }
                        else
                        {
                            viewModel.AlbumsWithRating[a.Album] += a.Rating;
                        }
                    }
                }
            }

            foreach (var album in viewModel.Albums)
            {
                if (!viewModel.AlbumsWithRating.Keys.Contains<Album>(album))
                {
                    viewModel.AlbumsWithRating.Add(album, 0);
                }
            }

            return this.View(viewModel);
        }

        /// <summary>
        /// Redirects to the Create page in the Album folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult Create()
        {
            var viewModel = new CreateAlbumViewModel();
            viewModel.Genres = this.genreService.GetAll();
            return this.View(viewModel);
        }

        /// <summary>
        /// Allows a signed in User to add an Album to the database.
        /// The User must be signed in.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        [HttpPost]
        public IActionResult Create(string title, string artist, int year, int genreId)
        {
            if (this.albumService.CreateAlbum(title, artist, year, genreId) == 0)
            {
                return this.RedirectToAction("AlbumAlreadyAdded", new { error = $"Album {title} by {artist} is already in the database" });
            }

            return this.RedirectToAction("ListAll");
        }

        /// <summary>
        /// Redirects to the Delete page in the Album folder.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult Delete()
        {
            var viewModel = new DeleteAlbumViewModel();
            viewModel.Albums = this.albumService.GetAll();
            return this.View(viewModel);
        }

        /// <summary>
        /// Allows a signed in User to delete an Album from the database.
        /// The User must be signed in.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        [HttpPost]
        public IActionResult Delete(int albumId)
        {
            var viewModel = new DeleteAlbumViewModel();
            viewModel.Albums = this.albumService.GetAll();

            this.albumService.DeleteAlbum(albumId);
            return this.RedirectToAction("ListAll");
        }

        /// <summary>
        /// Notifies the User that the Album they tried to add to the database is already in it.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        public IActionResult AlbumAlreadyAdded(string error)
        {
            var viewModel = new FailMessageViewModel();
            viewModel.Error = error;
            return this.View(viewModel);
        }

        /// <summary>
        /// Displays a page with detailed info about the Album the User has clicked on.
        /// </summary>
        /// <returns>Rendered view to the response.</returns>
        //[Route("Album/{id}")]
        public IActionResult AlbumInfo(int albumId)
        {
            var viewModel = new IndexAlbumViewModel();

            var a = albumService.GetAll().FirstOrDefault(x => x.AlbumId == albumId);

            viewModel.Artist = a.Artist;
            viewModel.GenreId = a.GenreId;
            viewModel.Genre = genreService.GetAll().FirstOrDefault(x => x.Id == a.GenreId).Name;
            viewModel.Title = a.Title;
            viewModel.Year = a.Year;
            viewModel.TimesRated = a.TimesRated;

            return this.View(viewModel);
        }

    }
}