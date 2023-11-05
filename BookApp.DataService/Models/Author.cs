namespace BookApp.DataService.Models;

public class Author
{
    public int AuthorId { get; set; }

    public string Name { get; set; } = string.Empty;
    // public string WebUrl { get; set; } = string.Empty;

    public ICollection<BookAuthor> BooksLinks { get; set; } = default!;
}