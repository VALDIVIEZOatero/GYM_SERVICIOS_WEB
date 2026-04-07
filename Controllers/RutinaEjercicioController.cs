using Microsoft.AspNetCore.Mvc;
using ApiGimnasio.Models;
using ApiGimnasio.Services;
using Microsoft.AspNetCore.Authorization;

namespace ApiGimnasio.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/rutina_ejercicio")]
    public class RutinaEjercicioController : ControllerBase
    {
        private readonly IRutinaEjercicioService _rutinaEjercicioService;
        public RutinaEjercicioController(IRutinaEjercicioService rutinaEjercicioService)
        {
            _rutinaEjercicioService = rutinaEjercicioService;
        } 
        [Authorize(Roles ="ADMIN")]
        [HttpGet]
        public async Task<IActionResult> GetRutinaEjercicios()
        {
            try
            {
                var rutinaEjercicio = await _rutinaEjercicioService.GetRutinaEjercicioAsync();
                return Ok(rutinaEjercicio);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN,SOCIO")]
        [HttpGet("cantidad")]
        public async Task<IActionResult> GetCountRutinaEjercicios()
        {
            try
            {
                var rutinaEjercicio = await _rutinaEjercicioService.GetCountRutinaEjercicioAsync();
                return Ok(rutinaEjercicio);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN,SOCIO")]
        [HttpGet("{rutinaId}/{ejercicioId}")]
        public async Task<IActionResult> GetPorIdRutinaEjercicios(
            int rutinaId, int ejercicioId)
        {
            try
            {
                var rutinaEjercicio = await _rutinaEjercicioService.GetPorIdRutinaEjercicioAsync(rutinaId , ejercicioId);
                return Ok(rutinaEjercicio);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN,SOCIO")]
        [HttpPost]
        public async Task<IActionResult> PostRutinaEjercicios([FromBody] RutinaEjercicio re)
        {
            try
            {
                var rutinaEjercicio = await _rutinaEjercicioService.PostRutinaEjercicioAsync(re);
                return Ok(rutinaEjercicio);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN,SOCIO")]
        [HttpPut("{rutinaId}/{ejercicioId}")]
        public async Task<IActionResult> PutRutinaEjercicios(
            int rutinaId,int ejercicioId ,[FromBody] RutinaEjercicio re)
        {
            try
            {
                var rutinaEjercicio = await _rutinaEjercicioService.PutRutinaEjercicioAsync(rutinaId , ejercicioId , re);
                if (rutinaEjercicio == null)
                {
                    return NotFound("EL ID RUTINA EJERCICIO NO FUE ENCONTRADO PARA ACTUALIZAR");
                }
                return Ok(rutinaEjercicio);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN,SOCIO")]
        [HttpDelete("{rutinaId}/{ejercicioId}")]
        public async Task<IActionResult> DeleteRutinaEjercicios(int rutinaId , int ejercicioId)
        {
            try
            {
                var rutinaEjercicio = await _rutinaEjercicioService.DeleteRutinaEjercicioAsync(rutinaId , ejercicioId);
                if (!rutinaEjercicio)
                {
                    return NotFound("EL ID RUTINA EJERCICIO NO FUE ENCONTRADO PARA ELIMINARLO");
                }
                return Ok("EL ID RUTINA EJERCICIO FUE ELIMINADO");
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
    }
    
}