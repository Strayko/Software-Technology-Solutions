using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using ST;

namespace STSolution.Tests
{
    public class DbSetContextMock
    {
        public DbSet<T> GetQuaryableMockDbSet<T>(Mock<DbSet<T>> mockSet, IQueryable<T> data) where T : class
        {
            mockSet.As<IQueryable<T>>().Setup(b => b.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(b => b.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(b => b.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(b => b.GetEnumerator()).Returns(data.GetEnumerator());
            return mockSet.Object;
        }

        public IQueryable<Blog> ListBlogsQueryable()
        {       
            var data = new List<Blog>
            {
                new Blog
                {
                    BlogId = 1, Name = "value", ShortDescription = "value", LongDescription = "value",
                    ImageUrl = "value",
                    ImageThumbnailUrl = "value", Category = null, CategoryId = 2, Notes = "value"
                },
                new Blog
                {
                    BlogId = 2, Name = "value", ShortDescription = "value", LongDescription = "value",
                    ImageUrl = "value",
                    ImageThumbnailUrl = "value", Category = null, CategoryId = 3, Notes = "value"
                },
                new Blog
                {
                    BlogId = 3, Name = "value", ShortDescription = "value", LongDescription = "value",
                    ImageUrl = "value",
                    ImageThumbnailUrl = "value", Category = null, CategoryId = 4, Notes = "value"
                }
            }.AsQueryable();
            return data;
        }
    }
}