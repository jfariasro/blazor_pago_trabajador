using AppWebBlazor2.Shared;

namespace AppWebBlazor2.Client.Services.Interfaces
{
    public interface IEmpleadoService
    {
        Task<List<EmpleadoDTO>> Listar();

        Task<bool> Registrar(EmpleadoDTO empleadoDTO);

        Task<bool> Editar(int id, EmpleadoDTO empleadoDTO);

        Task<bool> Eliminar(int id);
    }
}
