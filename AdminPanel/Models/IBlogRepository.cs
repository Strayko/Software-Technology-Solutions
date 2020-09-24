using System.Collections.Generic;

namespace AdminPanel.Models
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> AllBlogs { get; }
        Blog GetBlogById(int blogId);
    }
}