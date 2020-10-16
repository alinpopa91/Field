using Field.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Field.DAL.Persistence.Abstract
{
    public interface IErrorMapperRepository : IRepository<ErrorMapping>, IDisposable
    {
        IRepository<TEntity> CreateGenericRepository<TEntity>() where TEntity : class;


    }
}
