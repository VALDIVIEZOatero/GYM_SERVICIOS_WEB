
using ApiGimnasio.Models;
using ApiGimnasio.Dtos;
namespace ApiGimnasio.Services
{
    public interface IUsuarioService
    {
        Task<string?> LoginAsync(LoginDto login);
        Task<UserResponseDto> RegisterAsync(RegisterDto register);
        Task<List<UserResponseDto>> GetAllUsers();
    }
}
