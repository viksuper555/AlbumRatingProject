using AlbumRating.Data.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using Moq;
using AlbumRating.Data;
using System.Linq;
using System.Collections.Generic;
using AlbumRating.Services;

namespace AlbumRating.Tests
{
    [TestFixture]
    public class GenreTests
    {
        [Test]
        [Obsolete]
        public void AddGenreInDatabase()
        {
            var data = new List<Genre>
            {
                new Genre{ Name = "Pop"},
                new Genre{ Name = "Rock"},
                new Genre{ Name = "Rap"}

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Genre>>();
            mockSet.As<IQueryable<Genre>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Genre>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var optionsBuilder = new DbContextOptionsBuilder<AlbumRatingDbContext>();
            var mockContext = new Mock<AlbumRatingDbContext>(optionsBuilder.Options);

            mockContext.Setup(x =>x.Genres).Returns(mockSet.Object); //Setting it up to return Genres

            var service = new GenreService(mockContext.Object);
            var genres = service.GetAll();

            Assert.AreEqual(3, genres.Count);
            Assert.AreEqual("Pop", genres[0].Name);
            Assert.AreEqual("Rock", genres[1].Name);
            Assert.AreEqual("Rap", genres[2].Name);
        }
    }
}
