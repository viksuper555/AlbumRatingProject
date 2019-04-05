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

    [Authorize]
    public class UserController : Controller
    {
        private IAlbumsService albumService;
        private IGenreService genreService;
        private IUserService userService;

        public UserController(IUserService userService, IAlbumsService albumService, IGenreService genreService)
        {
            this.albumService = albumService;
            this.genreService = genreService;
            this.userService = userService;
        }

        public IActionResult Rate()
        {
            var viewModel = new RateAlbumViewModel();
            viewModel.Albums = this.albumService.GetAll();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Rate(int albumId, int rating)
        {
            var viewModel = new RateAlbumViewModel();
            viewModel.Albums = this.albumService.GetAll();

            var currentUserName = this.User.Identity.Name;
            var currentUser = this.userService.GetUserByName(currentUserName);

            if (this.userService.RateAlbum(albumId, rating, currentUser.UserId) == 0)
            {
                // take id and display info for it
                return this.RedirectToAction("AlbumAlreadyRated"); // redirect to "you've already rated this album"
            }

            return this.RedirectToAction("ListAll", "Album");
        }

        public IActionResult AlbumAlreadyRated()
        {
            return this.View();
        }

        /*[AllowAnonymous] add list all rated
        public IActionResult ListAll()
        {
            var viewModel = new IndexAllAlbumsViewModel();
            viewModel.Albums = this.albumService.GetAll();
            return this.View(viewModel);
        }*/

    }
}