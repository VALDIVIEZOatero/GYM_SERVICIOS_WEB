using Microsoft.EntityFrameworkCore;
using ApiGimnasio.Data;
using ApiGimnasio.Models;

namespace ApiGimnasio.Services
{
    public class MembresiaService : IMembresiaService
    {
        private readonly ScaffoldDbContext _context;
        public MembresiaService(ScaffoldDbContext context)
        {
            _context = context;
        }

        public async Task<List<Membresia>> GetMembresiaAsync()
        {
            return await _context.Membresias.ToListAsync();
        }
        public async Task<int> GetCountMembresiaAsync()
        {
            return await _context.Membresias.CountAsync();
        }
        public async Task<Membresia?> GetPorIdMembresiaAsync(int id)
        {
            return await _context.Membresias.FindAsync(id);
        }
        public async Task<Membresia> PostMembresiaAsync(Membresia m)
        {
            _context.Membresias.Add(m);
            await _context.SaveChangesAsync();
            return m;
        }
        public async Task<Membresia?> PutMembresiaAsync(int id , Membresia m)
        {
            var men = await _context.Membresias.FindAsync(id);
            if (men == null)
            {
                return null;
            }
            men.nombre = m.nombre;
            men.descripcion = m.descripcion;
            men.duracion_dia = m.duracion_dia;
            men.precio = m.precio;
            men.esRenovable = m.esRenovable;
            men.isActive = m.isActive;
            men.createdAt = m.createdAt;
            return men;
        }
        public async Task<bool> DeleteMembresiaAsync(int id)
        {
            var men = await _context.Membresias.FindAsync(id);
            if (men == null)
            {
                return false;
            }
            return true;
        }
    }
}