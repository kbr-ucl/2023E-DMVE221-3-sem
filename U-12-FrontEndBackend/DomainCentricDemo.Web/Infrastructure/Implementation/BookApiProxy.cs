using DomainCentricDemo.Web.Infrastructure.Dto;

namespace DomainCentricDemo.Web.Infrastructure.Implementation;

public class BookApiProxy : IBookApiProxy
{
    async Task IBookApiProxy.CreateAsync(BookDto book)
    {
        throw new NotImplementedException();
    }

    async Task IBookApiProxy.DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    async Task<IEnumerable<BookDto>?> IBookApiProxy.GetAllAsync()
    {
        throw new NotImplementedException();
    }

    async Task<BookDto?> IBookApiProxy.GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    async Task IBookApiProxy.UpdateAsync(BookDto book)
    {
        throw new NotImplementedException();
    }
}