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
    void IBookCommand.Create(BookCreateRequestDto createRequest)
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

    void IBookCommand.Delete(int id)
    {
        // Load
        var book = _bookRepository.Load(id);

        // Execute
        // book.IsDeletable();

        // Delete
        _bookRepository.Delete(book);
        _bookRepository.Commit();
    }

    void IBookCommand.Update(BookUpdateRequestDto updateRequest)
    {
        // Load
        var book = _bookRepository.Load(updateRequest.Id);

        // Execute
        book.Title = updateRequest.Title;
        book.Author = updateRequest.Author;
        book.Description = updateRequest.Description;
        book.RowVersion = updateRequest.RowVersion;

        // Persist
        _bookRepository.Save(book);
        _bookRepository.Commit();
    }
}