using PcBackEndAspNetAPI.Models.CartModels;

namespace PcBackEndAspNetAPI.Models.PaymentModels
{
    public class PaymentModel
    {
       public int ID { get; set; }
        public int OrderID { get; set; }
        public OrderModel Order { get; set; }
        public DateTime PaymentDate { get; set; }
        public string TransationId { get; set; }
        public string Status { get; set; }
    }
}
