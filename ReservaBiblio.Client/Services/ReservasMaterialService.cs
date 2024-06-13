using ReservaBiblio.Shared;
using System.Net.Http.Json;

namespace ReservaBiblio.Client.Services
{
    public class ReservasMaterialService : IReservasMaterialService
    {
        private readonly HttpClient _http;

        public ReservasMaterialService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ReservasMaterialDTO> Buscar(int Id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<ReservasMaterialDTO>>("api/ReservasMaterial/Buscar/{Id}");

            if (result!.EsCorrecto)
            {
                return result.Valor!;
            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }

        public async Task<List<ReservasMaterialDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<ReservasMaterialDTO>>>("api/ReservasMaterial/Lista");

            if (result!.EsCorrecto)
            {
                return result.Valor!;
            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }
        public async Task<int> Guardar(ReservasMaterialDTO ReservasMaterial)
        {
            var result = await _http.PostAsJsonAsync("api/ReservasMaterial/Guardar", ReservasMaterial);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
            {
                return response.Valor!;
            }
            else
            {
                throw new Exception(response.Mensaje);
            }
        }

        public async Task<int> Editar(ReservasMaterialDTO ReservasMaterial)
        {
            var result = await _http.PutAsJsonAsync($"api/ReservasMaterial/Editar/{ReservasMaterial.Id}", ReservasMaterial);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
            {
                return response.Valor!;
            }
            else
            {
                throw new Exception(response.Mensaje);
            }
        }

        public async Task<bool> Eliminar(int Id)
        {
            var result = await _http.DeleteAsync($"api/ReservasMaterial/Eliminar/{Id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
            {
                return response.EsCorrecto!;
            }
            else
            {
                throw new Exception(response.Mensaje);
            }
        }
    }
}
