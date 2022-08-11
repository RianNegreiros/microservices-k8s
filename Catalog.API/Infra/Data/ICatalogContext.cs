using Catalog.API.Core.Entities;
using MongoDB.Driver;

namespace Catalog.API.Infra.Data;

public interface ICatalogContext
{
    IMongoCollection<Product> Products { get; }
}