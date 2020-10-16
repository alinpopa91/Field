using Field.BLL.Common.Exceptions;
using Field.BLL.Communication;
using Field.BLL.Models;
using Field.DAL.Context;
using Field.DAL.Persistence.Abstract;
using Field.DAL.Persistence.Factories;
using Field.DAL.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Field.BLL.Services
{
    public class ProcessPaymentService : IProcessPaymentService
    {

        private readonly IUnitOfWorkFactory _factory;
        private readonly ICommunicator _communicator;
        private readonly ISettingService _settingsService;
        private readonly ILoggerFactory _loggerFactory;

        private IUnitOfWork _unitOfWork;

        //public ProcessPaymentService() : this(new UnitOfWorkFactory())
        //{

        //}

        public ProcessPaymentService(ICommunicator communicator, ISettingService settingsService, ILoggerFactory loggerFactory, IUnitOfWorkFactory factory)
        {
            _factory = factory;
            _communicator = communicator;
            _settingsService = settingsService;
            _loggerFactory = loggerFactory;
            _unitOfWork = factory.Create();
        }

        public ProcessPaymentResponse ProcessPayment(ProcessPaymentRequest request)
        {
            var toReturn = new ProcessPaymentResponse
            {
                Success = true
            };
            var result = new List<ValidationResult>();
            try
            {

                var newItem = new PaymentList
                {
                    CreditCardNumber = request.CreditCardNumber,
                    CardHolder = request.CardHolder,
                    ExpirationDate = request.ExpirationDate,
                    Amount = request.Amount,
                    SecurityCode = request.SecurityCode,
                    PaymentAgent = "Cheap"
                };
                int retry = 0;

                #region contract validation
                var validationContext = new ValidationContext(request, null, null);
                var isValid = Validator.TryValidateObject(request, validationContext, result, true);

                #endregion

                if (isValid)
                {
                    var writeResults = false;

                    if (newItem.Amount < 20)
                    {
                        writeResults = WritePayment(newItem, GatewayType.Cheap);
                        if (!writeResults)
                            throw new CustomException("Unavailable gateway");
                    }

                    if (newItem.Amount > 20 && newItem.Amount <= 500)
                    {
                        writeResults = WritePayment(newItem, GatewayType.Expensive);
                        if (!writeResults)
                            writeResults = WritePayment(newItem, GatewayType.Cheap);

                        if (!writeResults)
                            throw new CustomException("Unavailable gateway");
                    }

                    if (newItem.Amount > 500)
                    {
                        PremiumPaymentService premiumPaymentService = new PremiumPaymentService(_factory);

                        #region try 3 times
                        retry = 0;
                        while (retry++ < 3)
                        {
                            try
                            {
                                var premiumPayment = premiumPaymentService.ProcessPayment(request);
                                if (premiumPayment.Success)
                                    break;
                            }
                            catch (Exception ex)
                            {
                                if (retry == 3)
                                {
                                    writeResults = WritePayment(newItem, GatewayType.Cheap);
                                    if (!writeResults)
                                        throw new CustomException("Unavailable gateway");
                                }
                            }
                        }
                        #endregion

                    }

                }
                else
                {
                    throw new CustomException("Invalid contract");
                }
            }
            catch(CustomException cex)
            {
                toReturn.Success = false;
                toReturn.Errors = new List<string>();

                if (cex.ShortText == "Invalid contract")
                {
                    foreach (var str in result)
                    {
                        toReturn.Errors.Add(str.ErrorMessage.ToString());
                    }
                }

                toReturn.Errors.Add(cex.ShortText);
            }
            catch (Exception ex)
            {
                toReturn.Success = false;
                toReturn.Errors = new List<string>();
                toReturn.Errors.Add(ex.ToString());
            }
            return toReturn;

        }

        protected bool WritePayment(PaymentList item, GatewayType gatewayType)
        {
            try
            {
                if (gatewayType == GatewayType.Cheap)
                {
                    _unitOfWork.CheapPaymentGateway.AddPayment(item);
                    _unitOfWork.Commit();
                }

                if (gatewayType == GatewayType.Expensive)
                {
                    _unitOfWork.ExpensivePaymentGateway.AddExpensivePayment(item);
                    _unitOfWork.Commit();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }

    public enum GatewayType
    {
        Cheap,
        Expensive,
    }

}
