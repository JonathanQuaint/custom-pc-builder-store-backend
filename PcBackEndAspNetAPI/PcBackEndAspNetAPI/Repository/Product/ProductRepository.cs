using PcBackEndAspNetAPI.Data;
using PcBackEndAspNetAPI.Interfaces.Repository.Product;
using PcBackEndAspNetAPI.Models.ProductModels;
using Microsoft.EntityFrameworkCore;

namespace PcBackEndAspNetAPI.Repository.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(ProductModel product)
        {
            _context.Products.Add(product);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsyc(ProductModel product)
        {
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(ProductModel product)
        {
            _context.Products.Update(product);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckProductExistByNameAsycn(string name)
        {
           bool ProductExistOrNot = await _context.Products.AnyAsync(p => p.Name == name);

            return ProductExistOrNot; 
        }

        public async Task<bool> CheckProductExistByIdAsycn(int Id)
        {
            bool ProductExistOrNot = await _context.Products.AnyAsync(p => p.Id == Id);

            return ProductExistOrNot;
        }

        public async Task<ProductModel?> FindProductByIdAsync(int Id)
        {
            return await _context.Products.FindAsync(Id);
        }

        public async Task<List<ProductModel>> GetProductsByIdAsync(List<int> productIds)
        {
            return await _context.Products.Where(c => productIds.Contains(c.Id)).ToListAsync();
        }
    }
}
   
