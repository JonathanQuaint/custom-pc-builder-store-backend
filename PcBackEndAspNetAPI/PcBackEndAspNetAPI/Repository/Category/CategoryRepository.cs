using Microsoft.EntityFrameworkCore;
using PcBackEndAspNetAPI.Data;
using PcBackEndAspNetAPI.Interfaces.Repository.Category;
using PcBackEndAspNetAPI.Models.ProductModels;

namespace PcBackEndAspNetAPI.Repository.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCategoryAsync(CategoryModel category)
        {
            _context.Categories.Add(category);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(CategoryModel category)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsyc(CategoryModel category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryModel>> GetCategoriesByIdAsync(List<int> categoryIds)
        {
            return await _context.Categories.Where(c => categoryIds.Contains(c.Id)).ToListAsync();
        }

        public async Task<CategoryModel?> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }

        public async Task<CategoryModel?> GetCategoryByNameAsync(string name)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<bool> CheckCategoryExistByNameAsync(string name)
        {
            bool CategoryExistOrNot = await _context.Categories.AnyAsync(p => p.Name == name);

            return CategoryExistOrNot;
        }

        public async Task<bool> CheckCategoryExistByIdAsync(int Id)
        {
            bool CategoryExistOrNot = await _context.Categories.AnyAsync(p => p.Id == Id);

            return CategoryExistOrNot;
        }
    }
}
