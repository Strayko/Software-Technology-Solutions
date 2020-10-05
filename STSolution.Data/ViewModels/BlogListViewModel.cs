using System.Collections.Generic;

namespace ST.ViewModels
{
    public class BlogListViewModel
    {
        public IEnumerable<Blog> Blogs { get; set; }
        public string CurrentCategory { get; set; }
    }
}