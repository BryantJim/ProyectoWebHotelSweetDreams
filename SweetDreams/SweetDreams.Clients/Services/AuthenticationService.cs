using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SweetDreams.Clients.Models;

namespace SweetDreams.Clients.Services
{
    public interface IAuthenticationService
    {
        Cliente cliente { get; }
        Task Initialize();
        Task Login(string username, string password);
        Task Logout();
    }
    public class AuthenticationService : IAuthenticationService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        public Cliente cliente { get; private set; }

        public AuthenticationService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        )
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            cliente = await _localStorageService.GetItem<Cliente>("Clientes");
        }

        public async Task Login(string username, string password)
        {
            cliente = await _httpService.Post<Cliente>($"http://localhost:5000/Api/Clientes/authenticate", new { username, password });
            await _localStorageService.SetItem("Clientes", cliente);
        }

        public async Task Logout()
        {
            cliente = null;
            await _localStorageService.RemoveItem("Clientes");
            _navigationManager.NavigateTo("login");
        }
    }
}
