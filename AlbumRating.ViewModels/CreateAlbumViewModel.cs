using System;

namespace AlbumRating.ViewModels
{
    public class CreateAlbumViewModel
    {
        public int AlbumId { get; set; }

        public string Artist { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public string Title { get; set; }
    }
}
