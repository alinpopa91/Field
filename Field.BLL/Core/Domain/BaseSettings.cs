using Field.BLL.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Field.BLL.Core.Domain
{
    public class BaseSettings : ISettings
    {
        public bool Active { get; set; }
        public bool Log { get; set; }
        public string LogType { get; set; }
        public bool RabbitXmlLog { get; set; }
    }
}
