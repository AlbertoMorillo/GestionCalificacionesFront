using GestionCalificaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.ViewModel.Empleados
{
    public class EmpleadosViewMode
    {
        public int IdEmpleado { get; set; }
        public Nullable<int> IdTipoEmpleado { get; set; }
        public string semestreSelected { get; set; }
        public string ResetPasswordCode { get; set; }
        public int IdTipoDocumento { get; set; }
        public int IdUsuario { get; set; }
        public Nullable<int> IdPais { get; set; }
        public Nullable<int> IdDistritoMunicipal { get; set; }
        public Nullable<int> IdEstadoCivil { get; set; }
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
        public string CodigoProfesor { get; set; }

        public virtual DistritosMunicipales DistritosMunicipales { get; set; }
        public virtual TipoEmpleados TiposEmpleados { get; set; }
        public virtual Models.Usuarios Usuarios { get; set; }

        public virtual Profesor Profesor { get; set; }
    }
}