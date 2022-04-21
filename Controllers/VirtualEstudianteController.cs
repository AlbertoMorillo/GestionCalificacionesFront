using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GestionCalificaciones.Controllers
{
    public class VirtualEstudianteController : Controller
    {
        [Authorize]
        [Authorize(Roles = "ESTUDIANTES")]
        // GET: VirtualEstudiante
        public ActionResult Index()
        {
            var serEst = new Services.Estudiantes.EstudiantesModelService();
            var user = int.Parse(Roles.GetRolesForUser()[0]);
            var DatosPerfil = serEst.GetSelectWhere(user);
            ViewBag.DatosPerfil = DatosPerfil;
            string NombreFotoPerfil = DatosPerfil.PrimerNombre + " " + DatosPerfil.PrimerApellido;
            NombreFotoPerfil = NombreFotoPerfil.Trim(new Char[] { '=' });

            ViewBag.FotoPerfil = NombreFotoPerfil;
            return View();
        }
    }
}