using PcBackEndAspNetAPI.Models.ProductModels;

namespace PcBackEndAspNetAPI.Models.CartModels
{
    public class CartItemModel
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public CartModel Cart { get; set; }
        public int ProductID { get; set; }
        public ProductModel Product { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
