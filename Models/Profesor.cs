using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.Models
{
    public class Profesor
    {
        public int IdProfesor { get; set; }
        public Nullable<int> Codigo { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> IdEmpleado { get; set; }

        public virtual Empleados Empleados { get; set; }
    }
}