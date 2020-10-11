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
        private IQueryable<Blog> _data;
        private Mock<DbSet<Blog>> _mockSet;
        private Mock<IAppDbContext> _appDbContext;
        private BlogRepository _blogRepository;

        [SetUp]
        public void SetUp()
        {
            _dbSetContextHelperMock = new DbSetContextHelperMock();
            _data = _dbSetContextHelperMock.ListBlogsQueryable();
            
            _mockSet = new Mock<DbSet<Blog>>();
            _appDbContext = new Mock<IAppDbContext>();
            
            _dbSetContextHelperMock.ProvideQuaryableMockDbSet(_mockSet, _data);
            _appDbContext.Setup(b => b.Blogs).Returns(_mockSet.Object);
            
            _blogRepository = new BlogRepository(_appDbContext.Object);
        }
        
        [Test]
        public void GetAll_Blogs_FromDatabase()
        {
            var blogs = _blogRepository.AllBlogs;
            
            Assert.AreEqual(3, blogs.Count());
        }

        [Test]
        public void GetBlog_ById_ReturnSingleBlog()
        {
            var blog = _blogRepository.GetBlogById(1);
            
            Assert.AreEqual(1, blog.BlogId);
        }

        [Test]
        public void Save_Blog_ToDatabase()
        {
            _blogRepository.Add(It.IsAny<Blog>());
            
            _mockSet.Verify(m=>m.Add(It.IsAny<Blog>()), Times.Once);
            _appDbContext.Verify(m=>m.SaveChanges(), Times.Once);
        }

        [Test]
        public void UpdateSingle_Blog_ReturnBlog()
        {
            _appDbContext.Setup(b => b.SetModified(It.IsAny<Blog>()));
            
            _blogRepository.Update(It.IsAny<Blog>());

            _appDbContext.Verify(m=>m.SetModified(It.IsAny<Blog>()), Times.Once);
            _appDbContext.Verify(m=>m.SaveChanges(), Times.Once);
        }

        [Test]
        public void DeleteSingle_Blog_Return204NoContent()
        {
            _blogRepository.Delete(It.IsAny<int>());
            
            _mockSet.Verify(m=>m.Remove(It.IsAny<Blog>()), Times.Once);
            _appDbContext.Verify(m=>m.SaveChanges(), Times.Once);
        }
    }
}