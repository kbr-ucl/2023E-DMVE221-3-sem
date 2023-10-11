using DomainCentricDemo.Application.Dto;

namespace DomainCentricDemo.Application
{
    public interface IBookCommand
    {
        void Create(BookCommandRequestDto createRequest);
    }
}
