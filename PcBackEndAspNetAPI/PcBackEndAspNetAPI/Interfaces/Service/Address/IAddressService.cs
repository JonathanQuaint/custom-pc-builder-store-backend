using PcBackEndAspNetAPI.Models.CartModels;
using PcBackEndAspNetAPI.Services.Address;

namespace PcBackEndAspNetAPI.Interfaces.Service.Address
{
    public interface IAddressService
    {


        Task<List<AddressService>> CreateAddress();
        Task<List<AddressService>> EditAddress();
        Task<List<AddressService>> DeleteAddress();


    }
}
