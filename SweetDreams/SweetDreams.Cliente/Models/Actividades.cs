using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweetDreams.Cliente.Models
{
    public class Actividades
    {
        [Key]
        public int ActividadId { get; set; }
        public string NombreActividad { get; set; }
        public string Descripcion { get; set; }
        public string Lugar { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinal { get; set; }
        public bool Accesibilidad { get; set; }

        public Actividades()
        {
            ActividadId = 0;
            NombreActividad = string.Empty;
            Descripcion = string.Empty;
            Lugar = string.Empty;
            Fecha = DateTime.Now;
            HoraInicio = DateTime.Now;
            HoraFinal = DateTime.Now;
            Accesibilidad = true;
        }
    }
}
