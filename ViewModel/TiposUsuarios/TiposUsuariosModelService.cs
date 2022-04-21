using GestionCalificaciones.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.ViewModel.TiposUsuarios
{
    public class TiposUsuariosModelService
    {
        private const string URL = "https://localhost:44349/api/TiposUsuarios";
        internal IEnumerable<TipoUsuarios> GetSelect()
        {
            var client = new RestClient(URL);
            var request = new RestRequest(resource:"",method:Method.Get);

            var response = client.ExecuteAsync<TipoUsuarios>(request).GetAwaiter().GetResult();
            var jsonResponse = JsonConvert.DeserializeObject<IEnumerable<TipoUsuarios>>(response.Content);

            return jsonResponse;
        }
    }
}