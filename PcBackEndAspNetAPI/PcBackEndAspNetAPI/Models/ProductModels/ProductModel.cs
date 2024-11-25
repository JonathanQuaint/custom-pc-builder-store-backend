namespace PcBackEndAspNetAPI.Models.ProductModels
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
        public ICollection<CategoryModel> Categories { get; set; }
        public string ImageUrl { get; set; }
    }
}
