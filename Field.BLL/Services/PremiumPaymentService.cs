using Field.BLL.Common.Exceptions;
using Field.BLL.Models;
using Field.DAL.Context;
using Field.DAL.Persistence.Abstract;
using Field.DAL.Persistence.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Field.BLL.Services
{
    public class PremiumPaymentService : IProcessPaymentService
    {

        private readonly IUnitOfWorkFactory _factory;
        private IUnitOfWork _unitOfWork;

        public PremiumPaymentService() : this(new UnitOfWorkFactory())
        {

        }

        public PremiumPaymentService(IUnitOfWorkFactory factory)
        {
            _factory = factory;
            _unitOfWork = factory.Create();
        }
        public ProcessPaymentResponse ProcessPayment(ProcessPaymentRequest request)
        {
            var toReturn = new ProcessPaymentResponse
            {
                Success = true
            };
            try
            {

                var newItem = new PaymentList
                {
                    CreditCardNumber = request.CreditCardNumber,
                    CardHolder = request.CardHolder,
                    ExpirationDate = request.ExpirationDate,
                    Amount = request.Amount,
                    SecurityCode = request.SecurityCode,
                    PaymentAgent = "Premium"
                };

                _unitOfWork.ExpensivePaymentGateway.AddExpensivePayment(newItem);
                _unitOfWork.Commit();

            }
            catch (Exception cex)
            {
                toReturn.Success = false;
                toReturn.Errors = new List<string>
                {
                    cex.Message
                };

                toReturn.Message = cex.StackTrace;
            }

            return toReturn;

        }
    }
}
