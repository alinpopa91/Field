using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Field.BLL.Utils
{
    public class PINValidationAttribute : ValidationAttribute
    {
        public PINValidationAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var stringPin = value as string;
            if (string.IsNullOrEmpty(stringPin))
                return new ValidationResult("PIN is empty");

            if (stringPin.Length != 3)
                return new ValidationResult("PIN should contains 3 digits");

            var pin = 0;

            if (!int.TryParse(stringPin, out pin))
                return new ValidationResult("PIN is not integer");

            return ValidationResult.Success;
        }
    }
}
