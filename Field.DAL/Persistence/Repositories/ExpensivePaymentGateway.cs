using Field.DAL.Context;
using Field.DAL.Persistence.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Field.DAL.Persistence.Repositories
{
    public class ExpensivePaymentGateway : Repository<PaymentList>, IExpensivePaymentGateway
    {
        public const string AgentName = "Expensive";

        public ExpensivePaymentGateway(DbContext dbContext) : base(dbContext) { }

        public int AddExpensivePayment(PaymentList model)
        {
            model.PaymentAgent = "Expensive";
            Add(model);
            //Context.Set<PaymentList>().Add(model);
            return 1;
        }
    }
}
