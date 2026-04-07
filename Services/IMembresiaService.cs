using ApiGimnasio.Models;
public interface IMembresiaService
{
    Task<List<Membresia>> GetMembresiaAsync();
    Task<int> GetCountMembresiaAsync();
    Task<Membresia?> GetPorIdMembresiaAsync(int id);
    Task<Membresia>  PostMembresiaAsync(Membresia m);

    Task<Membresia?> PutMembresiaAsync(int id , Membresia m);
    Task<bool> DeleteMembresiaAsync(int id);

}