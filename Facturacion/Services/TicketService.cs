using Facturacion.DTO;

namespace Facturacion.Services
{
    public class TicketService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;

        public TicketService(HttpClient httpClient, AuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<List<TicketResponse>> GetTickets() 
        {
            try
            {
                //var token = await _authService.GetToken();

                //if (string.IsNullOrEmpty(token))
                //{
                //    throw new InvalidOperationException("El token es nulo o inválido. Iniciar Sesión");
                //}

                //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                var response = await _httpClient.GetFromJsonAsync<List<TicketResponse>>("api/tickets");

                return response;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error el obtener tickets. Revisar conexión a internet");
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error inesperado al obtener tickets");
            }
        }
    }
}
