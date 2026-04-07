using Microsoft.EntityFrameworkCore;
using ApiGimnasio.Data;
using ApiGimnasio.Models;

namespace ApiGimnasio.Services
{
    public class RutinaEjercicioService : IRutinaEjercicioService
    {
        private readonly ScaffoldDbContext _context;

        public RutinaEjercicioService(ScaffoldDbContext context)
        {
            _context = context;
        }

        public async Task<List<RutinaEjercicio>> GetRutinaEjercicioAsync()
        {
            return await _context.RutinaEjercicios.
            Include(re=>re.rutina).
            Include(re=>re.ejercicio).ToListAsync();
        } 

        public async Task<int> GetCountRutinaEjercicioAsync()
        {
            return await _context.RutinaEjercicios.CountAsync();
            
        }
        public async Task<RutinaEjercicio?> GetPorIdRutinaEjercicioAsync(
            int rutinaId,
            int ejercicioId
        )
        {
            
            return await _context.RutinaEjercicios.
            Include(re=>re.rutina).Include(re=>re.ejercicio).
            SingleOrDefaultAsync(re=>re.rutina_id == rutinaId && re.ejercicio_id == ejercicioId);
        }

        public async Task<RutinaEjercicio>  PostRutinaEjercicioAsync(RutinaEjercicio re)
        {
             _context.RutinaEjercicios.Add(re);
             await _context.SaveChangesAsync();
             return re;
        }

        public async Task<RutinaEjercicio?> PutRutinaEjercicioAsync(
            int rutinaId ,int ejercicioId , RutinaEjercicio re)
        {
            var rutinaEjercicio = await _context.RutinaEjercicios.
            SingleOrDefaultAsync(re=>re.rutina_id == rutinaId && re.ejercicio_id == ejercicioId);
            if(rutinaEjercicio == null)
            {
                return null;
            }
            rutinaEjercicio.ejercicio_id = re.ejercicio_id;
            rutinaEjercicio.orden = re.orden;
            rutinaEjercicio.serie= re.serie;
            rutinaEjercicio.repeticiones = re.repeticiones;
            rutinaEjercicio.peso_objetivo_kg = re.peso_objetivo_kg;
            rutinaEjercicio.duracion_seg = re.duracion_seg;
            rutinaEjercicio.descanso_seg = re.descanso_seg;
            rutinaEjercicio.nota = re.nota;
            await _context.SaveChangesAsync();
            return rutinaEjercicio;
        }
        public async Task<bool> DeleteRutinaEjercicioAsync(int rutinaId , int ejercicioId)
        {
            var rutinaEjercicio = await _context.RutinaEjercicios.
            SingleOrDefaultAsync(re=>re.rutina_id==rutinaId && re.ejercicio_id == ejercicioId);

            if(rutinaEjercicio == null) return false;
            
            _context.RutinaEjercicios.Remove(rutinaEjercicio);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}