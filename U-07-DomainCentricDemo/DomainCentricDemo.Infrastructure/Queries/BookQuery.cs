using DomainCentricDemo.Application;
using DomainCentricDemo.Application.Dto;

namespace DomainCentricDemo.Infrastructure.Queries;

public class BookQuery : IBookQuery
{
    BookDto IBookQuery.Get()
    {
        return new BookDto();
        //throw new NotImplementedException();
    }

    List<BookDto> IBookQuery.GetAll()
    {
        var books = new List<BookDto>();
        books.Add(new BookDto
        {
            Id = 1,
            Title = "My Book",
            Author = "Bob",
            Description = "The Web Book"
        });
        books.Add(new BookDto
        {
            Id = 2,
            Title = "My Book nr 2",
            Author = "John",
            Description = "The Best Web Book"
        });

        return books;
        //throw new NotImplementedException();
    }
}