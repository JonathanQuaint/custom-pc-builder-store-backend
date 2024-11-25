using PcBackEndAspNetAPI.Models.CartModels;
using PcBackEndAspNetAPI.Services.Payment;

namespace PcBackEndAspNetAPI.Interfaces.Service.Order
{
    public interface IOrderItemService
    {
        Task<List<OrderItemModel>> CreateOrder();
        Task<List<OrderItemModel>> EditOrder();
        Task<List<OrderItemModel>> DeleteOrder();

    }
}
