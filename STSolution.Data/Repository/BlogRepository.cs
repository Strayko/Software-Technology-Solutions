using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ST
{
    public class BlogRepository : IBlogRepository
    {
        private readonly IAppDbContext _appDbContext;

        public BlogRepository(IAppDbContext appDbContext)
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

        public void Add(Blog blog)
        {
            _appDbContext.Blogs.Add(blog);
            _appDbContext.SaveChanges();
        }

        public void Update(Blog blog)
        {
            _appDbContext.SetModified(blog);
            _appDbContext.SaveChanges();
        }

        public void Delete(int blogId)
        {
            var blog = _appDbContext.Blogs.Find(blogId);
            _appDbContext.Blogs.Remove(blog);
            _appDbContext.SaveChanges();
        }
    }
}