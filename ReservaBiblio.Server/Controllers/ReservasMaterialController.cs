using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservaBiblio.Server.Models;
using ReservaBiblio.Shared;

namespace ReservaBiblio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasMaterialController : ControllerBase
    {
        private readonly ReservasDbContext _dbContext;

        public ReservasMaterialController(ReservasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<ReservasMaterialDTO>>();
            var listaReservasMaterialDTO = new List<ReservasMaterialDTO>();

            try
            {
                foreach (var item in await _dbContext.ReservasMaterial.ToListAsync())
                {
                    listaReservasMaterialDTO.Add(new ReservasMaterialDTO
                    {
                        Id = item.Id,
                        ProfesorId = item.ProfesorId,
                        MaterialId = item.MaterialId,
                        Dia = item.Dia,
                        HoraInicio = item.HoraInicio,
                        HoraFin = item.HoraFin
                    });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaReservasMaterialDTO;
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
            var responseApi = new ResponseAPI<ReservasMaterialDTO>();
            var ReservasMaterialDTO = new ReservasMaterialDTO();

            try
            {
                var dbReservaMaterial = await _dbContext.ReservasMaterial.FirstOrDefaultAsync(x => x.Id == Id);
                if (dbReservaMaterial != null)
                {
                    ReservasMaterialDTO.Id = dbReservaMaterial.Id;
                    ReservasMaterialDTO.ProfesorId = dbReservaMaterial.ProfesorId;
                    ReservasMaterialDTO.MaterialId = dbReservaMaterial.MaterialId;
                    ReservasMaterialDTO.Dia = dbReservaMaterial.Dia;
                    ReservasMaterialDTO.HoraInicio = dbReservaMaterial.HoraInicio;
                    ReservasMaterialDTO.HoraFin = dbReservaMaterial.HoraFin;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = ReservasMaterialDTO;
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
