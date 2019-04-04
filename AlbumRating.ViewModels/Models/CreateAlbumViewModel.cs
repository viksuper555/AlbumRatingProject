using AlbumRating.Data.Models;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlbumRating.ViewModels.Models
{
    public class CreateAlbumViewModel
    {
        [Required]
        public string Artist { get; set; }

        [Range(1600, 2019)]
        public int Year { get; set; }
        [Required]
        public string Title { get; set; }

        public int GenreId { get; set; }

        public List<Genre> Genres { get; set; }

    }
}
