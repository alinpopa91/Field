using Field.BLL.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Field.BLL.Core.Logging
{
    public interface ILoggerFactory
    {
        ILogger<TEntity> CreateLogger<TEntity>(ISettings settings) where TEntity : class, new();
    }
}
