using PcBackEndAspNetAPI.Dto.Category;
using PcBackEndAspNetAPI.Dto.Product;
using PcBackEndAspNetAPI.Interfaces.Repository.Category;
using PcBackEndAspNetAPI.Interfaces.Repository.Product;
using PcBackEndAspNetAPI.Interfaces.Service.Category;
using PcBackEndAspNetAPI.Models.ProductModels;

namespace PcBackEndAspNetAPI.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<CategoryModel> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            bool categoryNameExist = await _categoryRepository.CheckCategoryExistByNameAsync(createCategoryDto.Name);

            if (categoryNameExist)
            {
                throw new ApplicationException("The categoryr name already exists");
            }

            var category = new CategoryModel
            {
                Name = createCategoryDto.Name
            };


            await _categoryRepository.AddCategoryAsync(category);

            return category;
        }

        public async Task<CategoryModel> EditCategory(EditCategoryDto editCategoryDto)
        {
            bool categoryIdExist = await _categoryRepository.CheckCategoryExistByIdAsync(editCategoryDto.Id);

            if (!categoryIdExist)
            {
                throw new ApplicationException("The id of the category not found");
            }

            var category = await _categoryRepository.GetCategoryByIdAsync(editCategoryDto.Id);

            if (editCategoryDto.ProductIds != null)
            {
                var existingProductIds = category.Products.Select(c => c.Id).ToList();
                var newProductIds = editCategoryDto.ProductIds.Except(existingProductIds).ToList();
                var removedProductIds = existingProductIds.Except(editCategoryDto.ProductIds).ToList();

                // Add new products
                if (newProductIds.Any())
                {
                    var newProducts = await _productRepository.GetProductsByIdAsync(newProductIds);
                    foreach (var product in newProducts)
                    {
                        category.Products.Add(product);
                        product.Categories.Add(category);
                    }
                }

                // Remove old products
                if (removedProductIds.Any())
                {
                    var removedProducts = category.Products.Where(p => removedProductIds.Contains(p.Id)).ToList();
                    foreach (var product in removedProducts)
                    {
                        category.Products.Remove(product);
                        product.Categories.Remove(category);
                    }
                }
            }

            await _categoryRepository.UpdateCategoryAsync(category);

            return category;
        }

        public async Task<CategoryModel> DeleteCategory(DeleteCategoryDto deleteCategoryDto)
        {
            bool categoryIdExist = await _categoryRepository.CheckCategoryExistByIdAsync(deleteCategoryDto.Id);
            if (!categoryIdExist)
            {
                throw new ApplicationException("The id of the category not found");
            }

            var category = await _categoryRepository.GetCategoryByIdAsync(deleteCategoryDto.Id);

            if (category.Name != deleteCategoryDto.Name)
            {
                throw new ApplicationException($"The name of category is different from {deleteCategoryDto.Name}");
            }

            await _categoryRepository.DeleteCategoryAsyc(category);

            return category;
        }


    }
}

