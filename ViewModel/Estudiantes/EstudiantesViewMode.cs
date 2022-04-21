using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.ViewModel.Estudiantes
{
    public class EstudiantesViewMode
    {
        public int IdEstudiante { get; set; }
        public int IdUsuario { get; set; }
        public int IdEscuela { get; set; }
        public Nullable<int> IdPais { get; set; }
        public int IdTipoDocumento { get; set; }
        public Nullable<int> IdDistritoMunicipal { get; set; }
        public Nullable<int> IdEstadoCivil { get; set; }
        public Nullable<int> IdOcupacion { get; set; }
        public String Matricula { get; set; }
        public String TipoUsuario { get; set; }

        public string NombreCompleto
        {
            get
            {
                return string.Format("{0} {1} {2}", PrimerNombre, PrimerApellido, SegundoApellido);
            }
        }

        public string NombreCompletoStr
        {
            set; get;
        }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string CorreoElectronico { get; set; }
        public string ResetPasswordCode { get; set; }

        public string Semestre { get; set; }
        public int? Bloqueo { get; set; }
        public string NombreEmergencia { get; set; }
        public string TElefonoEmergencia { get; set; }

        public partial class resumenEst
        {
            public string Matricula { get; set; }
            public string NombreCompletoStr { get; set; }
            public string TipoUsuario { get; set; }
            public int idUser { get; set; }
            public int Bloqueo { get; set; }

        }

        public virtual Models.DistritosMunicipales DistritosMunicipales { get; set; }
        public virtual Models.Usuarios Usuarios { get; set; }
        public virtual Models.Escuela Escuela { get; set; }
    }
}