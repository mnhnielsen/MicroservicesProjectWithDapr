
namespace sample.microservice.service2.Controllers
{
    [ApiController]
    public class StoreController : ControllerBase
    {
        public const string StoreName = "shippingstore";
        public const string PubSub = "commonpubsub";


        [HttpGet("get")]
        public ActionResult<string> Get()
        {
            return "Connected...";
        }

        [Topic(PubSub, Topics.OrderPreparedTopicName)]
        [HttpPost(Topics.OrderPreparedTopicName)]
        public async Task<ActionResult<Guid>> Ship(Shipment orderShipment, [FromServices] DaprClient daprClient)
        {
            var state = await daprClient.GetStateEntryAsync<ShippingState>(StoreName, orderShipment.OrderId.ToString());

            state.Value ??= new ShippingState()
            {
                OrderId = orderShipment.OrderId,
                ShipmentId = Guid.NewGuid()
        };

            await state.SaveAsync();

            var result = state.Value.ShipmentId;

            Console.WriteLine($"Shipment of orderId {orderShipment.OrderId} completed with id {result}");
            return this.Ok();
    }
}
}
