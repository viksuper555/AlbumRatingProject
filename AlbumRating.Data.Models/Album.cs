﻿namespace AlbumRating.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        public Album()
        {
            this.UserRatedAlbums = new List<UserRatedAlbum>();
        }

        public int AlbumId { get; set; }

        public string Artist { get; set; }

        public int Year { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public string Title { get; set; }

        public int TimesRated { get; set; }

        public ICollection<UserRatedAlbum> UserRatedAlbums { get; set; }
    }
}