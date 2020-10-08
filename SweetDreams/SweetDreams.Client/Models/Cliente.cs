using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetDreams.Client.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string NumeroTelefono { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }

        public Cliente()
        {
            ClienteId = 0;
            Nombre = string.Empty;
            NumeroTelefono = string.Empty;
            NombreUsuario = string.Empty;
            Correo = string.Empty;
            Clave = string.Empty;
        }

        public Cliente(int clienteId, string nombre, string numeroTelefono, string nombreUsuario, string correo, string clave)
        {
            ClienteId = clienteId;
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            NumeroTelefono = numeroTelefono ?? throw new ArgumentNullException(nameof(numeroTelefono));
            NombreUsuario = nombreUsuario ?? throw new ArgumentNullException(nameof(nombreUsuario));
            Correo = correo ?? throw new ArgumentNullException(nameof(correo));
            Clave = clave ?? throw new ArgumentNullException(nameof(clave));
        }

    }
    
}
