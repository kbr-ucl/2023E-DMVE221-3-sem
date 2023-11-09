﻿using AutoMapper;
using DomainCentricDemo.Application.Dto;
using DomainCentricDemo.Domain;

namespace DomainCentricDemo.Application.Implentation;

public class BookCommand : IBookCommand
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookCommand(IBookRepository bookRepository, IAuthorRepository authorRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    void IBookCommand.Create(BookCreateCommandRequestDto createRequest)
    {
        // Create Domain object
        var book = _mapper.Map<Book>(createRequest);

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
        book.Authors = updateRequest.AuthorIds.Select(id => _authorRepository.Load(id)).ToList();
        book.Description = updateRequest.Description;

        // Persist
        _bookRepository.Save(book);
        _bookRepository.Commit();
    }
}