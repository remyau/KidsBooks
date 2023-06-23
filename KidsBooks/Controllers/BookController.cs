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
        public async Task<IActionResult> Index()
        {
            var bookModel = await _iBooksRepository.GetAllBooksAsync();
            return View(bookModel);
        }

        [HttpGet]
        [Route("Book/Create")]
        public async Task<ViewResult> Create()
        {
            var categories = await _iInitialRepository.GetAllCategoriesAsync();
            var bookViewModel = new BooksViewModel
            {
                category = categories
            };
            return View(bookViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BooksViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                Book _book = await _iBooksRepository.AddBookAsync(bookViewModel.book);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<ViewResult> Edit(int Id)
        {
            Book _book = await _iBooksRepository.GetBookAsync(Id);
            var _category = await _iInitialRepository.GetAllCategoriesAsync();
            var bookViewModel = new BooksViewModel
            {
                book=_book,
                category=_category
            };
            return View(bookViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BooksViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                Book book = await _iBooksRepository.GetBookAsync(bookViewModel.book.Id);
                book.Name = bookViewModel.book.Name;
                book.Author = bookViewModel.book.Author;
                book.CategoryId = bookViewModel.book.CategoryId;
                book.Lang = bookViewModel.book.Lang;
                book.Publisher = bookViewModel.book.Publisher;
                book.Date_Published = bookViewModel.book.Date_Published;

                await _iBooksRepository.UpdateAsync(book);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            Book book = await _iBooksRepository.GetBookAsync(Id);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Book bookDelete)
        {
            if (bookDelete != null)
            {
                await _iBooksRepository.DeleteBookAsync(bookDelete.Id);
            }
            return RedirectToAction("Index");
        }

        public async Task<ViewResult> ViewBooks(int Id)
        {
            Book book = await _iBooksRepository.GetBookAsync(Id);
            var category = await _iInitialRepository.GetAllCategoriesAsync();
            Category cat1 = await _iInitialRepository.GetCategoryAsync(book.CategoryId);

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
