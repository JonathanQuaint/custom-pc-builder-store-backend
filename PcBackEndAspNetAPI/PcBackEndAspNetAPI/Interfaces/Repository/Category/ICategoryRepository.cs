using PcBackEndAspNetAPI.Models.ProductModels;

namespace PcBackEndAspNetAPI.Interfaces.Repository.Category
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(ProductModel product);
        Task UpdateCategoryAsync(ProductModel product);
        Task DeleteCategoryAsyc(ProductModel product);
        Task<List<CategoryModel>> GetCategoriesByIdAsync(List<int> categoryIds);
        Task<CategoryModel> GetCategoryById(int categoryId);
        Task<CategoryModel> GetCategoryByName(string name);

    }
}
