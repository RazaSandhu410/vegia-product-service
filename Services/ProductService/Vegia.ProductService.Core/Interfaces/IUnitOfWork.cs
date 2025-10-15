using System;
using System.Threading;
using System.Threading.Tasks;

namespace Vegia.ProductService.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repository Properties
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IVendorRepository VendorRepository { get; }
        IProductImageRepository ProductImageRepository { get; }
        IProductVendorRepository ProductVendorRepository { get; }
        #endregion

        #region Methods
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        void DisableLazyLoading(bool disabled);
        #endregion
    }
}
