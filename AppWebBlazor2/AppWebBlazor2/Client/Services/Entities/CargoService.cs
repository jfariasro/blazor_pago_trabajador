using AppWebBlazor2.Client.Services.Interfaces;
using AppWebBlazor2.Shared;
using System.Net.Http.Json;

namespace AppWebBlazor2.Client.Services.Entities
{
    public class CargoService : ICargoService
    {
        private readonly HttpClient _httpClient;

        public CargoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> Editar(int id, CargoDTO cargoDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Cargo/Editar/{id}", cargoDTO);

            var result = response.IsSuccessStatusCode ? true : false;

            return result;
        }

        public async Task<bool> Eliminar(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Cargo/Eliminar/{id}");

            var result = response.IsSuccessStatusCode ? true : false;

            return result;
        }

        public async Task<List<CargoDTO>> Listar()
        {
            var lista = new List<CargoDTO>();

            lista = await _httpClient.GetFromJsonAsync<List<CargoDTO>>("api/Cargo/Listar");

            return lista!;
        }

        public async Task<bool> Registrar(CargoDTO cargoDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Cargo/Registrar", cargoDTO);

            var result = response.IsSuccessStatusCode ? true : false;

            return result;
        }
    }
}
