using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweetDreams.Client.Models
{
    public class ReservacionesDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public int ReservacionId { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [Range(minimum: 1, maximum: 100000000, ErrorMessage = "Debe ingresar al menos un adulto")]
        public int CAdultos { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public int CNinos { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [Range(minimum: 1, maximum: 100000000, ErrorMessage = "Debe seleccionar un tipo de habitacion")]
        public int THabitacion { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [Range(minimum: 1, maximum: 100000000, ErrorMessage = "Debe ingresar al menos una habitacion")]
        public int CantidadHabitacion { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public decimal Precio { get; set; }

        public string Imagen { get; set; }

        public ReservacionesDetalle()
        {
            DetalleId = 0;
            ReservacionId = 0;
            CAdultos = 0;
            CNinos = 0;
            THabitacion = 0;
            CantidadHabitacion = 0;
            Precio = 0;
            Imagen = string.Empty;
        }

        public ReservacionesDetalle(int reservacionId,int cAdultos, int cNinos, int tHabitacion, int cantidadHabitacion, decimal precio, string imagen)
        {
            DetalleId = 0;
            ReservacionId = reservacionId;
            CAdultos = cAdultos;
            CNinos = cNinos;
            THabitacion = tHabitacion;
            CantidadHabitacion = cantidadHabitacion;
            Precio = precio;
            Imagen = imagen;
        }

    }
}
