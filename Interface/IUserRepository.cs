using Library.API.Models.DTO.User;

namespace Library.API.Interface
{
    public interface IUserRepository
    {
        Task<List<GetUserDTO>> GetAllUserAsync();
        Task<GetUserDTO?> GetUserByIdAsync(int id);
        Task<GetUserDTO> CreateUserAsync(CreateUserDTO createUserDTO);
        void DeleteUser(int id);
    }
}
