using Microsoft.EntityFrameworkCore;
using ApiGimnasio.Data;
using ApiGimnasio.Models;

namespace ApiGimnasio.Services
{
    public class AsistenciaService : IAsistenciaService
    {
        private readonly ScaffoldDbContext _context;

        public AsistenciaService(ScaffoldDbContext context)
        {
            _context = context;
        }

        public async Task<List<Asistencia>> GetAsistenciaAsync()
        {
            return await _context.Asistencias.ToListAsync();
        } 

        public async Task<int> GetCountAsistenciaAsync()
        {
            return await _context.Asistencias.CountAsync();
            
        }
        public async Task<Asistencia?> GetPorIdAsistenciaAsync(int id)
        {
            
            return await _context.Asistencias.FindAsync(id);
        }

        public async Task<Asistencia>  PostAsistenciaAsync(Asistencia a)
        {
             _context.Asistencias.Add(a);
             await _context.SaveChangesAsync();
             return a;
        }

        public async Task<Asistencia?> UpdateAsistenciaAsync(int id , Asistencia a)
        {
            var asistencia = await _context.Asistencias.FindAsync(id);
            if(asistencia == null)
            {
                return null;
            }
            asistencia.socio_id = a.socio_id;
            asistencia.fecha_entrada = a.fecha_entrada;
            asistencia.fecha_salida = a.fecha_salida;
            asistencia.observacion = a.observacion;
            asistencia.registrado_id = a.registrado_id;

            await _context.SaveChangesAsync();
            return asistencia;
        }
        public async Task<bool> DeleteAsistenciaAsync(int id)
        {
            var asistencia = await _context.Asistencias.FindAsync(id);

            if(asistencia == null) return false;
            
            _context.Asistencias.Remove(asistencia);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}