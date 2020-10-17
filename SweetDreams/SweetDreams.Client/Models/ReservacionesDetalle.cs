using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public string NumeroHabitacion { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [Range(minimum: 1, maximum: 100000000, ErrorMessage = "Debe ingresar al menos un adulto")]
        public int CAdultos { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public int CNinos { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public string THabitacion { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public decimal Precio { get; set; }

        [ForeignKey("HabitacionId")]
        public int HabitacionId { get; set; }

        public ReservacionesDetalle()
        {
            DetalleId = 0;
            ReservacionId = 0;
            CAdultos = 0;
            CNinos = 0;
            THabitacion = string.Empty;
            Precio = 0;
           
        }

        public ReservacionesDetalle(int reservacionId,int cAdultos, int cNinos, string tHabitacion, int cantidadHabitacion, decimal precio, string imagen)
        {
            DetalleId = 0;
            ReservacionId = reservacionId;
            CAdultos = cAdultos;
            CNinos = cNinos;
            THabitacion = tHabitacion;
            Precio = precio;
           
        }

    }
}
