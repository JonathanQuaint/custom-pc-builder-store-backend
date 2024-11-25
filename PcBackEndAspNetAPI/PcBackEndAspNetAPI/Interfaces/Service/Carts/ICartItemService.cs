using PcBackEndAspNetAPI.Models.CartModels;
using PcBackEndAspNetAPI.Models.ProductModels;

namespace PcBackEndAspNetAPI.Interfaces.Service.Carts
{
    public interface ICartItemService
    {


        Task<List<CartItemModel>> CreateCartItem();
        Task<List<CartItemModel>> EditCartItem();
        Task<List<CartItemModel>> DeleteCartItem();


    }
}
