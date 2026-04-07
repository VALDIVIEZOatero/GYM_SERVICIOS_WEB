using ApiGimnasio.Models;

public interface IEntrenadorService
{
    Task<List<Entrenador>> GetEntrenadorAsync();
    Task<int> GetCountEntrenadorAsync();
    Task<Entrenador?> GetPorIdEntrenadorAsync(int id);
    Task<Entrenador>  PostEntrenadorAsync(Entrenador entrenador);

    Task<Entrenador?> UpdateEntrenadorAsync(int id , Entrenador entrenador);
    Task<bool> DeleteEntrenadorAsync(int id);

}