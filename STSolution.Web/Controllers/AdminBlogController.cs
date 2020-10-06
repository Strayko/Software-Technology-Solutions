using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            ViewBag.Current = "AdminBlog";
            
            if (!ModelState.IsValid)
                return View();
            
            _blogRepository.Add(blog);
            return RedirectToAction("Index");
        }

        [Route("admin/blogs/edit/{blogId}")]
        public IActionResult Edit(int blogId)
        {
            ViewBag.Current = "AdminBlog";
            
            var blog = _blogRepository.GetBlogById(blogId);
            return View(blog);
        }

        public IActionResult Update(Blog blog)
        {
            _blogRepository.Update(blog);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int blogId)
        {
            _blogRepository.Delete(blogId);
            return RedirectToAction("Index");
        }
    }
}