using AlbumRating.Services.Contracts;
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
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Rate()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Rate(string title, int rating)
        {
            var currentUserName = this.User.Identity.Name;
            var currentUser = this.userService.GetUserByName(currentUserName);
            
            this.userService.RateAlbum(title, rating, currentUser.UserId);
            return this.RedirectToAction("ListAll");
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
