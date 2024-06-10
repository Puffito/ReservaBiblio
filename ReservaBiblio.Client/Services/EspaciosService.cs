using ReservaBiblio.Shared;
using System.Net.Http.Json;

namespace ReservaBiblio.Client.Services
{
    public class EspaciosService : IEspaciosService
    {
        private readonly HttpClient _http;

        public EspaciosService(HttpClient http)
        {
            _http = http;
        }

        public async Task<EspaciosDTO> Buscar(string clave)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<EspaciosDTO>>("api/espacios/Buscar{clave}");

            if (result!.EsCorrecto)
            {
                return result.Valor!;
            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }

        public async Task<List<EspaciosDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<EspaciosDTO>>>("api/espacios/Lista");

            if (result!.EsCorrecto)
            {
                return result.Valor!;
            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }
    }
}
