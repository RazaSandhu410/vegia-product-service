using System.Collections.Generic;
using Vegia.ProductService.Core.Entities;
using System.Threading.Tasks;

namespace Vegia.ProductService.Core.Interfaces
{
    public interface IProductImageRepository : IRepository<ProductImage>
    {
        Task<IEnumerable<ProductImage>> GetImagesByProductAsync(int productId);
        Task<ProductImage> GetPrimaryImageAsync(int productId);
        Task<bool> SetPrimaryImageAsync(int imageId);
    }
}

