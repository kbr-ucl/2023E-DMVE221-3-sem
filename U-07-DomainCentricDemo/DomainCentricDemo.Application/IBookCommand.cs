using DomainCentricDemo.Application.Dto;

namespace DomainCentricDemo.Application
{
    public interface IBookCommand
    {
        void Create(BookCommandRequestDto createRequest);
        void Update(BookUpdateRequestDto updateRequest);
        void Delete(int id);
    }
}
