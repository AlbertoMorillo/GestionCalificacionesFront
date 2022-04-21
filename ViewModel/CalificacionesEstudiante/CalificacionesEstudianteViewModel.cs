using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.ViewModel.CalificacionesEstudiante
{
    public class CalificacionesEstudianteViewModel
    {
        public string Materia { get; set; }
        public int? semestre { get; set; }
        public string descSemestre { get; set; }
        public string nombreEstudiante { get; set; }
        public string semestreSelected { get; set; }
        public string matriculan { get; set; }
        public int? escuela { get; set; }
        public string nombreEscuela { get; set; }
        public int? pensum { get; set; }
        public int? grupo { get; set; }
        public int? tipo { get; set; }
        public int? parcial { get; set; }
        public int? practica { get; set; }
        public int? final { get; set; }
        public int? total { get; set; }
        public int? estatus { get; set; }
        public int? tpractico { get; set; }
        public int? codigoprof { get; set; }
        public string calificadoPor { get; set; }

        public string Asignatura { get; set; }

        public string NotaLiteral { get; set; }
    }
}