using Field.DAL.Context;
using Field.DAL.Persistence.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Field.DAL.Persistence.Repositories
{
    public class CheapPaymentGateway : Repository<PaymentList>, ICheapPaymentGateway
    {
        public const string AgentName = "Cheap";

        public CheapPaymentGateway(DbContext dbContext) : base(dbContext) { }

        public int AddPayment(PaymentList model)
        {
            model.PaymentAgent = "Cheap";
            Add(model);
            //Context.Set<PaymentList>().Add(model);
            return 1;
        }
    }
}
