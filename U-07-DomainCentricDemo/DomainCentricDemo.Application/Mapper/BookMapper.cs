using DomainCentricDemo.Application.Dto;
using DomainCentricDemo.Domain;

namespace DomainCentricDemo.Application.Mapper;

public class BookMapper
{
    public static Book MapToDomain(BookCreateCommandRequestDto dto, IAuthorRepository authorRepository)
    {
        return new Book { Title = dto.Title, Description = dto.Description, Authors = dto.AuthorIds.Select(authorRepository.Load).ToList() };
    }

    public static BookDto MapToDto(Book book)
    {
        return new BookDto{Id = book.Id, Title = book.Title, Description = book.Description, Authors = book.Authors.Select(AuthorMapper.MapToDto).ToList()};
    }
}

public class AuthorMapper
{
    public static AuthorDto MapToDto(Author author)
    {
        return new AuthorDto{Id = author.Id, Description = author.Description, Title = author.Title, Books = author.Books.Select(BookMapper.MapToDto).ToList()};
    }
}