using DomainCentricDemo.Domain;

namespace DomainCentricDemo.Application;

public interface IBookRepository
{
    void Create(Book book);
    Book Load(int id);
    void Save(Book book);
    void Delete(Book book);
}