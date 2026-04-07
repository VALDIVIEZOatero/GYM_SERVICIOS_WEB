using ApiGimnasio.Models;

public interface IRolService
{
    Task<List<Rol>> GetRolesAsync();
    Task<int> GetCountRolesAsync();
    Task<Rol?> GetPorIdRolesAsync(int id);
    Task<Rol>  PostRolesAsync(Rol rol);

    Task<Rol?> PutRolesAsync(int id , Rol rol);
    Task<bool> DeleteRolesAsync(int id);

}