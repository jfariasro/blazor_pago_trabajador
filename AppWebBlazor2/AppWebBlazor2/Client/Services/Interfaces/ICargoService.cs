using AppWebBlazor2.Shared;

namespace AppWebBlazor2.Client.Services.Interfaces
{
    public interface ICargoService
    {
        Task<List<CargoDTO>> Listar();

        Task<bool> Registrar(CargoDTO cargoDTO);

        Task<bool> Editar(int id, CargoDTO cargoDTO);

        Task<bool> Eliminar(int id);
    }
}
