using ReservaBiblio.Shared;

namespace ReservaBiblio.Client.Services
{
    public interface IEspaciosService
    {
        Task<List<EspaciosDTO>> Lista();
        Task<EspaciosDTO> Buscar(string clave);
    }
}
