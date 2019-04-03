using AlbumRating.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumRating.Controllers
{
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
            service.CreateGenre(name);
            return this.RedirectToAction("Index", "Home");
        }

    }
}
