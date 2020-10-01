using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweetDreams.Admin.Models
{
    public class Habitacion
    {
        [Key]
        public int IdHabitacion { get; set; }
        public int NumeroHabitacion { get; set; }
        public string Tipo { get; set; }
        public string Caracteriscas { get; set; }
        public decimal Precio { get; set; }
        public string Foto { get; set; }
        public bool Estado { get; set; }
        public bool Accesibilidad { get; set; }

        public Habitacion()
        {
            IdHabitacion = 0;
            NumeroHabitacion = 0;
            Tipo = string.Empty;
            Caracteriscas = string.Empty;
            Precio = 0;
            Foto = null;
            Estado = true;
            Accesibilidad = true;
        }

        public Habitacion(int idHabitacion, int numeroHabitacion, string tipo, string caracteriscas, decimal precio, string foto, bool estado, bool accesibilidad)
        {
            IdHabitacion = idHabitacion;
            NumeroHabitacion = numeroHabitacion;
            Tipo = tipo;
            Caracteriscas = caracteriscas;
            Precio = precio;
            Foto = foto;
            Estado = estado;
            Accesibilidad = accesibilidad;
        }
    }
}
