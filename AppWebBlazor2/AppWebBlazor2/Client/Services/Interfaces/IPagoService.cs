using AppWebBlazor2.Shared;

namespace AppWebBlazor2.Client.Services.Interfaces
{
    public interface IPagoService
    {
        Task<List<PagoDTO>> Listar();

        Task<bool> Registrar(PagoDTO pagoDTO);

        Task<bool> Editar(int id, PagoDTO pagoDTO);

        Task<bool> Eliminar(int id);
    }
}
