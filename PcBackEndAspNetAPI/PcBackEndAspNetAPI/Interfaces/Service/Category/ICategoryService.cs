using PcBackEndAspNetAPI.Dto.Category;
using PcBackEndAspNetAPI.Models.CartModels;
using PcBackEndAspNetAPI.Models.ProductModels;

namespace PcBackEndAspNetAPI.Interfaces.Service.Category
{
    public interface ICategoryService
    {
        Task<CategoryModel> CreateCategory(CreateCategoryDto createCategoryDto);
        Task<CategoryModel> EditCategory(EditCategoryDto editCategoryDto);
        Task<CategoryModel> DeleteCategory(DeleteCategoryDto deleteCategoryDto);
        

    }
}
