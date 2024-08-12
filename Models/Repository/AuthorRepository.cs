namespace BookStore.Models.Repository
{
	public class AuthorRepository : IBookStoreRepository<AuthorViewModel>
	{
		List<AuthorViewModel> authors;
		public AuthorRepository() 
		{
			authors = new List<AuthorViewModel>()
		{
				new AuthorViewModel { Id = 0, FullName = "..Please Select Autho.." },
				new AuthorViewModel { Id = 1, FullName = "Alfarouk"},
				new AuthorViewModel { Id = 2, FullName = "Mohamed"},
				new AuthorViewModel { Id = 3, FullName = "Mahmoud"}
		};
		}
		public void Add(AuthorViewModel Author)
		{
			Author.Id = authors.Max(x => x.Id) + 1;
			authors.Add(Author);
		}

		public void Delete(int id)
		{
			authors.Remove(Find(id));
		}

		public AuthorViewModel Find(int id)
		{
			return authors.SingleOrDefault(x => x.Id == id);
		}

		public IList<AuthorViewModel> List()
		{
			return authors;
		}

		public void Update(AuthorViewModel AuthorUpdate)
		{
			var author = Find(AuthorUpdate.Id);
			if (author != null)
			{
				author.FullName = AuthorUpdate.FullName;
			}
		}
	}
}