using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidsBooks.Models
{
    public class InitialRepository : IInitialRepository
    {
        private BookDbContext context;

        public InitialRepository(BookDbContext Context)
        {
            this.context = Context;
        }

        List<Category> IInitialRepository.GetAllCategories()
        {
            return context.Categories.ToList(); ;
        }

        Category IInitialRepository.GetCategory(int Id)
        {
            return context.Categories.SingleOrDefault(c => c.Id == Id);
        }
    }
}
