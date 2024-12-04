using PcBackEndAspNetAPI.Dto.Product;
using PcBackEndAspNetAPI.Models.ProductModels;

namespace PcBackEndAspNetAPI.Interfaces.Service.Product
{
    public interface IProductService
    {
        Task<ProductModel> CreateProduct(CreateProductDto createProduct);
        Task<ProductModel> EditProduct(EditProductDto editProductDto);
        Task<ProductModel> DeleteProduct(DeleteProductDto deleteProduct);

    }
}
