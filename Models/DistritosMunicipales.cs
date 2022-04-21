using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.Models
{
    public class DistritosMunicipales
    {
        public int IdDistritoMunicipal { get; set; }
        public int IdMunicipio { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
    }
}