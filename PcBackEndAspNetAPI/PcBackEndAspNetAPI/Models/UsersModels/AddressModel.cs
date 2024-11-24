namespace PcBackEndAspNetAPI.Models.UsersModels
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int UserID { get; set; }
        public UserModel User { get; set; }


    }
}
