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

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await Task.Run(()=> context.Categories.ToList()) ;
        }

        public async Task<Category> GetCategoryAsync(int Id)
        {
            return await Task.Run(()=> context.Categories.SingleOrDefault(c => c.Id == Id));
        }
    }
}
