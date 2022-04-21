using GestionCalificaciones.Services;
using GestionCalificaciones.ViewModel.Empleados;
using GestionCalificaciones.ViewModel.Estudiantes;
using GestionCalificaciones.ViewModel.TiposUsuarios;
using GestionCalificaciones.ViewModel.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace GestionCalificaciones.Models.Security
{
    public class GCMvcRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {

            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            UsuariosFormViewModel usuarios = new UsuariosModelService().GetSelectWhere(username,null);

            EstudiantesViewMode estudiantes = null;
            EmpleadosViewMode empleados = null;

            if (usuarios.IdTipoUsuario == 1)
            {
                estudiantes = new Services.Estudiantes.EstudiantesModelService().GetSelectWhere(usuarios.IdUsuario);
                
            }
            else
                empleados = new Services.Empleados.EmpleadosModelService().GetSelectWhere(usuarios.IdUsuario);

                if (usuarios != null)
                    if (usuarios.IdTipoUsuario == 1)
                        return new string[] { usuarios.IdUsuario.ToString(), "ESTUDIANTES", usuarios.Usuario, estudiantes.PrimerNombre + " " + estudiantes.PrimerApellido };
                    else
                        return new string[] { usuarios.IdUsuario.ToString(), "EMPLEADO", usuarios.Usuario, empleados.PrimerNombre + " " + empleados.PrimerApellido };
                else
                    return new string[] { };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            
            var roles = new TiposUsuariosModelService().GetSelect().Where(W => W.Nombre.Contains(roleName)).FirstOrDefault();

            if (roles != null)
                return new string[] { roles.IdTipoUsuario.ToString() };
            else
                return new string[] { };
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            UsuariosFormViewModel usuarios = new UsuariosModelService().GetSelectWhere(username, null);

            if (usuarios != null)
                return roleName == usuarios.TiposUsuarios.Text ? true : false;
            else
                return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}