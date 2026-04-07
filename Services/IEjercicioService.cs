using ApiGimnasio.Data;
using ApiGimnasio.Models;

public interface IEjercicioServicio
{
    Task<List<Ejercicio>> GetEjercicioAsync();
    Task<int> GetCountEjercicioAsync();
    Task<Ejercicio?> GetPorIdEjercicioAsync(int id);
    Task<Ejercicio>  PostEjercicioAsync(Ejercicio e);

    Task<Ejercicio?> UpdateEjercicioAsync(int id , Ejercicio e);
    Task<bool> DeleteEjercicioAsync(int id);

}