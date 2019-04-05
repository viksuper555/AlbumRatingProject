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

        public int CreateAlbum(string title, string artist, int year, int genreId)
        {
            var album = new Album() { Title = title, Artist = artist, Year = year, GenreId = genreId };
            this.context.Albums.Add(album);
            this.context.SaveChanges();
            return album.AlbumId;
        }

        public int DeleteAlbum(int albumId)
        {
            var album = this.context.Albums.FirstOrDefault(x => x.AlbumId == albumId);
            this.context.Albums.Remove(album);
            this.context.SaveChanges();
            return album.AlbumId;
        }

        public List<Album> GetAll()
        {
            return this.context.Albums.ToList();
        }
    }
}