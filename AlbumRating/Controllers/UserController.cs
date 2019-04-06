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
                var alreadyRated = viewModel.Albums.FirstOrDefault(x => x.AlbumId == albumId);
                return (this.RedirectToAction("AlbumAlreadyRated", new { error = $"You've already rated {alreadyRated.Title} by {alreadyRated.Artist}" }));

            }

            return this.RedirectToAction("ListAll", "Album");
        }

        public IActionResult AlbumAlreadyRated(string error)
        {
            var viewModel = new FailMessageViewModel();
            viewModel.Error = error;
            return this.View(viewModel); ;
        }

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