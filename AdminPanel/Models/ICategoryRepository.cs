using System.Collections.Generic;

namespace AdminPanel.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}