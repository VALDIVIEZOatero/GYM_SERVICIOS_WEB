using Microsoft.AspNetCore.Mvc;
using ApiGimnasio.Models;
using ApiGimnasio.Services;
using Microsoft.AspNetCore.Authorization;


namespace ApiGimnasio.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/socio_entrenador")]
    public class SocioEntrenadorController : ControllerBase
    {
        private readonly ISocioEntrenadorService _socioEntrenadorService;

        public SocioEntrenadorController(ISocioEntrenadorService socioEntrenadorService)
        {
            _socioEntrenadorService = socioEntrenadorService;
        }
        [Authorize(Roles ="ADMIN")]
        [HttpGet]
        public async Task<IActionResult> GetSocioEntrenadores()
        {
            try
            {
                var se = await _socioEntrenadorService.GetSocioEntrenadorAsync();
                return Ok(se);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");} 
        }
        [Authorize(Roles ="ADMIN")]
        [HttpGet("cantidad")]
        public async Task<IActionResult> GetCountSocioEntrenadores()
        {
            try
            {
                var se = await _socioEntrenadorService.GetCountSocioEntrenadorAsync();
                return Ok(se);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");} 
        }
        [Authorize(Roles ="ENTRENADOR")]
        [HttpGet("{socioId}/{entrenadorId}")]
        public async Task<IActionResult> GetPorIdSocioEntrenadores(int socioId , int entrenadorId)
        {
            try
            {
                var se = await _socioEntrenadorService.GetPorIdSocioEntrenadorAsync(socioId , entrenadorId);
                if (se == null)
                {
                    return NotFound("EL ID DEL SOCIO-ENTRENADOR NO FUE ENCONTRADO");
                }
                return Ok(se);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");} 
        }
        [Authorize(Roles ="ADMIN")]
        [HttpPost]
        public async Task<IActionResult> PostSocioEntrenadores([FromBody] SocioEntrenador se)
        {
            try
            {
                var se_nuevo = await _socioEntrenadorService.PostSocioEntrenadorAsync(se);
                return Ok(se_nuevo);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");} 
        }
        [Authorize(Roles ="ADMIN")]
        [HttpPut("{socioId}/{entrenadorId}")]
        public async Task<IActionResult> PutSocioEntrenadores(int socioId , int entrenadorId ,[FromBody] SocioEntrenador se_put)
        {
            try
            {
                var se = await _socioEntrenadorService.PutSocioEntrenadorAsync(socioId , entrenadorId , se_put );
                if (se == null)
                {
                    return NotFound("EL ID DEL SOCIO ENTRENADOR NO FUE ENCONTRADO PARA ACTUALIZAR");
                }
                return Ok(se);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");} 
        }
        [Authorize(Roles ="ADMIN")]
        [HttpDelete("{socioId}/{entrenadorId}")]
        public async Task<IActionResult> DeleteSocioEntrenadores(int socioId , int entrenadorId)
        {
            try
            {
                var se = await _socioEntrenadorService.DeleteSocioEntrenadorAsync(socioId , entrenadorId);
                if (!se)
                {
                    return NotFound("EL ID DEL SOCIO ENTRENADOR NO FUE ENCONTRADO PARA ELIMINARLO");

                }
                return Ok("SOCIO ENTRENADOR ELMINIADO");
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");} 
        }
    }
}