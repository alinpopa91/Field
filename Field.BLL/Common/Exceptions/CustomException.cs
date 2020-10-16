using Field.DAL.Context;
using Field.DAL.Persistence.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Field.BLL.Common.Exceptions
{
    public class CustomException : Exception
    {
        public string ShortText { get; set; }

        public const int DefaultErrorCode = 1;

        public CustomException(string text)
        {
            ShortText = text;

        }

    }
}
