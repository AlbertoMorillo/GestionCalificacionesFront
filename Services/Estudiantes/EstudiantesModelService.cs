using GestionCalificaciones.ViewModel.Estudiantes;
using GestionCalificaciones.ViewModel.Usuarios;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GestionCalificaciones.Services.Estudiantes
{
    public class EstudiantesModelService
    {
        private const string URL = "https://localhost:44349/api/Estudiantes";
        internal List<EstudiantesViewMode> GetSelectWhere(object p1, object p2, object p3, object p4, string resetCode)
        {
            throw new NotImplementedException();
        }

        internal void UpdatePasswordCode(object idUsuario, string v)
        {
            throw new NotImplementedException();
        }

        internal List<EstudiantesViewMode> GetSelectWhere(object p1, object p2, string email, object p3)
        {
            throw new NotImplementedException();
        }

        internal List<EstudiantesViewMode> GetSelectWhere(object p, string usuario)
        {
            throw new NotImplementedException();
        }

        internal EstudiantesViewMode GetSelectWhere(int idUsuario)
        {
            var client = new RestClient(URL);
            var request = new RestRequest(idUsuario.ToString(), Method.Get);

            var response = client.ExecuteAsync<EstudiantesViewMode>(request).GetAwaiter().GetResult();
            var jsonResponse = JsonConvert.DeserializeObject<EstudiantesViewMode>(response.Content);
            EstudiantesViewMode user = new EstudiantesViewMode
            {
                IdEstudiante = jsonResponse.IdEstudiante,
                IdUsuario = jsonResponse.IdUsuario,
                IdEscuela = jsonResponse.IdEscuela,
                IdPais = jsonResponse.IdPais,
                IdTipoDocumento = jsonResponse.IdTipoDocumento,
                IdDistritoMunicipal = jsonResponse.IdDistritoMunicipal,
                IdEstadoCivil = jsonResponse.IdEstadoCivil,
                IdOcupacion = jsonResponse.IdOcupacion,
                Matricula = jsonResponse.Matricula,
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

        internal EstudiantesViewMode GetSelectWhere(string idUsuario)
        {
            var client = new RestClient(URL);
            var request = new RestRequest(idUsuario, Method.Get);

            var response = client.ExecuteAsync<EstudiantesViewMode>(request).GetAwaiter().GetResult();
            var jsonResponse = JsonConvert.DeserializeObject<EstudiantesViewMode>(response.Content);
            EstudiantesViewMode user = new EstudiantesViewMode
            {
                IdEstudiante = jsonResponse.IdEstudiante,
                IdUsuario = jsonResponse.IdUsuario,
                IdEscuela = jsonResponse.IdEscuela,
                IdPais = jsonResponse.IdPais,
                IdTipoDocumento = jsonResponse.IdTipoDocumento,
                IdDistritoMunicipal = jsonResponse.IdDistritoMunicipal,
                IdEstadoCivil = jsonResponse.IdEstadoCivil,
                IdOcupacion = jsonResponse.IdOcupacion,
                Matricula = jsonResponse.Matricula,
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
    }
}