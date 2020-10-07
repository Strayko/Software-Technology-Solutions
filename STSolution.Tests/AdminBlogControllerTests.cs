using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ST;
using ST.Controllers;

namespace STSolution.Tests
{
    [TestFixture]
    public class AdminBlogControllerTests
    {
        
        Blog blog = new Blog
        {
            BlogId = 1,
            Name = "",
            ShortDescription = "value",
            LongDescription = "value",
            ImageUrl = "value",
            ImageThumbnailUrl = "",
            Category = null,
            Notes = "",
            CategoryId = 2
        };

        [Test]
        public void GetIndex_FromController_ReturnAllBlogs()
        {
            var mock = new Mock<IBlogRepository>();
            mock.Setup(b => b.AllBlogs);

            var adminBlogController = new AdminBlogController(mock.Object);
            adminBlogController.Index();

            mock.Verify(b => b.AllBlogs, Times.Once);
        }

        [Test]
        public void GetCreate_FromController_ReturnView()
        {
            var mock = new Mock<IBlogRepository>();

            AdminBlogController adminBlogController = new AdminBlogController(mock.Object);
            IActionResult result = adminBlogController.Create();

            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }

        [Test]
        public void PostCreate_FromController_SaveBlogToDatabase()
        {
            var mock = new Mock<IBlogRepository>();
            var adminBlogController = new AdminBlogController(mock.Object); 
            
            adminBlogController.Create(blog);

            mock.Verify(b => b.Add(blog));
        }

        [Test]
        public void GetEdit_FromController_ReturnSingleBlog()
        {
            var mock = new Mock<IBlogRepository>();
            mock.Setup(b => b.GetBlogById(It.IsAny<int>()));

            var adminBlogController = new AdminBlogController(mock.Object);
            adminBlogController.Edit(It.IsAny<int>());

            mock.Verify(b => b.GetBlogById(It.IsAny<int>()), Times.Once);
        }
    }
}