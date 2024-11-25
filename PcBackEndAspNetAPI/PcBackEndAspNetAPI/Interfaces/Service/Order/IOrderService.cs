using PcBackEndAspNetAPI.Models.CartModels;

namespace PcBackEndAspNetAPI.Interfaces.Service.Order
{
    public interface IOrderService
    {

        Task<List<OrderModel>> CreateOrder();
        Task<List<OrderModel>> EditOrder();
        Task<List<OrderModel>> DeleteOrder();


    }
}
