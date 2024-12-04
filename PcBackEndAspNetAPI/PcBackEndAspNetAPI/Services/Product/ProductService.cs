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

            foreach (var category in categories)
            {
                category.Products.Add(product);
            }

            await _productRepository.AddProductAsync(product);
            return product;
        }

     
        public async Task<ProductModel> EditProduct(EditProductDto editProductDto)
        {
            bool productIdExistOrNot = await _productRepository.CheckProductExistByIdAsycn(editProductDto.Id);

            if (!productIdExistOrNot)
            {
                throw new ApplicationException($"No product found with the id {editProductDto.Id}");
            }

            var product = await _productRepository.FindProductByIdAsync(editProductDto.Id);

            if (product == null)
            {
                throw new ApplicationException($"No product found with the id {editProductDto.Id}");
            }

            // Update properties if they are not null or default
            product.Name = editProductDto.Name ?? product.Name;
            product.Description = editProductDto.Description ?? product.Description;
            product.Price = editProductDto.Price != default ? editProductDto.Price : product.Price;
            product.Brand = editProductDto.Brand ?? product.Brand;
            product.Stock = editProductDto.Stock != default ? editProductDto.Stock : product.Stock;
            product.ImageUrl = editProductDto.ImageUrl ?? product.ImageUrl;

            if (editProductDto.CategoryIds != null)
            {
                var existingCategoryIds = product.Categories.Select(c => c.Id).ToList();
                var newCategoryIds = editProductDto.CategoryIds.Except(existingCategoryIds).ToList();
                var removedCategoryIds = existingCategoryIds.Except(editProductDto.CategoryIds).ToList();

                // Add new categories
                if (newCategoryIds.Any())
                {
                    var newCategories = await _categoryRepository.GetCategoriesByIdAsync(newCategoryIds);
                    foreach (var category in newCategories)
                    {
                        product.Categories.Add(category);
                        category.Products.Add(product);
                    }
                }

                // Remove old categories
                if (removedCategoryIds.Any())
                {
                    var removedCategories = product.Categories.Where(c => removedCategoryIds.Contains(c.Id)).ToList();
                    foreach (var category in removedCategories)
                    {
                        product.Categories.Remove(category);
                        category.Products.Remove(product);
                    }
                }
            }


            await _productRepository.UpdateProductAsync(product);
            return product;
        }

        public async Task<ProductModel> DeleteProduct(DeleteProductDto deleteProduct)
        {

            bool ProductIdExistOrNot = await _productRepository.CheckProductExistByIdAsycn(deleteProduct.Id);

            if (!ProductIdExistOrNot)
            {
                throw new ApplicationException($"No product found with the id {deleteProduct.Id}");

            }

            var product = await _productRepository.FindProductByIdAsync(deleteProduct.Id);


            if (product.Name != deleteProduct.Name)
            {

                throw new ApplicationException($"The name of product is different from {deleteProduct.Name}");

            }

            var categories = product.Categories;

            foreach (var category in categories)
            {
                category.Products.Remove(product);
            }

            await _productRepository.DeleteProductAsyc(product);
            return product;
        }

    }
}
