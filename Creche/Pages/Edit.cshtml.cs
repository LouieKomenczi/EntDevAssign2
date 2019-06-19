using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Creche.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
//editing an object, very similar as creating an object page

namespace Creche.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ID { get; set; }

        [BindProperty]
        public Student Student { get; set; }

        [BindProperty]
        [Required]
        public bool[] DaysSelected { get; set; } = { false, false, false, false, false };
        public string[] Days { get; set; } = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

        [BindProperty]
        public string[] Gender { get; set; } = { "Male", "Female" };

        [BindProperty]
        public string[] Hours { get; set; } = { "Part Time", "Full Time" };

        [BindProperty]
        public string[] Relationship { get; set; } = { "Father", "Mother", "Other" };

        [BindProperty]
        public bool ValidDays { get; set; } = true;

        [BindProperty]
        public bool Error { get; set; } = false;

        [BindProperty]
        public string Dob { get; set; }

        [BindProperty]
        public string StartDate { get; set; }

        private readonly CrecheContext _db;

        public EditModel(CrecheContext db)
        {
            _db = db;
        }
        public IList<Student> Students { get; private set; }

        public async Task OnGetAsync()
        {

            Students = await _db.Student.AsNoTracking().ToListAsync();
            foreach (var student in Students)
                if (student.ID == Convert.ToInt32(ID))
                {
                    Student = student;
                }
            Dob = Student.Dob.ToString("yyyy-MM-dd");
            StartDate = Student.StartDate.ToString("yyyy-MM-dd");

            if (Student.Days.Contains("Monday")) DaysSelected[0] = true;
            if (Student.Days.Contains("Tuesday")) DaysSelected[1] = true;
            if (Student.Days.Contains("Wednesday")) DaysSelected[2] = true;
            if (Student.Days.Contains("Thursday")) DaysSelected[3] = true;
            if (Student.Days.Contains("Friday")) DaysSelected[4] = true;

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

            if (!ModelState.IsValid)
            {
                Error = true;
                return Page();
            }

            _db.Attach(Student).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Student {Student.ID} not found!");
            }

            return RedirectToPage("Update");
        }
    }
}