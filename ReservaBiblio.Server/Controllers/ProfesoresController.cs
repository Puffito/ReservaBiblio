using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservaBiblio.Server.Models;
using ReservaBiblio.Shared;
using Microsoft.EntityFrameworkCore;

namespace ReservaBiblio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private readonly ReservasDbContext _dbContext;

        public ProfesoresController(ReservasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<ProfesoresDTO>>();
            var listaProfesoresDTO = new List<ProfesoresDTO>();

            try
            {
                foreach (var item in await _dbContext.Profesores.ToListAsync())
                {
                    listaProfesoresDTO.Add(new ProfesoresDTO
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Correo = item.Correo,
                        Departamento = item.Departamento,
                        Contrasena = item.Contrasena,
                        RangoAdministrador = item.RangoAdministrador
                    });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaProfesoresDTO;
            }catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);

        }
    }
}
