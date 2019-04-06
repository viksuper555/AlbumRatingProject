namespace AlbumRating.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AlbumRating.Data;
    using AlbumRating.Data.Models;
    using AlbumRating.Services.Contracts;

    public class AlbumService : IAlbumsService
    {
        private AlbumRatingDbContext context;

        public AlbumService(AlbumRatingDbContext context)
        {
            this.context = context;
        }

        public int CreateAlbum(string title, string artist, int year, int genreId) // add to db
        {
            var album = new Album() { Title = title, Artist = artist, Year = year, GenreId = genreId, TimesRated = 0};

            foreach (var albumInDb in this.context.Albums)
            {
                if (albumInDb.Title == album.Title && albumInDb.Artist == albumInDb.Artist)
                {
                    return 0;
                }
            }

            this.context.Albums.Add(album);
            this.context.SaveChanges();
            return album.AlbumId;
        }

        public int DeleteAlbum(int albumId) // delete from db
        {
            var album = this.context.Albums.FirstOrDefault(x => x.AlbumId == albumId);
            this.context.Albums.Remove(album);
            this.context.SaveChanges();
            return album.AlbumId;
        }

        public List<UserRatedAlbum> GetAllRatings()
        {
            return this.context.UserRatedAlbums.Where(x => x.User != null).ToList();
        }

        public List<Album> GetAll()
        {
            return this.context.Albums.ToList();
        }
    }
}