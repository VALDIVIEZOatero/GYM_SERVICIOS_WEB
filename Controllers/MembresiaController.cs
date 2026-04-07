using Microsoft.AspNetCore.Mvc;
using ApiGimnasio.Models;
using ApiGimnasio.Services;
using Microsoft.AspNetCore.Authorization;

namespace ApiGimnasio.Controllers
{

    [ApiController]
    [Authorize]
    [Route("api/membresias")]
    public class MembresiaController : ControllerBase
    {
        private readonly IMembresiaService _membresiaService;
        public MembresiaController(IMembresiaService membresiaService)
        {
            _membresiaService = membresiaService;
        }
        [Authorize(Roles ="ADMIN")]
        [HttpGet]
        public async Task<IActionResult> GetMembresias()
        {
            try
            {
                var mem = await _membresiaService.GetMembresiaAsync();
                return Ok(mem);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpGet("cantidad")]
        public async Task<IActionResult> GetCountMembresias()
        {
            try
            {
                var mem = await _membresiaService.GetCountMembresiaAsync();
                return Ok(mem);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPorIdMembresias(int id)
        {
            try
            {
                var mem = await _membresiaService.GetPorIdMembresiaAsync(id);
                return Ok(mem);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpPost]
        public async Task<IActionResult> GetMembresias([FromBody] Membresia m)
        {
            try
            {
                var mem = await _membresiaService.PostMembresiaAsync(m);
                return Ok(mem);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpPut("{id}")]
        public async Task<IActionResult> GetMembresias(int id ,[FromBody] Membresia m)
        {
            try
            {
                var mem = await _membresiaService.PutMembresiaAsync(id , m);
                if (mem == null)
                {
                    return NotFound("EL ID - MEMBRESIA NO FUE ENCONTRADO PARA ACTUALIZAR");
                }

                return Ok(mem);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembresias(int id)
        {
            try
            {
                var mem = await _membresiaService.DeleteMembresiaAsync(id);
                if (!mem)
                {
                    return NotFound("EL ID - MEMBRESIA NO FUE ENCONTRADO PARA ELIMINAR");
                }
                return Ok("EL ID - MEMEBRESIA FUE ELEMINADO");
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }

    }
}