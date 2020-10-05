using System.Collections.Generic;

namespace ST
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category {CategoryId = 1, CategoryName = "Java", Description = "Lorem ispum sit dolor amet Java"},
                new Category {CategoryId = 2, CategoryName = "ASP.NET", Description = "Lorem ispum sit dolor amet ASP.NET"},
                new Category {CategoryId = 2, CategoryName = "PHP", Description = "Lorem ispum sit dolor amet PHP"},
            };
    }
}