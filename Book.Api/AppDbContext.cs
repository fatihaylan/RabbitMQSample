﻿using BookApi.Books;
using Microsoft.EntityFrameworkCore;

namespace BookApi;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Book> Books => Set<Book>();
}