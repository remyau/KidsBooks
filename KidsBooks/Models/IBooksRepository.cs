using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidsBooks.Models
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> AddBookAsync(Book book);
        Task<Book> GetBookAsync(int Id);
        Task<Book> DeleteBookAsync(int Id);
        Task<Book> UpdateAsync(Book bookChanges);
    }
}
