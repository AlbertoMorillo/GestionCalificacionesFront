using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.Models
{
    public class Escuela
    {
        public int IdEscuela { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public string NombreLabel { get; set; }
        public Nullable<int> Mostrar { get; set; }
    }
}