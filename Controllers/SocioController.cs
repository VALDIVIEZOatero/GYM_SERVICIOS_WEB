using Microsoft.AspNetCore.Mvc;
using ApiGimnasio.Models;
using ApiGimnasio.Data;
using Microsoft.AspNetCore.Authorization;

namespace ApiGimnasio.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/socios")]
    public class SocioController : ControllerBase
    {
        private readonly ISocioService _socioService;

        public SocioController(ISocioService socioService)
        {
            _socioService = socioService;
        }
        [Authorize(Roles ="ADMIN")]
        [HttpGet]
        public async Task<IActionResult> GetSocios()
        {
            try
            {
                var socio = await _socioService.GetSocioAsync();
                return Ok(socio);
            }
            catch(Exception){return  StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpGet("cantidad")]
        public async Task<IActionResult> GetCountSocios()
        {
            try
            {
                var socio = await _socioService.GetCountSociosAsync();
                return Ok(socio);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN,SOCIO")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocios(int id)
        {
            try
            {
                var socio = await _socioService.GetPorIdSociosAsync(id);
                if(socio == null)
                {
                    return NotFound("ID NO FUE ENCONTRADO!");
                }
                return Ok(socio);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpPost]
        public async Task<IActionResult> PostSocios([FromBody] Socio nuevo_socio)
        {
            try
            {
                var socio = await _socioService.PostSociosAsync(nuevo_socio);
                return Ok(socio);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSocios(int id ,[FromBody] Socio socio_put)
        {
            try
            {
                var socio = await _socioService.PutSociosAsync(id , socio_put);
                if (socio == null)
                {
                    return NotFound("ID SOCIO NO FUE ENCONTRADO PARA ACTUALIZAR");
                }
                return Ok(socio);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocios(int id)
        {
            try
            {
                var socio = await _socioService.DeleteSociosAsync(id);
                if (!socio)
                {
                    return NotFound("EL ID SOCIO NO FUE ENCONTRADO PARA ELIMINAR");
                }
                return Ok("EL SOCIO FUE ELIMINADO");
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
    }
}