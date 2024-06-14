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

        [HttpGet]
        [Route("Buscar/{Id}")]
        public async Task<IActionResult> Buscar(int Id)
        {
            var responseApi = new ResponseAPI<ProfesoresDTO>();
            var ProfesorDTO = new ProfesoresDTO();

            try
            {
                var dbProfesor = await _dbContext.Profesores.FirstOrDefaultAsync(x => x.Id == Id);
                if (dbProfesor != null)
                {
                    

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = ProfesorDTO;
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
        public async Task<IActionResult> Guardar(ProfesoresDTO profesor)
        {
            var responseApi = new ResponseAPI<string>();

            try
            {
                var dbProfesor = new Profesores
                {
                    Nombre = profesor.Nombre,
                    Correo = profesor.Correo,
                    Departamento = profesor.Departamento,
                    Contrasena = profesor.Contrasena,
                    RangoAdministrador = profesor.RangoAdministrador
                };

                _dbContext.Profesores.Add(dbProfesor);
                await _dbContext.SaveChangesAsync();

                if (dbProfesor.Id != 0)
                {

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbProfesor.Nombre;

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
        public async Task<IActionResult> Editar(ProfesoresDTO profesor, int Id)
        {
            var responseApi = new ResponseAPI<string>();

            try
            {

                var dbProfesor = await _dbContext.Profesores.FirstOrDefaultAsync(e=>e.Id == Id);

                if (dbProfesor != null)
                {
                    dbProfesor.Nombre = profesor.Nombre;
                    dbProfesor.Correo = profesor.Correo;
                    dbProfesor.Departamento = profesor.Departamento;
                    dbProfesor.Contrasena = profesor.Contrasena;
                    dbProfesor.RangoAdministrador = profesor.RangoAdministrador;

                    _dbContext.Profesores.Update(dbProfesor);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbProfesor.Nombre;

                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Profesor no encontrado";
                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message ;
            }
            return Ok(responseApi);

        }

        [HttpDelete]
        [Route("Eliminar/{Correo}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var responseApi = new ResponseAPI<string>();

            try
            {

                var dbProfesor = await _dbContext.Profesores.FirstOrDefaultAsync(e => e.Id == Id);

                if (dbProfesor != null)
                {

                    _dbContext.Profesores.Remove(dbProfesor);
                    await _dbContext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "Profesor no encontrado";
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
