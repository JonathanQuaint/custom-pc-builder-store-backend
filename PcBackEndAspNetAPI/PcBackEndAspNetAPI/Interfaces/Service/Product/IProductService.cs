using PcBackEndAspNetAPI.Dto.Product;
using PcBackEndAspNetAPI.Models.ProductModels;

namespace PcBackEndAspNetAPI.Interfaces.Service.Product
{
    public interface IProductService
    {
        Task<List<ProductModel>> CreateProduct(CreateProductDto createProduct);
        Task<List<ProductModel>> EditProduct(CreateProductDto createProduct);
        Task<List<ProductModel>> DeleteProduct(CreateProductDto createProduct);

    }
}
