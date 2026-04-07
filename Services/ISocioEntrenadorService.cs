using ApiGimnasio.Models;

public interface ISocioEntrenadorService
{
    Task<List<SocioEntrenador>> GetSocioEntrenadorAsync();
    Task<int> GetCountSocioEntrenadorAsync();
    Task<SocioEntrenador?> GetPorIdSocioEntrenadorAsync(int socioId , int entrenadorId);
    Task<SocioEntrenador>  PostSocioEntrenadorAsync(SocioEntrenador se);

    Task<SocioEntrenador?> PutSocioEntrenadorAsync(int socioId , int entrenadorId , SocioEntrenador se);
    Task<bool> DeleteSocioEntrenadorAsync(int socioId , int entrenadorId);

}