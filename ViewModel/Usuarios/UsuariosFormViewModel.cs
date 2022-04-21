using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionCalificaciones.ViewModel.Usuarios
{
    public class UsuariosFormViewModel
    {
        public int IdUsuario { get; set; }
        [Required, Display(Name = "Usuario")]
        public string Usuario { get; set; }
        [Required, Display(Name = "Contraseña")]
        public string Password { get; set; }
        public int IdTipoUsuario { get; set; }
        public int? Bloqueo { get; set; }
        public SelectListItem TiposUsuarios { get; set; }
    }
}