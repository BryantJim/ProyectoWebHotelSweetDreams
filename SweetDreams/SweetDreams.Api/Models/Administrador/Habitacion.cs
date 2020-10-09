using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweetDreams.Api.Models.Administrador
{
    public class Habitacion
    {
        [Key]
        public int HabitacionId { get; set; }
        public string NumeroHabitacion { get; set; }
        public string Tipo { get; set; }
        public string CaracteristicasSelecciones { get; set; }
        public string Caracteriscas { get; set; }
        public decimal Precio { get; set; }
        public string Foto { get; set; }
        public bool Estado { get; set; }
        public bool Accesibilidad { get; set; }
    }
}
