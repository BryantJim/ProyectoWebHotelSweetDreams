using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweetDreams.Clients.Models
{
    public class Reservaciones
    {
        public int ReservacionId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaSalida { get; set; }
        public decimal Balance { get; set; }
        public string Tarjeta { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaExpiracion { get; set; }

        public bool Accesibilidad { get; set; }

        public List<ReservacionesDetalle> ReservacionDetalle { get; set; }

        public Reservaciones()
        {
            ReservacionId = 0;
            FechaInicio = DateTime.Now;
            FechaSalida = DateTime.Now;
            FechaExpiracion = DateTime.Now;
            Tarjeta = string.Empty;
            Codigo = string.Empty;
            Balance = 0;
            ReservacionDetalle = new List<ReservacionesDetalle>();
            Accesibilidad = true;
        }

        public Reservaciones(int reservacionId, DateTime fechaInicio, DateTime fechaSalida, DateTime fechaExpiracion, string tarjeta, string codigo, decimal balance, List<ReservacionesDetalle> reservacionDetalle, bool accesabilidad)
        {
            ReservacionId = reservacionId;
            FechaInicio = fechaInicio;
            FechaSalida = fechaSalida;
            FechaExpiracion = fechaExpiracion;
            Tarjeta = tarjeta;
            Codigo = codigo;
            Balance = Balance;
            ReservacionDetalle = reservacionDetalle;
            Accesibilidad = accesabilidad;
        }
    }
}
