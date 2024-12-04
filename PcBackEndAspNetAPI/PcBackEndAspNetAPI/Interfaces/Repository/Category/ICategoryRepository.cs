using PcBackEndAspNetAPI.Models.ProductModels;

namespace PcBackEndAspNetAPI.Interfaces.Repository.Category
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(CategoryModel category);
        Task UpdateCategoryAsync(CategoryModel category);
        Task DeleteCategoryAsyc(CategoryModel category);
        Task<List<CategoryModel>> GetCategoriesByIdAsync(List<int> categoryIds);
        Task<CategoryModel> GetCategoryByIdAsync(int Id);
        Task<CategoryModel> GetCategoryByNameAsync(string name);
        Task<bool> CheckCategoryExistByNameAsync(string name);
        Task<bool> CheckCategoryExistByIdAsync(int Id);

    }
}
