using Microsoft.AspNetCore.Mvc;
using ApiGimnasio.Models;
using ApiGimnasio.Services;
using Microsoft.AspNetCore.Authorization;

namespace ApiGimnasio.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/rutinas")]
    public class RutinaController : ControllerBase
    {
        private readonly IRutinaService _rutinaService;
        public RutinaController(IRutinaService rutinaService)
        {
            _rutinaService = rutinaService;
        } 
        [Authorize(Roles ="ADMIN,SOCIO")]
        [HttpGet]
        public async Task<IActionResult> GetRutinas()
        {
            try
            {
                var rutina = await _rutinaService.GetRutinaAsync();
                return Ok(rutina);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN,SOCIO")]
        [HttpGet("cantidad")]
        public async Task<IActionResult> GetCountRutinas()
        {
            try
            {
                var rutina = await _rutinaService.GetCountRutinaAsync();
                return Ok(rutina);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN,SOCIO")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPorIdRutinas(int id)
        {
            try
            {
                var rutina = await _rutinaService.GetPorIdRutinaAsync(id);
                if(rutina == null)
                {
                    return NotFound("ID NO ENCONTRADO");
                }
                return Ok(rutina);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpPost]
        public async Task<IActionResult> PostRutinas([FromBody] Rutina r)
        {
            try
            {
                var rutina = await _rutinaService.PostRutinaAsync(r);
                return Ok(rutina);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRutinas(int id ,[FromBody] Rutina r)
        {
            try
            {
                var rutina = await _rutinaService.PutRutinaAsync(id , r);
                if (rutina == null)
                {
                    return NotFound("EL ID  RUTINA NO FUE ENCONTRADO PARA ACTUALIZAR");
                }
                return Ok(rutina);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRutinas(int id)
        {
            try
            {
                var rutina = await _rutinaService.DeleteRutinaAsync(id);
                if (!rutina)
                {
                    return NotFound("EL ID RUTINA NO FUE ENCONTRADO PARA ELIMINAR");
                }
                return Ok("EL ID RUTINA FUE ELIMINADO");
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
    }
}