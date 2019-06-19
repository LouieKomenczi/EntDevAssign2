using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Creche.Models;
using System.Globalization;
using System.Net;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Creche.Pages
{
    public class AddModel : PageModel
    {
        private readonly CrecheContext _db;
        
        public AddModel(CrecheContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Student { get; set; } = new Student();

        public IList<Student> Students { get; private set; }

        [BindProperty]
        [Required]
        public bool[] DaysSelected { get; set; } = { false, false, false, false, false };
        public string[] Days { get; set; } = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

        [BindProperty] 
        public string[] Gender { get; set; } = { "Male", "Female" };

        [BindProperty]
        public string[] Hours { get; set; }  = { "Part Time", "Full Time" };

        [BindProperty]
        public string[] Relationship { get; set; } = { "Father", "Mother", "Other" };
        
        [BindProperty]
        public bool ValidDays { get; set; } = true;

        [BindProperty]
        public bool Error { get; set; } = false;

        public void OnGet()
        {
            Student.Cost = 0;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //loading the values for days selected into student object and counting how many days
            var dayNumber = 0;
            ValidDays = false;
            for (int i = 0; i < 5; i++)
            {
                if (DaysSelected[i])
                {
                    ValidDays = true;
                    Student.Days += " " + Days[i];
                    dayNumber++;
                }                
            }

            //loading the values for gender into student object
            var gender = Request.Form["Student.Gender"];
            if (gender == "Male") Student.Gender = "Male"; else Student.Gender = "Female";

            //loading the values for relationshop into student object
            string relationship = Request.Form["Student.Relationship"];
            if (relationship == "Father") Student.Relationship = "Father";
            if (relationship == "Mother") Student.Relationship = "Mother";
            if (relationship == "Other") Student.Relationship = "Other";

            //loading the values for part time/full time and calculating price
            Student.Hours = Request.Form["Student.Hours"];
            double price = 0;
            if (Student.Hours == "Part Time")
            {              
                price = 20 * dayNumber;
            }
            else
            if (Student.Hours == "Full Time")
            {            
                price = 35 * dayNumber;
            }

            //check for valid days, at least one day has to be selected
            if (!ValidDays)
            {
                Error = true;
                return Page();
            }           

            //applying the discount if 4 or 5 days attendance
            if (dayNumber > 3) price = price - (price * 10 / 100);
            Student.Cost = price;

            //sending price through session variable
            HttpContext.Session.SetDouble("Price", price);

            if (ModelState.IsValid)
            {      

                //saving changes to data base and redirect to Result page
                _db.Student.Add(Student);
                await  _db.SaveChangesAsync();
                return RedirectToPage("/Result");
            }
            else
            {
                //return to current page if did not pass client side validation
                Error = true;
                return Page();
            }
        
        }
    }
}