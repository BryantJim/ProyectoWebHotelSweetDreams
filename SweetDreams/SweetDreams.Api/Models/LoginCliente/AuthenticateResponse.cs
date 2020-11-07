using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweetDreams.Api.Models.Administrador;

namespace SweetDreams.Api.Models.LoginCliente
{
    public class AuthenticateResponse
    {
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string NombreUsuario { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public bool Accesibilidad { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(Clientes cliente, string token)
        {
            ClienteId = cliente.ClienteId;
            Nombres = cliente.Nombres;
            NombreUsuario = cliente.NombreUsuario;
            Telefono = cliente.Telefono;
            Correo = cliente.Correo;
            Clave = cliente.Clave;
            Accesibilidad = cliente.Accesibilidad;
            Token = token;
        }
    }
}
