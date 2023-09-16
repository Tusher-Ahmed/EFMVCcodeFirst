using MVCcodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCcodeFirst.Data
{
    public class ApplicationDBContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}