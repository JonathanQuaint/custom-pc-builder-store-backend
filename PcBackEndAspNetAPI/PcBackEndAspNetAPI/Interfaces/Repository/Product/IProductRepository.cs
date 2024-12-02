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
        Task<ProductModel> 
    }
}
