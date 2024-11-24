using PcBackEndAspNetAPI.Models.UsersModels;

namespace PcBackEndAspNetAPI.Models.CartModels
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public double TotalAmount { get; set; }
        public ICollection<OrderItemModel> OrderItems { get; set; }
    }
}
