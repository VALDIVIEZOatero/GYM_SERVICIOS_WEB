using Microsoft.AspNetCore.Mvc;
using ApiGimnasio.Models;
using ApiGimnasio.Services;
using Microsoft.AspNetCore.Authorization;
using System.Xml;
namespace ApiGimnasio.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/roles")]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [Authorize(Roles ="ADMIN")]
        [HttpGet]
        public  async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await _rolService.GetRolesAsync();
                return Ok(roles);
            }
            catch (Exception)
            {
                return StatusCode(500,"Error interno del servidor");
            }
        }
        [HttpGet("Cantidad")]
        public async Task<IActionResult> GetCountRoles ()
        {
            try
            {
                var roles = await _rolService.GetCountRolesAsync();
                return Ok(roles);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPorIdRoles(int id)
        {
            try
            {
                var roles = await _rolService.GetPorIdRolesAsync(id);
                if (roles == null)
                {
                   return NotFound("EL ID NO FUE ENCONTRADO"); 
                }
                return Ok(roles);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}   
        }

        [HttpPost]
        public async Task<IActionResult> PostRoles([FromBody] Rol r)
        {
            try
            {
                var rol = await _rolService.PostRolesAsync( r);
                return Ok(rol);
            }catch(Exception){return StatusCode(500 , "Error interno del servidor");}
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoles(int id , Rol rol_put)
        {
            try
            {
                var rol = await _rolService.PutRolesAsync(id , rol_put);
                if(rol == null)
                {
                    return NotFound("ID NO ENCONTRADO!");
                }
                return Ok(rol);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoles(int id)
        {
            var rol = await _rolService.DeleteRolesAsync(id);
            if (!rol)
            {
                return NotFound("EL ID NO FUE ENCONTRADO");
            }
            return Ok("ID ELIMINADO");
            }
        }
}