using System;
using System.Collections.Generic;
using System.Text;

namespace Field.BLL.Core.Configuration
{
    public interface ISettings
    {
        bool Active { get; set; }
        bool Log { get; set; }
        string LogType { get; set; }//sql or rabbit
    }
}
