using System;
using System.Collections.Generic;

namespace Field.DAL.Context
{
    public partial class ErrorMapping
    {
        public int Id { get; set; }
        public int ErrorId { get; set; }
        public int? Type { get; set; }
        public string Description { get; set; }
    }
}
