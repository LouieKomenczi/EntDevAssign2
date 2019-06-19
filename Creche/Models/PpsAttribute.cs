using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//validation for PPS
namespace Creche.Models
{
    public class PpsAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object Pps, ValidationContext validationContext)
        {

            Student student = (Student)validationContext.ObjectInstance;
            student.Pps = student.Pps.ToUpper();
            var checksum = 0;
            //check for valid length of pps number
            if (student.Pps.Length<7 ) return new ValidationResult("Invalid PPS");
            else
            {
                //calculating wheight for check sum
                for (int i = 0; i < 7; i++)
                {
                    checksum += (student.Pps[i] - '0') * (8 - i);
                }
                //adding last letter weight  if pps is 8 characters(new format)
                try
                {
                    checksum += (student.Pps[8] - 64) * 9;
                }
                catch
                {

                }
                //modulus 23 gives us the check character
                checksum = (checksum % 23);
                //validating the check character
                if ((checksum == 0) && (student.Pps[7] == (char)87))
                    return ValidationResult.Success;
                else
                if (student.Pps[7] == (char)(64 + checksum))
                    return ValidationResult.Success;
                else
                {
                    return new ValidationResult("Invalid PPS");
                }

            }
            
        }
    }
}




