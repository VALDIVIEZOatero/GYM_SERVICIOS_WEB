using Microsoft.AspNetCore.Mvc;
using ApiGimnasio.Models;
using ApiGimnasio.Services;
using Microsoft.AspNetCore.Authorization;

namespace ApiGimnasio.Services
{
    [ApiController]
    [Authorize]
    [Route("api/socio_membresia")]
    public class SocioMembresiaController : ControllerBase
    {
        private readonly ISocioMembresiaService _socioMembresiaService;

        public SocioMembresiaController(ISocioMembresiaService socioMembresiaService)
        {
            _socioMembresiaService = socioMembresiaService;
        }
        [Authorize(Roles ="ADMIN")]
        [HttpGet]
        public async Task<IActionResult> GetSocioMembresias()
        {
            try
            {
                var sm = await _socioMembresiaService.GetSocioMembresiaAsync();
                return Ok(sm);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpGet("cantidad")]
        public async Task<IActionResult> GetCountSocioMembresias()
        {
            try
            {
                var sm = await _socioMembresiaService.GetCountSocioMembresiaAsync();
                return Ok(sm);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN,SOCIO")]
        [HttpGet("{socioId}/{membresiaId}")]
        public async Task<IActionResult> GetPorIdSocioMembresias(
            int socioId , int membresiaId)
        {
            try
            {
                var sm = await _socioMembresiaService.GetPorIdSocioMembresiaAsync(
                    socioId , membresiaId);
                return Ok(sm);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpPost]
        public async Task<IActionResult> PostSocioMembresias([FromBody] SocioMembresia sm)
        {
            try
            {
                var sme = await _socioMembresiaService.PostSocioMembresiaAsync(sm);
                return Ok(sme);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpPut("{socioId}/{membresiaId}")]
        public async Task<IActionResult> PutSocioMembresias(
            int socioId , int membresiaId ,[FromBody] SocioMembresia sm)
        {
            try
            {
                var sme = await _socioMembresiaService.PutSocioMembresiaAsync(socioId ,membresiaId , sm);
                if(sme == null){
                   return NotFound("EL ID SOCIO MEMBRESIA NO FUE ENCONTRADO PARA ACTUALIZAR"); 
                }
                return Ok(sme);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpDelete("{socioId}/{membresiaId}")]
        public async Task<IActionResult> DeleteSocioMembresias(
            int socioId , int membresiaId )
        {
            try
            {
                var sme = await _socioMembresiaService.DeleteSocioMembresiaAsync(
                    socioId , membresiaId);
                if (!sme)
                {
                    return NotFound("LE ID SOCIO MEMBRESIA NO FUE ENCONTRADO PARA ELIMINAR");
                }
                return Ok("ID SOCIO MEMBRESIA FUE ELIMINADO");
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
    }
}