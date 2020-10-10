using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweetDreams.Client.Models
{
    public class Cliente
    {
        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public string Clave { get; set; }

        public bool Accesibilidad { get; set; }
    }
    
}
