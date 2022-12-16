namespace sample.microservice.catalog.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(string productId);
    }
}
