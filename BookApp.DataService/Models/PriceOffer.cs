namespace BookApp.DataService.Models;

public class PriceOffer
{
    public int PriceOfferId { get; set; }
    public decimal NewPrice { get; set; }
    public string PromotionalText { get; set; } = string.Empty;

    // Relationships
    public int BookId { get; set; }
}