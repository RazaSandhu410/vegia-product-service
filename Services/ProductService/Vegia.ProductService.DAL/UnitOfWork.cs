using System;
using System.Threading;
using System.Threading.Tasks;
using Vegia.ProductService.Core.Interfaces;
using Vegia.ProductService.DAL.Repositories;
using Vegia.ProductService.DAL.Contexts;

namespace Vegia.ProductService.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly ProductDbContext _context;
       
        private IProductRepository? _productRepository;
        private ICategoryRepository? _categoryRepository;
        private IVendorRepository? _vendorRepository;
        private IProductImageRepository? _productImageRepository;
        private IProductVendorRepository? _productVendorRepository;
        #endregion

        #region Constructors
        public UnitOfWork(ProductDbContext context)
        {
            _context = context;
        }
        #endregion

        #region IUnitOfWork Members
        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);

        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_context);

        public IVendorRepository VendorRepository => _vendorRepository ??= new VendorRepository(_context);

        public IProductImageRepository ProductImageRepository => _productImageRepository ??= new ProductImageRepository(_context);

        public IProductVendorRepository ProductVendorRepository => _productVendorRepository ??= new ProductVendorRepository(_context);
        #endregion

        #region Methods
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void DisableLazyLoading(bool disabled)
        {
            _context.ChangeTracker.LazyLoadingEnabled = !disabled;
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            _productRepository = null;
            _categoryRepository = null;
            _vendorRepository = null;
            _productImageRepository = null;
            _productVendorRepository = null;
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
