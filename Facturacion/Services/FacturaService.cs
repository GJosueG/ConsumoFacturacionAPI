using Facturacion.DTO;
using System.Net.Http.Headers;

namespace Facturacion.Services
{
    public class FacturaService
    {
      private readonly HttpClient _httpClient;
      private readonly AuthService _authService;

        public FacturaService(HttpClient httpClient, AuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<List<FacturaResponse>> GetFacturas()
        {
            try
            {
               //var token = await _authService.GetToken();

               // if (string.IsNullOrWhiteSpace(token))
               // {
               //     throw new InvalidOperationException("El token es nulo o invalido. Iniciar sesión");
               // }

               // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                var response = await _httpClient.GetFromJsonAsync<List<FacturaResponse>>("api/facturas");

                return response;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al obtener facturas. Revisar conexión a internet");
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error inesperado al obtener facturas");
            }
        }
    } 
}

