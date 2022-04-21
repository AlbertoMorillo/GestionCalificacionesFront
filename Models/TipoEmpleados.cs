using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.Models
{
    public class TipoEmpleados
    {
        public int IdTipoEmpleado { get; set; }
        public string Nombre { get; set; }

        public virtual Empleados Empleados { get; set; }
    }
}