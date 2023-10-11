using DomainCentricDemo.Application.Dto;
using DomainCentricDemo.Domain;

namespace DomainCentricDemo.Application.Implentation;

public class BookCommand : IBookCommand
{
    private readonly IBookRepository _bookRepository;
    public BookCommand(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    void IBookCommand.Create(BookCommandRequestDto createRequest)
    {
        // Create Domain object
        var book = new Book
        {
            Author = createRequest.Author,
            Description = createRequest.Description,
            Title = createRequest.Title
        };

        // Persist Domain object
        _bookRepository.Create(book);
        _bookRepository.Commit();
    }
}