using System.Transactions;
using DomainCentricDemo.Application;
using Microsoft.EntityFrameworkCore.Storage;

namespace DomainCentricDemo.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly BookContext _db;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(BookContext db)
    {
        _db = db;
    }

    void IUnitOfWork.BeginTransaction(IsolationLevel isolationLevel)
    {
        if (_db.Database.CurrentTransaction != null) return;
        _transaction = _db.Database.BeginTransaction();
    }

    void IUnitOfWork.Commit()
    {
        _transaction?.Commit();
        _transaction?.Dispose();
    }

    void IUnitOfWork.Rollback()
    {
        _transaction?.Rollback();
        _transaction?.Dispose();
    }
}