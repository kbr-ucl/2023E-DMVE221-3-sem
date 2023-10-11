using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainCentricDemo.Domain;

namespace DomainCentricDemo.Application
{
    public interface IBookRepository
    {
        void Create(Book book);
        void Commit();
    }
}
