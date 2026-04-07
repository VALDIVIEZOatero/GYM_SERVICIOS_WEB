using Microsoft.AspNetCore.Mvc;
using ApiGimnasio.Models;
using ApiGimnasio.Services;
using Microsoft.AspNetCore.Authorization;

namespace ApiGimnasio.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/ejercicios")]
    public class EjercicioController : ControllerBase
    {
        private readonly IEjercicioServicio _ejercicioService;

        public EjercicioController(IEjercicioServicio ejercicioServicio)
        {
            _ejercicioService = ejercicioServicio;
        }
        [Authorize(Roles ="ADMIN,SOCIO")]
        [HttpGet]
        public  async Task<IActionResult> GetEjercicios()
        {
            try
            {
                var ejercicio = await _ejercicioService.GetEjercicioAsync();
                return Ok(ejercicio);
            }
            catch (Exception)
            {
                return StatusCode(500,"Error interno del servidor");
            }
        }
        [Authorize(Roles ="ADMIN,SOCIO")]
        [HttpGet("Cantidad")]
        public async Task<IActionResult> GetCountEjercicios()
        {
            try
            {
                var ejercicio = await _ejercicioService.GetCountEjercicioAsync();
                return Ok(ejercicio);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN,SOCIO")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPorIdEjercicios(int id)
        {
            try
            {
                var ejercicio = await _ejercicioService.GetPorIdEjercicioAsync(id);
                if (ejercicio == null)
                {
                   return NotFound("EL ID NO FUE ENCONTRADO"); 
                }
                return Ok(ejercicio);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}   
        }
        [Authorize(Roles ="ADMIN")]
        [HttpPost]
        public async Task<IActionResult> PostPedidos([FromBody] Ejercicio e)
        {
            try
            {
                var ejercicio = await _ejercicioService.PostEjercicioAsync(e);
                return Ok(ejercicio);
            }catch(Exception){return StatusCode(500 , "Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEjercicios(int id ,[FromBody] Ejercicio e)
        {
            try
            {
                var ejercicio = await _ejercicioService.UpdateEjercicioAsync(id ,e);
                if(ejercicio == null)
                {
                    return NotFound("ID EJERCICIO  NO FUE ENCONTRADO  PARA ACTUALIZAR");
                }
                return Ok(ejercicio);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEjercicios(int id)
        {
            var ejercicio = await _ejercicioService.DeleteEjercicioAsync(id);
            if (!ejercicio)
            {
                return NotFound("EL ID EJERCICIO NO FUE ENCONTRADO PARA ELIMINAR");
            }
            return Ok("ID EJERCICIO ELIMINADO");
            }
        }
}