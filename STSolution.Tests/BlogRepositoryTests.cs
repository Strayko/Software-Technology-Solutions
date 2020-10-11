using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using ST;

namespace STSolution.Tests
{
    [TestFixture]
    public class BlogRepositoryTests
    {
        private DbSetContextHelperMock _dbSetContextHelperMock;

        [SetUp]
        public void SetUp()
        {
            _dbSetContextHelperMock = new DbSetContextHelperMock();
        }
        
        [Test]
        public void GetAll_Blogs_FromDatabase()
        {
            var data = _dbSetContextHelperMock.ListBlogsQueryable();

            var mockSet = new Mock<DbSet<Blog>>();
            _dbSetContextHelperMock.ProvideQuaryableMockDbSet(mockSet, data);

            var appDbContext = new Mock<IAppDbContext>();
            appDbContext.Setup(b => b.Blogs).Returns(mockSet.Object);
            
            var blogRepository = new BlogRepository(appDbContext.Object);
            var blogs = blogRepository.AllBlogs;
            
            Assert.AreEqual(3, blogs.Count());
        }

        [Test]
        public void GetBlog_ById_ReturnSingleBlog()
        {
            var data = _dbSetContextHelperMock.ListBlogsQueryable();
            var mockSet = new Mock<DbSet<Blog>>();
            _dbSetContextHelperMock.ProvideQuaryableMockDbSet(mockSet, data);
            
            var appDbContext = new Mock<IAppDbContext>();
            appDbContext.Setup(b => b.Blogs).Returns(mockSet.Object);
            
            var blogRepository = new BlogRepository(appDbContext.Object);
            var blog = blogRepository.GetBlogById(1);
            
            Assert.AreEqual(1, blog.BlogId);
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

        [Test]
        public void UpdateSingleBlog_Only_ChangedValues()
        {
            var mockSet = new Mock<DbSet<Blog>>();
            var appDbContext = new Mock<IAppDbContext>(); 
            appDbContext.Setup(b => b.Blogs).Returns(mockSet.Object);
            appDbContext.Setup(b => b.SetModified(It.IsAny<Blog>()));
            
            var blogRepository = new BlogRepository(appDbContext.Object);
            blogRepository.Update(It.IsAny<Blog>());

            appDbContext.Verify(m=>m.SetModified(It.IsAny<Blog>()));
            appDbContext.Verify(m=>m.SaveChanges(), Times.Once);
        }
    }
}