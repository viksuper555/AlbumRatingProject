namespace AlbumRating.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AlbumRating.Data.Models;

    public interface IUserService
    {
        List<User> GetAll();

        User GetUserByName(string name);

        int RateAlbum(int albumId, int rating, int userId);

        List<UserRatedAlbum> GetAllRated(int userId);

    }
}