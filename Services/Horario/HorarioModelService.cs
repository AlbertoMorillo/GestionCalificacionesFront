using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.Services.Horario
{
    public class HorarioModelService
    {
        private const string URL = "https://localhost:44349/api/Horarios/";
        public List<string> GetHorarioDistinct(int v1, string v2)
        {
            var client = new RestClient(URL);
            var resuorce = v1 + "/" + int.Parse(v2);
            var request = new RestRequest(resuorce, Method.Get);

            var response = client.ExecuteAsync<List<string>>(request).GetAwaiter().GetResult();
            var jsonResponse = JsonConvert.DeserializeObject<List<string>>(response.Content);

            return jsonResponse;
            
        }

        internal List<int?> GetGruposDistinct(string v, int sEMESTRE_ACTUAL, int codigoProfesor)
        {
            var client = new RestClient(URL);
            var resource = int.Parse(v) + "/" + sEMESTRE_ACTUAL + "/" + codigoProfesor;
            var request = new RestRequest(resource, Method.Get);

            var response = client.ExecuteAsync<List<int?>>(request).GetAwaiter().GetResult();
            var jsonResponse = JsonConvert.DeserializeObject<List<int?>>(response.Content);

            return jsonResponse;
        }

        internal List<Models.Horario> GetCalificacionEstudiante(string v, int sEMESTRE_ACTUAL, int codigoProfesor)
        {
            var client = new RestClient("https://localhost:44349/api/Calificacions/Init/");
            var resource = codigoProfesor+"/"+int.Parse(v) + "/" + sEMESTRE_ACTUAL ;
            var request = new RestRequest(resource, Method.Get);

            var response = client.ExecuteAsync<List<Models.Horario>>(request).GetAwaiter().GetResult();
            var jsonResponse = JsonConvert.DeserializeObject<List<Models.Horario>>(response.Content);

            return jsonResponse;
        }
    }
}