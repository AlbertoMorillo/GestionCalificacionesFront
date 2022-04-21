using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.Models
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Password { get; set; }
        public int IdTipoUsuario { get; set; }
        public Nullable<int> Bloqueo { get; set; }
        public string Usuario1 { get; set; }
    }
}