using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ST
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _appDbContext;

        public BlogRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Blog> AllBlogs
        {
            get
            {
                return _appDbContext.Blogs.Include(c => c.Category);
            }
        }

        public Blog GetBlogById(int blogId)
        {
            return _appDbContext.Blogs.FirstOrDefault(b => b.BlogId == blogId);
        }
    }
}