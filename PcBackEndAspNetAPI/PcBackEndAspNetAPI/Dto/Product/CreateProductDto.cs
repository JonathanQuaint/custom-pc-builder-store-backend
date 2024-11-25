using Microsoft.Build.Framework;

namespace PcBackEndAspNetAPI.Dto.Product
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Brand { get; set; }


        [Required]
        public int Stock { get; set; }


        [Required]
        public string Category { get; set; }

        public string ImageUrl { get; set; }

    }
}
