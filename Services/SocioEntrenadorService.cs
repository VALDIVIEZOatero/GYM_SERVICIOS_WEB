using Microsoft.EntityFrameworkCore;
using ApiGimnasio.Data;
using ApiGimnasio.Models;

namespace ApiGimnasio.Services
{
    public class SocioEntrenadorService : ISocioEntrenadorService
    {
        private readonly ScaffoldDbContext _context;

        public SocioEntrenadorService(ScaffoldDbContext context)
        {
            _context = context;
        }

        public async Task<List<SocioEntrenador>> GetSocioEntrenadorAsync()
        {
            return await _context.SocioEntrenadores.

            Include(se=>se.socios).
            Include(se => se.entrenadores).ToListAsync();
        }
        public async Task<int> GetCountSocioEntrenadorAsync()
        {
            return await _context.SocioEntrenadores.CountAsync();
        }
        public async Task<SocioEntrenador?> GetPorIdSocioEntrenadorAsync(int socioId , int entrenadorId )
        {
          return await _context.SocioEntrenadores.
          Include(se=>se.socios)
          .Include(se=>se.entrenadores)
          .SingleOrDefaultAsync(se=> se.socio_id == socioId && se.entrenador_id == entrenadorId);
        }
        public async Task<SocioEntrenador>  PostSocioEntrenadorAsync(SocioEntrenador se)
        {
            _context.SocioEntrenadores.Add(se);
            await _context.SaveChangesAsync();
            return se;
        }

        public async Task<SocioEntrenador?> PutSocioEntrenadorAsync(int socioId , int entrenadorId , SocioEntrenador s)
        {
            var socioEntrenador = await _context.SocioEntrenadores
            .SingleOrDefaultAsync(se=> se.socio_id == socioId && se.entrenador_id == entrenadorId);
            if (socioEntrenador == null)
            {
                return null;
            }
            socioEntrenador.socio_id = s.socio_id;
            socioEntrenador.entrenador_id = s.entrenador_id;
            socioEntrenador.fecha_asignacion = s.fecha_asignacion;
            socioEntrenador.activo = s.activo;

            await _context.SaveChangesAsync();
            return socioEntrenador;
        }
        public async Task<bool> DeleteSocioEntrenadorAsync(int socioId , int entrenadorId)
        {
            var socioEntrenador = await _context.SocioEntrenadores.
            SingleOrDefaultAsync(se=> se.socio_id== socioId && se.entrenador_id == entrenadorId);
            if(socioEntrenador == null)
            {
                return false;
            }
            _context.SocioEntrenadores.Remove(socioEntrenador);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}