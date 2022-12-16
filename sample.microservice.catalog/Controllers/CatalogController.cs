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

        public ActionResult<string> Get()
        {
            return "Connected catalog service...";
        }
    }
}
