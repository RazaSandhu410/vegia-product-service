using System.Collections.Generic;
using Vegia.ProductService.Core.Entities;
using System.Threading.Tasks;

namespace Vegia.ProductService.Core.Interfaces
{
    public interface IProductVendorRepository : IRepository<ProductVendor>
    {
        Task<IEnumerable<ProductVendor>> GetVendorProductsAsync(int vendorId);
        Task<ProductVendor> GetProductVendorAsync(int productId, int vendorId);
        Task<bool> ProductVendorExistsAsync(int productId, int vendorId);
    }
}

