using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Creche.Models;
using Microsoft.EntityFrameworkCore;

namespace Creche.Pages
{
    public class DetailModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ID { get; set; }

        private readonly CrecheContext _db;

        public DetailModel(CrecheContext db)
        {
            _db = db;
        }
        public IList<Student> Students { get; private set; }

        public async Task OnGetAsync()
        {
            //loads from temp db to Students list, this will be used in the HTML with for to display all students 
            Students = await _db.Student.AsNoTracking().ToListAsync();           
        }

        public void OnPost()
        {
            
        }

    }
}