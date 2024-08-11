using BookStore.Models;
using BookStore.Models.Repository;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Controllers
{
	public class AuthorController : Controller
	{
		private readonly IBookStoreRepository<AuthorViewModel> authorRepository;
		public AuthorController(IBookStoreRepository<AuthorViewModel> authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        public IActionResult Index()
		{
			var authors = authorRepository.List();

            return View(authors);
		}

		// Get: Author/Create
		public IActionResult Add()
		{
			return View();
		}

		// Post:
		[HttpPost]
		public IActionResult Add(AuthorViewModel author)
		{
			authorRepository.Add(author);
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int Id)
		{
			return View(authorRepository.Find(Id));
		}

		[HttpPost]
		public IActionResult Edit(AuthorViewModel author)
		{
			authorRepository.Update(author);
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int Id)
		{
			authorRepository.Delete(Id);
			return RedirectToAction("Index");
		}

	}
}