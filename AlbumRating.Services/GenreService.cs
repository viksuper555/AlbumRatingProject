namespace AlbumRating.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AlbumRating.Data;
    using AlbumRating.Data.Models;
    using AlbumRating.Services.Contracts;

    /// <summary>
    /// GenresService is a class that inherits the IGenreService interface.
    /// Contains methods to manipulate and get data from the Genres table in the database.
    /// <list type="bullet">
    /// <item>
    /// <term>CreateGenre</term>
    /// <description>The CreateGenre method adds a new genre to the database with the given parameters.</description>
    /// </item>
    /// <item>
    /// <term>GetAll</term>
    /// <description>The GetAll method returns all Genres from the database.</description>
    /// </item>
    /// </list>
    /// </summary>
    /// 
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

            foreach (var genreInDb in this.context.Genres)
            {
                if (genreInDb.Name == genre.Name)
                {
                    return 0;
                }
            }

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