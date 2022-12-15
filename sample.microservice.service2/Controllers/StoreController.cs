
namespace sample.microservice.service2.Controllers
{
    [ApiController]
    public class StoreController : ControllerBase
    {
        public const string StoreName = "shippingstore";
        public const string PubSub = "commonpubsub";

        private readonly ILogger<StoreController> _logger;

        public StoreController(ILogger<StoreController> logger)
        {
            _logger = logger;
        }


        [HttpGet("get")]
        public ActionResult<string> Get()
        {
            return "Connected shipping service...";
        }

        [Topic(PubSub, Topics.OrderStoredTopicName)]
        [HttpPost("checkout")]
        public async Task<ActionResult<Guid>> Ship(Order orderShipment, [FromServices] DaprClient daprClient)
        {
            //var state = await daprClient.GetStateEntryAsync<ShippingState>(StoreName, orderShipment.OrderId.ToString());

            //state.Value ??= new ShippingState()
            //{
            //    OrderId = orderShipment.OrderId,
            //    ShipmentId = Guid.NewGuid()
            //};

            //await state.SaveAsync();

            //var result = state.Value.ShipmentId;

            Console.WriteLine($"Got orderID : " + orderShipment.Id);
            return this.Ok();
        }
    }
}
