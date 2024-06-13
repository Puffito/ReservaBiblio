using ReservaBiblio.Shared;
using System.Net.Http.Json;

namespace ReservaBiblio.Client.Services
{
    public class ReservasEspaciosService : IReservasEspaciosService
    {
        private readonly HttpClient _http;

        public ReservasEspaciosService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ReservasEspaciosDTO> Buscar(int Id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<ReservasEspaciosDTO>>("api/ReservasEspacios/Buscar/{Id}");

            if (result!.EsCorrecto)
            {
                return result.Valor!;
            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }

        public async Task<List<ReservasEspaciosDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<ReservasEspaciosDTO>>>("api/ReservasEspacios/Lista");

            if (result!.EsCorrecto)
            {
                return result.Valor!;
            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }
        public async Task<int> Guardar(ReservasEspaciosDTO ReservaEspacios)
        {
            var result = await _http.PostAsJsonAsync("api/ReservasEspacios/Guardar", ReservaEspacios);
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

        public async Task<int> Editar(ReservasEspaciosDTO ReservaEspacios)
        {
            var result = await _http.PutAsJsonAsync($"api/ReservasEspacios/Editar/{ReservaEspacios.Id}", ReservaEspacios);
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
            var result = await _http.DeleteAsync($"api/ReservasEspacios/Eliminar/{Id}");
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
