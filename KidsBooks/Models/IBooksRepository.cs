using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidsBooks.Models
{
    public interface IBooksRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book AddBook(Book book);
        Book GetBook(int Id);
        Book DeleteBook(int Id);
        Book Update(Book bookChanges);
    }
}
