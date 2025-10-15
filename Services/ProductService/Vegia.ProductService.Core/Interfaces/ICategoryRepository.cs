using System.Collections.Generic;
using Vegia.ProductService.Core.Entities;
using System.Threading.Tasks;

namespace Vegia.ProductService.Core.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesWithProductsAsync();
        Task<Category> GetCategoryByNameAsync(string name);
        Task<bool> CategoryHasProductsAsync(int categoryId);
    }
}

