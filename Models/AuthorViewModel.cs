namespace BookStore.Models
{
	public class AuthorViewModel
	{
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public AuthorViewModel()
        {
        }
        public AuthorViewModel(int Id, string FullName)
        {
            this.Id = Id;   
            this.FullName = FullName;   
        }
    }
}
