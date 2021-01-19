using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidsBooks.Models
{
    public interface IInitialRepository
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryAsync(int Id);
    }
}
