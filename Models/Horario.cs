using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.Models
{
    public class Horario
    {
        
        public int? Semestre { get; set; }
        
        public int? Materia { get; set; }
        
        public int? Grupo { get; set; }
        
        public int? Tipo { get; set; }
        
        public int? Dia { get; set; }
        
        public int? Profesor { get; set; }
        
        public decimal? He { get; set; }
        
        public decimal? Hs { get; set; }
        public string Aula { get; set; }
        public int? Limite { get; set; }
        public int? Grupos { get; set; }
        public int? Escuela { get; set; }
        public DateTime? Fechahora { get; set; }
        public int? Usuario { get; set; }
        public string Estatus { get; set; }
        public int IdHorarios { get; set; }
    }
}