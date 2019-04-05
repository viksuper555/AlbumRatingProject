namespace AlbumRating.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AlbumRating.Data.Models;

    public interface IGenreService
    {
        int CreateGenre(string name);

        List<Genre> GetAll();
    }
}