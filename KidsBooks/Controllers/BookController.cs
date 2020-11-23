using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KidsBooks.Models;
using KidsBooks.View_Models;
using Microsoft.AspNetCore.Mvc;

namespace KidsBooks.Controllers
{
    public class BookController : Controller
    {
        private IBooksRepository _iBooksRepository;
        private IInitialRepository _iInitialRepository;

        public BookController(IBooksRepository ibooksRepository,IInitialRepository iinitialRepository)
        {
            _iBooksRepository = ibooksRepository;
            _iInitialRepository = iinitialRepository;
        }

        [Route("Book")]        
        public IActionResult Index()
        {
            var bookModel = _iBooksRepository.GetAllBooks();
            return View(bookModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            var categories = _iInitialRepository.GetAllCategories();
            var bookViewModel = new BooksViewModel
            {
                category = categories
            };
            return View(bookViewModel);
        }

        [HttpPost]
        public IActionResult Create(BooksViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                Book _book = _iBooksRepository.AddBook(bookViewModel.book);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ViewResult Edit(int Id)
        {
            Book _book = _iBooksRepository.GetBook(Id);
            var _category = _iInitialRepository.GetAllCategories();
            var bookViewModel = new BooksViewModel
            {
                book=_book,
                category=_category
            };
            return View(bookViewModel);
        }

        [HttpPost]
        public IActionResult Edit(BooksViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                Book book = _iBooksRepository.GetBook(bookViewModel.book.Id);
                book.Name = bookViewModel.book.Name;
                book.Author = bookViewModel.book.Author;
                book.CategoryId = bookViewModel.book.CategoryId;
                book.Lang = bookViewModel.book.Lang;
                book.Publisher = bookViewModel.book.Publisher;
                book.Date_Published = bookViewModel.book.Date_Published;

                _iBooksRepository.Update(book);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Book book = _iBooksRepository.GetBook(Id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(Book bookDelete)
        {
            if (bookDelete != null)
            {
                _iBooksRepository.DeleteBook(bookDelete.Id);
            }
            return RedirectToAction("Index");
        }

        public ViewResult ViewBooks(int Id)
        {
            Book book = _iBooksRepository.GetBook(Id);
            var category = _iInitialRepository.GetAllCategories();
            Category cat1 = _iInitialRepository.GetCategory(book.CategoryId);

            BooksShowViewModel bookViewModel = new BooksShowViewModel
            {
                book = book,
                category = category,
                CategoryName=cat1.Name
            };
            return View(bookViewModel);
        }
    }
}
