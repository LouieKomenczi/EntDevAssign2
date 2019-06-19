using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Creche.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
//deleting an object page
namespace Creche.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ID { get; set; }

        [BindProperty]
        [Display(Name = "Confirm PPS to Delete")]
        public string ConfirmPPS { get; set; }

        [BindProperty]
        public Student Student { get; set; }       
 

        private readonly CrecheContext _db;

        public DeleteModel(CrecheContext db)
        {
            _db = db;
        }
        public IList<Student> Students { get; private set; }
        //loading all objects to Students list
        public async Task OnGetAsync()
        {

            Students = await _db.Student.AsNoTracking().ToListAsync();
            foreach(var student in Students)
                if(student.ID == Convert.ToInt32(ID))
                {
                    Student = student;
                }

        }
        //delete object and return to VIEW page
        public async Task<IActionResult> OnPostAsync()
        {
            if (Student != null)
            {
                var student = await _db.Student.FindAsync(Student.ID);                 
                _db.Student.Remove(student);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage("View");
        }

    }
}