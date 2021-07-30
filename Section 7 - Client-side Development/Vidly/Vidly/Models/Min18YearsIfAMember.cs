using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        // Use second IsValid in suggetions
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Create custom validation
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is requeird.");

            // Validate age
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age > 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to gon on a membership");
        }
    }
}