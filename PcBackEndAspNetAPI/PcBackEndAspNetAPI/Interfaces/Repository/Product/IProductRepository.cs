using PcBackEndAspNetAPI.Dto.Product;
using PcBackEndAspNetAPI.Models.ProductModels;

namespace PcBackEndAspNetAPI.Interfaces.Repository.Product
{
    public interface IProductRepository
    {
        Task AddProductAsync(ProductModel product);
        Task UpdateProductAsync(ProductModel product);
        Task DeleteProductAsyc(ProductModel product);
        Task<bool> CheckProductExistByNameAsycn(string name);
        Task<bool> CheckProductExistByIdAsycn(int Id);
        Task<ProductModel?> FindProductByIdAsync(int Id);
        Task<List<ProductModel>> GetProductsByIdAsync(List<int> productIds);

    }
}
