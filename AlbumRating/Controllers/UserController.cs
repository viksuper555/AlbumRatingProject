using AlbumRating.Services.Contracts;
using AlbumRating.ViewModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumRating.Controllers
{
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

           // return this.View();
        }

        [HttpPost]
        public IActionResult Rate(int albumId, int rating)
        {
            var viewModel = new RateAlbumViewModel();
            viewModel.Albums = this.albumService.GetAll();

            var currentUserName = this.User.Identity.Name;
            var currentUser = this.userService.GetUserByName(currentUserName);
            
            this.userService.RateAlbum(albumId, rating, currentUser.UserId);
            return this.RedirectToAction("ListAll", "Album");
            //return this.View(viewModel);
        }

        /*[AllowAnonymous]
        public IActionResult ListAll()
        {
            var viewModel = new IndexAllAlbumsViewModel();
            viewModel.Albums = this.albumService.GetAll();
            return this.View(viewModel);
        }*/


    }
}
