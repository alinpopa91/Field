using System;
using System.Collections.Generic;

namespace Field.DAL.Context
{
    public partial class PaymentList
    {
        public int Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public decimal? Amount { get; set; }
        public string PaymentAgent { get; set; }
    }
}
