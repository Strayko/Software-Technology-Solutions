using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
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
        
        [Route("admin/blogs")]
        public IActionResult Index()
        {
            ViewBag.Current = "AdminBlog";

            var blogs = _blogRepository.AllBlogs.OrderBy(b => b.Name);
            return View(blogs);
        }
        
        [HttpGet]
        [Route("admin/blogs/create")]
        public IActionResult Create()
        {
            ViewBag.Current = "AdminBlog";
            
            return View();
        }

        [HttpPost]
        [Route("admin/blogs/create")]
        public IActionResult Create(Blog blog)
        {
            _blogRepository.Add(blog);
            
            return RedirectToAction("Index");
        }
    }
}