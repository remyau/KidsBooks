using KidsBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidsBooks.View_Models
{
    public class BooksViewModel
    {
        public Book book { get; set; }
        public IEnumerable<Category> category { get; set; }
    }
}
 
