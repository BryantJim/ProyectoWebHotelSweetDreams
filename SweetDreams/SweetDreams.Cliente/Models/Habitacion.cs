using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweetDreams.Cliente.Models
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

        public Habitacion()
        {
            HabitacionId = 0;
            NumeroHabitacion = string.Empty;
            Tipo = string.Empty;
            CaracteristicasSelecciones = string.Empty;
            Caracteriscas = string.Empty;
            Precio = 0;
            Foto = null;
            Estado = true;
            Accesibilidad = true;
        }

        public Habitacion(int Habitacionid, string numeroHabitacion, string tipo, string caracteristicasSelecciones, string caracteriscas, decimal precio, string foto, bool estado, bool accesibilidad)
        {
            HabitacionId = Habitacionid;
            NumeroHabitacion = numeroHabitacion;
            Tipo = tipo;
            CaracteristicasSelecciones = caracteristicasSelecciones;
            Caracteriscas = caracteriscas;
            Precio = precio;
            Foto = foto;
            Estado = estado;
            Accesibilidad = accesibilidad;
        }
    }
}
