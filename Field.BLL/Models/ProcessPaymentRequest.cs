using Field.BLL.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Field.BLL.Models
{
    public class ProcessPaymentRequest
    {
        [Required(ErrorMessage = "CreditCardNumber is empty")]
        [MinLength(16, ErrorMessage = "Length should be 16")]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Card holder should not be empty")]
        public string CardHolder { get; set; }

        [CurrentDateAttribute(ErrorMessage = "Expirationdate can not be in the past")]
        public DateTime ExpirationDate { get; set; }

        [PINValidationAttribute()]
        public string SecurityCode { get; set; }

        [Required]
        [AmountValidatorAttribute(ErrorMessage = "Amount should be positive")]
        public decimal Amount { get; set; }
    }
}
