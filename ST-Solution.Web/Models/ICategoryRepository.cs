using System.Collections.Generic;

namespace ST
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}