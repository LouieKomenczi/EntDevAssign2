using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Creche.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//message to user that update was succesfull
namespace Creche.Pages
{
    public class UpdateModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = HttpContext.Session.GetDouble("Price").ToString();
        }
    }
}