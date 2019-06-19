using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
// validation for DOB
namespace Creche.Models
{
    public class DobAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object Dob, ValidationContext validationContext)
        {
            Student student = (Student)validationContext.ObjectInstance;
            //test for DOB is a past date
            if (DateTime.Now < student.Dob)
            {
                return new ValidationResult("DOB cannot be in the future");

            }
            else
            //test for age on start date is between 3 and 5
            if (((student.StartDate - student.Dob).TotalDays < 1095) || ((student.StartDate - student.Dob).TotalDays > 1827))
            {
                return new ValidationResult("Age must be under 5 and over 3 at start date");
            }
            else
                return ValidationResult.Success;

                      
        }
    }
}
