using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Models.Repository;
using BookStore.ViewModels;

namespace BookStore.Controllers
{
	public class BookController : Controller
	{
		public readonly IBookStoreRepository<BookViewModel> bookRepository;
		public readonly IBookStoreRepository<AuthorViewModel> authorRepository;
        public BookController(IBookStoreRepository<BookViewModel> bookRepository,
			IBookStoreRepository<AuthorViewModel> authorRepository)
        {
            this.bookRepository = bookRepository;
			this.authorRepository = authorRepository;
		}
        public IActionResult Index()
		{
			return View(bookRepository.List());
		}
		public IActionResult Create() 
		{
			var model = new BookAuthorViewModel
			{
				Authors = authorRepository.List().ToList()
			};
			return View(model);
		}

		[HttpPost]
		public IActionResult Create(BookAuthorViewModel model)
		{
			
			var newId = bookRepository.List().Max(x => x.Id) + 1;
			var book = new BookViewModel()
			{
				Id = newId,
				Title = model.Title,
				Description = model.Description,
				Author = authorRepository.Find(model.AuthorId)
			};
			if (book.Author.Id == 0)
			{ 
				ViewBag.Massage = "Please select Author";
				var vmodel = new BookAuthorViewModel
				{
					Authors = authorRepository.List().ToList()
				};
				return View(vmodel);
			}
			bookRepository.Add(book);
			return RedirectToAction("Index");		
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{	
			var book = bookRepository.Find(id);

			var bookAuthorViewmodel = new BookAuthorViewModel()
			{
				Id = book.Id,
				Title = book.Title,
				Description = book.Description,
				AuthorId = book.Author.Id,
				Authors = authorRepository.List().ToList()
			};
			return View(bookAuthorViewmodel);
		}

		[HttpPost]
		public IActionResult Edit(BookAuthorViewModel model)
		{
			var book = bookRepository.Find(model.Id);
			if (book != null) 
			{ 
				book.Title = model.Title;
				book.Description = model.Description;
				book.Author = authorRepository.Find(model.AuthorId);
			}
			if (book.Author.Id == 0)
			{
				ViewBag.Massage = "Please select Author";
				var vmodel = new BookAuthorViewModel
				{
					Authors = authorRepository.List().ToList()
				};
				return View(vmodel);
			}
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

// ENJOY
//public IActionResult Index()
//{
//	var books = bookRepository.List();
//	foreach (var b00k in books)
//	{
//		if (b00k.Author.Id == 0)

//			var book = books.FirstOrDefault(x => x.Id == 0);
//		bookRepository.Update(book);
//	}

//	return View();
//}
