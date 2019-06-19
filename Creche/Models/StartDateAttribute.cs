using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//validation for start date
namespace Creche.Models
{
    public class StartDateAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object StartDate, ValidationContext validationContext)
        {

            Student student = (Student)validationContext.ObjectInstance;
            if (DateTime.Now > student.StartDate)
            {
                return new ValidationResult("Start date must be in the future");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
