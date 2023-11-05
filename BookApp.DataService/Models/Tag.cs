namespace BookApp.DataService.Models;

public class Tag
{
    public int TagId { get; set; }

    public ICollection<Book> Books { get; set; } = default!;
}