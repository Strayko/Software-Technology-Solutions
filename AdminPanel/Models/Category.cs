using System.Collections.Generic;

namespace AdminPanel.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}