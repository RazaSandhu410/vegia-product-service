using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vegia.ProductService.Core.Interfaces;
using Vegia.ProductService.Core.Entities;
using Vegia.ProductService.DAL.Contexts;

namespace Vegia.ProductService.DAL.Repositories
{
    public class ProductVendorRepository : Repository<ProductVendor>, IProductVendorRepository
    {
        public ProductVendorRepository(ProductDbContext context) : base(context) { }

        public async Task<IEnumerable<ProductVendor>> GetVendorProductsAsync(int vendorId)
            => await _dbSet
                .Include(pv => pv.Product)
                .Where(pv => pv.VendorId == vendorId)
                .ToListAsync();

        public async Task<ProductVendor?> GetProductVendorAsync(int productId, int vendorId)
            => await _dbSet
                .FirstOrDefaultAsync(pv => pv.ProductId == productId && pv.VendorId == vendorId);

        public async Task<bool> ProductVendorExistsAsync(int productId, int vendorId)
            => await _dbSet
                .AnyAsync(pv => pv.ProductId == productId && pv.VendorId == vendorId);
    }
}
