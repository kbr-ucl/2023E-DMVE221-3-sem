using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainCentricDemo.Application;
using DomainCentricDemo.Domain;

namespace DomainCentricDemo.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _db;
        public BookRepository(BookContext db)
        {
            _db = db;
        }

        void IBookRepository.Commit()
        {
            _db.SaveChanges();
        }

        void IBookRepository.Create(Book book)
        {
            _db.Books.Add(book);
        }
    }
}
