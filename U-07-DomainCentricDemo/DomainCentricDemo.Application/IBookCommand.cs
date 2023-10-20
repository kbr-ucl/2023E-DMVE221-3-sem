using DomainCentricDemo.Application.Dto;

namespace DomainCentricDemo.Application
{
    public interface IBookCommand
    {
        void Create(BookCreateRequestDto createRequest);
        void Update(BookUpdateRequestDto updateRequest);
        void Delete(int id);
    }
}
