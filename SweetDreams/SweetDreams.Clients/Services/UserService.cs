using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweetDreams.Clients.Models;

namespace SweetDreams.Clients.Services
{
    public interface IUserService
    {
        Task<IEnumerable<Cliente>> GetAll();
    }
    public class UserService : IUserService
    {
        private IHttpService _httpService;

        public UserService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _httpService.Get<IEnumerable<Cliente>>("/Clientes");
        }
    }
}
