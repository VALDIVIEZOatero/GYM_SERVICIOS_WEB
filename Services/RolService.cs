using Microsoft.EntityFrameworkCore;
using ApiGimnasio.Data;
using ApiGimnasio.Models;

namespace ApiGimnasio.Services
{
    public class RolService : IRolService
    {
        private readonly ScaffoldDbContext _context;

        public RolService(ScaffoldDbContext context)
        {
            _context = context;
        }

        public async Task<List<Rol>> GetRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        } 

        public async Task<int> GetCountRolesAsync()
        {
            return await _context.Roles.CountAsync();
            
        }
        public async Task<Rol?> GetPorIdRolesAsync(int id)
        {
            
            return await _context.Roles.FindAsync(id);
        }

        public async Task<Rol> PostRolesAsync(Rol nuevoRol)
        {
             _context.Roles.Add(nuevoRol);
             await _context.SaveChangesAsync();
             return nuevoRol;
        }

        public async Task<Rol?> PutRolesAsync(int id , Rol rol_put)
        {
            var rol = await _context.Roles.FindAsync(id);
            if(rol == null)
            {
                return null;
            }
            rol.name = rol_put.name;
            rol.nombre_normal = rol_put.nombre_normal;
            rol.isactive = rol_put.isactive;
            rol.createdAt = rol_put.createdAt;
            await _context.SaveChangesAsync();
            return rol;
        }
        public async Task<bool> DeleteRolesAsync(int id)
        {
            var rol = await _context.Roles.FindAsync(id);

            if(rol == null) return false;
            
            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}