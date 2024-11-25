using PcBackEndAspNetAPI.Models.UsersModels;
using PcBackEndAspNetAPI.Services.Payment;

namespace PcBackEndAspNetAPI.Interfaces.Service.Payment
{
    public interface IPaymentService
    {
        Task<List<PaymentService>> CreatePayment();
        Task<List<PaymentService>> EditPayment();
        Task<List<PaymentService>> DeletePayment();

    }
}
