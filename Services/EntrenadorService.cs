using Microsoft.EntityFrameworkCore;
using ApiGimnasio.Data;
using ApiGimnasio.Models;

namespace ApiGimnasio.Services
{
    public class EntrenadorService : IEntrenadorService
    {
        private readonly ScaffoldDbContext _context;

        public EntrenadorService(ScaffoldDbContext context)
        {
            _context = context;
        }

        public async Task<List<Entrenador>> GetEntrenadorAsync()
        {
            return await _context.Entrenadores.ToListAsync();
        }
        public async Task<int> GetCountEntrenadorAsync()
        {
            return await _context.Entrenadores.CountAsync();
        }
        public async Task<Entrenador?> GetPorIdEntrenadorAsync(int id)
        {
            return await _context.Entrenadores.FindAsync(id);
        }
        public async Task<Entrenador> PostEntrenadorAsync(Entrenador entrenador)
        {
          _context.Entrenadores.Add(entrenador);
          await _context.SaveChangesAsync();
          return entrenador;  
        }
        public async Task<Entrenador?> UpdateEntrenadorAsync(int id , Entrenador entrenador)
        {
            var entrenador_put = await _context.Entrenadores.FindAsync(id);
            if (entrenador_put == null)
            {
                return null;
            }
            entrenador_put.user_id = entrenador.user_id;
            entrenador_put.especialidad = entrenador.especialidad;
            entrenador_put.certificacion = entrenador.certificacion;
            entrenador_put.fecha_ingreso = entrenador.fecha_ingreso;
            entrenador_put.isActive = entrenador.isActive;

            return entrenador_put;
        }
        public async Task<bool> DeleteEntrenadorAsync(int id)
        {
            var entrenador_delete = await _context.Entrenadores.FindAsync(id);
            if (entrenador_delete == null)
            {
                return false;
            }
            _context.Entrenadores.Remove(entrenador_delete);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}