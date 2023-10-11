using DomainCentricDemo.Application;
using DomainCentricDemo.Application.Dto;
using Microsoft.EntityFrameworkCore;

namespace DomainCentricDemo.Infrastructure.Queries;

public class BookQuery : IBookQuery
{
    private readonly BookContext _db;

    public BookQuery(BookContext db)
    {
        _db = db;
    }

    BookDto? IBookQuery.Get(int id)
    {
        var book = _db.Books.AsNoTracking().FirstOrDefault(a => a.Id == id);
        if (book == null) return null;


        return new BookDto
        {
            Author = book.Author,
            Description = book.Description,
            Id = book.Id,
            Title = book.Title
        };
    }

    List<BookDto> IBookQuery.GetAll()
    {
        var books = new List<BookDto>();
        foreach (var book in _db.Books)
            books.Add(new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description
            });


        return books;
    }
}