﻿using System.Collections.Generic;

namespace ST
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> AllBlogs { get; }
        Blog GetBlogById(int blogId);
        void Add(Blog blog);
        void Update(Blog blog);
        void Delete(int blogId);
    }
}