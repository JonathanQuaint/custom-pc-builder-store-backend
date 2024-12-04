using System.ComponentModel.DataAnnotations;

namespace PcBackEndAspNetAPI.Dto.Category
{
    public class EditCategoryDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<int> ProductIds { get; set; }

    }
}
