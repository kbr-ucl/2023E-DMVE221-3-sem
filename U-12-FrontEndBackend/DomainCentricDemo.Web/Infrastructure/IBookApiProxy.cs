using DomainCentricDemo.Web.Infrastructure.Dto;

namespace DomainCentricDemo.Web.Infrastructure
{
    public interface IBookApiProxy
    {
        void Create(BookDto book);
        BookDto? Get(int id);
        void Delete(int id);
        void Update(BookDto book);
        IEnumerable<BookDto> GetAll();
    }
}
