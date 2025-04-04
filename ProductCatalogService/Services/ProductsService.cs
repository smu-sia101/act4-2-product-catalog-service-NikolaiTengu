using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductCatalogService.ProductsModels;

namespace ProductCatalogService.Services
{
    public class ProductsService
    {
        private readonly IMongoCollection<Products> _productsCollection;

        public ProductsService(
            IOptions<ProductsDatabaseSettings> productsDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                productsDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                productsDatabaseSettings.Value.DatabaseName);

            _productsCollection = mongoDatabase.GetCollection<Products>(
                productsDatabaseSettings.Value.ProductsCollectionName);
        }

        public async Task<List<Products>> GetAsync() =>
            await _productsCollection.Find(_ => true).ToListAsync();

        public async Task<Products?> GetAsync(string id) =>
            await _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Products newBook) =>
            await _productsCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Products updatedBook) =>
            await _productsCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _productsCollection.DeleteOneAsync(x => x.Id == id);
    }
}

