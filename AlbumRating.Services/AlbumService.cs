namespace AlbumRating.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AlbumRating.Data;
    using AlbumRating.Data.Models;
    using AlbumRating.Services.Contracts;

    /// <summary>
    /// AlbumsService is a class that inherits the IAlbumService interface.
    /// Contains methods to manipulate and get data from the Albums table in the database.
    /// <list type="bullet">
    /// <item>
    /// <term>CreateAlbum</term>
    /// <description>The CreateAlbum method adds a new album to the database with the given parameters.</description>
    /// </item>
    /// <item>
    /// <term>DeleteAlbum</term>
    /// <description>The DeleteAlbum method deletes the album with the given id from the database.</description>
    /// </item>
    /// <item>
    /// <term>GetAllRatings</term>
    /// <description>The GetAllRatings method returns all the entries from the UserRatedAlbum table.</description>
    /// </item>
    /// <item>
    /// <term>GetAll</term>
    /// <description>The GetAll method returns all Albums from the database.</description>
    /// </item>
    /// </list>
    /// </summary>
    /// 

    public class AlbumService : IAlbumsService
    {
        private AlbumRatingDbContext context;

        public AlbumService(AlbumRatingDbContext context)
        {
            this.context = context;
        }

        public int CreateAlbum(string title, string artist, int year, int genreId) 
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

        public int DeleteAlbum(int albumId)
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