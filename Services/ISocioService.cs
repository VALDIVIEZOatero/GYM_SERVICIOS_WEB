using ApiGimnasio.Data;
using ApiGimnasio.Models;

public interface ISocioService
{
    Task<List<Socio>> GetSocioAsync();
    Task<int> GetCountSociosAsync();
    Task<Socio?> GetPorIdSociosAsync(int id);
    Task<Socio>  PostSociosAsync(Socio socio);

    Task<Socio?> PutSociosAsync(int id , Socio socio);
    Task<bool> DeleteSociosAsync(int id);

}