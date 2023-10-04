using DomainCentricDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace DomainCentricDemo.Infrastructure;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
}