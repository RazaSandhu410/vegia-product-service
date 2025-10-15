using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vegia.ProductService.Core.Interfaces;
using Vegia.ProductService.Core.Entities;
using Vegia.ProductService.DAL.Contexts;

namespace Vegia.ProductService.DAL.Repositories
{
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(ProductDbContext context) : base(context) { }

        public async Task<IEnumerable<ProductImage>> GetImagesByProductAsync(int productId)
            => await _dbSet.Where(pi => pi.ProductId == productId).ToListAsync();

        public async Task<ProductImage?> GetPrimaryImageAsync(int productId)
            => await _dbSet.FirstOrDefaultAsync(pi => pi.ProductId == productId && pi.IsPrimary);

        public async Task<bool> SetPrimaryImageAsync(int imageId)
        {
            var image = await _dbSet.FindAsync(imageId);
            if (image == null) return false;

            // Reset current primary image
            var currentPrimary = await _dbSet
                .FirstOrDefaultAsync(pi => pi.ProductId == image.ProductId && pi.IsPrimary);
            if (currentPrimary != null)
            {
                currentPrimary.IsPrimary = false;
                _dbSet.Update(currentPrimary);
            }

            // Set new primary image
            image.IsPrimary = true;
            _dbSet.Update(image);

            return true;
        }
    }
}
