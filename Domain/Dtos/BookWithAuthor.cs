namespace Domain.Dtos;

public class BookWithAuthor
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public int PublishedYear { get; set; }
    public string Genre { get; set; }
    public bool IsAvailable { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
}