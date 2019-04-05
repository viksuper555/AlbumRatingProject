namespace AlbumRating.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AlbumRating.Services.Contracts;
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
            this.service.CreateGenre(name);
            return this.RedirectToAction("Index", "Home");
        }
    }
}
