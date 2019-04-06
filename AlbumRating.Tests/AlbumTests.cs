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
    public class AlbumTests
    {
        [Test]
        [Obsolete]
        public void AddAlbumInDatabase()
        {
            var data = new List<Album>
            {
                new Album{ Title = "Seven Rings"},
                new Album{ Title = "KOD"},
                new Album{ Title = "Kamikaze"}

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Album>>();
            mockSet.As<IQueryable<Album>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Album>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Album>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Album>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var optionsBuilder = new DbContextOptionsBuilder<AlbumRatingDbContext>();
            var mockContext = new Mock<AlbumRatingDbContext>(optionsBuilder.Options);

            mockContext.Setup(x => x.Albums).Returns(mockSet.Object); //Setting it up to return Genres

            var service = new AlbumService(mockContext.Object);
            var genres = service.GetAll();

            Assert.AreEqual(3, genres.Count);
            Assert.AreEqual("Seven Rings", genres[0].Title);
            Assert.AreEqual("KOD", genres[1].Title);
            Assert.AreEqual("Kamikaze", genres[2].Title);
        }

        
    }
}
