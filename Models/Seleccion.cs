using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.Models
{
    public class Seleccion
    {
        
        public int Semestre { get; set; }
        
        public int Matriculan { get; set; }
        
        public int? Escuela { get; set; }
        
        public int? Pensum { get; set; }
        
        public int? Materia { get; set; }
        
        public int? Grupo { get; set; }
        
        public int IdSeleccion { get; set; }
    }
}