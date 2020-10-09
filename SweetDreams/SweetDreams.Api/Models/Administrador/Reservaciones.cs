using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweetDreams.Api.Models.Administrador
{
    public class Reservaciones
    {
        [Key]
        public int ReservacionId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string Tarjeta { get; set; }
        public string Codigo { get; set; }
        public decimal Balance { get; set; }

        [ForeignKey("ReservacionId")]
        public List<ReservacionesDetalle> ReservacionDetalle { get; set; }
    }
}
