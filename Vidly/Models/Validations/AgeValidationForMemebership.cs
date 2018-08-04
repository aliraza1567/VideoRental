using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models.Validations
{
    public class AgeValidationForMemebership : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }

            if (customer.DateOfBirth == null)
            {
                return new ValidationResult("Birth Date is required");
            }

            var age = DateTime.Today.Year - customer.DateOfBirth.Value.Year;

            return age >= 18 ? ValidationResult.Success : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }
    }
}