namespace BookStore.Models.Repository
{
	public class BookRepository : IBookStoreRepository<BookViewModel>
	{
		public List<BookViewModel> Books = new List<BookViewModel>() 
		{
			new BookViewModel { Id = 1, Title = "Alfa Bio", Description = "Alfa BIO"},
			new BookViewModel { Id = 2, Title = "C#", Description = "C# Book"},
			new BookViewModel { Id = 3, Title = "C++", Description = "C++ Book"}
		};

		public BookRepository() { }
		public void Add(BookViewModel Book)
		{
			Book.Id = Books.Max(x => x.Id) + 1;
			Books.Add(Book);
		}

		public void Delete(int id)
		{
			var Book = Find(id);
			if (Book != null) 
				Books.Remove(Book);
		}

		public BookViewModel Find(int id)
		{
			return Books.SingleOrDefault(x => x.Id == id);
		}

		public IList<BookViewModel> List()
		{
			return Books;
		}

		public void Update(BookViewModel UpdateBook)
		{
			var Book = Find(UpdateBook.Id);
			if (Book != null)
			{
				Book.Title = UpdateBook.Title;
				Book.Description = UpdateBook.Description;
				Book.Author.FullName = UpdateBook.Author.FullName;
			}
		}
	}
}
