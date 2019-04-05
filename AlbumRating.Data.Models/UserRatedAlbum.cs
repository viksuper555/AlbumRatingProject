namespace AlbumRating.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class UserRatedAlbum
    {
        [Key, Column]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        public int AlbumId { get; set; }

        public User User { get; set; }

        public Album Album { get; set; }

        public int Rating { get; set; } 
    }
}