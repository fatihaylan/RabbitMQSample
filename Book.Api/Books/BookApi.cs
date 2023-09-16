using BookApi.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Keywords;
using RabbitMQ.Services;

namespace BookApi.Books;

internal static class BookApi
{
    public static RouteGroupBuilder MapBooks(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/books");

        group.MapGet("/", async (AppDbContext db) =>
        {
            return await db.Books.Select(b => b.ToBookDto()).AsNoTracking().ToListAsync();
        });

        group.MapGet("/{id}", async Task<Results<Ok<BookDto>, NotFound>> (AppDbContext db, int id) =>
        {
            return await db.Books.FindAsync(id) switch
            {
                Book book => TypedResults.Ok(book.ToBookDto()),
                _ => TypedResults.NotFound()
            };
        });

        group.MapPost("/", async Task<Created<BookDto>> (AppDbContext db, CreateBookDto newBook, IPublisher publisher) =>
        {
            var book = new Book
            {
                Title = newBook.Title,
                Genre = newBook.Genre,
                Author = newBook.Author
            };
            db.Books.Add(book);
            await db.SaveChangesAsync();
            
            publisher.Publish(book.ToBookDto().GetNewBookMails(), CommonKeywords.ExchangeNames.BookExchange, CommonKeywords.QueueNames.NewBookNotifier);

            return TypedResults.Created($"/books/{book.Id}", book.ToBookDto());
        });

        return group;
    }
}
