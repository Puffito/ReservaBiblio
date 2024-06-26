﻿using ReservaBiblio.Shared;
using System.Net.Http.Json;

namespace ReservaBiblio.Client.Services
{
    public class ProfesoresService : IProfesoresService
    {
        private readonly HttpClient _http;

        public ProfesoresService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ProfesoresDTO> Buscar(int Id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<ProfesoresDTO>>("api/Profesores/Buscar/{Id}");

            if (result!.EsCorrecto)
            {
                return result.Valor!;
            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }

        public async Task<ProfesoresDTO> BuscarCorreo(string Correo)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<ProfesoresDTO>>("api/Profesores/BuscarCorreo/{Correo}");

            if (result!.EsCorrecto)
            {
                return result.Valor!;
            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }

        public async Task<List<ProfesoresDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<ProfesoresDTO>>>("api/Profesores/Lista");

            if (result!.EsCorrecto)
            {
                return result.Valor!;
            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }
        public async Task<int> Guardar(ProfesoresDTO Profesor)
        {
            var result = await _http.PostAsJsonAsync("api/Profesores/Guardar", Profesor);
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

        public async Task<int> Editar(ProfesoresDTO Profesor)
        {
            var result = await _http.PutAsJsonAsync($"api/Profesores/Editar/{Profesor.Id}", Profesor);
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
            var result = await _http.DeleteAsync($"api/Profesores/Eliminar/{Id}");
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
