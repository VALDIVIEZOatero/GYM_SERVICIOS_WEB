using Microsoft.EntityFrameworkCore;
using ApiGimnasio.Data;
using ApiGimnasio.Models;

namespace ApiGimnasio.Services
{
    public class EjercicioService : IEjercicioServicio
    {
        private readonly ScaffoldDbContext _context;

        public EjercicioService(ScaffoldDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ejercicio>> GetEjercicioAsync()
        {
            return await _context.Ejercicios.ToListAsync();
        } 

        public async Task<int> GetCountEjercicioAsync()
        {
            return await _context.Ejercicios.CountAsync();
            
        }
        public async Task<Ejercicio?> GetPorIdEjercicioAsync(int id)
        {
            
            return await _context.Ejercicios.FindAsync(id);
        }

        public async Task<Ejercicio>  PostEjercicioAsync(Ejercicio e)
        {
             _context.Ejercicios.Add(e);
             await _context.SaveChangesAsync();
             return e;
        }

        public async Task<Ejercicio?> UpdateEjercicioAsync(int id , Ejercicio e)
        {
            var ejercicio = await _context.Ejercicios.FindAsync(id);
            if(ejercicio == null)
            {
                return null;
            }
            ejercicio.nombre = e.nombre;
            ejercicio.descripcion = e.descripcion;
            ejercicio.grupo_muscular = e.grupo_muscular;
            ejercicio.is_active = e.is_active;
            await _context.SaveChangesAsync();
            return ejercicio;
        }
        public async Task<bool> DeleteEjercicioAsync(int id)
        {
            var ejercicio = await _context.Ejercicios.FindAsync(id);

            if(ejercicio == null) return false;
            
            _context.Ejercicios.Remove(ejercicio);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}