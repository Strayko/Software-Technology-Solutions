﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using ST;

namespace STSolution.Tests
{
    [TestFixture]
    public class BlogRepositoryTests
    {
        private DbContextMock _dbSetContextMock;

        [SetUp]
        public void SetUp()
        {
            _dbSetContextMock = new DbContextMock();
        }
        
        [Test]
        public void GetAll_Blogs_FromDatabase()
        {
            var data = _dbSetContextMock.ListBlogsQueryable();

            var mockSet = new Mock<DbSet<Blog>>();
            _dbSetContextMock.GetQuaryableMockDbSet(mockSet, data);

            var appDbContext = new Mock<IAppDbContext>();
            appDbContext.Setup(b => b.Blogs).Returns(mockSet.Object);
            
            var blogRepository = new BlogRepository(appDbContext.Object);
            var blogs = blogRepository.AllBlogs;
            
            Assert.AreEqual(3, blogs.Count());
        }

        [Test]
        public void Save_Blog_ToDatabase()
        {
            var mockSet = new Mock<DbSet<Blog>>();
            var appDbContext = new Mock<IAppDbContext>();
            appDbContext.Setup(b => b.Blogs).Returns(mockSet.Object);
            
            var blogRepository = new BlogRepository(appDbContext.Object);
            blogRepository.Add(It.IsAny<Blog>());
            
            mockSet.Verify(m=>m.Add(It.IsAny<Blog>()), Times.Once);
            appDbContext.Verify(m=>m.SaveChanges(), Times.Once);
        }
    }
}