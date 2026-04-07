using ApiGimnasio.Data;
using ApiGimnasio.Dtos;
using ApiGimnasio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiGimnasio.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ScaffoldDbContext _context;
        private readonly IConfiguration _configuration;

        public UsuarioService(ScaffoldDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<List<UserResponseDto>> GetAllUsers()
        {
            var usuarios = await _context.Usuarios
            .Include(u=>u.user_roles)
            .ThenInclude(u=>u.rols)
            .ToListAsync();
                return usuarios.Select(u => new UserResponseDto
    {
        Id = u.user_id,
        UserName = u.user_name,
        Email = u.correo,
        Telefono = u.telefono,
        IsActive = u.isactive,
        Roles = u.user_roles
                    .Where(ur => ur.rols != null)
                    .Select(ur =>(string?) ur.rols!.name)
                    .ToList()
    }).ToList();
        }

        // Login seguro
        public async Task<string?> LoginAsync(LoginDto login)
        {
            var user = await _context.Usuarios
                .Include(u => u.user_roles)
                .ThenInclude(ur => ur.rols)
                .FirstOrDefaultAsync(u => u.user_name == login.UserName);

            if (user == null)
                return null;

            user.last_loginAt = DateTime.Now;
            await _context.SaveChangesAsync();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.user_name),
                new Claim("UserId", user.user_id.ToString())
            };

            // Seguridad: verificamos null
            foreach (var ur in user.user_roles ?? new List<UserRole>())
            {
                if (ur.rols != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, ur.rols.name));
                }
            }

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
            );
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "ApiGimnasio",
                audience: "ApiGimnasioUsers",
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // Registro seguro
        public async Task<UserResponseDto> RegisterAsync(RegisterDto register)
        {
            var user = new Usuario
            {
                user_name = register.UserName,
                nombreUser_normal = register.UserName.ToUpper(),
                correo = register.Email,
                correo_normal = register.Email.ToUpper(),
                password_user = register.Password,
                telefono = register.Telefono,
                createdAt = DateTime.Now,
                isactive = true
            };

            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();

            var userRole = new UserRole
            {
                user_id = user.user_id,
                rol_id = register.RolId,
                assignedAt = DateTime.Now
            };

            _context.UserRoles.Add(userRole);
            await _context.SaveChangesAsync();

            // Traemos los roles de manera segura
            var roles = await _context.UserRoles
    .Where(ur => ur.user_id == user.user_id)
    .Include(ur => ur.rols)
    .Select(ur => ur.rols != null ? ur.rols.name : null)
    .Where(name => !string.IsNullOrEmpty(name)) // filtra null y ""
    .ToListAsync();

            return new UserResponseDto
            {
                Id = user.user_id,
                UserName = user.user_name,
                Email = user.correo,
                Telefono = user.telefono,
                IsActive = true,
                Roles = roles
            };
        }
    }
}