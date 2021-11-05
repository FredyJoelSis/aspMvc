using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvc_web_crud_psql.Models
{
    [Table("empleados",Schema = "public")]

    public class EmpleadoClass
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int edad { get; set; }
        public int telefono { get; set; }
        public string direccion { get; set; }
    }
}