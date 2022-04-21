using GestionCalificaciones.ViewModel.Empleados;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.Services.Empleados
{
    public class EmpleadosModelService
    {
        private const string URL = "https://localhost:44349/api/Empleadoes";
        public List<EmpleadosViewMode> GetSelectWhere(int? IdEmpleado)
        {
            
            return null;
        }

        public List<EmpleadosViewMode> GetSelectWhere(int? IdEmpleado, string CorreoEletronico)
        {
            return null;
        }


        public EmpleadosViewMode GetSelectWhere(int IdUsuario)
        {

            var client = new RestClient(URL);
            var request = new RestRequest(IdUsuario.ToString(), Method.Get);

            var response = client.ExecuteAsync<EmpleadosViewMode>(request).GetAwaiter().GetResult();
            var jsonResponse = JsonConvert.DeserializeObject<EmpleadosViewMode>(response.Content);
            EmpleadosViewMode user = new EmpleadosViewMode
            {

                IdEmpleado = jsonResponse.IdEmpleado,
                IdUsuario = jsonResponse.IdUsuario,
                IdPais = jsonResponse.IdPais,
                IdTipoDocumento = jsonResponse.IdTipoDocumento,
                IdDistritoMunicipal = jsonResponse.IdDistritoMunicipal,
                IdEstadoCivil = jsonResponse.IdEstadoCivil,
                PrimerNombre = jsonResponse.PrimerNombre,
                SegundoNombre = jsonResponse.SegundoNombre,
                PrimerApellido = jsonResponse.PrimerApellido,
                SegundoApellido = jsonResponse.SegundoApellido,
                FechaNacimiento = jsonResponse.FechaNacimiento,
                Sexo = jsonResponse.Sexo,
                Documento = jsonResponse.Documento,
                Direccion = jsonResponse.Direccion,
                Telefono = jsonResponse.Telefono,
                Celular = jsonResponse.Celular,
                CorreoElectronico = jsonResponse.CorreoElectronico,
                DistritosMunicipales = jsonResponse.DistritosMunicipales,
                Usuarios = jsonResponse.Usuarios
            };
            return user;
        }
        public List<EmpleadosViewMode> GetSelectWhere(int? IdEmpleado, string CorreoEletronico = null, string Documento = null, string resetCode = null)
        {
            return null;
        }

        
    }
}