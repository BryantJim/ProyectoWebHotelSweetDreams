using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweetDreams.Client.Models
{
    public class Reservaciones
    {
        [Key]
        public int ReservacionId { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public DateTime FechaInicio { get; set; }
        
        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public DateTime FechaSalida { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public string NumeroTarjeta { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public DateTime FechaExpiracion { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public string CodigoSeguridad { get; set; }

        public decimal Balance { get; set; }

        public bool Accesibilidad { get; set; }

        [ForeignKey("ReservacionId")]
        public List<ReservacionesDetalle> ReservacionDetalle { get; set; }



        public Reservaciones()
        {
            ReservacionId = 0;
            FechaInicio = DateTime.Now;
            FechaSalida = DateTime.Now;
            NumeroTarjeta = string.Empty;
            FechaExpiracion = DateTime.Now;
            CodigoSeguridad = string.Empty;
            Balance = 0;
            ReservacionDetalle = new List<ReservacionesDetalle>();
            Accesibilidad = true;
        }
    }
}
