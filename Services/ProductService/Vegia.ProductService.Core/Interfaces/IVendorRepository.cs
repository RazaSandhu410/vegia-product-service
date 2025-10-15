using System.Collections.Generic;
using Vegia.ProductService.Core.Entities;
using System.Threading.Tasks;

namespace Vegia.ProductService.Core.Interfaces
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        Task<IEnumerable<Vendor>> GetVendorsWithProductsAsync();
        Task<Vendor> GetVendorByEmailAsync(string email);
        Task<IEnumerable<Vendor>> GetActiveVendorsAsync();
    }
}

