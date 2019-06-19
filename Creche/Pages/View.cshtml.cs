using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Creche.Models;

namespace Creche.Pages
{
    public class ViewModel : PageModel
    {
        private readonly CrecheContext _db;

        public ViewModel(CrecheContext db)
        {
            _db = db;
        }
        public IList<Student> Students { get; private set; }

        [BindProperty]
        public string SearchName { get; set; }

        [TempData]
        public string SearchBy { get; set; }

        public async Task OnGetAsync()
        {
            Students = await _db.Student.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            SearchBy = SearchName;
            return RedirectToPage("View");
        }
    }
}