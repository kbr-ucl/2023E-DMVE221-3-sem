using System.Transactions;

namespace DomainCentricDemo.Application;

public interface IUnitOfWork
{
    void Commit();
    void Rollback();
    void BeginTransaction(IsolationLevel isolationLevel);
}


