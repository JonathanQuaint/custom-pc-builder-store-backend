using PcBackEndAspNetAPI.Dto.Product;
using PcBackEndAspNetAPI.Models.ProductModels;
using PcBackEndAspNetAPI.Models.UsersModels;

namespace PcBackEndAspNetAPI.Interfaces.Service.User
{
    public interface IUserService
    {
        Task<List<UserModel>> CreateUser();
        Task<List<UserModel>> EditUser();
        Task<List<UserModel>> DeleteUser();

    }
}
