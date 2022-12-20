namespace sample.microservice.catalog.Data
{
    public class Seed
    {
        public static ICollection<Product> Data =>
            new[]
            {
                new Product
                {
                    ProductCode = "Cookie"
                },
                new Product
                {
                    ProductCode = "Bread"
                }
            };
    }
}
