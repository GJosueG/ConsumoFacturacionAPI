using Facturacion.DTO;
using System.Net.Http.Headers;

namespace Facturacion.Services
{
    public class ProductoService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;

        public ProductoService(HttpClient httpClient, AuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }
        public async Task<List<ProductoResponse>> GetProductos()
        {
            try
            {
                //var token = await _authService.GetToken();

                //if (string.IsNullOrEmpty(token))
                //{
                //    throw new InvalidOperationException("El token es nulo o inválido. Iniciar Sesión");
                //}

                //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                var response = await _httpClient.GetFromJsonAsync<List<ProductoResponse>>("api/productos");

                return response;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al obtener productos. Revisar conexión a internet");
            }
            catch (Exception ex) 
            {
                throw new Exception("Ha ocurrido un error inesperado al obtener productos");
            }

        }
    }
}
