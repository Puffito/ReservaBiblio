using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservaBiblio.Server.Models;
using ReservaBiblio.Shared;

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
                        HoraFin = item.HoraFin
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
                    ReservasEspaciosDTO.Id = dbReservaEspacio.Id;
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
        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(ReservasEspaciosDTO reservaEspacio)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbReservaEspacio = new ReservasEspacios
                {
                    ProfesorId = reservaEspacio.ProfesorId,
                    EspacioId = reservaEspacio.EspacioId,
                    Dia = reservaEspacio.Dia,
                    HoraInicio = reservaEspacio.HoraInicio,
                    HoraFin = reservaEspacio.HoraFin,
                };

                _dbContext.ReservasEspacios.Add(dbReservaEspacio);
                await _dbContext.SaveChangesAsync();

                if (dbReservaEspacio.Id != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbReservaEspacio.Id;

                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = "No guardado";
            }
            return Ok(responseApi);

        }

        [HttpPut]
        [Route("Editar/{Id}")]
        public async Task<IActionResult> Editar(ReservasEspaciosDTO reservaEspacio, int Id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {

                var dbReservaEspacio = await _dbContext.ReservasEspacios.FirstOrDefaultAsync(e => e.Id == Id);

                if (dbReservaEspacio != null)
                {
                    dbReservaEspacio.ProfesorId = reservaEspacio.ProfesorId;
                    dbReservaEspacio.EspacioId = reservaEspacio.EspacioId;
                    dbReservaEspacio.Dia = reservaEspacio.Dia;
                    dbReservaEspacio.HoraInicio = reservaEspacio.HoraInicio;
                    dbReservaEspacio.HoraFin = reservaEspacio.HoraFin;

                    _dbContext.ReservasEspacios.Update(dbReservaEspacio);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbReservaEspacio.Id;

                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Reserva no encontrado";
                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);

        }

        [HttpDelete]
        [Route("Eliminar/{Id}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {

                var dbReservaEspacio = await _dbContext.ReservasEspacios.FirstOrDefaultAsync(e => e.Id == Id);

                if (dbReservaEspacio != null)
                {

                    _dbContext.ReservasEspacios.Remove(dbReservaEspacio);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Reserva no encontrado";
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
