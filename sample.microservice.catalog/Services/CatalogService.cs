namespace sample.microservice.catalog.Services
{
    public class CatalogService : ICatalogService
    {
        public const string StoreName = "statestore";
        public async Task<Product?> GetProductAsync(string productId)
        {
            throw new NotImplementedException();

        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
