using AlbumRating.Data;
using AlbumRating.Data.Models;
using AlbumRating.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlbumRating.Services
{
    public class GenreService : IGenreService
    {

        private AlbumRatingDbContext context;

        public GenreService(AlbumRatingDbContext context)
        {
            this.context = context;
        }

        public int CreateGenre(string name)
        {
            var genre = new Genre() { Name = name };
            this.context.Genres.Add(genre);
            this.context.SaveChanges();

            return genre.Id;

        }

        public List<Genre> GetAll()
        {
            return this.context.Genres.ToList();
        }
    }
}
