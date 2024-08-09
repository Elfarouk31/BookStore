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
			return View(authorRepository.List());
		}

		// Get: Author/Create
		public IActionResult Create()
		{
			return View();
		}

		// Post:
		[HttpPost]
		public IActionResult Create(AuthorViewModel Author)
		{
			authorRepository.Add(Author);
			return RedirectToAction("Index");
		}
	}
}
