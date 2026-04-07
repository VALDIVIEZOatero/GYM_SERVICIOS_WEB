using Microsoft.AspNetCore.Mvc;
using ApiGimnasio.Models;
using ApiGimnasio.Services;
using Microsoft.AspNetCore.Authorization;

namespace ApiGimnasio.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/asistencias")]
    public class AsistenciaController : ControllerBase
    {
        private readonly IAsistenciaService _asistenciaService;

        public AsistenciaController(IAsistenciaService asistenciaService)
        {
            _asistenciaService = asistenciaService;
        }
        [Authorize(Roles ="ADMIN,ENTRENADOR")]
        [HttpGet]
        public  async Task<IActionResult> GetAsistencias()
        {
            try
            {
                var asistencia = await _asistenciaService.GetAsistenciaAsync();
                return Ok(asistencia);
            }
            catch (Exception)
            {
                return StatusCode(500,"Error interno del servidor");
            }
        }
        [Authorize(Roles ="ADMIN,ENTRENADOR")]        
        [HttpGet("Cantidad")]
        public async Task<IActionResult> GetCountAsistencias()
        {
            try
            {
                var asistencia = await _asistenciaService.GetCountAsistenciaAsync();
                return Ok(asistencia);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN,ENTRENADOR,SOCIO")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPorIdAsistencias(int id)
        {
            try
            {
                var asistencia = await _asistenciaService.GetPorIdAsistenciaAsync(id);
                if (asistencia == null)
                {
                   return NotFound("EL ID ASISTENCIA NO FUE ENCONTRADO"); 
                }
                return Ok(asistencia);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}   
        }
        [Authorize(Roles ="ENTRENADOR")]
        [HttpPost]
        public async Task<IActionResult> PostAsistencias([FromBody] Asistencia a)
        {
            try
            {
                var asistencia = await _asistenciaService.PostAsistenciaAsync(a);
                return Ok(asistencia);
            }catch(Exception){return StatusCode(500 , "Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsistencias(int id , Asistencia a)
        {
            try
            {
                var asistencia = await _asistenciaService.UpdateAsistenciaAsync(id , a);
                if(asistencia == null)
                {
                    return NotFound("ID  DE AISTENCIA NO ENCONTRADO PARA ACTUALIZAR");
                }
                return Ok(asistencia);
            }
            catch(Exception){return StatusCode(500,"Error interno del servidor");}
        }
        [Authorize(Roles ="ADMIN")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsistencias(int id)
        {
            var asistencia = await _asistenciaService.DeleteAsistenciaAsync(id);
            if (!asistencia)
            {
                return NotFound("EL ID ASISTENCIA NO FUE ENCONTRADO PARA ELIMINAR");
            }
            return Ok(" EL ID ASISTENCIA ELIMINADO");
            }
        }
}