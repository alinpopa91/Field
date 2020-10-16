using Field.DAL.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Field.DAL.Persistence.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> CreateGenericRepository<TEntity>() where TEntity : class;

        IExpensivePaymentGateway ExpensivePaymentGateway { get; }
        ICheapPaymentGateway CheapPaymentGateway { get; }
        IErrorMapperRepository ErrorMapperRepository { get; }
        int Commit();
    }
}
