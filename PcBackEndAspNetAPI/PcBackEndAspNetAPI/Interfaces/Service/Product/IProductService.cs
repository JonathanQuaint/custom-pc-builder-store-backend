using PcBackEndAspNetAPI.Dto.Product;
using PcBackEndAspNetAPI.Models.ProductModels;

namespace PcBackEndAspNetAPI.Interfaces.Service.Product
{
    public interface IProductService
    {
        Task<ProductModel> CreateProduct(CreateProductDto createProduct);
        Task<ProductModel> EditProduct(CreateProductDto createProduct);
        Task<ProductModel> DeleteProduct(CreateProductDto createProduct);

    }
}
