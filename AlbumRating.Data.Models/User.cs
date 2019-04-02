using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlbumRating.Data.Models
{

    public class User : IdentityUser
    {

        public User()
        {
            this.UserRatedAlbums = new List<UserRatedAlbum>();
        }

        public int UserId { get; set; }

        public string Name { get; set; }

        public ICollection<UserRatedAlbum> UserRatedAlbums { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

    }
}