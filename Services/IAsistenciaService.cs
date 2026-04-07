
using ApiGimnasio.Models;
public interface IAsistenciaService
{
    Task<List<Asistencia>> GetAsistenciaAsync();
    Task<int> GetCountAsistenciaAsync();
    Task<Asistencia?> GetPorIdAsistenciaAsync(int id);
    Task<Asistencia>  PostAsistenciaAsync(Asistencia a);

    Task<Asistencia?> UpdateAsistenciaAsync(int id , Asistencia a);
    Task<bool> DeleteAsistenciaAsync(int id);

}