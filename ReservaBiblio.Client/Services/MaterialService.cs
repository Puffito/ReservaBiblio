using ReservaBiblio.Shared;
using System.Net.Http.Json;

namespace ReservaBiblio.Client.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly HttpClient _http;

        public MaterialService(HttpClient http)
        {
            _http = http;
        }

        public async Task<MaterialDTO> Buscar(string clave)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<MaterialDTO>>("api/Material/Buscar{clave}");

            if (result!.EsCorrecto)
            {
                return result.Valor!;
            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }

        public async Task<List<MaterialDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<MaterialDTO>>>("api/Material/Lista");

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