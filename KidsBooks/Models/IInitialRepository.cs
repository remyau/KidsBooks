using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidsBooks.Models
{
    public interface IInitialRepository
    {
        List<Category> GetAllCategories();
        Category GetCategory(int Id);
    }
}
