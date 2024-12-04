using System.ComponentModel.DataAnnotations;

namespace PcBackEndAspNetAPI.Dto.Product
{
    public class EditProductDto
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
        public List<int> CategoryIds { get; set; }
        public string ImageUrl { get; set; }

    }
}
