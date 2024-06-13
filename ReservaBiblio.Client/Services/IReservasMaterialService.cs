using ReservaBiblio.Shared;

namespace ReservaBiblio.Client.Services
{
    public interface IReservasMaterialService
    {
        Task<List<ReservasMaterialDTO>> Lista();
        Task<ReservasMaterialDTO> Buscar(int id);
        Task<int> Guardar(ReservasMaterialDTO ReservasMaterial);
        Task<int> Editar(ReservasMaterialDTO ReservasMaterial);
        Task<bool> Eliminar(int id);
    }
}
