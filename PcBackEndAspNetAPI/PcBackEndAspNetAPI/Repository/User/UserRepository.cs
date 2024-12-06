using PcBackEndAspNetAPI.Data;
using PcBackEndAspNetAPI.Interfaces.Repository.User;
using PcBackEndAspNetAPI.Models.UsersModels;

namespace PcBackEndAspNetAPI.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(UserModel user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        
        }

        public Task<bool> CheckUserExistByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(UserModel user)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUserByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
