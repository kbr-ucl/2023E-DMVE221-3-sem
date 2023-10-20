using DomainCentricDemo.Domain;

namespace DomainCentricDemo.Application;

public interface IAuthorRepository
{
    void Create(Author book);
    void Commit();
    Author Load(int id);
    void Save(Author book);
    void Delete(Author book);
}