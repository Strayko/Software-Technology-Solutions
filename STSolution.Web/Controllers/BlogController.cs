using Microsoft.AspNetCore.Mvc;
using ST.ViewModels;

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
            BlogListViewModel blogListViewModel = new BlogListViewModel();
            blogListViewModel.Blogs = _blogRepository.AllBlogs;

            blogListViewModel.CurrentCategory = "PHP";
            return View(blogListViewModel);
        }
    }
}