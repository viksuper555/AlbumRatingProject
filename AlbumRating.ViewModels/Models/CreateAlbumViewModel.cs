using AlbumRating.Data.Models;
using System.Collections.Generic;
using System;

namespace AlbumRating.ViewModels.Models
{
    public class CreateAlbumViewModel
    {
        public string Artist { get; set; }

        public int Year { get; set; }

        public string Title { get; set; }

        public int GenreId { get; set; }

        public List<Genre> Genres { get; set; }

    }
}
