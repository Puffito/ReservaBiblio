using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservaBiblio.Server.Models;
using ReservaBiblio.Shared;

namespace ReservaBiblio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly ReservasDbContext _dbContext;

        public MaterialController(ReservasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<MaterialDTO>>();
            var listaMaterialDTO = new List<MaterialDTO>();

            try
            {
                foreach (var item in await _dbContext.Material.ToListAsync())
                {
                    listaMaterialDTO.Add(new MaterialDTO
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Clave = item.Clave,
                        Descripcion = item.Descripcion,
                        Imagen = item.Imagen
                    });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaMaterialDTO;
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
            var responseApi = new ResponseAPI<MaterialDTO>();
            var MaterialDTO = new MaterialDTO();

            try
            {
                var dbMaterial = await _dbContext.Material.FirstOrDefaultAsync(x => x.Clave == Clave);
                if (dbMaterial != null)
                {


                    responseApi.EsCorrecto = true;
                    responseApi.Valor = MaterialDTO;
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
