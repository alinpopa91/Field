using System;
using System.Collections.Generic;
using System.Text;

namespace Field.BLL.Models
{
    public class ProcessPaymentResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; }
    }
}
