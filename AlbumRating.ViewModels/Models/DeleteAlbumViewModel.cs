namespace AlbumRating.ViewModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using AlbumRating.Data.Models;

    public class DeleteAlbumViewModel
    {
        public string Title { get; set; }

        [Required]
        public int AlbumId { get; set; }

        public List<Album> Albums { get; set; }
    }
}