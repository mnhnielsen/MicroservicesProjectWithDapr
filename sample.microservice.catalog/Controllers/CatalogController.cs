namespace sample.microservice.catalog.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class CatalogController : ControllerBase
    {
        public const string PubSub = "commonpubsub";

        private readonly ICatalogService _catalogService;


        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
        }

        [HttpGet("get")]
        public ActionResult<string> Get()
        {
            return ($"Status: {_catalogService.Configure()}");
        }


        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _catalogService.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductAsync(string productId)
        {
            var product = await _catalogService.GetProductAsync(productId);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
