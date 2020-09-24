using Microsoft.AspNetCore.Mvc;

namespace ST.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BlogController(IBlogRepository blogRepository, ICategoryRepository categoryRepository)
        {
            _blogRepository = blogRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            ViewBag.CurrentCategory = "PHP";
            return View(_blogRepository.AllBlogs);
        }
    }
}