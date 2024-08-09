namespace BookStore.Models
{
	public class BookViewModel
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AuthorViewModel Author { get; set; }
        
        public BookViewModel()
        {
        }
    }
}
