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

    [Authorize]
    public class AlbumController : Controller
    {
        private IAlbumsService albumService;
        private IGenreService genreService;
        private IUserService userService;

        public AlbumController(IUserService userService, IAlbumsService albumService, IGenreService genreService)
        {
            this.albumService = albumService;
            this.genreService = genreService;
            this.userService = userService;
        }

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
                var timesRated = 0;
                foreach (var user in userService.GetAll())
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
                        timesRated++;
                    }
                }

                    //viewModel.AlbumsWithRating[a.Album] = a.Rating / timesRated;
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

        public IActionResult Create()
        {
            var viewModel = new CreateAlbumViewModel();
            viewModel.Genres = this.genreService.GetAll();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(string title, string artist, int year, int genreId)
        {
            if (this.albumService.CreateAlbum(title, artist, year, genreId) == 0)
            {
                return (this.RedirectToAction("AlbumAlreadyAdded", new { error = $"Album {title} by {artist} is already in the database" }));
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

        public IActionResult AlbumAlreadyAdded(string error)
        {
            var viewModel = new FailMessageViewModel();
            viewModel.Error = error;
            return this.View(viewModel);
        }
    }
}