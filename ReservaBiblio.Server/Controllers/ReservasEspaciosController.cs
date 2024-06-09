using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservaBiblio.Server.Models;
using ReservaBiblio.Shared;
using Microsoft.EntityFrameworkCore;

namespace ReservaBiblio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasEspaciosController : ControllerBase
    {
        private readonly ReservasDbContext _dbContext;

        public ReservasEspaciosController(ReservasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<ReservasEspaciosDTO>>();
            var listaReservasEspaciosDTO = new List<ReservasEspaciosDTO>();

            try
            {
                foreach (var item in await _dbContext.ReservasEspacios.ToListAsync())
                {
                    listaReservasEspaciosDTO.Add(new ReservasEspaciosDTO
                    {
                        Id = item.Id,
                        ProfesorId = item.ProfesorId,
                        EspacioId = item.EspacioId,
                        Dia = item.Dia,
                        HoraInicio = item.HoraInicio,
                        HoraFin = item.HoraFin,
                        Espacio = new EspacioDTO
                        {
                            Id = item.Espacio.Id,
                            Nombre = item.Espacio.Nombre
                        },
                        Profesor = new ProfesoresDTO
                        {
                            Id = item.Profesor.Id,
                            Nombre = item.Profesor.Nombre,
                            Correo = item.Profesor.Correo,
                            Departamento = item.Profesor.Departamento,
                            Contrasena = item.Profesor.Contrasena,
                        }
                    });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaReservasEspaciosDTO;
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);

        }
        [HttpGet]
        [Route("Buscar/{Id}")]
        public async Task<IActionResult> Buscar(int Id)
        {
            var responseApi = new ResponseAPI<ReservasEspaciosDTO>();
            var ReservasEspaciosDTO = new ReservasEspaciosDTO();

            try
            {
                var dbReservaEspacio = await _dbContext.ReservasEspacios.FirstOrDefaultAsync(x => x.Id == Id);
                if (dbReservaEspacio != null)
                {
                    ReservasEspaciosDTO.Id =dbReservaEspacio.Id;
                    ReservasEspaciosDTO.ProfesorId = dbReservaEspacio.ProfesorId;
                    ReservasEspaciosDTO.EspacioId = dbReservaEspacio.EspacioId;
                    ReservasEspaciosDTO.Dia = dbReservaEspacio.Dia;
                    ReservasEspaciosDTO.HoraInicio = dbReservaEspacio.HoraInicio;
                    ReservasEspaciosDTO.HoraFin = dbReservaEspacio.HoraFin;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = ReservasEspaciosDTO;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No encontrado";
                }

            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);

        }
    }
}
