using DomainCentricDemo.Web.Infrastructure.Dto;

namespace DomainCentricDemo.Web.Infrastructure.Implementation
{
    public class BookApiProxy : IBookApiProxy
    {
        void IBookApiProxy.Create(BookDto book)
        {
            throw new NotImplementedException();
        }

        void IBookApiProxy.Delete(int id)
        {
            throw new NotImplementedException();
        }

        BookDto? IBookApiProxy.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<BookDto> IBookApiProxy.GetAll()
        {
            throw new NotImplementedException();
        }

        void IBookApiProxy.Update(BookDto book)
        {
            throw new NotImplementedException();
        }
    }
}
