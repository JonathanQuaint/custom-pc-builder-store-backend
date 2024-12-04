using System.ComponentModel.DataAnnotations;

namespace PcBackEndAspNetAPI.Dto.Category
{
    public class DeleteCategoryDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
