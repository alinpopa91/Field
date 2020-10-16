using Field.DAL.Context;
using Field.DAL.Persistence.Abstract;
using Field.DAL.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Field.DAL.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FieldContext _dbContext;

        public UnitOfWork()
        {
            _dbContext = new FieldContext();
        }

        public IRepository<TEntity> CreateGenericRepository<TEntity>()
            where TEntity : class
        {
            return new Repository<TEntity>(_dbContext);
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _cheapPaymentGateway?.Dispose();
            _cheapPaymentGateway = null;

            _expensivePaymentGateway?.Dispose();
            _expensivePaymentGateway = null;

            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        private ICheapPaymentGateway _cheapPaymentGateway;
        public ICheapPaymentGateway CheapPaymentGateway
        {
            get { return _cheapPaymentGateway ?? (_cheapPaymentGateway = new CheapPaymentGateway(_dbContext)); }
        }

        private IExpensivePaymentGateway _expensivePaymentGateway;
        public IExpensivePaymentGateway ExpensivePaymentGateway
        {
            get { return _expensivePaymentGateway ?? (_expensivePaymentGateway = new ExpensivePaymentGateway(_dbContext)); }
        }

        private IErrorMapperRepository _errorMapperRepository;
        public IErrorMapperRepository ErrorMapperRepository
        {
            get { return _errorMapperRepository ?? (_errorMapperRepository = new ErrorMapperRepository(_dbContext)); }
        }

    }
}
