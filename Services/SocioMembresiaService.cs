using Microsoft.EntityFrameworkCore;
using ApiGimnasio.Data;
using ApiGimnasio.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ApiGimnasio.Services
{
    public class SocioMembresiaService : ISocioMembresiaService
    {
        private readonly ScaffoldDbContext _context;
        public SocioMembresiaService(ScaffoldDbContext context)
        {
            _context = context;
        }
        public async Task<List<SocioMembresia>> GetSocioMembresiaAsync()
        {
            return await _context.SocioMembresias.
            Include(sm=>sm.socio).
            Include(sm=>sm.membresia).ToListAsync();
        }
        public async Task<int> GetCountSocioMembresiaAsync()
        {
            return await _context.SocioMembresias.CountAsync();
        }
        public async Task<SocioMembresia?> GetPorIdSocioMembresiaAsync(int socioId , int membresiaId)
        {
            return await _context.SocioMembresias.
            Include(sm=>sm.socio)
            .Include(sm=>sm.membresia)
            .SingleOrDefaultAsync(sm=>sm.socio_id == socioId && sm.membresia_id == membresiaId);
        }
        public async Task<SocioMembresia> PostSocioMembresiaAsync(SocioMembresia sm)
        {
            _context.SocioMembresias.Add(sm);
            await _context.SaveChangesAsync();
            return sm;
        }
        public async Task<SocioMembresia?> PutSocioMembresiaAsync(int socioId , int membresiaId , SocioMembresia sm)
        {
            var sme = await _context.SocioMembresias.
            SingleOrDefaultAsync(sm=> sm.socio_id == socioId && sm.membresia_id == membresiaId);
            if (sme == null)
            {
                return null;
            }
            sme.socio_id = sm.socio_id;
            sme.membresia_id = sm.membresia_id;
            sme.fecha_ingreso = sm.fecha_ingreso;
            sme.fecha_fin = sm.fecha_fin;
            sme.estado = sm.estado;
            sme.monto_pago = sm.monto_pago;
            sme.notas = sm.notas;
            sme.createdAt = sm.createdAt;

            return sme;
        }
        public async Task<bool> DeleteSocioMembresiaAsync(int socioId , int membresiaId)
        {
            var sme = await _context.SocioMembresias.
            SingleOrDefaultAsync(sm=>sm.socio_id == socioId && sm.membresia_id == membresiaId);
            if(sme == null)
            {
                return false;
            } 
            _context.SocioMembresias.Remove(sme);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}