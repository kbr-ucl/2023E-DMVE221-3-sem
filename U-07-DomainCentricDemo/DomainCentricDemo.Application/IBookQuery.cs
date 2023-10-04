using DomainCentricDemo.Application.Dto;

namespace DomainCentricDemo.Application;

public interface IBookQuery
{
    BookDto Get();
    List<BookDto> GetAll();
}