using ReservaBiblio.Shared;

namespace ReservaBiblio.Client.Services
{
    public interface IMaterialService
    {
        Task<List<MaterialDTO>> Lista();
        Task<MaterialDTO> Buscar(string clave);
    }
}
