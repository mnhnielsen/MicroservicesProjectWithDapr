using sample.microservice.catalog.Data;

namespace sample.microservice.catalog.Services
{
    public class CatalogService : ICatalogService
    {
        public const string StoreName = "statestore";
        private readonly ProductContext _context;


        public CatalogService(ProductContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool Configure()
        {
            return _context.Database.EnsureCreated();
        }
        public async Task<Product?> GetProductAsync(string productId)
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.OrderBy(p => p.ProductCode).ToListAsync();
        }
    }
}
