using Facturacion.DTO;
using System.Net.Http.Headers;

namespace Facturacion.Services
{
    public class CategoriaService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;

        public CategoriaService(HttpClient httpClient, AuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<List<CategoriaResponse>> GetCategorias()
        {
            try
            {
                // Obtener el token de autenticación si es necesario
                // var token = await _authService.GetToken();
                // if (string.IsNullOrEmpty(token))
                // {
                //     throw new InvalidOperationException("El token es nulo o inválido. Iniciar Sesión");
                // }

                // Incluir el token en el encabezado de la petición (si se requiere autenticación)
                // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

                // Llamar al endpoint para obtener la lista de categorías
                var response = await _httpClient.GetFromJsonAsync<List<CategoriaResponse>>("api/categorias");

                return response;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al obtener categorías. Revisar conexión a internet");
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error inesperado al obtener categorías");
            }
        }
    }
}
