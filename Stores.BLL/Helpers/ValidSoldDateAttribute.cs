using System;
using System.ComponentModel.DataAnnotations;

namespace Stores.BLL.Helpers
{
    internal class ValidSoldDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var enteredDate = Convert.ToDateTime(value);

            if (enteredDate > DateTime.Now)
                return new ValidationResult("Product Sold Date can not be greater than current date.");
            else
                return ValidationResult.Success;

        }
    }
}