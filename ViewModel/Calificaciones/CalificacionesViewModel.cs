using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.ViewModel.Calificaciones
{
    public class CalificacionesViewModel
    {
        public string Materia { get; set; }
        public string nombreMateria { get; set; }
        public int? semestre { get; set; }
        public int idCalificacion { get; set; }
        public string nombreProfesor { get; set; }
        public string nombreSemestre { get; set; }
        public DateTime fechaModificacion { get; set; }
        public string origenModificacion { get; set; }
        public string matriculan { get; set; }
        public int? escuela { get; set; }
        public int? pensum { get; set; }
        public string Asignatura { get; set; }
        public string idProfesor { get; set; }
        public int? grupo { get; set; }
        public int? tipo { get; set; }
        public int? parcial { get; set; }
        public int? practica { get; set; }
        public int? final { get; set; }
        public int? total { get; set; }
        public int? estatus { get; set; }
        public int? tpractico { get; set; }
        public string nombreEstudiante { get; set; }
        public string usuario { get; set; }
        public DateTime fechahorap { get; set; }
        public int? codigoprof { get; set; }
        public int? coladas { get; set; }
        public bool? replicada { get; set; }
        public List<Grupo> ListGrupo { get; set; }
        public List<Estudiante> estudiantesSelected { get; set; }
        public int cantEstudianteSelected { get; set; }
        public string notaLiteral { get; set; }

        public partial class Grupo
        {
            public int? NumGrupo { get; set; }

        }

        public partial class Estudiante
        {
            public string Matricula { get; set; }
            public string Nombre { get; set; }
            public string TP { get; set; }
            public string PP { get; set; }
            public string EF { get; set; }
            public string PF { get; set; }
            public string NL { get; set; }

        }
    }
}