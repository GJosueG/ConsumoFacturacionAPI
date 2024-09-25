using Facturacion.DTO;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.IdentityModel.Tokens.Jwt;
using System.Net.NetworkInformation;

namespace Facturacion.Services
{
    public class AuthService
    {
        private readonly ProtectedBrowserStorage _localstorage;
        private readonly HttpClient _httpClient;
        private string? _token;

        public AuthService(ProtectedBrowserStorage localstorage, HttpClient httpClient)
        {
            _localstorage = localstorage;
            _httpClient = httpClient;
        }

        public async Task<string> Login(UsuarioSession usersession)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/usuarios/login", usersession);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<string>();
                return result;
            }

            return null;
        }

        //Guardar token en el navegador
        public async Task SetToken(string token)
        {
            _token = token;
            await _localstorage.SetAsync("token", token);
        }

        //Obtener token del navegador
        public async Task<string> GetToken()
        {
            if (string.IsNullOrEmpty(_token))
            {
                var localStorageResult = await _localstorage.GetAsync<string>("token");
                if (localStorageResult.Success || string.IsNullOrEmpty(localStorageResult.Value))
                {
                    _token = null;
                    return null;
                }
                _token = localStorageResult.Value;
            }       
            
            return _token;
        }

        //Verificar si el usuario esta autenticado
        public async Task<bool> IsAuthenticated()
        {
            var token = await GetToken();

            return !string.IsNullOrEmpty(token) && !IsTokenExpired(token);
        }

        //verificar si el token ha expirado
        public bool IsTokenExpired(string token)
        {
            var jwToken = new JwtSecurityToken(token);
            return jwToken.ValidTo < DateTime.UtcNow;
        }

        //Cerrar Sesión
        public async Task LogOut()
        {
            _token= null;
            await _localstorage.DeleteAsync("token");
        }
       
    }
}
