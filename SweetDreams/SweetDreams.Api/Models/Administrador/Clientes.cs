using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SweetDreams.Api.Models.Administrador
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string NombreUsuario { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public bool Accesibilidad { get; set; }
    }
}
