using GestionCalificaciones.Models;
using GestionCalificaciones.ViewModel.Calificaciones;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.Services
{
    public class CalificacionModelService
    {
        internal List<Calificacion> getSelectWhere(int codigoProfesor, string materia, int? grupo, int semestre)
        {
            var client = new RestClient("https://localhost:44349/api/Calificacions/");
            var resource = "";
            if(grupo.HasValue)
                resource = codigoProfesor + "/" + materia + "/" + grupo + "/" + semestre;
            else
                resource = codigoProfesor + "/" + materia + "/" + semestre;
            var request = new RestRequest(resource, Method.Get);

            var response = client.ExecuteAsync<List<Models.Calificacion>>(request).GetAwaiter().GetResult();
            var jsonResponse = JsonConvert.DeserializeObject<List<Models.Calificacion>>(response.Content);

            return jsonResponse;
        }

        internal Models.Calificacion getSelectWhere(int profesor, int? materia, int? grupo, int semestre, string matriculan)
        {
            var client = new RestClient("https://localhost:44349/api/Calificacions/");
            var resource = "";

            resource = profesor + "/" + materia + "/" + grupo + "/" + semestre + "/"+matriculan;
            var request = new RestRequest(resource, Method.Get);

            var response = client.ExecuteAsync<Models.Calificacion>(request).GetAwaiter().GetResult();
            var jsonResponse = JsonConvert.DeserializeObject<Models.Calificacion>(response.Content);

            return jsonResponse;
        }

        internal void SaveChange(List<CalificacionesViewModel> calificaiconViewList)
        {
            foreach (var c in calificaiconViewList)
            {
                var Calificacion = new Calificacion
                {
                    Semestre = Convert.ToInt32(c.semestre),
                    Matriculan = c.matriculan,
                    Escuela = c.escuela,
                    Pensum = c.pensum,
                    Materia = Convert.ToInt32(c.Materia),
                    Grupo = c.grupo,
                    Tipo = c.tipo,
                    Parcial = c.parcial,
                    Practica = c.practica,
                    Final = c.final,
                    Total = c.total,
                    Estatus = c.estatus,
                    Tpractico = c.tpractico,
                    Usuario = Convert.ToInt32(c.usuario),
                    Codigoprof = c.codigoprof,
                    Nl = c.notaLiteral
                };
                var client = new RestClient("https://localhost:44349/api/Calificacions/");
                var request = new RestRequest();
                request.AddBody(Calificacion);
                var response = client.PostAsync(request).GetAwaiter().GetResult();
                var jsonResponse = JsonConvert.DeserializeObject<Models.Calificacion>(response.Content);
            }
        }
    }
}