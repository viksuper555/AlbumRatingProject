namespace AlbumRating.ViewModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AlbumRating.Data.Models;

    public class CreateAlbumViewModel
    {
        [Required]
        public string Artist { get; set; }

        [Range(1900, 2019)]
        public int Year { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int GenreId { get; set; }

        public List<Genre> Genres { get; set; }
    }
}