namespace sample.microservice.catalog.Controllers
{
    [ApiController]
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
            return "Connected catalog service...";
        }

        public async Task<IActionResult> GetProductAsync(string productId)
        {
            var product = await _catalogService.GetProductAsync(productId);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
