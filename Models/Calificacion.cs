using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.Models
{
    public class Calificacion
    {
        
        public int Semestre { get; set; }
        
        public string Matriculan { get; set; }
        
        public int? Escuela { get; set; }
        
        public int? Pensum { get; set; }
        
        public int? Materia { get; set; }
        
        public int? Grupo { get; set; }
        
        public int? Tipo { get; set; }
        
        public int? Parcial { get; set; }
        
        public int? Practica { get; set; }
        
        public int? Final { get; set; }
        
        public int? Total { get; set; }
        
        public int? Estatus { get; set; }
        
        public int? Tpractico { get; set; }
        
        public int? Usuario { get; set; }
        
        public int? Codigoprof { get; set; }
        
        public int IdCalificacion { get; set; }
        
        public string Nl { get; set; }
    }
}