using ApiGimnasio.Data;
using ApiGimnasio.Models;

public interface IRutinaService
{
    Task<List<Rutina>> GetRutinaAsync();
    Task<int> GetCountRutinaAsync();
    Task<Rutina?> GetPorIdRutinaAsync(int id);
    Task<Rutina>  PostRutinaAsync(Rutina r);

    Task<Rutina?> PutRutinaAsync(int id , Rutina r);
    Task<bool> DeleteRutinaAsync(int id);

}