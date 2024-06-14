using ReservaBiblio.Shared;

namespace ReservaBiblio.Client.Services
{
    public interface IProfesoresService
    {
        Task<List<ProfesoresDTO>> Lista();
        Task<ProfesoresDTO> Buscar(int id);
        Task<int> Guardar(ProfesoresDTO Profesores);
        Task<int> Editar(ProfesoresDTO Profesores);
        Task<bool> Eliminar(int id);
    }
}
