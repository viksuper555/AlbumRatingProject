namespace AlbumRating.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AlbumRating.Services;
    using AlbumRating.Services.Contracts;
    using AlbumRating.ViewModels.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class AlbumController : Controller
    {
        private IAlbumsService albumService;
        private IGenreService genreService;

        public AlbumController(IAlbumsService albumService, IGenreService genreService)
        {
            this.albumService = albumService;
            this.genreService = genreService;
        }

        [AllowAnonymous]
        public IActionResult ListAll()
        {
            var viewModel = new IndexAllAlbumsViewModel();
            viewModel.Albums = this.albumService.GetAll();
            return this.View(viewModel);
        }

        public IActionResult Create()
        {
            var viewModel = new CreateAlbumViewModel();
            viewModel.Genres = this.genreService.GetAll();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(string title, string artist, int year, int genreId)
        {
            if(this.albumService.CreateAlbum(title, artist, year, genreId) == 0)
            {
                return this.RedirectToAction("AlbumAlreadyAdded");
            }
            return this.RedirectToAction("ListAll"); // change to redirect to some other page
        }

        public IActionResult Delete()
        {
            var viewModel = new DeleteAlbumViewModel();
            viewModel.Albums = this.albumService.GetAll();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int albumId)
        {
            var viewModel = new DeleteAlbumViewModel();
            viewModel.Albums = this.albumService.GetAll();

            this.albumService.DeleteAlbum(albumId);
            return this.RedirectToAction("ListAll"); // change to redirect to some other page
        }

        public IActionResult AlbumAlreadyAdded()
        {
            return this.View();
        }
    }
}