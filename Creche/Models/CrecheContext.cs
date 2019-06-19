using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creche.Models
{
    //used with temp data base
    public class CrecheContext:DbContext
    {
        public CrecheContext(DbContextOptions<CrecheContext> options)
            : base(options)
        {  }

        public DbSet<Student> Student { get; set; }
    }
}
