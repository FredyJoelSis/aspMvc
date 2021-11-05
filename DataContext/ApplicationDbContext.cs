using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using mvc_web_crud_psql.Models;

namespace mvc_web_crud_psql.DataContext
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext() : base(nameOrConnectionString: "Myconnection")
        {

        }

        public virtual DbSet<EmpleadoClass> Empleadoobj { get; set; }
    }
}