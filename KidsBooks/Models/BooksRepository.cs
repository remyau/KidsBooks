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

        public async Task<Book> AddBookAsync(Book book)
        {
            book.Date_Added = DateTime.Now;
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> GetBookAsync(int Id)
        {
            return await Task.Run(() =>
            _context.Books.SingleOrDefault(c=> c.Id==Id));
        }

        public async Task<Book> UpdateAsync(Book bookChanges)
        {
            var book = _context.Books.Attach(bookChanges);
            book.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return bookChanges;
        }

        public async Task<Book> DeleteBookAsync(int Id)
        {
            Book book = _context.Books.Find(Id);
            if(book!=null)
            {
                await Task.Run(()=> _context.Books.Remove(book));
                await _context.SaveChangesAsync();
            }

            return book;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await Task.Run(()=> _context.Books.Where(x=> x.CategoryId!=9).ToList());
        }
        
    }
}
