namespace AlbumRating.ViewModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using AlbumRating.Data.Models;

    public class RateAlbumViewModel
    {
        [Required]
        public string Title { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        public int AlbumId { get; set; }

        public List<Album> Albums { get; set; }
    }
}