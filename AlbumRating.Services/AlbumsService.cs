﻿using AlbumRating.Data;
using AlbumRating.Data.Models;
using AlbumRating.Services.Contracts;
using System;

namespace AlbumRating.Services
{
    public class AlbumsService : IAlbumsService
    {
        private AlbumRatingDbContext context;

        public AlbumsService(AlbumRatingDbContext context)
        {
            this.context = context;
        }
        public int CreateAlbum(int albumId, string title, string artist, int year, string genre)
        {
            var album = new Album() { AlbumId= albumId, Title = title, Artist = artist, Year = year, Genre = genre };
            context.Albums.Add(album);
            context.SaveChanges();

            return album.AlbumId;
        }
    }
}
