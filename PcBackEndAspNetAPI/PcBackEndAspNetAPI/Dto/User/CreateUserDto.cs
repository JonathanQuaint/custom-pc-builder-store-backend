using System.ComponentModel.DataAnnotations;

namespace PcBackEndAspNetAPI.Dto.User
{
    public class CreateUserDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
