using Field.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Field.DAL.Persistence.Abstract
{
    public interface ICheapPaymentGateway : IRepository<PaymentList>, IDisposable
    {
        int AddPayment(PaymentList model);
    }
}
