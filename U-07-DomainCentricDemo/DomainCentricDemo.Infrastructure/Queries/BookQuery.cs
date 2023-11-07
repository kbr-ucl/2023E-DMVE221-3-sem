using DomainCentricDemo.Application;
using DomainCentricDemo.Application.Dto;
using DomainCentricDemo.Application.Mapper;
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
        var book = _db.Books.AsNoTracking().Include(a => a.Authors).FirstOrDefault(a => a.Id == id);
        if (book == null) return null;

        return BookMapper.MapToDto(book);
    }

    List<BookDto> IBookQuery.GetAll()
    {
        var books = new List<BookDto>();
        foreach (var book in _db.Books.Include(a => a.Authors))
            books.Add(BookMapper.MapToDto(book));


        return books;
    }
}