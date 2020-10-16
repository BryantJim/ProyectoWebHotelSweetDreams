using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetDreams.Admin.Models
{
    public class Actividades
    {
        public int ActividadId { get; set; }
        public string NombreActividad { get; set; }
        public string Descripcion { get; set; }
        public string Lugar { get; set; }
        public DateTime Fecha { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFinal { get; set; }
        public bool Accesibilidad { get; set; }

        public Actividades()
        {
            ActividadId = 0;
            NombreActividad = string.Empty;
            Descripcion = string.Empty;
            Lugar = string.Empty;
            Fecha = DateTime.Now;
            HoraInicio = string.Empty;
            HoraFinal = string.Empty;
            Accesibilidad = true;
        }
    }
}
