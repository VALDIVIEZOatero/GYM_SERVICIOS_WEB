using Microsoft.EntityFrameworkCore;
using ApiGimnasio.Data;
using ApiGimnasio.Models;

namespace ApiGimnasio.Services
{
    public class RutinaService : IRutinaService
    {
        private readonly ScaffoldDbContext _context;

        public RutinaService(ScaffoldDbContext context)
        {
            _context = context;
        }

        public async Task<List<Rutina>> GetRutinaAsync()
        {
            return await _context.Rutinas.ToListAsync();
        } 

        public async Task<int> GetCountRutinaAsync()
        {
            return await _context.Rutinas.CountAsync();
            
        }
        public async Task<Rutina?> GetPorIdRutinaAsync(int id)
        {
            
            return await _context.Rutinas.FindAsync(id);
        }

        public async Task<Rutina> PostRutinaAsync(Rutina r)
        {
             _context.Rutinas.Add(r);
             await _context.SaveChangesAsync();
             return r;
        }

        public async Task<Rutina?> PutRutinaAsync(int id , Rutina r)
        {
            var rutina = await _context.Rutinas.FindAsync(id);
            if(rutina == null)
            {
                return null;
            }
            rutina.socio_id = r.socio_id;
            rutina.entrenador_id = r.entrenador_id;
            rutina.nombre = r.nombre;
            rutina.objetivo = r.objetivo;
            rutina.fecha_inicio = r.fecha_inicio;
            rutina.fecha_fin = r.fecha_fin;
            rutina.activa = r.activa;
            rutina.createdAt = r.createdAt;
            await _context.SaveChangesAsync();
            return rutina;
        }
        public async Task<bool> DeleteRutinaAsync(int id)
        {
            var rutina = await _context.Rutinas.FindAsync(id);

            if(rutina == null) return false;
            
            _context.Rutinas.Remove(rutina);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}