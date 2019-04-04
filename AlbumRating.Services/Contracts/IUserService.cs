using AlbumRating.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlbumRating.Services.Contracts
{
    public interface IUserService
    {
        List<User> GetAll();

        User GetUserByName(string name);

        int RateAlbum(string title, int rating, int userId);

    }
}
