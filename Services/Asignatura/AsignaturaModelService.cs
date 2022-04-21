using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.Services.Asignatura
{
    public class AsignaturaModelService
    {
        private const string URL = "https://localhost:44349/api/Asignatura/";
        public Models.Asignatura GetSelectWhereNameAsignatura(string materia)
        {
            var client = new RestClient("https://localhost:44349");
            var resource = "/Materia/"+materia;
            var request = new RestRequest(resource, Method.Get);

            var response = client.ExecuteAsync<Models.Asignatura>(request).GetAwaiter().GetResult();
            var jsonResponse = JsonConvert.DeserializeObject<Models.Asignatura>(response.Content);

            return jsonResponse;
        }
    }
}