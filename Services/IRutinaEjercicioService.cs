using ApiGimnasio.Data;
using ApiGimnasio.Models;

public interface IRutinaEjercicioService
{
    Task<List<RutinaEjercicio>> GetRutinaEjercicioAsync();
    Task<int> GetCountRutinaEjercicioAsync();
    Task<RutinaEjercicio?> GetPorIdRutinaEjercicioAsync(int rutinaId , int ejercicioId);
    Task<RutinaEjercicio>  PostRutinaEjercicioAsync(RutinaEjercicio re);

    Task<RutinaEjercicio?> PutRutinaEjercicioAsync(int rutinaId , int ejercicioId , RutinaEjercicio re);
    Task<bool> DeleteRutinaEjercicioAsync(int rutinaId , int ejercicioId);

}