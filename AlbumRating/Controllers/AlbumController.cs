using AlbumRating.Services;
using AlbumRating.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using AlbumRating.ViewModels.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AlbumRating.Controllers
{
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
            int albumId  = this.albumService.CreateAlbum(title, artist, year, genreId); //
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

    }
}