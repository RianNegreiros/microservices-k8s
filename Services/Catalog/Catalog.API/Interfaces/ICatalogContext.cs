using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Interfaces;

public interface ICatalogContext
{
    IMongoCollection<Product> Products { get; }
}