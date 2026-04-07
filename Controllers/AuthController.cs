using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using ApiGimnasio.Dtos;
using ApiGimnasio.Controllers;
using ApiGimnasio.Data;
using ApiGimnasio.Models;
using System.Security.Claims;
using System.Text;
using ApiGimnasio.Services;
using Microsoft.Identity.Client;
namespace ApiGimnasio.Controllers
{
    [ApiController]

    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public AuthController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [Authorize(Roles ="ADMIN")]
        [HttpGet("usuarios")]
        public async Task<IActionResult> GetAllUsuarios()
        {
            try
            {
                var user = await _usuarioService.GetAllUsers();
                if (user == null || !user.Any())
                {
                    return NotFound("No hay usuarios registrados");
                }
                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(500,"Error interno del servidor");
            }
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> LoginGym([FromBody] LoginDto login)
        {
            var token = await _usuarioService.LoginAsync(login);
            if (token == null)
            {
                return NotFound("USUARIO NO ENCONTRADO");
            }
            return Ok(new {token});
        }
    
        [HttpPost("registro")]
        public async Task<IActionResult> RegistroGym([FromBody] RegisterDto register)
        {
            var user = await _usuarioService.RegisterAsync(register);
            return Ok(user);
        }
    
    }
}
