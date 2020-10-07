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
        private Mock<IBlogRepository> _blogRepository;
        private AdminBlogController _adminBlogController;

        [SetUp]
        public void SetUp()
        {
            _blogRepository = new Mock<IBlogRepository>();
            _adminBlogController = new AdminBlogController(_blogRepository.Object);
        }

        [Test]
        public void GetIndex_FromController_ReturnAllBlogs()
        {
            _blogRepository.Setup(b => b.AllBlogs);
            _adminBlogController.Index();

            _blogRepository.Verify(b => b.AllBlogs, Times.Once);
        }

        [Test]
        public void GetCreate_FromController_ReturnView()
        {
            IActionResult result = _adminBlogController.Create();

            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }

        [Test]
        public void PostCreate_FromController_SaveBlogToDatabase()
        {
            _blogRepository.Setup(b => b.Add(It.IsAny<Blog>()));

            _adminBlogController.Create(It.IsAny<Blog>());
            _blogRepository.Verify(b => b.Add(It.IsAny<Blog>()));
        }

        [Test]
        public void GetEdit_FromController_ReturnSingleBlog()
        {
            _blogRepository.Setup(b => b.GetBlogById(It.IsAny<int>()));

            _adminBlogController.Edit(It.IsAny<int>());
            _blogRepository.Verify(b => b.GetBlogById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void UpdateBlog_FromController_ReturnUpdatedBlog()
        {
            _blogRepository.Setup(b => b.Update(It.IsAny<Blog>()));
            _adminBlogController.Update(It.IsAny<Blog>());

            _blogRepository.Verify(b => b.Update(It.IsAny<Blog>()));
        }

        [Test]
        public void DeleteBlog_FromController_Return204NoContent()
        {
            _blogRepository.Setup(b => b.Delete(It.IsAny<int>()));
            _adminBlogController.Delete(It.IsAny<int>());

            _blogRepository.Verify(b => b.Delete(It.IsAny<int>()));
        }
    }
}