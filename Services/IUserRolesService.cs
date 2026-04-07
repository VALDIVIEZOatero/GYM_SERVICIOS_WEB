using ApiGimnasio.Models;

public interface IUserRoleService
{
    Task<List<UserRole>> GetUserRolesAsync();
    Task<int> GetCountUseRolesAsync();
    Task<UserRole?> GetPorIdUserRolesAsync(int Uid , int Rid);
    Task<UserRole>  PostUserRolesAsync(UserRole user_rol);

    Task<UserRole?> PutUserRolesAsync(int Uid , int Rid , UserRole user_rol);
    Task<bool> DeleteUserRolesAsync(int id , int idr);

}