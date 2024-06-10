using ReservaBiblio.Shared;

namespace ReservaBiblio.Client.Services
{
    public interface IProfesoresService
    {
        Task<List<ProfesoresDTO>> Lista();
        Task<ProfesoresDTO> Buscar(string correo);
        Task<string> Guardar(ProfesoresDTO Profesores);
        Task<string> Editar(ProfesoresDTO Profesores);
        Task<bool> Eliminar(string correo);
    }
}
