using PcBackEndAspNetAPI.Models.CartModels;

namespace PcBackEndAspNetAPI.Interfaces.Service.Carts
{
    public interface ICartService
    {

        Task<List<CartModel>> CreateCart();
        Task<List<CartModel>> EditCart();
        Task<List<CartModel>> DeleteCart();



    }
}
