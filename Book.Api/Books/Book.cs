using System.ComponentModel.DataAnnotations;

namespace BookApi.Books;

public class Book
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Genre { get; set; }
    [Required]
    public string Author { get; set; }
}

public class BookDto
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Genre { get; set; }
    [Required]
    public string Author { get; set; }
}

public class CreateBookDto
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Genre { get; set; }
    [Required]
    public string Author { get; set; }
}

public static class BookMappingExtensions
{
    public static BookDto ToBookDto(this Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Genre = book.Genre,
            Author = book.Author
        };
    }
}