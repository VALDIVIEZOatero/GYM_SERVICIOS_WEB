using Microsoft.EntityFrameworkCore;
using ApiGimnasio.Data;
using ApiGimnasio.Models;

namespace ApiGimnasio.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly ScaffoldDbContext _context;

        public UserRoleService(ScaffoldDbContext context)
        {
            _context = context;
        }

        // Obtener todos los UserRoles
        public async Task<List<UserRole>> GetUserRolesAsync()
        {
            return await _context.UserRoles
                .Include(ur => ur.usuarios)
                .Include(ur => ur.rols)
                .ToListAsync();
        }

        // Contar todos los UserRoles
        public async Task<int> GetCountUseRolesAsync()
        {
            return await _context.UserRoles.CountAsync();
        }

        // Obtener UserRole por UserId y RoleId
        public async Task<UserRole?> GetPorIdUserRolesAsync(int Uid, int Rid)
        {
            return await _context.UserRoles
                .Include(ur => ur.usuarios)
                .Include(ur => ur.rols)
                .SingleOrDefaultAsync(ur => ur.user_id == Uid && ur.rol_id == Rid);
        }

        // Crear nuevo UserRole
        public async Task<UserRole> PostUserRolesAsync(UserRole nuevo_userol)
        {
            _context.UserRoles.Add(nuevo_userol);
            await _context.SaveChangesAsync();
            return nuevo_userol;
        }

        // Actualizar UserRole existente
        public async Task<UserRole?> PutUserRolesAsync(int u, int r, UserRole userol_put)
        {
            var user_rol = await _context.UserRoles
                .SingleOrDefaultAsync(ur => ur.user_id == u && ur.rol_id == r);

            if (user_rol == null) return null;

            // Actualizamos propiedades
            user_rol.user_id = userol_put.user_id;
            user_rol.rol_id = userol_put.rol_id;
            user_rol.assignedAt = userol_put.assignedAt;

            await _context.SaveChangesAsync();
            return user_rol;
        }

        // Eliminar UserRole
        public async Task<bool> DeleteUserRolesAsync(int u, int r)
        {
            var user_rol = await _context.UserRoles
                .SingleOrDefaultAsync(ur => ur.user_id == u && ur.rol_id == r);

            if (user_rol == null) return false;

            _context.UserRoles.Remove(user_rol);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
