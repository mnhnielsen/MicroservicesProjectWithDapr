namespace sample.microservice.catalog.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext()
        {

        }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().
                HasData(
                new Product
                {
                    Id = "1",
                    ProductCode = "Cookie"
                },
                new Product
                {
                    Id = "2",
                    ProductCode = "Brownie"
                },
                new Product
                {
                    Id = "3",
                    ProductCode = "Cheesecake"
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
