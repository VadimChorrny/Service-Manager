using Core.DTOs.UserDTO;

namespace Core.Interfaces.CustomServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> Get();
        Task<UserDTO> GetUserById(string id);
        Task<UserDTO> GetUserByEmail(string email);
        Task Create(UserDTO user);
        Task Edit(UserDTO user);
        Task Delete(string id);
        //Task<string> GetUserRoleAsync(Author author);
        //Task<IEnumerable<TableResponseDTO>> GetUserTables(string id);
    }
}
