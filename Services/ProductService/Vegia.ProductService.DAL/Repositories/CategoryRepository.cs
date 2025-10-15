using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vegia.ProductService.Core.Interfaces;
using Vegia.ProductService.Core.Entities;
using Vegia.ProductService.DAL.Contexts;

namespace Vegia.ProductService.DAL.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductDbContext context) : base(context) { }

        public async Task<IEnumerable<Category>> GetCategoriesWithProductsAsync()
        {
            // Category doesn't have direct Products navigation property
            return await _dbSet.ToListAsync();
        }

        public async Task<Category?> GetCategoryByNameAsync(string name)
            => await _dbSet.FirstOrDefaultAsync(c => c.Name == name);

        public async Task<bool> CategoryHasProductsAsync(int categoryId)
        {
            // Check if any products have this category
            return await _context.Products.AnyAsync(p => p.CategoryId == categoryId);
        }
    }
}
