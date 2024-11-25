using PcBackEndAspNetAPI.Models.CartModels;
using PcBackEndAspNetAPI.Models.ProductModels;

namespace PcBackEndAspNetAPI.Interfaces.Service.Category
{
    public interface ICategoryService
    {


        Task<List<CategoryModel>> CreateCategory();
        Task<List<CategoryModel>> EditCategory();
        Task<List<CategoryModel>> DeleteCategory();


    }
}
