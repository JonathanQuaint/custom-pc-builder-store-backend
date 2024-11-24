using PcBackEndAspNetAPI.Models.CartModels;

namespace PcBackEndAspNetAPI.Models.UsersModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }      
        public ICollection<AddressModel> Address { get; set; }
        public ICollection<OrderModel> Orders { get; set; }
    }
}
