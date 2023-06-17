namespace NLibrary.Persistence.Entities;

public class Book
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
}
