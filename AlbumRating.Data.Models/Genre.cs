namespace AlbumRating.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Genre
    {
        public Genre()
        {
            this.Albums = new List<Album>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Album> Albums { get; set; }
    }
}