//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionCalificaciones.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class GestionCalificacionDBEntities1 : DbContext
    {
        public GestionCalificacionDBEntities1()
            : base("name=GestionCalificacionDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<spes_CalificacionEstudiante_Result> spes_CalificacionEstudiante(string materia, Nullable<int> grupo, Nullable<int> semestre)
        {
            var materiaParameter = materia != null ?
                new ObjectParameter("materia", materia) :
                new ObjectParameter("materia", typeof(string));
    
            var grupoParameter = grupo.HasValue ?
                new ObjectParameter("grupo", grupo) :
                new ObjectParameter("grupo", typeof(int));
    
            var semestreParameter = semestre.HasValue ?
                new ObjectParameter("semestre", semestre) :
                new ObjectParameter("semestre", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spes_CalificacionEstudiante_Result>("spes_CalificacionEstudiante", materiaParameter, grupoParameter, semestreParameter);
        }
    
        public virtual ObjectResult<spes_Calificaciones_Result> spes_Calificaciones(string matricula, Nullable<int> semestre)
        {
            var matriculaParameter = matricula != null ?
                new ObjectParameter("matricula", matricula) :
                new ObjectParameter("matricula", typeof(string));
    
            var semestreParameter = semestre.HasValue ?
                new ObjectParameter("semestre", semestre) :
                new ObjectParameter("semestre", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spes_Calificaciones_Result>("spes_Calificaciones", matriculaParameter, semestreParameter);
        }
    }
}
