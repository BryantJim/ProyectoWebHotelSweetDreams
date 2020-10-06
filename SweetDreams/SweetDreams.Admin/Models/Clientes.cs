using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetDreams.Admin.Models
{
    public class Clientes
    {
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string NombreUsuario { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public bool Accesibilidad { get; set; }
        public Clientes()
        {
            ClienteId = 0;
            Nombres = string.Empty;
            NombreUsuario = string.Empty;
            Telefono = string.Empty;
            Correo = string.Empty;
            Clave = string.Empty;
            Accesibilidad = true;
        }

        public Clientes(int clienteId, string nombres, string nombreUsuario, string telefono, string correo, string clave, bool accesibilidad)
        {
            ClienteId = clienteId;
            Nombres = nombres;
            NombreUsuario = nombreUsuario;
            Telefono = telefono;
            Correo = correo;
            Clave = clave;
            Accesibilidad = accesibilidad;
        }
    }
}
