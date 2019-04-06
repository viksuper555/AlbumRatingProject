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
    public class GenreController : Controller
    {
        private IGenreService service;

        public GenreController(IGenreService service)
        {
            this.service = service;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            if(this.service.CreateGenre(name) == 0)
            {
                return (this.RedirectToAction("GenreAlreadyAdded", new { error = $"Genre {name} is already in the database"}));
            }

            return this.RedirectToAction("ListAll", "Album");
        }

        public IActionResult GenreAlreadyAdded(string error)
        {
            var viewModel = new FailMessageViewModel();
            viewModel.Error = error;
            return this.View(viewModel);
        }
    }
}
