using AlbumRating.Data;
using AlbumRating.Data.Models;
using AlbumRating.Services.Contracts;
using System;
using System.Linq;

namespace AlbumRating.Services
{
    public class AlbumService : IAlbumsService
    {
        private AlbumRatingDbContext context;

        public AlbumService(AlbumRatingDbContext context)
        {
            this.context = context;
        }
        public int CreateAlbum(string title, string artist, int year, string genre) 
        {
            var album = new Album() {Title = title, Artist = artist, Year = year, Genre = genre };
            context.Albums.Add(album);
            context.SaveChanges();

            return album.AlbumId;
        }

        public int DeleteAlbum(string title)
        {
            var album = this.context.Albums.FirstOrDefault(x => x.Title == title);
            this.context.Albums.Remove(album);
            this.context.SaveChanges();
            return album.AlbumId;
        }
    }
}
