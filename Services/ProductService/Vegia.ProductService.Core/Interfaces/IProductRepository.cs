using System.Collections.Generic;
using Vegia.ProductService.Core.Entities;
using System.Threading.Tasks;

namespace Vegia.ProductService.Core.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> GetProductsByVendorAsync(int vendorId);
        Task<Product> GetProductWithDetailsAsync(int id);
        Task<IEnumerable<Product>> GetActiveProductsAsync();
        Task<bool> ProductExistsAsync(string productName);
    }
}

