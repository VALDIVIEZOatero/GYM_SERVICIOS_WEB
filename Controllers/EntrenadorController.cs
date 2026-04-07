using Microsoft.AspNetCore.Mvc;
using ApiGimnasio.Models;
using ApiGimnasio.Services;
using Microsoft.AspNetCore.Authorization;

namespace ApiGimnasio.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/entrenadores")]
    public class EntrenadorController : ControllerBase
    {
        private readonly IEntrenadorService _entrenadorService;

        public EntrenadorController(IEntrenadorService entrenadorService)
        {
            _entrenadorService = entrenadorService;
        }
        [Authorize(Roles ="ADMIN")]
        [HttpGet]
        public async Task<IActionResult> GetEntrenadores()
        {
            try
            {
                var entrenador = await _entrenadorService.GetEntrenadorAsync();
                return Ok(entrenador);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpGet("cantidad")]
        public async Task<IActionResult> GetCountEntrenadores()
        {
            try
            {
                var entrenador = await _entrenadorService.GetCountEntrenadorAsync();
                return Ok(entrenador);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN,ENTRENADOR")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPorIdEntrenadores(int id)
        {
            try
            {
                var entrenador_get_id = await _entrenadorService.GetPorIdEntrenadorAsync(id);
                if(entrenador_get_id == null)
                {
                    return NotFound("ID DEL ENTRENADOR NO FUE ENCONTRADO!");
                }
                return Ok(entrenador_get_id);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpPost]
        public async Task<IActionResult> PostEntrenadores([FromBody] Entrenador nuevo_entrenador)
        {
            try
            {
                var entrenador = await _entrenadorService.PostEntrenadorAsync(nuevo_entrenador);
                return Ok(entrenador);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEntrenadores(int id ,[FromBody] Entrenador entrenador_put)
        {
            try
            {
                var entrenador = await _entrenadorService.UpdateEntrenadorAsync(id , entrenador_put);
                if (entrenador == null)
                {
                    return NotFound("EL ID DEL ENTRENADOR NO SE ENCUENTRA PARA ACTUALIZAR");
                }
                return Ok(entrenador);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntrenadores(int id)
        {
            try
            {
                var entrenador = await _entrenadorService.DeleteEntrenadorAsync(id);
                if (!entrenador)
                {
                    return NotFound("EL ID DEL ENTRENADOR NO FUE ECONTRADO PARA ELIMINAR");
                }
                return Ok("ENTRENADOR ELIMINADO");
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
    }
}