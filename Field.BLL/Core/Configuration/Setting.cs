using System;
using System.Collections.Generic;
using System.Text;

namespace Field.BLL.Core.Configuration
{
    public class Setting
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
