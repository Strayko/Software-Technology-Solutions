using System;
using Moq;
using NUnit.Framework;
using ST;
using ST.Controllers;

namespace STSolution.Tests
{
    [TestFixture]
    public class AdminBlogControllerTests
    {
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