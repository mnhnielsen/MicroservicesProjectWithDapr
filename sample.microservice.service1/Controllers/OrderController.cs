
namespace sample.microservice.service1.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        public const string StoreName = "orderstore";
        public const string PubSub = "commonpubsub";

        [HttpPost("order")]
        public async Task<ActionResult<Guid>> SubmitOrder(Order order, [FromServices] DaprClient daprClient)
        {
            order.Id = Guid.NewGuid(); //Create new Guid for the order

            //Store the order in configured state store
            //var state = await daprClient.GetStateEntryAsync<OrderState>(StoreName, order.Id.ToString()); //Request async dapr sidecar with store name and and id. The format id "orderstore||orderID"

            //state.Value ??= new OrderState() //Create order state for the order with date and order
            //{
            //    CreatedOn = DateTime.UtcNow,
            //    Order = order
            //};

            //await state.SaveAsync();    //Save

            //Publish order on topic to subscribers.
            await daprClient.PublishEventAsync<Order>(PubSub, Topics.OrderSubmittedTopicName, order);

            Console.WriteLine($"Submitted order {order.Id}");
            return order.Id;
        }
    }
}
