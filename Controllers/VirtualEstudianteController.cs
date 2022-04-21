using GestionCalificaciones.Models;
using GestionCalificaciones.Services.Asignatura;
using GestionCalificaciones.ViewModel.CalificacionesEstudiante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GestionCalificaciones.Controllers
{
    [Authorize]
    [Authorize(Roles = "ESTUDIANTES")]
    public class VirtualEstudianteController : Controller
    {
        
        // GET: VirtualEstudiante
        GestionCalificacionDBEntities1 _db;
        string SrtrinRutaDirecion;
        public VirtualEstudianteController()
        {
            _db = new GestionCalificacionDBEntities1();
        }
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

        public ActionResult Calificaciones()
        {
            ViewBag.semestreSelected = null;
            var listCalEstudiante = new List<CalificacionesEstudianteViewModel>();

            var CalificaciconesEstudiante = _db.spes_Calificaciones(Roles.GetRolesForUser()[2], null).ToList();
            var list = new List<int>();
            list.Add(2);
            ViewBag.listSemestre = ToSelectList(list).Prepend(new SelectListItem { Value = null, Text = "Seleccionar" });

            string FirstViewSemestre = Constantes.Constantes.Valores.SEMESTRE_ACTUAL.ToString();
            foreach (var data in CalificaciconesEstudiante)
            {
                string asignaturaNombre = new AsignaturaModelService().GetSelectWhereNameAsignatura(data.materia.ToString()).AsignaturaNom;
                var calEstudiante = new CalificacionesEstudianteViewModel();
                calEstudiante.parcial = data.parcial;
                calEstudiante.practica = data.practica;
                calEstudiante.final = data.final;
                calEstudiante.NotaLiteral = data.NL;
                calEstudiante.total = data.total;
                calEstudiante.Asignatura = asignaturaNombre;
                calEstudiante.Materia = data.materia.ToString();
                listCalEstudiante.Add(calEstudiante);
            }
            listCalEstudiante.ForEach(s => s.semestreSelected = FirstViewSemestre);
            return View(listCalEstudiante);
        }

        private SelectList ToSelectList(List<int> semestreList)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var data in semestreList)
            {
                list.Add(new SelectListItem()
                {
                    Text = data.ToString(),
                    Value = data.ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }
        [HttpPost]
        public ActionResult getCalificacionesBySemestre(string semestreSelected)
        {

            int? semestre;
            int sem;
            if (int.TryParse(semestreSelected, out sem))
                semestre = sem;
            else
                semestre = null;

            ViewBag.semestreSelected = Constantes.Constantes.Valores.SEMESTRE_ACTUAL;
            var CalificaciconesEstudiante = _db.spes_Calificaciones(Roles.GetRolesForUser()[2], Constantes.Constantes.Valores.SEMESTRE_ACTUAL).ToList();

            var listCalEstudiante = new List<CalificacionesEstudianteViewModel>();

            var SemestresCursadoSP = new List<int>();
            SemestresCursadoSP.Add(2);
            ViewBag.listSemestre = ToSelectList(SemestresCursadoSP).Append(new SelectListItem { Value = null, Text = "Seleccionar" });

            string FirstViewSemestre = "ENERO - ABRIL 2022";
            foreach (var data in CalificaciconesEstudiante)
            {
                string asignaturaNombre = new AsignaturaModelService().GetSelectWhereNameAsignatura(data.materia.ToString()).AsignaturaNom;
                var calEstudiante = new CalificacionesEstudianteViewModel();
                calEstudiante.parcial = data.parcial;
                calEstudiante.practica = data.practica;
                calEstudiante.final = data.final;
                calEstudiante.NotaLiteral = data.NL;
                calEstudiante.total = data.total;
                calEstudiante.Asignatura = asignaturaNombre;
                calEstudiante.Materia = data.materia.ToString();
                listCalEstudiante.Add(calEstudiante);
            }
            listCalEstudiante.ForEach(s => s.semestreSelected = semestreSelected);
            return PartialView("_CalificacionesVisualizacion", listCalEstudiante);
        }
    }
}