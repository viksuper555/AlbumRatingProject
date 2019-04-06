using AlbumRating.Data;
using AlbumRating.Data.Models;
using AlbumRating.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlbumRating.Services
{
    public class UserService : IUserService
    {
        private AlbumRatingDbContext context;

        public UserService(AlbumRatingDbContext context)
        {
            this.context = context;
        }

        public List<User> GetAll()
        {
            return this.context.Users.ToList();
        }

        public User GetUserByName(string name)
        {
            var user = this.context.Users.FirstOrDefault(x => x.UserName == name);
            return user;
        }

        public List<UserRatedAlbum> GetAllRated(int userId)
        {
            return this.context.UserRatedAlbums.Where(x => x.UserId == userId && x.Album != null).ToList();
        }

        public int RateAlbum(int albumId, int rating, int userId)
        {
            var album = this.context.Albums.FirstOrDefault(x => x.AlbumId == albumId);
            var user = this.context.Users.FirstOrDefault(x => x.UserId == userId);

            var ratedAlbum = new UserRatedAlbum() { User = user, UserId = userId, Album = album, AlbumId = album.AlbumId, Rating = rating };

            foreach (var ratedInDb in this.context.UserRatedAlbums)
            {
                if (ratedInDb.AlbumId == ratedAlbum.AlbumId && ratedInDb.UserId == ratedAlbum.UserId)
                {
                    return 0;
                }
            }

            album.TimesRated += 1;

            this.context.UserRatedAlbums.Add(ratedAlbum);
            this.context.SaveChanges();

            return user.UserId;
        }

    }
}
