using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Creche.Models
{
    //this class collects all the data 
    public class Student 
    {
        [Key]
        public int ID { get; set; }

        
        [Required]
        [RegularExpression(@"\d{7}([a-z]{1,2}|[A-Z]{1,2})", ErrorMessage = "PPS must start with 7 numbers and followed by 2 letters.")]
        [Display(Name = "PPS Number")]
        [Pps]
        public string Pps { get; set; } = "";

        [Required]
        [RegularExpression(@"([\w\s'.-]){2,50}", ErrorMessage = "Last name must be between 2 and 50 characters. ")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = "";
                
        [Required]
        [RegularExpression(@"([\w\s'.-]){2,50}", ErrorMessage = "Last name must be between 2 and 50 characters. ")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = "";
                
        [Required]
        [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}", ApplyFormatInEditMode =true)]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Dob]
        public DateTime Dob { get; set; }
        
        [Required]
        [RegularExpression(@"([\w\s'.-]){2,50}", ErrorMessage = "Last name must be between 2 and 50 characters. ")]
        [Display(Name = "Parent First Name")]
        public string ParentFirstName { get; set; } = "";

        [Required]
        [RegularExpression(@"([\w\s'.-]){2,50}", ErrorMessage = "Last name must be between 2 and 50 characters. ")]
        [Display(Name = "Parent Last Name")]
        public string ParentLastName { get; set; } = "";

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; } = "";

        [Required]
        [RegularExpression(@"08\d{8}", ErrorMessage = "Mobile number must have 10 numbers and start with 08.")]
        [Display(Name = "Mobile")]
        public string MobileNumber { get; set; } = "";

        [RegularExpression(@"0\d{9}", ErrorMessage = "Phone number must have 10 numbers and start with 0.")]
        [Display(Name = "Phone")]
        public string SecondNumber { get; set; } = "";

        [Required]
        [RegularExpression(@"0\d{9}", ErrorMessage = "Alternative phone number must have 10 numbers and start with 0.")]
        [Display(Name = "Alternative Phone")]
        public string OtherNumber { get; set; } = "";

        [Required]
        [RegularExpression(@"[\w-\.]+@([\w-]+\.)+[\w-]{2,4}", ErrorMessage ="Email 1: not a valid email.")]
        [Display(Name = "Email")]
        public string Email { get; set; } = "";

        
        [RegularExpression(@"[\w-\.]+@([\w-]+\.)+[\w-]{2,4}", ErrorMessage = "Email 2: not a valid email.")]
        [Display(Name = "Second Email")]
        public string SecondEmail { get; set; } = "";

        [Required]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]     
        [StartDate]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Relationship")]
        public string Relationship { get; set; }

        [Display(Name = "Gender")]
        [Required]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Hours")]
        public string Hours{ get; set; }
        
        [Display(Name = "Days")]
        public string Days { get; set; }

        [Display(Name = "Price Per Week")]
        public double Cost { get; set; }

        

    }
}
