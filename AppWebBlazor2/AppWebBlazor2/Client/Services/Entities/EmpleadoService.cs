using AppWebBlazor2.Client.Services.Interfaces;
using AppWebBlazor2.Shared;
using System.Net.Http.Json;

namespace AppWebBlazor2.Client.Services.Entities
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly HttpClient _httpClient;

        public EmpleadoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> Editar(int id, EmpleadoDTO empleadoDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Empleado/Editar/{id}", empleadoDTO);

            var result = response.IsSuccessStatusCode ? true : false;

            return result;
        }

        public async Task<bool> Eliminar(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Empleado/Eliminar/{id}");

            var result = response.IsSuccessStatusCode ? true : false;

            return result;
        }

        public async Task<List<EmpleadoDTO>> Listar()
        {
            var lista = new List<EmpleadoDTO>();

            lista = await _httpClient.GetFromJsonAsync<List<EmpleadoDTO>>("api/Empleado/Listar");

            return lista!;
        }

        public async Task<bool> Registrar(EmpleadoDTO empleadoDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Empleado/Registrar", empleadoDTO);

            var result = response.IsSuccessStatusCode ? true : false;

            return result;
        }
    }
}
