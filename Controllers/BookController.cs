using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Models.Repository;

namespace BookStore.Controllers
{
	public class BookController : Controller
	{
		public readonly IBookStoreRepository<BookViewModel> bookRepository;
        public BookController(IBookStoreRepository<BookViewModel> bookRepository)
        {
            this.bookRepository = bookRepository;
		}
        public IActionResult Index()
		{
			return View(bookRepository.List());
		}
		public IActionResult Create() 
		{
			return View(); 
		}

		[HttpPost]
		public IActionResult Create(BookViewModel book)
		{
			bookRepository.Add(book);
			return RedirectToAction("Index");	
		}
		public IActionResult Edit()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			return View(bookRepository.Find(id));	
		}	

		[HttpPost]
		public IActionResult Edit(BookViewModel book)
		{
			bookRepository.Update(book);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Delete(int id)
		{
			bookRepository.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
