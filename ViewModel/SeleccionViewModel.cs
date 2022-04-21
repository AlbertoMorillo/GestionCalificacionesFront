using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCalificaciones.ViewModel
{
    public class SeleccionViewModel
    {
        public int? IdSeleccion { get; set; }
        public int semestre { get; set; }
        public string matriculan { get; set; }

        public int? escuela { get; set; }
        public int? pensum { get; set; }
        public string materia { get; set; }
        public int? grupo { get; set; }
        public int? tipo { get; set; }
        public decimal estatusel { get; set; }
        public DateTime? fechas { get; set; }
        public DateTime? fechar { get; set; }
        public string usuario { get; set; }
        public decimal? tiposel { get; set; }
        public int? estatusret { get; set; }
        public bool? replicado { get; set; }
        public bool? pagado { get; set; }
        public int idSeleccion { get; set; }
    }
}