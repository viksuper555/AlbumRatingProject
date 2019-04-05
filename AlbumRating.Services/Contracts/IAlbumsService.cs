namespace AlbumRating.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AlbumRating.Data.Models;

    public interface IAlbumsService
    {
        int CreateAlbum(string title, string artist, int year, int genreId);

        int DeleteAlbum(int albumId);

        List<Album> GetAll();
    }
}