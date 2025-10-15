using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vegia.ProductService.Core.Interfaces;
using Vegia.ProductService.Core.Entities;
using Vegia.ProductService.DAL.Contexts;

namespace Vegia.ProductService.DAL.Repositories
{
    public class VendorRepository : Repository<Vendor>, IVendorRepository
    {
        public VendorRepository(ProductDbContext context) : base(context) { }

        public async Task<IEnumerable<Vendor>> GetVendorsWithProductsAsync()
            => await _dbSet
                .Include(v => v.ProductVendors)
                    .ThenInclude(pv => pv.Product)
                .ToListAsync();

        public async Task<Vendor?> GetVendorByEmailAsync(string email)
            => await _dbSet.FirstOrDefaultAsync(v => v.Email == email);

        public async Task<IEnumerable<Vendor>> GetActiveVendorsAsync()
            => await _dbSet.Where(v => v.IsActive).ToListAsync();
    }
}
