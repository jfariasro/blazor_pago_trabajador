using AppWebBlazor2.Client.Services.Interfaces;
using AppWebBlazor2.Shared;
using System.Net.Http.Json;

namespace AppWebBlazor2.Client.Services.Entities
{
    public class PagoService : IPagoService
    {
        private readonly HttpClient _httpClient;

        public PagoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> Editar(int id, PagoDTO pagoDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Pago/Editar/{id}", pagoDTO);

            var result = response.IsSuccessStatusCode ? true : false;

            return result;
        }

        public async Task<bool> Eliminar(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Pago/Eliminar/{id}");

            var result = response.IsSuccessStatusCode ? true : false;

            return result;
        }

        public async Task<List<PagoDTO>> Listar()
        {
            var lista = new List<PagoDTO>();

            lista = await _httpClient.GetFromJsonAsync<List<PagoDTO>>("api/Pago/Listar");

            return lista!;
        }

        public async Task<bool> Registrar(PagoDTO pagoDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Pago/Registrar", pagoDTO);

            var result = response.IsSuccessStatusCode ? true : false;

            return result;
        }

    }
}
