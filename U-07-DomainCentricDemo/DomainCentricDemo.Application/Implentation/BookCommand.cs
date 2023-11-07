using System.Transactions;
using DomainCentricDemo.Application.Dto;
using DomainCentricDemo.Domain;

namespace DomainCentricDemo.Application.Implentation;

public class BookCommand : IBookCommand
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _uow;

    public BookCommand(IBookRepository bookRepository, IUnitOfWork uow)
    {
        _bookRepository = bookRepository;
        _uow = uow;
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
    }

    void IBookCommand.Delete(int id)
    {
        // Load
        var book = _bookRepository.Load(id);

        // Execute
        // book.IsDeletable();

        // Delete
        _bookRepository.Delete(book);
    }

    void IBookCommand.Update(BookUpdateRequestDto updateRequest)
    {
        // Transaction scope
        _uow.BeginTransaction(IsolationLevel.Serializable);
        try
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
            _uow.Commit();
        }
        catch
        {
            _uow.Rollback();
            throw;
        }
    }
}