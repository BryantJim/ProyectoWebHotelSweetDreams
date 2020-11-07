using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using SweetDreams.Api.Models.Administrador;
using SweetDreams.Api.Helpers;
using SweetDreams.Api.Models.LoginCliente;
using SweetDreams.Api.DAL;

namespace SweetDreams.Api.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<Clientes> GetAll();
        Clientes GetById(int id);
    }
    public class UserService : IUserService
    {
        private Contexto contexto;

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<Clientes> _clientes = new List<Clientes>();

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, Contexto contexto)
        {
            _appSettings = appSettings.Value;
            _clientes = contexto.Clientes.Where(h => h.Accesibilidad == true).ToList();
            this.contexto = contexto;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var cliente = _clientes.SingleOrDefault(x => x.NombreUsuario == model.Username && x.Clave == model.Password);

            // return null if user not found
            if (cliente == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(cliente);

            return new AuthenticateResponse(cliente, token);
        }

        public IEnumerable<Clientes> GetAll()
        {
            return _clientes;
        }

        public Clientes GetById(int id)
        {
            return _clientes.FirstOrDefault(x => x.ClienteId == id);
        }

        // helper methods

        private string generateJwtToken(Clientes cliente)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", cliente.ClienteId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
