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

        public AlbumController(IAlbumsService service)
        {
            this.service = service;
        }

        public IActionResult Create()
        {
            return this.View();
        }
    }
}
