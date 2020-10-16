using Field.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Field.BLL.Services
{
    public interface IProcessPaymentService
    {
        ProcessPaymentResponse ProcessPayment(ProcessPaymentRequest request);
    }
}
