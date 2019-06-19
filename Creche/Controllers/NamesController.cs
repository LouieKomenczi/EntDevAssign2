using Creche.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creche.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamesController:ControllerBase
    {
        private readonly CrecheContext _db;       

        public NamesController(CrecheContext db)
        {
            _db = db;
          
        }

        public IList<Student> Students { get; private set; }

        //GET 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetStudent()
        {
            var names = new List<string>();
            
            Students = await _db.Student.ToListAsync();         
            foreach(var student in Students)
            {               
                names.Add(student.FirstName + ' ' + student.LastName);
            }        
                
            return names;
            
        }

        //GET with incoming value
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetStudent(int ID)
        {
            string days="";
            Students = await _db.Student.ToListAsync();
            foreach (var student in Students)
            {
                if (student.ID == ID)
                    days = student.Days;
            }
            return days;
        }


    }
}
