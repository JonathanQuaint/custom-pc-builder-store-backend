using Newtonsoft.Json;
using PcBackEndAspNetAPI.Dto.Product;
using PcBackEndAspNetAPI.Interfaces.Repository.Category;
using PcBackEndAspNetAPI.Interfaces.Repository.Product;
using PcBackEndAspNetAPI.Interfaces.Service.Product;
using PcBackEndAspNetAPI.Models.ProductModels;

namespace PcBackEndAspNetAPI.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ProductModel> CreateProduct(CreateProductDto createProduct)
        {
            bool ProductExistOrNot = await _productRepository.CheckProductExistByNameAsycn(createProduct.Name);
            if (ProductExistOrNot)
            {

                throw new ApplicationException("The product already exists");

            }

            var categories = await _categoryRepository.GetCategoriesByIdAsync(createProduct.CategoryIds);

            if (categories.Count != createProduct.CategoryIds.Count)
            {
                throw new ApplicationException("One or more categories not found");
            }

            var product = new ProductModel
            {
                Name = createProduct.Name,
                Description = createProduct.Description,
                Price = createProduct.Price,
                Brand = createProduct.Brand,
                Stock = createProduct.Stock,
                Categories = categories,
                ImageUrl = createProduct.ImageUrl
            };


            await _productRepository.AddProductAsync(product);
            return product;
        }

        public Task<ProductModel> DeleteProduct(CreateProductDto createProduct)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> EditProduct(CreateProductDto createProduct)
        {
            throw new NotImplementedException();
        }
    }
}
