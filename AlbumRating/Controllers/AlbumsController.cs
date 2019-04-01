using AlbumRating.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumRating.Controllers
{
    public class AlbumsController : Controller
    {
        private IAlbumsService service;

        public AlbumsController(IAlbumsService Service)
        {
            this.service = Service;
        }

        public IActionResult Create()
        {
            return this.View();
        }
    }
}
