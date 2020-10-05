using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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

        public void Add(Blog blog)
        {
            _appDbContext.Blogs.Add(blog);
            _appDbContext.SaveChanges();
        }

        public void Update(Blog blog)
        {
            var entry = _appDbContext.Entry(blog);
            entry.State = EntityState.Modified;
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