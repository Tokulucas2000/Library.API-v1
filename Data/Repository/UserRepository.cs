using Library.API.Interface;
using Library.API.Models.DTO.User;
using Library.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext _context;
        public UserRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<List<GetUserDTO>> GetAllUserAsync()
        {
            return  await _context.Users
                .Where(u => !u.Deleted) 
                .Select(u => new GetUserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email
                })
                .ToListAsync();
        }

        public async Task<GetUserDTO?> GetUserByIdAsync(int id)
        {
            var users = await _context.Users.Where(u => u.Id == id && !u.Deleted)
                .Select(u => new GetUserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email
                })
                .FirstOrDefaultAsync();
            if (users == null)
            {
                throw new Exception("A user does not exist or already has been deleted"); 
            }
            return users;
        }

        public async Task<GetUserDTO> CreateUserAsync(CreateUserDTO createUserDTO)
        {
            try 
            {
                if(createUserDTO == null)
                {
                    throw new ArgumentNullException(nameof(createUserDTO), "CreateUserDTO cannot be null.");
                }

                var validateUser = _context.Users.Any(u => u.Email == createUserDTO.Email && !u.Deleted);
                if (validateUser)
                {
                    throw new Exception("A user with the same email already exists.");
                }
                var user = new User
                {
                    Name = createUserDTO.Name,
                    Email = createUserDTO.Email,
                };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return new GetUserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteUser(int id)
        {
            var findUser = _context.Users.FirstOrDefault(u => u.Id == id && !u.Deleted);
            if (findUser == null)
            {
                throw new Exception("User not found or already deleted.");
            }
            findUser.Deleted = true;
            _context.Update(findUser);
            _context.SaveChanges();
        }

    }
}
