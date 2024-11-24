using PcBackEndAspNetAPI.Models.ProductModels;

namespace PcBackEndAspNetAPI.Models.CartModels
{
    public class OrderItemModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderModel Order { get; set; }
        public int ProductID { get; set; }
        public ProductModel Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

    }
}
