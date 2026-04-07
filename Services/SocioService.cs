using Microsoft.EntityFrameworkCore;
using ApiGimnasio.Data;
using ApiGimnasio.Models;

namespace ApiGimnasio.Services
{
    public class SocioService : ISocioService
    {
        private readonly ScaffoldDbContext _context;

        public SocioService(ScaffoldDbContext context)
        {
            _context = context;
        }
        public async Task<List<Socio>> GetSocioAsync()
        {
            return await _context.Socios.ToListAsync();
        }
        public async Task<int> GetCountSociosAsync()
        {
            return await _context.Socios.CountAsync();
        }
        public async Task<Socio?> GetPorIdSociosAsync(int id)
        {
            return await _context.Socios.FindAsync(id);
            
        }

        public async Task<Socio> PostSociosAsync(Socio socio)
        {
            _context.Socios.Add(socio);
            await _context.SaveChangesAsync();
            return socio;
        }

        public async Task<Socio?> PutSociosAsync(int id , Socio socio)
        {
            var socio_put = await _context.Socios.FindAsync(id);
            if(socio_put == null)
            {
                return null;
            }
            socio_put.user_id = socio.user_id;
            socio_put.fecha_nacimiento = socio.fecha_nacimiento;
            socio_put.genero = socio.genero;
            socio_put.alturacm = socio.alturacm;
            socio_put.peso = socio.peso;
            socio_put.emergencia_nombre = socio.emergencia_nombre;
            socio_put.emergencia_telefono = socio.emergencia_telefono;
            socio_put.fecha_registro = socio.fecha_registro;
            socio_put.isActive = socio.isActive;

            await _context.SaveChangesAsync();
            return socio_put;
        }
        public async Task<bool> DeleteSociosAsync(int id)
        {
           var socio = await _context.Socios.FindAsync(id);
           if(socio == null)return false;
           _context.Socios.Remove(socio);
           await _context.SaveChangesAsync();
           return true;   
        }


    }
}