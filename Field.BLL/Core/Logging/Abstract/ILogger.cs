using System;
using System.Collections.Generic;
using System.Text;

namespace Field.BLL.Core.Logging.Abstract
{
    public interface ILogger<TEntity> where TEntity : class
    {
        //Task<int> Log(LogInfo logInfo);
        //Task<int> LogStatistics(LogStatistics logStatistics);
        //Task<int> LogError(LogError logError);

        int Log(LogInfo logInfo);
        int LogStatistics(LogStatistics logStatistics);
        int LogError(LogError logError);
    }
}
