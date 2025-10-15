using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vegia.ProductService.Core.Interfaces;
using Vegia.ProductService.Core.Entities;
using Vegia.ProductService.DAL.Contexts;

namespace Vegia.ProductService.DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
            => await _dbSet.Where(p => p.CategoryId == categoryId).ToListAsync();

        public async Task<IEnumerable<Product>> GetProductsByVendorAsync(int vendorId)
            => await _dbSet.Where(p => p.ProductVendors.Any(pv => pv.VendorId == vendorId)).ToListAsync();

        public async Task<Product?> GetProductWithDetailsAsync(int id)
            => await _dbSet
                .Include(p => p.ProductImages)
                .Include(p => p.ProductVendors)
                    .ThenInclude(pv => pv.Vendor)
                .FirstOrDefaultAsync(p => p.ProductId == id);

        public async Task<IEnumerable<Product>> GetActiveProductsAsync()
            => await _dbSet.Where(p => p.IsActive).ToListAsync();

        public async Task<bool> ProductExistsAsync(string productName)
            => await _dbSet.AnyAsync(p => p.Name == productName);
    }
}
