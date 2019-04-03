using AlbumRating.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlbumRating.Services.Contracts
{
    public interface IGenreService
    {
        int CreateGenre(string name);
        List<Genre> GetAll();
    }
}
