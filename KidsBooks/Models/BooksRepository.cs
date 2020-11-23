using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidsBooks.Models
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookDbContext _context;

        public BooksRepository(BookDbContext Context)
        {
            this._context = Context;
        }

        public Book AddBook(Book book)
        {
            book.Date_Added = DateTime.Now;
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public Book GetBook(int Id)
        {
            return _context.Books.SingleOrDefault(c=> c.Id==Id);
        }

        public Book Update(Book bookChanges)
        {
            var book = _context.Books.Attach(bookChanges);
            book.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return bookChanges;
        }

        Book IBooksRepository.DeleteBook(int Id)
        {
            Book book = _context.Books.Find(Id);
            if(book!=null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }

            return book;
        }

        IEnumerable<Book> IBooksRepository.GetAllBooks()
        {
            return _context.Books;
        }
        
    }
}
