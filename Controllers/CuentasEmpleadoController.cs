using GestionCalificaciones.Services;
using GestionCalificaciones.Services.Empleados;
using GestionCalificaciones.ViewModel.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GestionCalificaciones.Controllers
{
    public class CuentasEmpleadoController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuariosFormViewModel viewMode)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var service = new UsuariosModelService();
                    UsuariosFormViewModel Usuarios = service.GetSelectWhere(viewMode.Usuario, null);

                    if (Usuarios.Password == viewMode.Password)
                    {
                        FormsAuthentication.SetAuthCookie(Usuarios.Usuario.ToString(), false);
                        return RedirectToAction("Index", "VirtualEmpleado");
                    }
                    else
                    {
                        ModelState.AddModelError("password", "Usuario o contraseña incorrecta.");
                        throw new ValidationException("Usuario o contraseña incorrecta.");
                    }
                }
                else
                    throw new ValidationException();
            }
            catch (ValidationException e)
            {
                return View(viewMode);
            }
            catch (Exception e)
            {
                return View(viewMode);
            }

        }

        #region Reset password
        public ActionResult ForgotPassword()
        {
            ViewBag.Message = "";
            return View();
        }

               #endregion

    }
}