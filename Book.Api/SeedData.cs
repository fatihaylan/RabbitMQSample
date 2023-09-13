using BookApi.Books;

namespace BookApi;

public static class SeedData
{
    public static void Initialize(AppDbContext db)
    {
        using (db)
        {
            var books = new List<Book>
            {
                new Book { Title = "The Lord of the Rings", Genre = "High fantasy", Author = "J.R.R. Tolkien" },
                new Book { Title = "The Hobbit", Genre = "Novel", Author = "J.R.R. Tolkien" },
                new Book { Title = "Clean Code: A Handbook of Agile Software Craftsmanship", Genre = "Programming", Author = "Robert C. Martin" }
            };

            db.Books.AddRange(books);
            db.SaveChanges();
        }
    }
}