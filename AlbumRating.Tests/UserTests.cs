namespace AlbumRating.Tests
{
    using AlbumRating.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System;
    using Moq;
    using AlbumRating.Data;
    using System.Linq;
    using System.Collections.Generic;
    using AlbumRating.Services;

    [TestFixture]
    public class UserTests
    {
        [Test]
        [Obsolete]
        public void AddUserInDatabase()
        {
            var data = new List<User>
            {
                new User{ Name = "a@abv.bg"},
                new User{ Name = "b@abv.bg"},
                new User{ Name = "c@abv.bg"}

            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var optionsBuilder = new DbContextOptionsBuilder<AlbumRatingDbContext>();
            var mockContext = new Mock<AlbumRatingDbContext>(optionsBuilder.Options);

            mockContext.Setup(x => x.Users).Returns(mockSet.Object); // Setting it up to return Users

            var service = new UserService(mockContext.Object);
            var users = service.GetAll();

            Assert.AreEqual(3, users.Count);
            Assert.AreEqual("a@abv.bg", users[0].Name);
            Assert.AreEqual("b@abv.bg", users[1].Name);
            Assert.AreEqual("c@abv.bg", users[2].Name);
        }

    }
}
