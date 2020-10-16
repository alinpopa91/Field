using Field.BLL.Core.Configuration;
using Field.BLL.Core.Domain;
using Field.DAL.Persistence.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Field.BLL.Core.Logging
{
    public class LoggerFactory : ILoggerFactory
    {
        private readonly IUnitOfWorkFactory _factory;

        public LoggerFactory(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }
        public ILogger<TEntity> CreateLogger<TEntity>(ISettings settings) where TEntity : class, new()
        {
            var logSettings = settings as BaseSettings;
            return new SqlLogger<TEntity>(_factory, settings);
        }
    }
}
