using Catalog.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProduct(string ID);
        Task<IEnumerable<Product>> GetAllProductsByName(string name);
        Task<IEnumerable<Product>> GetAllProductsByCategory(string category);

        Task Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(string ID);
    }
}
