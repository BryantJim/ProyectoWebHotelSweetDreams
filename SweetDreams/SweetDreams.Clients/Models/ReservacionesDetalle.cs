using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SweetDreams.Clients.Models
{
    public class ReservacionesDetalle
    {
        public int DetalleId { get; set; }
        public int ReservacionId { get; set; }
        public string NumeroHabitacion { get; set; }
        public int CantidadAdultos { get; set; }
        public int CantidadNinos { get; set; }
        public string Tipo { get; set; }
        public decimal Precio { get; set; }
        public int HabitacionId { get; set; }

        public ReservacionesDetalle()
        {
            DetalleId = 0;
            ReservacionId = 0;
            CantidadAdultos = 0;
            CantidadNinos = 0;
            Tipo = string.Empty;
            Precio = 0;
        }

        public ReservacionesDetalle(int detalleId, int reservacionId, string numeroHabitacion, int cantidadAdultos, int cantidadNinos, string tipo, decimal precio)
        {
            DetalleId = detalleId;
            ReservacionId = reservacionId;
            NumeroHabitacion = numeroHabitacion;
            CantidadAdultos = cantidadAdultos;
            CantidadNinos = cantidadNinos;
            Tipo = tipo;
            Precio = precio;
        }
    }
}
