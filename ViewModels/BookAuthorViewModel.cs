using BookStore.Models;

namespace BookStore.ViewModels
{
	public class BookAuthorViewModel
	{
        public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int AuthorId { get; set; }
		public List<AuthorViewModel> Authors { get; set; }
        public BookAuthorViewModel()
        {
        }
    }
}
