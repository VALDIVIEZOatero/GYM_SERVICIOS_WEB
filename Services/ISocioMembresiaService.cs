using ApiGimnasio.Data;
using ApiGimnasio.Models;

public interface ISocioMembresiaService
{
    Task<List<SocioMembresia>> GetSocioMembresiaAsync();
    Task<int> GetCountSocioMembresiaAsync();
    Task<SocioMembresia?> GetPorIdSocioMembresiaAsync(int socioId , int membresiaId);
    Task<SocioMembresia>  PostSocioMembresiaAsync(SocioMembresia sm);

    Task<SocioMembresia?> PutSocioMembresiaAsync(int socioId , int membresiaId , SocioMembresia sm);
    Task<bool> DeleteSocioMembresiaAsync(int socioId , int membresiaId );

}