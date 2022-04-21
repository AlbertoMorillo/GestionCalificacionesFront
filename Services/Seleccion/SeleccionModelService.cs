using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.Services.Seleccion
{
    public class SeleccionModelService
    {
        private const string URL = "https://localhost:44349/api/Seleccions/";
        internal List<Models.Seleccion> GetCalificacionEstudiante(string materia, int sEMESTRE_ACTUAL, int? grupo)
        {
            var client = new RestClient(URL);
            var resource = materia+"/" + sEMESTRE_ACTUAL+"/"+grupo;
            var request = new RestRequest(resource, Method.Get);

            var response = client.ExecuteAsync<List<Models.Seleccion>>(request).GetAwaiter().GetResult();
            var jsonResponse = JsonConvert.DeserializeObject<List<Models.Seleccion>>(response.Content);

            return jsonResponse;
        }
    }
}