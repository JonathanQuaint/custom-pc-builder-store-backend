using PcBackEndAspNetAPI.Models.UsersModels;

namespace PcBackEndAspNetAPI.Interfaces.Repository.User
{
    public interface IUserRepository
    {
        Task AddUserAsync(UserModel user);
        Task<UserModel> GetUserByIdAsync(string userId);
        Task UpdateUserAsync(UserModel user);
        Task DeleteUserAsync(UserModel user);
        Task<bool> CheckUserExistByIdAsync(string userId);
    }
}
