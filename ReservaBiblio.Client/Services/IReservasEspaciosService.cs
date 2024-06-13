using ReservaBiblio.Shared;

namespace ReservaBiblio.Client.Services
{
    public interface IReservasEspaciosService
    {
        Task<List<ReservasEspaciosDTO>> Lista();
        Task<ReservasEspaciosDTO> Buscar(int id);
        Task<int> Guardar(ReservasEspaciosDTO ReservasMaterial);
        Task<int> Editar(ReservasEspaciosDTO ReservasMaterial);
        Task<bool> Eliminar(int id);
    }
}
