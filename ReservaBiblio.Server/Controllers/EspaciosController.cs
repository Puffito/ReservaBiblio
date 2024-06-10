using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservaBiblio.Server.Models;
using ReservaBiblio.Shared;
using Microsoft.EntityFrameworkCore;

namespace ReservaBiblio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspaciosController : ControllerBase
    {
        private readonly ReservasDbContext _dbContext;

        public EspaciosController(ReservasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<EspaciosDTO>>();
            var listaEspaciosDTO = new List<EspaciosDTO>();

            try
            {
                foreach (var item in await _dbContext.Espacios.ToListAsync())
                {
                    listaEspaciosDTO.Add(new EspaciosDTO
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Clave = item.Clave,
                        Descripcion = item.Descripcion,
                        Imagen = item.Imagen
                    });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaEspaciosDTO;
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);

        }
        [HttpGet]
        [Route("Buscar/{Clave}")]
        public async Task<IActionResult> Buscar(string Clave)
        {
            var responseApi = new ResponseAPI<EspaciosDTO>();
            var EspacioDTO = new EspaciosDTO();

            try
            {
                var dbEspacio = await _dbContext.Espacios.FirstOrDefaultAsync(x => x.Clave == Clave);
                if (dbEspacio != null)
                {


                    responseApi.EsCorrecto = true;
                    responseApi.Valor = EspacioDTO;
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
