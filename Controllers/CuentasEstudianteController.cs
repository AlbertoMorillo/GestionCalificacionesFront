using GestionCalificaciones.Services;
using GestionCalificaciones.Services.Estudiantes;
using GestionCalificaciones.ViewModel.Estudiantes;
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
    public class CuentasEstudianteController : Controller
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
                    var estudiantesViewMode = service.GetSelectWhere(viewMode.Usuario,null);
                    if ((estudiantesViewMode.Bloqueo ?? 0) == 1)
                    {
                        ModelState.AddModelError("Usuario", "Usuario Bloqueado, favor comunicarse con Registro");
                        throw new ValidationException("Usuario Bloqueado, favor comunicarse con Registro");
                    }
                    else if ((estudiantesViewMode.Bloqueo ?? 0) == 2)
                    {
                        ModelState.AddModelError("Usuario", "Matricula retirada. Debe  pasar por el departamento de orientación a realizar reingreso.");
                        throw new ValidationException("Matricula retirada. Debe  pasar por el departamento de orientación a realizar reingreso.");
                    }
                    else
                    {
                        if (estudiantesViewMode.Password == viewMode.Password)
                        {
                            FormsAuthentication.SetAuthCookie(Usuarios.Usuario.ToString(), false);

                            return RedirectToAction("Index", "VirtualEstudiante");
                        }
                        else
                        {
                            ModelState.AddModelError("Password", "Usuario o contraseña incorrecta.");
                            throw new ValidationException("Usuario o contraseña incorrecta.");
                        }
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

        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            //Verificar correo ID
            //Generar passsword link
            //Eviar correo
            ViewBag.Message = "";
            var EstudianteService = new EstudiantesModelService();
            var User = EstudianteService.GetSelectWhere(null, null, email, null).FirstOrDefault();
            if (User != null)
            {
                string resetCode = Guid.NewGuid().ToString();
                SendVerificationLinkEmail(email, resetCode);
                EstudianteService.UpdatePasswordCode(User.IdUsuario, resetCode);
                ViewBag.Message = "Hemos enviado un link a su correo electrónico institucional.";
            }
            else
            {
                ModelState.AddModelError("Correo", "Lo lamento, no se encontró ningún correo");
            }
            return View();
        }
        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            var User = new EstudiantesModelService().GetSelectWhere(null, null, emailID, null).FirstOrDefault();
            return User != null;
        }

        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode)
        {
            var verifyUrl = "/CuentasEstudiante/ResetPassword/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("am19-0870@unphu.edu.do", "Soporte");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "12345";
            string subject = "Recuperación de contraseña";

            string body = "<br/><br/>Haga click en el link para cambiar su contraseña." +
                " <br/><br/><a href='" + link + "'>" + link + "</a> ";

            var smtp = new SmtpClient
            {
                Host = "smtp.office365.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }

        public ActionResult ResetPassword(string id)
        {
            if (id != null)
            {
                ViewBag.Message = "";
                var User = new EstudiantesModelService().GetSelectWhere(null, null, null, null, id).FirstOrDefault();
                if (User != null)
                {
                    ResetPasswordViewModel model = new ResetPasswordViewModel();
                    model.resetCode = id;
                    return View(model);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            ViewBag.Message = "";
            if (ModelState.IsValid)
            {
                var estudianteService = new EstudiantesModelService();
                var User = estudianteService.GetSelectWhere(null, null, null, null, model.resetCode).FirstOrDefault();
                if (User != null)
                {
                    estudianteService.UpdatePasswordCode(User.IdUsuario, "");

                    if (new UsuariosModelService().UpdatePassword(User.IdUsuario, User.Matricula, null, model.NewPassword).Equals(Constantes.Constantes.Valores.EXITOSO))
                        ViewBag.Message = "Password modificado exitosamente.";
                    else
                        ModelState.AddModelError("Error", "Inválido");
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Inválido");
            }
            return View(model);
        }
        #endregion
    }
}