using AlbumRating.Services;
using AlbumRating.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using AlbumRating.ViewModels.Models;
using System.Threading.Tasks;

namespace AlbumRating.Controllers
{
    public class AlbumController : Controller
    {
        private IAlbumsService albumService;
        private IGenreService genreService;


        public AlbumController(IAlbumsService albumService, IGenreService genreService)
        {
            this.albumService = albumService;
            this.genreService = genreService;
        }

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
            this.albumService.CreateAlbum(title, artist, year, genreId); // 

            return this.RedirectToAction("ListAll"); // change to redirect to some other page
        }

        public IActionResult Delete()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Delete(string title)
        {
            this.albumService.DeleteAlbum(title);
            return this.RedirectToAction("ListAll"); // change to redirect to some other page
        }

    }
}
