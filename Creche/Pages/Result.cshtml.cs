using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Creche.Models;

namespace Creche.Pages
{
    

    public class ResultModel : PageModel
    {
        public string Message { get; set; }
        

        public void OnGet()
        {   
            //catching the session variable and setting it to Message that will be displayed in  the view
            Message = HttpContext.Session.GetDouble("Price").ToString();
        }

        
    }
}