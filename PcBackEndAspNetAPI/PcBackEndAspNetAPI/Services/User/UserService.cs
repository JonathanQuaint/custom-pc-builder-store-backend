using PcBackEndAspNetAPI.Interfaces.Repository.User;
using PcBackEndAspNetAPI.Interfaces.Service.User;
using PcBackEndAspNetAPI.Models.UsersModels;

namespace PcBackEndAspNetAPI.Services.User
{
    public class UserService : IUserService
    {
        public Task<UserModel> CreateUser()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser()
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUserById()
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}
