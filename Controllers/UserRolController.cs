using Microsoft.AspNetCore.Mvc;
using ApiGimnasio.Models;
using ApiGimnasio.Data;
using Microsoft.AspNetCore.Authorization;
namespace ApiGimnasio.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/user_roles")]
    public class UserRolController : ControllerBase
    {
        private readonly IUserRoleService _userRolService;

        public UserRolController(IUserRoleService userRolService)
        {
            _userRolService = userRolService;
        }
        [Authorize(Roles ="ADMIN")]
        [HttpGet]
        public async Task<IActionResult> GetUserRoles()
        {
            try
            {
                var user_rol = await _userRolService.GetUserRolesAsync();
                return Ok(user_rol);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpGet("{id_use}/{id_rol}")]
        public async Task<IActionResult> GetPorIdUserRoles(int id_use , int id_rol)
        {
            try
            {
                var user_rol = await _userRolService.GetPorIdUserRolesAsync(id_use,id_rol);
                if (user_rol == null)
                {
                    return NotFound("ID NO ENCONTRADO");
                }
                return Ok(user_rol);
            }
            catch (Exception)
            {
                return StatusCode(500,"Error interno del servidor");
            }
        }
        [Authorize(Roles ="ADMIN")]
        [HttpGet("Cantidad")]
        public async Task<IActionResult> GetCountUserRoles()
        {
            try
            {
                var user_rol_count = await _userRolService.GetCountUseRolesAsync();
                return Ok(user_rol_count);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpPost]
        public async Task<IActionResult> PostUserRol([FromBody] UserRole nuevo_user_rol)
        {
            try
            {
                var user_rol = await _userRolService.PostUserRolesAsync(nuevo_user_rol);
                return Ok(user_rol);
            }
            catch (Exception)
            {
                return StatusCode(500,"Error interno del servidor");
                
            }
        }
        [Authorize(Roles ="ADMIN")]
        [HttpPut("{id_user}/{id_rol}")]
        public async Task<IActionResult> UpdateUserRoles(int id_user , int id_rol ,[FromBody] UserRole user_rol_put )
        {
            try
            {
                var user_rol = await _userRolService.PutUserRolesAsync(id_user,id_rol,user_rol_put);
                if(user_rol == null)
                {
                    return NotFound("ID NO ENCONTRADO");
                }
                return Ok(user_rol);
            }
            catch (Exception)
            {
                return StatusCode(500,"Error interno del servidor");
                
            }
        }
        [Authorize(Roles ="ADMIN")]
        [HttpDelete("{id}/{idr}")]
        public async Task<IActionResult> DeleteUserRoles(int id , int idr)
        {
            try
            {
                var user_rol = await _userRolService.DeleteUserRolesAsync(id,idr);
                if (!user_rol)
                {
                    return NotFound("EL ID NO FUE ENCONTRADO");
                }
                return Ok("USER ROL ELIMINADO");
            }
            catch (Exception)
            {
                return StatusCode(500,"Error inerno del servidor");
            }       
        }

  }
}
