using GestionCalificaciones.Models;
using GestionCalificaciones.ViewModel.Usuarios;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace GestionCalificaciones.Services
{
    public class UsuariosModelService
    {
        private const string URL = "https://localhost:44349/api/Usuarios";
        internal object UpdatePassword(object idUsuario, object matricula, object p, string newPassword)
        {
            throw new NotImplementedException();
        }

        internal UsuariosFormViewModel GetSelectWhere(string usuario, object p = null)
        {
            var client = new RestClient(URL);
            var request = new RestRequest(usuario,Method.Get);
            
            var response = client.ExecuteAsync<Usuarios>(request).GetAwaiter().GetResult();
            var jsonResponse = JsonConvert.DeserializeObject<Usuarios>(response.Content);
            UsuariosFormViewModel user = new UsuariosFormViewModel
            {
                IdUsuario = jsonResponse.IdUsuario,
                Usuario = jsonResponse.Usuario1,
                Password = jsonResponse.Password,
                IdTipoUsuario = jsonResponse.IdTipoUsuario,
                Bloqueo = jsonResponse.Bloqueo
            }; 
            return user;
        }
    }
}