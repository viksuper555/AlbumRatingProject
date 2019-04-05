namespace AlbumRating.ViewModels.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class IndexAlbumViewModel
    {
        public string Title { get; set; }

        public int GenreId { get; set; }

        public string Genre { get; set; }

        public int Year { get; set; }

        public string Artist { get; set; }
    }
}