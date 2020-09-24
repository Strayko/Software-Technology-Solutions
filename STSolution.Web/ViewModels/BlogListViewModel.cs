using System.Collections.Generic;

namespace ST.ViewModels
{
    public class BlogListViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }
        public string CurrentCategory { get; set; }
    }
}