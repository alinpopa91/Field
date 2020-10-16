using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Field.BLL.Utils
{
    public class AmountValidatorAttribute : ValidationAttribute
    {
        public AmountValidatorAttribute()
        {
        }

        public override bool IsValid(object value)
        {

            if (value is decimal amount)
            {
                if ((decimal)value < 0)
                    return false;
                return true;
            }
            else
                return false;
        }
    }
}
