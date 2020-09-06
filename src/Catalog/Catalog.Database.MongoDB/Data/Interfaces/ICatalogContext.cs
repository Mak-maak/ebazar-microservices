using Catalog.Entities.Entities;
using MongoDB.Driver;

namespace Catalog.Database.Data.Interfaces
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}