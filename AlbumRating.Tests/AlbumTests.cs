namespace AlbumRating.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AlbumRating.Data;
    using AlbumRating.Data.Models;
    using AlbumRating.Services;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using NUnit.Framework;

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

            mockContext.Setup(x => x.Albums).Returns(mockSet.Object); // Setting it up to return Albums

            var service = new AlbumService(mockContext.Object);
            var albums = service.GetAll();

            Assert.AreEqual(3, albums.Count);
            Assert.AreEqual("Seven Rings", albums[0].Title);
            Assert.AreEqual("KOD", albums[1].Title);
            Assert.AreEqual("Kamikaze", albums[2].Title);
        }

        [Test]
        public void DeleteAlbumFromDatabase()
        {
            var data = new List<Album>
            {
                new Album{ AlbumId = 1},
                new Album{ AlbumId = 3},
                new Album{ AlbumId = 5}

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Album>>();
            mockSet.As<IQueryable<Album>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Album>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Album>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Album>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var optionsBuilder = new DbContextOptionsBuilder<AlbumRatingDbContext>();
            var mockContext = new Mock<AlbumRatingDbContext>(optionsBuilder.Options);

            mockContext.Setup(x => x.Albums).Returns(mockSet.Object); // Setting it up to return Albums

            var service = new AlbumService(mockContext.Object);
            var albums = service.GetAll();

            int deletedAlbumId = service.DeleteAlbum(albums[0].AlbumId);

            Assert.IsNull(service.GetAll().FirstOrDefault(x => x.AlbumId == deletedAlbumId));
        }

    }   
}
