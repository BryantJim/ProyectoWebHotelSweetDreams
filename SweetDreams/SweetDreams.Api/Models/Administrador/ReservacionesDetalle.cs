using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweetDreams.Api.Models.Administrador
{
    public class ReservacionesDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int ReservacionId { get; set; }
        public string NumeroHabitacion { get; set; }
        public int CantidadAdultos { get; set; }
        public int CantidadNinos { get; set; }
        public string Tipo { get; set; }
        public decimal Precio { get; set; }

        [ForeignKey("HabitacionId")]
        public int HabitacionId { get; set; }
    }
}
