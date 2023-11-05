// Copyright (c) 2023 Mohammed Hamada, GitHub: M7amd7amada.
// Licensed under MIT license. See LICENSE file in the project root for license information.

namespace BookApp.DataService.Models;

public class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime PublishedOn { get; set; }
    public string Publisher { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public bool SoftDeleted { get; set; } = false;

    // Relationships

    public ICollection<Tag>? Tags { get; set; }
    public ICollection<BookAuthor> AuthorsLink { get; set; } = default!;
    public ICollection<Review>? Reviews { get; set; }
    public PriceOffer? Promotion { get; set; }

}
