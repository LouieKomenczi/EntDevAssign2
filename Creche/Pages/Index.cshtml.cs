using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Creche.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Creche.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [BindProperty]
        public Rootobject weather { get; set; }

        public string Message = "This is you're first vist!";

        public async Task<IActionResult> OnGetAsync()
        {
            //cookie to display last vist, expires after 1 year
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Append("VisitDate", DateTime.Now.ToShortDateString(), options);
            if (Request.Cookies["Visitdate"] != null)
            {
                Message = "You're last visit was on " + Request.Cookies["VisitDate"];
            }

            var client = _clientFactory.CreateClient();

            try
            {
                client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/weather?q=Sligo,Ie&units=metric&APPID=fdf7895fafa873b96a6735347df8c15c");
                HttpResponseMessage response = await client.GetAsync($"");
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                weather = JsonConvert.DeserializeObject<Rootobject>(stringResult);
                return Page();
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest($"Error getting data from jsonplaceholder {httpRequestException.Message}");
            }           
            
        }
    }
}