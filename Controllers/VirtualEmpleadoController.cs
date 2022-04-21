using GestionCalificaciones.Models;
using GestionCalificaciones.Services;
using GestionCalificaciones.Services.Asignatura;
using GestionCalificaciones.Services.Empleados;
using GestionCalificaciones.Services.Estudiantes;
using GestionCalificaciones.Services.Horario;
using GestionCalificaciones.Services.Seleccion;
using GestionCalificaciones.ViewModel.Calificaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GestionCalificaciones.Controllers
{
    [Authorize]
    [Authorize(Roles = "EMPLEADO,ADMINITRATIVO,ADMISION,CONTABILIDAD,ORIENTACION,CAJA,REGISTRO,RRHH,EVALUACION")]
    public class VirtualEmpleadoController : Controller
    {
        GestionCalificacionDBEntities1 _db;
        string SrtrinRutaDirecion;
        public VirtualEmpleadoController()
        {
            _db = new GestionCalificacionDBEntities1();
        }
        // GET: VirtualEmpleado

        public ActionResult Index()
        {
            var userLogged = HttpContext.User.Identity.Name;
            var DatosPerfil = new Services.Empleados.EmpleadosModelService().GetSelectWhere(int.Parse(Roles.GetRolesForUser()[0]));
            ViewBag.DatosPerfil = DatosPerfil;
            string NombreFotoPerfil = DatosPerfil.PrimerNombre + " " + DatosPerfil.PrimerApellido;
            NombreFotoPerfil = NombreFotoPerfil.Trim(new Char[] { '=' });

            ViewBag.FotoPerfil = NombreFotoPerfil;

            return View();
        }

        public ActionResult RegistroCalificacion()
        {
            if (TempData["Success"] != null && (TempData["Success"] as bool?) == true)
                ViewBag.guardadoFinal = true;
            else
                ViewBag.guardadoFinal = false;

            //Validacion Calendario
            

            var HorarioService = new HorarioModelService();
            string codigoProfesorStr = new EmpleadosModelService().GetSelectWhere(Convert.ToInt32(Roles.GetRolesForUser()[0])).CodigoProfesor;
            int codigoProfesor = Convert.ToInt32(codigoProfesorStr);
            var listHorarioDB = HorarioService.GetHorarioDistinct(2, Roles.GetRolesForUser()[0]);
            ViewBag.listMateria = ToSelectList(listHorarioDB);

            CalificacionesViewModel calificacionesViewModel = new CalificacionesViewModel();
            calificacionesViewModel.codigoprof = codigoProfesor;
            calificacionesViewModel.semestre = Constantes.Constantes.Valores.SEMESTRE_ACTUAL;
            calificacionesViewModel.ListGrupo = new List<CalificacionesViewModel.Grupo>();
            List<int?> grupos = new HorarioModelService().GetGruposDistinct(listHorarioDB.FirstOrDefault(), Constantes.Constantes.Valores.SEMESTRE_ACTUAL, Convert.ToInt32(Roles.GetRolesForUser()[0]));
            ViewBag.MateriaSelected = listHorarioDB.FirstOrDefault();
            CalificacionesViewModel.Grupo grupoModel;

            foreach (var item in grupos)
            {
                grupoModel = new CalificacionesViewModel.Grupo { NumGrupo = item };
                var spesCalficacion = _db.spes_CalificacionEstudiante(listHorarioDB.FirstOrDefault(), null, null).ToList();
                calificacionesViewModel.estudiantesSelected = new List<CalificacionesViewModel.Estudiante>();
                calificacionesViewModel.cantEstudianteSelected = spesCalficacion.Count();
                if (spesCalficacion.Count() > 0)
                {
                    spesCalficacion.ForEach(c => calificacionesViewModel.estudiantesSelected.Add(new CalificacionesViewModel.Estudiante
                    {
                        Matricula = c.matriculan.ToString(),
                        Nombre = c.PrimerNombre + " " + c.SegundoNombre + " " + c.PrimerApellido + " " + c.SegundoApellido,
                        NL = "",
                        TP = c.tpractico.ToString(),
                        PP = c.parcial.ToString(),
                        EF = c.final.ToString(),
                        PF = c.total.ToString()
                    }));
                }
                calificacionesViewModel.ListGrupo.Add(grupoModel);
            }
            // Validacion calificado previamente??
            ViewBag.flagCalificado = getEstatusCalificadoPrevio(Constantes.Constantes.Valores.SEMESTRE_ACTUAL, Convert.ToInt32(Roles.GetRolesForUser()[0]), null, listHorarioDB.FirstOrDefault());

            calificacionesViewModel.Materia = listHorarioDB.FirstOrDefault();
            ViewBag.listGrupo = ToSelectList(calificacionesViewModel.ListGrupo).Prepend(new SelectListItem { Value = null, Text = "Seleccionar" });
            return View(calificacionesViewModel);
        }



        [HttpPost]
        public ActionResult getGrupoByMateria(string materiaSelected)
        {
            //Validacion Calendario

            var HorarioService = new HorarioModelService();
            

            var listHorarioDB = HorarioService.GetHorarioDistinct(Constantes.Constantes.Valores.SEMESTRE_ACTUAL, Roles.GetRolesForUser()[0]);
            ViewBag.listMateria = ToSelectList(listHorarioDB);

            CalificacionesViewModel calificacionesViewModel = new CalificacionesViewModel();
            calificacionesViewModel.codigoprof = Convert.ToInt32(Roles.GetRolesForUser()[0]);
            calificacionesViewModel.semestre = Constantes.Constantes.Valores.SEMESTRE_ACTUAL;
            calificacionesViewModel.Materia = materiaSelected;
            calificacionesViewModel.ListGrupo = new List<CalificacionesViewModel.Grupo>();
            List<int?> grupos = new HorarioModelService().GetGruposDistinct(materiaSelected, Constantes.Constantes.Valores.SEMESTRE_ACTUAL, Convert.ToInt32(Roles.GetRolesForUser()[0]));
            CalificacionesViewModel.Grupo grupoModel;

            foreach (var item in grupos)
            {
                grupoModel = new CalificacionesViewModel.Grupo { NumGrupo = item };
                var spesCalficacion = _db.spes_CalificacionEstudiante(materiaSelected, null, null).ToList();
                calificacionesViewModel.estudiantesSelected = new List<CalificacionesViewModel.Estudiante>();
                calificacionesViewModel.cantEstudianteSelected = spesCalficacion.Count();
                if (spesCalficacion.Count() > 0)
                {
                    spesCalficacion.ForEach(c => calificacionesViewModel.estudiantesSelected.Add(new CalificacionesViewModel.Estudiante
                    {
                        Matricula = c.matriculan.ToString(),
                        Nombre = c.PrimerNombre + " " + c.SegundoNombre + " " + c.PrimerApellido + " " + c.SegundoApellido,
                        NL = "",
                        TP = c.tpractico.ToString(),
                        PP = c.parcial.ToString(),
                        EF = c.final.ToString(),
                        PF = c.total.ToString()
                    }));
                }
                calificacionesViewModel.ListGrupo.Add(grupoModel);
            }
            calificacionesViewModel.Materia = materiaSelected;
            // Validacion calificado previamente??
            ViewBag.flagCalificado = getEstatusCalificadoPrevio(Constantes.Constantes.Valores.SEMESTRE_ACTUAL, Convert.ToInt32(Roles.GetRolesForUser()[0]), null, materiaSelected);

            ViewBag.listGrupo = ToSelectList(calificacionesViewModel.ListGrupo).Prepend(new SelectListItem { Value = null, Text = "Seleccionar" });
            return PartialView("_CalificacionesEstudiante", calificacionesViewModel);
        }

        [HttpPost]
        public ActionResult getLisEstByMateriaGrupo(string materiaSelected, string grupoSel)
        {
            //Validacion Calendario
            


            var HorarioService = new HorarioModelService();
            int? grupoSelected;
            int grpsl;
            if (int.TryParse(grupoSel, out grpsl))
                grupoSelected = grpsl;
            else
                grupoSelected = null;
            // Validacion calificado previamente??
            ViewBag.flagCalificado = getEstatusCalificadoPrevio(Constantes.Constantes.Valores.SEMESTRE_ACTUAL, Convert.ToInt32(Roles.GetRolesForUser()[0]), grupoSelected, materiaSelected);

            var listHorarioDB = HorarioService.GetHorarioDistinct(Constantes.Constantes.Valores.SEMESTRE_ACTUAL, Roles.GetRolesForUser()[0]);
            ViewBag.listMateria = ToSelectList(listHorarioDB);


            CalificacionesViewModel calificacionesViewModel = new CalificacionesViewModel();
            calificacionesViewModel.codigoprof = Convert.ToInt32(Roles.GetRolesForUser()[0]);
            calificacionesViewModel.semestre = Constantes.Constantes.Valores.SEMESTRE_ACTUAL;
            calificacionesViewModel.Materia = materiaSelected;
            calificacionesViewModel.ListGrupo = new List<CalificacionesViewModel.Grupo>();
            List<int?> grupos = new HorarioModelService().GetGruposDistinct(materiaSelected, Constantes.Constantes.Valores.SEMESTRE_ACTUAL, Convert.ToInt32(Roles.GetRolesForUser()[0]));

            CalificacionesViewModel.Grupo grupoModel;
            foreach (var item in grupos)
            {
                grupoModel = new CalificacionesViewModel.Grupo { NumGrupo = item };
                var spesCalficacion = _db.spes_CalificacionEstudiante(materiaSelected, grupoSelected, null).ToList();
                calificacionesViewModel.estudiantesSelected = new List<CalificacionesViewModel.Estudiante>();
                calificacionesViewModel.cantEstudianteSelected = spesCalficacion.Count();
                if (spesCalficacion.Count() > 0)
                {
                    spesCalficacion.ForEach(c => calificacionesViewModel.estudiantesSelected.Add(new CalificacionesViewModel.Estudiante
                    {
                        Matricula = c.matriculan.ToString(),
                        Nombre = c.PrimerNombre + " " + c.SegundoNombre + " " + c.PrimerApellido + " " + c.SegundoApellido,
                        NL = "",
                        TP = c.tpractico.ToString(),
                        PP = c.parcial.ToString(),
                        EF = c.final.ToString(),
                        PF = c.total.ToString()
                    }));
                }
                calificacionesViewModel.ListGrupo.Add(grupoModel);
            }
            calificacionesViewModel.Materia = materiaSelected;
            calificacionesViewModel.grupo = grupoSelected;
            ViewBag.listGrupo = ToSelectList(calificacionesViewModel.ListGrupo).Prepend(new SelectListItem { Value = null, Text = "Seleccionar" });
            return PartialView("_CalificacionesEstudiante", calificacionesViewModel);
        }

        [HttpPost]
        public ActionResult GuardarCalificaciones(CalificacionesViewModel model)
        {
            
            var spesCalficacion = _db.spes_CalificacionEstudiante(model.Materia, model.grupo, null).ToList();

            if (model.estudiantesSelected.Count > 0)
            {
                var CalificaiconViewList = new List<CalificacionesViewModel>();
                CalificacionesViewModel CalificacionView;
                foreach (var item in model.estudiantesSelected)
                {
                    CalificacionView = new CalificacionesViewModel();
                    CalificacionView.matriculan = item.Matricula;
                    CalificacionView.semestre = spesCalficacion.Where(c => c.matriculan.ToString() == item.Matricula && c.grupo == model.grupo).Select(c => c.semestre).FirstOrDefault();
                    CalificacionView.Materia = model.Materia;
                    CalificacionView.grupo = model.grupo;
                    CalificacionView.tipo = 0;
                    CalificacionView.parcial = (item.PP != null) ? Convert.ToInt32(item.PP) : 0;
                    CalificacionView.practica = (item.TP != null) ? Convert.ToInt32(item.TP) : 0;
                    CalificacionView.final = (item.EF != null) ? Convert.ToInt32(item.EF) : 0;
                    CalificacionView.total = (item.PF != null) ? Convert.ToInt32(item.PF) : 0;
                    CalificacionView.estatus = Constantes.Constantes.Valores.CALIFICADA;
                    CalificacionView.tpractico = (item.TP != null) ? Convert.ToInt32(item.TP) : 0;
                    CalificacionView.usuario = Roles.GetRolesForUser()[2];
                    CalificacionView.codigoprof = Convert.ToInt32(Roles.GetRolesForUser()[2]);
                    CalificacionView.fechahorap = DateTime.Now;
                    CalificacionView.coladas = 0;
                    CalificacionView.notaLiteral = item.NL;
                    CalificaiconViewList.Add(CalificacionView);
                }

                new CalificacionModelService().SaveChange(CalificaiconViewList);
                TempData["Success"] = true;
            }
            return RedirectToAction("RegistroCalificacion");
        }

        public SelectList ToSelectList(List<string> table)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var data in table)
            {
                var materiaName = new AsignaturaModelService().GetSelectWhereNameAsignatura(data.ToString()).AsignaturaNom;
                list.Add(new SelectListItem()
                {
                    Text = materiaName,
                    Value = data.ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        public bool getEstatusCalificadoPrevio(int semestre, int codigoProfesor, int? grupo, string materia)
        {
            List<Calificacion> calificaciones = new CalificacionModelService().getSelectWhere(codigoProfesor, materia, grupo, semestre);
            if (calificaciones.Count > 0)
            {
                int grupoCalificacion = calificaciones.Count();
                int grupoCalificado = calificaciones.Where(c => c.Estatus == Constantes.Constantes.Valores.CALIFICADA).Count();

                if (grupoCalificacion == grupoCalificado)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        private SelectList ToSelectList(List<CalificacionesViewModel.Grupo> listGrupo)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var data in listGrupo)
            {
                list.Add(new SelectListItem()
                {
                    Text = data.NumGrupo.ToString(),
                    Value = data.NumGrupo.ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }
    }
}