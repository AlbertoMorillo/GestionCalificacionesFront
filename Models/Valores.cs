using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.Models
{
    public class Valores
    {
        public int IdValores { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }
        public string Valor2 { get; set; }
        public Nullable<int> Padre { get; set; }
        public string valor3 { get; set; }
        public string valor4 { get; set; }
    }
}