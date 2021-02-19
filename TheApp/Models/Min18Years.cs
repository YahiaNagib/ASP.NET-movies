using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheApp.Models
{
    public class Min18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required");
            
            if (DateTime.Now.Subtract((DateTime)customer.Birthdate).TotalDays < 18*365)
            {
                return new ValidationResult("You should be more than 18 years old to apply");
            } else
            {
                return ValidationResult.Success;
            }
        }
    }
}