using AlbumRating.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumRating.Controllers
{
    public class AlbumController : Controller
    {
        private IAlbumsService service;
        private int last_id = 0;

        public AlbumController(IAlbumsService service)
        {
            this.service = service;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string title, string artist, int year, string genre)
        {
            service.CreateAlbum(title, artist, year, genre);
            return this.RedirectToAction("Index", "Home"); // change to redirect to some other page
        }

        public IActionResult Delete()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Delete(string title)
        {
            service.DeleteAlbum(title);
            return this.RedirectToAction("Index", "Home"); // change to redirect to some other page
        }

    }
}
