using PcBackEndAspNetAPI.Models.UsersModels;

namespace PcBackEndAspNetAPI.Models.CartModels
{
    public class CartModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public UserModel User { get; set; }
        public ICollection<CartItemModel> CartItems { get; set; }
    }
}
