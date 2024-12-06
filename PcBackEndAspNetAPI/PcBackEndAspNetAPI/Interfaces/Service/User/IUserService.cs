using PcBackEndAspNetAPI.Dto.Product;
using PcBackEndAspNetAPI.Models.ProductModels;
using PcBackEndAspNetAPI.Models.UsersModels;

namespace PcBackEndAspNetAPI.Interfaces.Service.User
{
    public interface IUserService
    {
        Task<UserModel> CreateUser();
        Task<UserModel> UpdateUser();
        Task<bool> DeleteUser();

    }
}
