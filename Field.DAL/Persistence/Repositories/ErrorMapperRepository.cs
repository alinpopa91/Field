using Field.DAL.Context;
using Field.DAL.Persistence.Abstract;
using Field.DAL.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Field.DAL.Persistence.Repositories
{
    public class ErrorMapperRepository : Repository<ErrorMapping>, IErrorMapperRepository
    {
        public ErrorMapperRepository(DbContext dbContext) : base(dbContext) { }

        public IRepository<TEntity> CreateGenericRepository<TEntity>()
            where TEntity : class
        {
            return new Repository<TEntity>(Context);
        }

    }
}
