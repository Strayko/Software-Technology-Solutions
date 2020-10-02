using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ST.Controllers
{
    public class AdminBlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public AdminBlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        
        public IActionResult Index()
        {
            ViewBag.Current = "AdminBlog";

            var blogs = _blogRepository.AllBlogs.OrderBy(b => b.Name);
            return View(blogs);
        }
    }
}